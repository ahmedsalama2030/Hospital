using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Web.Areas.Admin.helper;
using Web.Resources;

namespace Web.Areas.Admin.Pages.Hospitals
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IRepositoryApp<Core.Entities.Hospital> _hospital;
        private readonly IMapper _mapper;
         private readonly CulutureServices _lang;
         private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public CreateModel(
                IRepositoryApp<Core.Entities.Hospital> Hospital,
               CulutureServices lang,
                MessageResult MessageResult,
                                IAuthorizationService authorizationService,

               IMapper Mapper)
        {
            _hospital = Hospital;
            _mapper = Mapper;
             _lang = lang;
             _messageResult = MessageResult;
            AuthorizationService = authorizationService;



        }
        [BindProperty]
        public  Core.Entities.Hospital   hospital  { get; set; }

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
            if (ModelState.IsValid)
            {
                 var hospitalResult = _mapper.Map<Core.Entities.Hospital>(hospital);
                _hospital.Add(hospitalResult);
                var result = await _hospital.SaveAllAsync();
                return (result) ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();
            }
            else
                return _messageResult.failureResultField();
        }





    }
}
