using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Clinics_Reservation
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<ClinicSchedul> _clinic;
        private readonly IMapper mapper;
        private readonly CulutureServices _culuture;

        public IndexModel(
        IRepositoryApp<ClinicSchedul> clinic,
        CulutureServices culutureServices,
        IMapper Mapper)
        {
            _clinic = clinic;
            _culuture = culutureServices;
            mapper = Mapper;
        }
        public IEnumerable<ClinicSchedul> clinics { get; set; }
        public string lang { get; set; }
        public async Task OnGetAsync()
        {
            lang = _culuture.GetCulture();
            clinics = await _clinic.GetAllAsync();
        }
    }
}
