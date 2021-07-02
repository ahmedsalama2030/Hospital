using Core.Dtos.Home;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Pages.ViewComponents
{
    public class SideBarNavViewComponent : ViewComponent
    {

        private readonly IRepositoryApp<GeneralSetting> _setting;
        private readonly CulutureServices language;

        public SideBarNavViewComponent(
            IRepositoryApp<GeneralSetting> GeneralSetting,
             CulutureServices Language
            )
        {
            _setting = GeneralSetting;
            language = Language;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settings = await _setting.FirstAsync();
            var siteName = language.GetCulture() == "en" ? settings.AdminSiteName : settings.AdminSiteNameAr;
            var model = new SideBar
            {
                SiteName = siteName,
                Path = settings.SiteLogoPath
            };
            return View(model);


        }
    }
}