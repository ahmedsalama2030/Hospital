using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Common;
using Core.Dtos.Department;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Admin.helper;

namespace Web.Areas.Admin.Pages.Departments
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class EditModel : PageModel
    {
        private readonly IRepositoryApp<Department> _department;
        private readonly IRepositoryApp<Hospital> _hospital;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IRepositoryApp<DepartmentImages> _departmentImages;
        private IWebHostEnvironment _ihostingEnvironment;
        private readonly IAuthorizationService AuthorizationService;


        public EditModel(
         IRepositoryApp<Department> department,
         IRepositoryApp<Hospital> hospital,
         IMapper mapper,
         CulutureServices lang,
         MessageResult MessageResult,
         IRepositoryApp<DepartmentImages> DepartmentImages,
                         IAuthorizationService authorizationService,

        IWebHostEnvironment ihostingEnvironment
         )
        {
            _department = department;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            _departmentImages = DepartmentImages;
            _hospital = hospital;
            _ihostingEnvironment = ihostingEnvironment;
            AuthorizationService = authorizationService;



        }
        [BindProperty]
        public DepartmentDtoGet department { get; set; }
        [BindProperty]
        public IFormFileCollection photosUpload { get; set; }
        public List<SelectListItem> hospitals { get; set; }
        public IEnumerable<DepartmentImages> departmentImages { get; set; }

        public string lang { get; set; }
        public void OnGet()
        {
            lang = _lang.GetCulture();
            hospitals = _hospital.GetContext().Select(a =>
                                         new SelectListItem
                                         {
                                             Value = a.Id.ToString(),
                                             Text = lang == "en" ? a.Name : a.NameAr
                                         }).ToList();
            var departmentResult = HttpContext.Items["entity"] as Department;
            departmentImages = departmentResult.DepartmentImages;
            var clinic = HttpContext.Items["entity"] as ClinicSchedul;
            department = _mapper.Map<DepartmentDtoGet>(departmentResult);
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (id != department.Id)
                return _messageResult.failureIdNotFound();
            List<ImagesPath> paths;
            var departmentResult = HttpContext.Items["entity"] as Department;
            departmentResult = _mapper.Map(department, departmentResult);
            if (photosUpload.Count() > 0)
            {
                paths = await photosUpload.SaveImagesOnDisk(_ihostingEnvironment, "department");
                var images = _mapper.Map<ICollection<DepartmentImages>>(paths);
                departmentResult.DepartmentImages = MCollections<DepartmentImages>.AddRange(departmentResult.DepartmentImages, images);
            }
            var result = await _department.SaveAllAsync();
            return result ? _messageResult.SucessResultSave() : _messageResult.failureResultStateChange();


        }

        // delete images
        public async Task<IActionResult> OnGetDeleteImageAsync(Guid photoId)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion

            var image = await _departmentImages.GetByIdAsync(photoId);
            if (image == null)
                return _messageResult.failureIdNotFound();
            _departmentImages.Delete(image);
            var deleteHard = image.Path.DeleteImageOnDisk(_ihostingEnvironment);
            var result = await _departmentImages.SaveAllAsync();
            return (result) ? _messageResult.SucessResultDelete(image.Id.ToString()) : _messageResult.failureResultSave();

        }
        public IActionResult RedirectToPageMaster => new RedirectToPageResult("Edit");

        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                   PageHandlerExecutionDelegate next)

        {
            Guid Id = Guid.Empty;
            Id = Guid.Parse(context.HttpContext.Request.RouteValues["id"].ToString());
            if (!context.ModelState.IsValid)
            {
                context.Result = _messageResult.failureResultField();
                return;
            }
            var entity = await _department.SingleOrDefaultAsync(a => a.Id == Id, a => a.DepartmentImages);
            if (entity == null)
            {
                context.Result = Redirect("/Error");
                return;
            }
            context.HttpContext.Items.Add("entity", entity);
            await next.Invoke();
        }

    }
}

