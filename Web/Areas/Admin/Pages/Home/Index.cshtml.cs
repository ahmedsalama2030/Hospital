using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Admin.Pages.Models;

namespace Web.Areas.Admin.Pages.Home
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<GeneralSetting> _generalSetting;
        private readonly IRepositoryApp<User> _users;
        private readonly IRepositoryApp<ContactUs> _contact;
        private readonly IRepositoryApp<Core.Entities.News> _news;
        private readonly IRepositoryApp<Appointment> _appointment;
        private readonly CulutureServices _culutureServices;
 
        public IndexModel(
            IRepositoryApp<GeneralSetting> GeneralSetting,
            IRepositoryApp<User> Users,
            IRepositoryApp<ContactUs> Contact,
            IRepositoryApp<Core.Entities.News> News,
            IRepositoryApp<Appointment> Appointment,
 
            CulutureServices culutureServices


            )

        {
            _generalSetting = GeneralSetting;
            _users = Users;
            _contact = Contact;
            _news = News;
            _appointment = Appointment;
            _culutureServices = culutureServices;
 
        }


        public string logoPath { get; set; }
        public IRepositoryApp<GeneralSetting> GeneralSetting { get; }
        public int Users { get; set; }
        public int Contact { get; set; }
        public int News { get; set; }
        public int Appointment { get; set; }
         public async Task OnGetAsync()
        {
            var setting = await _generalSetting.FirstAsync();
            logoPath = setting.SiteLogoPath;
             Users = (await _users.GetAllAsync()).Count();
            Contact = (await _contact.GetAllAsync()).Count();
            News = (await _news.GetAllAsync()).Count();
            Appointment = (await _appointment.GetAllAsync()).Count();
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

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await HttpContext.SignOutAsync("Identity.Application");
            return LocalRedirect("/Auth/Login/Index");

        }
        #region not allow
        public void s()
        {
            //var groupedResult = (from Appoint in _appointment.GetAll()
            //                     group Appoint by Appoint.CreatedDate.Year into AppointFilter
            //                     select new
            //                     {
            //                         year = AppointFilter.Key,
            //                         Months = new
            //                         {
            //                             name = (from AppointMoths in AppointFilter
            //                                     group AppointMoths by AppointMoths.CreatedDate.Month into Appoint
            //                                     select new
            //                                     {
            //                                         name = Appoint.Key,
            //                                         count = Appoint.Count()
            //                                     }
            //                                  )
            //                         }




            //                     });
        }

        #endregion
    }
}
