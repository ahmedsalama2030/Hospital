
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.Appointment;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Web.Resources;

namespace Web.Pages.BookAppointment
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<ClinicSchedul> _clinic;
        private readonly IRepositoryApp<Appointment> _appointment;
        private readonly IMapper _mapper;
        private readonly CulutureServices _culuture;
        private readonly IStringLocalizer<Resource> _localizer;

        public IndexModel(
        IRepositoryApp<Appointment> appointment,
        IRepositoryApp<ClinicSchedul>clinicSchedul,
        CulutureServices culutureServices,
        IStringLocalizer<Resource> localizer,
        IMapper Mapper)
        {
            _appointment = appointment;
            _clinic = clinicSchedul;
            _culuture = culutureServices;
            _mapper = Mapper;
            _localizer = localizer;
        }
        [BindProperty]
        public AppointmentGetDto appointment { get; set; }
         public string lang { get; set; }
        public void OnGet (string today)
        {
            lang = _culuture.GetCulture();
             var clinic =   HttpContext.Items["entity"] as ClinicSchedul;
            appointment = new AppointmentGetDto();
             appointment.ClincName = (lang == "en" )? clinic.ClinicName : clinic.ClinicNameAr;
            appointment.Note = clinic.TimeFrom + '-' + clinic.TimeTo + '/' + _localizer[today];
        }
        public async Task<ActionResult> OnPostAsync()
        {
            var appointmentNew = _mapper.Map<Appointment>(appointment);
            _appointment.Add(appointmentNew);
            var result = await _appointment.SaveAllAsync();
            if (result)
                return Content("<span  class='message-success'  >" + _localizer["sucess send"].Value + "</span>");
            else
                return Content("<span  class='message-error'  >" + _localizer["failure send"].Value + "</span>");
        
             
    }


    public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                 PageHandlerExecutionDelegate next)

        {
            var  id = context.HttpContext.Request.RouteValues["id"].ToString() ;
            if (string.IsNullOrEmpty(id))
            {
                context.Result = RedirectToPage("/Site-Error");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = Content("<span  class='message-error'  >" + _localizer["some field error"].Value + "</span>");
                return;
            }

            var entity = await _clinic.GetByIdAsync(Guid.Parse(id));
            if (entity == null)
            {
                context.Result = Redirect("/Site-Error");
                return;
            }
            context.HttpContext.Items.Add("entity", entity);
            await next.Invoke();
        }

    }
}
