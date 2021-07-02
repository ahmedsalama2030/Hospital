 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.AboutUs;
using Core.Dtos_User.Home;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace Web.Pages.Home
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
        public HomeDetailDto home { get; set; }
        public string lang { get; set; }
        public async Task OnGetAsync()
        {
            var settings = await _setting.FirstAsync();
            home = _mapper.Map<HomeDetailDto>(settings);
            lang = _culuture.GetCulture();
        }
        public IActionResult OnGetChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );
            return LocalRedirect(returnUrl);

        }
    }
}

