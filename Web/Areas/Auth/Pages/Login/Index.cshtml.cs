using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Admin.helper;
using Web.Areas.Auth.Pages.ViewModels;

using Core.Interfaces;
using Infrastructure.Services;

namespace Web.Areas.Auth.Pages.Login
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly MessageResult _messageResult;
        private readonly SignInManager<User> _signInManager;
        private readonly IRepositoryApp<GeneralSetting> _generalSetting;
        private readonly CulutureServices _language;

        public IndexModel(
            UserManager<User> userManager,
            MessageResult MessageResult,
            SignInManager<User> signInManager,
        IRepositoryApp<GeneralSetting> GeneralSetting,
                     CulutureServices Language


)
        {
            _userManager = userManager;
            _messageResult = MessageResult;
            _signInManager = signInManager;
            _generalSetting = GeneralSetting;
            _language = Language;
        }
        [BindProperty]
        public LoginForm LoginForm { get; set; }
        public string sitename { get; set; }
        public async Task OnGetAsync(string ReturnUrl = null)
        {
            var setting = await _generalSetting.FirstAsync();
            sitename = _language.GetCulture() == "en" ? setting.AdminSiteName : setting.AdminSiteNameAr;

        }
        public async Task<ActionResult> OnPostAsync(string RedirectUrl = null)
        {
            if (ModelState.IsValid)
            {
                var check = LoginForm.Email.Contains('@');
                User user = null;
                if (check)
                    user = await _userManager.FindByEmailAsync(LoginForm.Email);
                else
                    user = await _userManager.FindByNameAsync(LoginForm.Email);
                if (user == null)
                    return _messageResult.failureResultSave("user not found");
                RedirectUrl = RedirectUrl ?? "/admin/home/index";
                var result = await _signInManager.PasswordSignInAsync(user.UserName, LoginForm.Password, true, false);
                if (result.Succeeded)
                {
                    if (Url.IsLocalUrl(RedirectUrl))
                        return _messageResult.SucessResultSaveUrl(RedirectUrl);
                    else
                        return _messageResult.SucessResultSaveUrl("/admin/home/index");
                }
                return _messageResult.failureResultSave("username or password  is incorrect");
            }
            else
                return _messageResult.failureResultField();

        }
    }
}
