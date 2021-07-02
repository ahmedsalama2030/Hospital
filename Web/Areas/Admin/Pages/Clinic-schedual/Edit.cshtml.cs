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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Admin.helper;

namespace Web.Areas.Admin.Pages.Clinic_schedual
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class EditModel : PageModel
    {
        private readonly IRepositoryApp<ClinicSchedul> _clinic;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public EditModel(
          IRepositoryApp<ClinicSchedul> ClinicName,
          IMapper mapper,
          CulutureServices lang,
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
        public   void OnGet (Guid Id)
        {
            lang = _lang.GetCulture();
            var clinic = HttpContext.Items["entity"] as ClinicSchedul;
             clinicSchedul = _mapper.Map<ClinicSchedulDtoGet>(clinic);

        }
        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (Id != clinicSchedul.Id)
                return _messageResult.failureResultSave();
            var clinic = HttpContext.Items["entity"] as ClinicSchedul;
            clinic = _mapper.Map (clinicSchedul, clinic);
             return  (_clinic.checkState(clinic,"Modified")) ? _messageResult .SaveChanges(await _clinic.SaveAllAsync()) : _messageResult.failureResultStateChange();
             
        }
        public IActionResult RedirectToPageMaster =>   RedirectToPage ("Edit");

        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                     PageHandlerExecutionDelegate next)

        {
            if(!context.ModelState.IsValid)
            {
                context.Result = _messageResult.failureResultField();
                return;
            }
            Guid Id = Guid.Empty;
            Id = Guid.Parse(context.HttpContext.Request.RouteValues["id"].ToString());
            var entity = await _clinic.SingleOrDefaultAsync(i => i.Id == Id);
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
