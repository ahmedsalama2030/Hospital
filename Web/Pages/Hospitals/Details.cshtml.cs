using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.hospital;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Hospitals
{
    [AllowAnonymous]

    public class DetailsModel : PageModel
    {
         private readonly IMapper _mapper;
        private readonly IRepositoryApp<Hospital> _hospital;
        private readonly CulutureServices _culuture;

        public DetailsModel(
           IRepositoryApp<Hospital> Hospital,
          CulutureServices culutureServices,
        IMapper Mapper)
        {
             _hospital = Hospital;
            _culuture = culutureServices;
            _mapper = Mapper;
        }

        public string lang { get; set; }
        public HospitalGetlDto hospitals { get; set; }
        public async Task OnGetAsync(Guid id)
        {
            var hospital =await _hospital.SingleOrDefaultAsync(d=>d.Id==id,a=>a.Departments);
            if (hospital == null)
                RedirectToPage("/home/");

            hospitals = _mapper.Map<HospitalGetlDto>(hospital);

        }
    }
}
