using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Common;
using Core.Dtos.Department;
using Core.Dtos.hospital;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Admin.helper;

namespace Web.Areas.Admin.Pages.Departments
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IRepositoryApp<Department> _department;
        private readonly IRepositoryApp<Hospital> _hospital;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private IWebHostEnvironment _ihostingEnvironment;
        private readonly IAuthorizationService AuthorizationService;


        public CreateModel(
         IRepositoryApp<Department> department,
         IRepositoryApp<Hospital> hospital,
         IMapper mapper,
         CulutureServices lang,
         MessageResult MessageResult,
              IAuthorizationService authorizationService,

        IWebHostEnvironment ihostingEnvironment 


       )

        {
            _department = department;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            _hospital = hospital;
            _ihostingEnvironment = ihostingEnvironment;
            AuthorizationService = authorizationService;



        }
        [BindProperty]
        public DepartmentDtoGet department { get; set; }
        [BindProperty]
        public IFormFileCollection photosUpload { get; set; }
        public List<SelectListItem> hospitals { get; set; }
 
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
        }
        public async Task<IActionResult> OnPostAsync()
        {
             if (ModelState.IsValid)
            {
                #region remove in production
                var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
                if (policyCheck.Succeeded)
                    return _messageResult.failureResultSave("You do not have permission");
                #endregion
                List<ImagesPath> paths = null;
                var DepartmentResult = _mapper.Map<Department>(department);
                if (photosUpload.Count() > 0)
                {
                    paths = await photosUpload.SaveImagesOnDisk(_ihostingEnvironment,"department");
                    DepartmentResult.DepartmentImages = _mapper.Map<ICollection<DepartmentImages>>(paths);
                }
                 
                _department.Add(DepartmentResult);
                var result = await _department.SaveAllAsync();
                return (result) ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();
            }
            else
                return _messageResult.failureResultField();
        }

 
    }
}
