
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Common;
using Core.Dtos.Department;
using Core.Dtos.Doctor;
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

namespace Web.Areas.Admin.Pages.Doctors
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class EditModel : PageModel
    {
        private readonly IRepositoryApp<Doctor> _doctor;
        private readonly IRepositoryApp<Department> _department;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private IWebHostEnvironment _ihostingEnvironment;
        private readonly IAuthorizationService AuthorizationService;

        public EditModel(
         IRepositoryApp<Doctor> doctor,
         IRepositoryApp<Department> department,
         IMapper mapper,
         CulutureServices lang,
         MessageResult MessageResult,
                         IAuthorizationService authorizationService,

        IWebHostEnvironment ihostingEnvironment


       )

        {
            _doctor = doctor;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            _department = department;
            _ihostingEnvironment = ihostingEnvironment;
            AuthorizationService = authorizationService;



        }
        [BindProperty]
        public DoctorDtoPost DoctorPost { get; set; }
        [BindProperty]
        public IFormFile photosUpload { get; set; }
        public List<SelectListItem> departments { get; set; }

        public string lang { get; set; }
        public void OnGet()
        {
            lang = _lang.GetCulture();
            departments = _department.GetContext().Select(a =>
                                         new SelectListItem
                                         {
                                             Value = a.Id.ToString(),
                                             Text = lang == "en" ? a.Name : a.NameAr
                                         }).ToList();

            var doctorResult = HttpContext.Items["entity"] as Doctor;
            DoctorPost = _mapper.Map<DoctorDtoPost>(doctorResult);
        }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (id != DoctorPost.Id)
                return _messageResult.failureIdNotFound();
            ImagesPath paths=null;
            var doctorResult = HttpContext.Items["entity"] as Doctor;
            doctorResult = _mapper.Map(DoctorPost, doctorResult);
            if (photosUpload != null)
            {
                paths =await photosUpload.SaveImageOnDisk(_ihostingEnvironment, "doctors");
                doctorResult.PhotoPath = paths.Path.ToString();
            }
           return (_doctor.checkState(doctorResult, "Modified")) ? _messageResult.SaveChanges(await _doctor.SaveAllAsync()) : _messageResult.failureResultStateChange();

        }


        // delete images
        public async Task<IActionResult> OnGetDeleteImageAsync(Guid Id)
        {

            var doctorResult = HttpContext.Items["entity"] as Doctor;
            if (doctorResult == null)
                return _messageResult.failureIdNotFound();
            var deleteHard = doctorResult.PhotoPath.DeleteImageOnDisk(_ihostingEnvironment);
            doctorResult.PhotoPath = "";
            var result = await _doctor.SaveAllAsync();
            return (result) ? _messageResult.SucessResultDelete(doctorResult.Id.ToString()) : _messageResult.failureResultSave();

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
            var entity = await _doctor.SingleOrDefaultAsync(a => a.Id == Id);
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

