using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.hospital;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Web.Areas.Admin.helper;
using Web.Resources;

namespace Web.Areas.Admin.Pages.Hospitals
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class EditModel : PageModel
    {
        private readonly IRepositoryApp< Hospital> _hospital;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
         private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public EditModel(
                 IRepositoryApp< Hospital> Hospital,
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
        public HospitalDtoGet hospital { set; get; }
        public string lang { get; set; }
        public void OnGet(Guid Id)
        {
            lang = _lang.GetCulture();
            var hospitalGet = HttpContext.Items["entity"] as Hospital;
            hospital = _mapper.Map<HospitalDtoGet>(hospitalGet);

        }
        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (Id != hospital.Id)
                return _messageResult.failureResultSave();
            var clinic = HttpContext.Items["entity"] as Hospital;
            clinic = _mapper.Map(hospital, clinic);
            return (_hospital.checkState(clinic, "Modified")) ? _messageResult.SaveChanges(await _hospital.SaveAllAsync()) : _messageResult.failureResultStateChange();

        }

        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                     PageHandlerExecutionDelegate next)

        {
            if (!context.ModelState.IsValid)
            {
                context.Result = _messageResult.failureResultField();
                return;
            }
            Guid Id = Guid.Empty;
            Id = Guid.Parse(context.HttpContext.Request.RouteValues["id"].ToString());
            var entity = await _hospital.GetByIdAsync(Id);
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
