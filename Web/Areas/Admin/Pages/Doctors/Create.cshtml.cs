 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Common;
using Core.Dtos.Department;
using Core.Dtos.Doctor;
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

namespace Web.Areas.Admin.Pages.Doctors
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IRepositoryApp<Doctor> _doctor;
        private readonly IRepositoryApp<Department> _department;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private IWebHostEnvironment _ihostingEnvironment;
        private readonly IAuthorizationService AuthorizationService;


        public CreateModel(
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
        public IFormFile  photosUpload { get; set; }
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
                ImagesPath paths = null;
                var DoctorResult = _mapper.Map<Doctor>(DoctorPost);
                if (photosUpload!=null)
                {
                    paths =await photosUpload.SaveImageOnDisk(_ihostingEnvironment, "doctors");
                    DoctorResult.PhotoPath = paths.Path.ToString();
                }

                _doctor.Add(DoctorResult);
                var result = await _doctor.SaveAllAsync();
                return (result) ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();
            
            }
            else
                return _messageResult.failureResultField();
        }


    }
}

