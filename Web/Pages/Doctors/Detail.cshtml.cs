using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.Doctor;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Doctors
{
    [AllowAnonymous]
    public class DetailModel : PageModel
    {
        private readonly IRepositoryApp<Doctor> _doctor;
        private readonly IMapper _mapper;
        private readonly CulutureServices _culuture;

        public DetailModel(
          IRepositoryApp<Doctor> doctor,
           CulutureServices culutureServices,
        IMapper Mapper)
        {
            _doctor = doctor;
            _culuture = culutureServices;
            _mapper = Mapper;
        }

        public string lang { get; set; }
        public DoctorDtoListGet Doctor { get; set; }

        public async Task OnGetAsync(Guid Id)
        {
            var doctor =await _doctor.SingleOrDefaultAsync(a=>a.Id==Id, a => a.Department);
            if (doctor == null)
                RedirectToPage("/Doctors/Index");
            Doctor = _mapper.Map<DoctorDtoListGet>(doctor);
            lang = _culuture.GetCulture();
        }
    }
}
