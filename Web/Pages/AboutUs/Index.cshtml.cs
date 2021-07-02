using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.AboutUs;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Web.Pages.AboutUs
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<GeneralSetting> _setting;
         private readonly IMapper _mapper;
        private readonly CulutureServices _culuture;
 
        public IndexModel(
        IRepositoryApp<GeneralSetting> setting,
        IRepositoryApp<Core.Entities.ContactUs> contactUs,
        CulutureServices culutureServices,
         IMapper Mapper)
        {
            _setting = setting;
             _culuture = culutureServices;
            _mapper = Mapper;
         }
         public AboutUsDetailDto aboutUs { get; set; }
         public string lang { get; set; }
        public async Task OnGetAsync()
        {
            var settings =await _setting.FirstAsync();
              aboutUs = _mapper.Map<AboutUsDetailDto>(settings);
        }
    }
}
