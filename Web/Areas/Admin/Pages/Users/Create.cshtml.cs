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
  using Microsoft.EntityFrameworkCore;
using Core.Dtos.Auth;

namespace Web.Areas.Admin.Pages.Users
{
    [Authorize(Policy = "AllowUserAdmin")]
    [BindProperties]
    public class CreateModel : PageModel
    {
         private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly CulutureServices _lang;
         private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public CreateModel(
             UserManager<User> userManager,
             RoleManager<Role> roleManager,
               CulutureServices lang,
                MessageResult MessageResult,
                IAuthorizationService authorizationService,
               IMapper Mapper)
        {
             _mapper = Mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _lang = lang;
             _messageResult = MessageResult;
            AuthorizationService = authorizationService;


        }
       
        public List<string> RolesSelect { get; set; } = new List<string>();
         
        public List<Role> roles { get; set; }
        
        public   UserRegisterDto UserDto { get; set; }
        
        public string lang { get; set; }
        public async Task OnGetAsync()
        {
             roles  =await _roleManager.Roles.ToListAsync();
            lang = _lang.GetCulture();
        }
 
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                #region remove in production
                var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
                if (policyCheck.Succeeded)
                  return  _messageResult.failureResultSave("You do not have permission");
                #endregion
                var user = _mapper.Map<User>(UserDto);
               var result= await _userManager.CreateAsync(user, UserDto.Password);
                if (result.Succeeded)
                {
                    if (RolesSelect.Count() > 0)
                    {
                        var roleResult = await _userManager.AddToRolesAsync(user, (IEnumerable<string>)RolesSelect);
                        if (roleResult.Succeeded)
                            return _messageResult.SucessResultSave();
                        else
                            _messageResult.failureRoleSave();
                    }
                    return _messageResult.SucessResultSave();

                }
                 
                return   _messageResult.failureResultSave(result.Errors.FirstOrDefault().Code);
            }
            else
                return _messageResult.failureResultField();
        }





    }
}
