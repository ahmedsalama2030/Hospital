using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.clinics;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Admin.helper;

namespace Web.Areas.Admin.Pages.Clinic_schedual
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IRepositoryApp<ClinicSchedul> _clinic;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;


        public CreateModel(
          IRepositoryApp<ClinicSchedul> ClinicName,
          IMapper mapper,
          CulutureServices lang ,
                          IAuthorizationService authorizationService,

           MessageResult MessageResult 

          )

        {
             _clinic = ClinicName;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            AuthorizationService = authorizationService;

        }
        [BindProperty]
        public ClinicSchedulDtoGet clinicSchedul { set; get; }
        public string lang { get; set; }
        public void OnGet()
        {
             lang = _lang.GetCulture();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            var clinics = _mapper.Map<ClinicSchedul>(clinicSchedul); 
            _clinic.Add(clinics);
           var result= await _clinic.SaveAllAsync();
            return result ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();
        }
    }
}
