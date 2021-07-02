
using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Web.Areas.Admin.helper;
using Web.Resources;
using Microsoft.AspNetCore.Identity;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Dtos.Auth;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using Web.Areas.Admin.Pages.Models;

namespace Web.Areas.Admin.Pages.Users
{
    [Authorize(Policy = "AllowUserAdmin")]
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly CulutureServices _lang;
        private readonly IStringLocalizer<Resource> _localizer;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public EditModel(
             UserManager<User> userManager,
             RoleManager<Role> roleManager,
               CulutureServices lang,
               IStringLocalizer<Resource> Localizer,
               MessageResult MessageResult,
                 IAuthorizationService authorizationService,

               IMapper Mapper)
        {
            _mapper = Mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _lang = lang;
            _localizer = Localizer;
            _messageResult = MessageResult;
            AuthorizationService = authorizationService;


        }
        public List<string> RolesSelect { get; set; } = new List<string>();
        public List<RolesUserDto> roles { get; set; }
        public ChangePassword changePassword { get; set; }
        public UserEditDto userRegister { get; set; }

        public string lang { get; set; }
        public async Task OnGetAsync(Guid id)
        {
            var user = HttpContext.Items["entity"] as User;
            RolesSelect = (List<string>)await _userManager.GetRolesAsync(user);
            var rolesUserSelected = await _roleManager.Roles.ToListAsync();
            var rolesUser = _mapper.Map<List<RolesUserDto>>(rolesUserSelected);
            setSelected(ref rolesUser);
            roles = rolesUser;
            userRegister = _mapper.Map<UserEditDto>(user);
            lang = _lang.GetCulture();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion

            var userOld = HttpContext.Items["entity"] as User;
            var user = _mapper.Map(userRegister, userOld);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(changePassword.Password) || !string.IsNullOrWhiteSpace(changePassword.Password))
                {
                    var passwordResult = await updatePasswordAsync(user);
                    if (!passwordResult)
                        return _messageResult.failureRoleSave("fail password update");
                }
                var rolesResult = await updateRolesAsync(user);
                return rolesResult;
            }
            return _messageResult.failureResultSave(result.Errors.FirstOrDefault().Code);

        }

        public void setSelected(ref List<RolesUserDto> roles)
        {
            roles.ForEach(e =>
            {
                if (RolesSelect.Contains(e.Name) || RolesSelect.Contains(e.NameAr))
                {
                    e.Selected = true;
                }
            });
        }

        public async Task<JsonResult> updateRolesAsync(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            RolesSelect = RolesSelect ?? new List<string>() { };
            var result = await _userManager.AddToRolesAsync(user, RolesSelect.Except(userRoles));
            if (!result.Succeeded)
                return _messageResult.failureRoleSave("fail role add");
            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(RolesSelect));
            if (!result.Succeeded)
                return _messageResult.failureRoleSave("fail role update");
            return _messageResult.SucessResultSave();
        }

        public async Task<bool> updatePasswordAsync(User user)
        {
            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, changePassword.Password);
            return result.Succeeded;
        }
        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                             PageHandlerExecutionDelegate next)

        {
            if (!context.ModelState.IsValid)
            {
                context.Result = _messageResult.failureResultField();
                return;
            }
            Guid Id = Guid.Empty;
            Id = Guid.Parse(context.HttpContext.Request.RouteValues["id"].ToString());
            var entity = await _userManager.FindByIdAsync(Id.ToString());
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
