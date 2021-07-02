using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.Auth;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web.Areas.Admin.helper;
using Web.Areas.Admin.Pages.Models;
namespace Web.Areas.Admin.Pages.Users
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<User> _users;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly UserManager<User> _userManager;
        private readonly ISecurityRepository _userRepo;
        private readonly IAuthorizationService AuthorizationService;

        public IndexModel(
            IRepositoryApp<User> news,
            IMapper mapper,
            CulutureServices lang,
             MessageResult MessageResult,
             UserManager<User> userManager,
             IAuthorizationService authorizationService,
           ISecurityRepository userRepo

             )

        {
             _users = news;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            _userManager = userManager;
            _userRepo = userRepo;
            AuthorizationService = authorizationService;

        }
        public IEnumerable<UserListDto> Users { get; set; }
    public string lang { get; set; }
    public int length { get; set; }

    public async Task OnGetAsync()
    {
             
            lang = _lang.GetCulture();
        var usersRole = await _userRepo.GetUsersRoles();

        length = usersRole.Count();
        Users = usersRole.Take(10);

    }

    public async Task<JsonResult> OnGetNewsListAsync(RequestQuery query)
    {

        var dataFilter = await _userRepo.GetUsersRoles();
        var total = dataFilter.Count();
        var totalFilter = total;
        // filter 
        if (!string.IsNullOrEmpty(query.filterText) && !string.IsNullOrEmpty(query.filterType))
        {
            if (query.filterType == "name")
            {
                dataFilter = dataFilter.Where(a => a.FirstName.StartsWith(query.filterText) || a.FirstName.StartsWith(query.filterText));

            }
            else
                dataFilter = dataFilter.Where(a => a.PhoneNumber.StartsWith(query.filterText) || a.PhoneNumber.StartsWith(query.filterText));
            totalFilter = dataFilter.Count();
        }


        dataFilter = dataFilter.Skip(query.start).Take(query.length);
        if (query.sortDirection == "asc")
            dataFilter.OrderBy(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));
        else
            dataFilter.OrderByDescending(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));

        var result = new DataTableRespone<UserListDto>()
        {
            draw = query.draw,      // number draw 
            recordsFiltered = totalFilter,  // record filter
            recordsTotal = total, // total recordd
            data = dataFilter,     //   data 
            lang = _lang.GetCulture()  // lang
        };
        var finalResult = new JsonResult(result);
        return finalResult;


    }

    public async Task<IActionResult> OnPostDeleteAsync(string entities)
    {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (string.IsNullOrEmpty(entities))
            return _messageResult.failureResultSave("empty");
       
        var entityResult = JsonConvert.DeserializeObject<IEnumerable<User>>(entities);

        foreach (var item in entityResult)
        {
            var user = await _users.GetByIdAsync(item.Id);
            _users.Delete(user);
        }
        var result = await _users.SaveAllAsync();
        if (result)
            return _messageResult.SucessResultSave();
        else
            return _messageResult.failureResultSave();


    }




}


}
