using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Web.Areas.Admin.helper;
using Web.Areas.Admin.Pages.Models;

namespace Web.Areas.Admin.Pages.Hospitals
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {
       
        private readonly IRepositoryApp<Core.Entities.Hospital> _hospitals;
         private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public IndexModel(
         IRepositoryApp<Core.Entities.Hospital> hospitals,
          CulutureServices lang,
          IAuthorizationService authorizationService,

           MessageResult MessageResult 
        )
           {
            _hospitals = hospitals;
             _lang = lang;
            _messageResult = MessageResult;
            AuthorizationService = authorizationService;

        }
        [BindProperty]
        public IEnumerable<Core.Entities.Hospital> hospitals { get; set; }
        public string lang { get; set; }
        public int length { get; set; }
        public async Task OnGetAsync()
        {
            lang = _lang.GetCulture();
            hospitals = await _hospitals.GetAllAsync();
            length = hospitals.Count();
            hospitals = hospitals.Take(10); // defualt length
        }
        public async Task<JsonResult> OnGetNewsListAsync(RequestQuery query)
        {
            var  dataFilter = await _hospitals.GetAllAsync();
            var total = dataFilter.Count();
             // filter 
            if (!string.IsNullOrEmpty(query.filterText) && !string.IsNullOrEmpty(query.filterType))
            {
                if (query.filterType == "name")
                 dataFilter = await _hospitals.GetAllAsync(a => a.Name.StartsWith(query.filterText) || a.NameAr.StartsWith(query.filterText));
                 // filter complete
            }
             dataFilter = dataFilter.Skip(query.start).Take(query.length);
            if (query.sortDirection == "asc")
                dataFilter.OrderBy(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));
            else
                dataFilter.OrderByDescending(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));
            var result = new DataTableRespone<Core.Entities.Hospital>()
            {
                draw = query.draw,      // number draw 
                recordsFiltered = total,  // record filter
                recordsTotal = dataFilter.Count(), // total recordd
                data = dataFilter,     //   data 
             };
            return  new JsonResult(result);
       }

        public async Task<IActionResult> OnPostDeleteAsync(string entities)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (string.IsNullOrEmpty(entities))
                return BadRequest();
            var entityResult = JsonConvert.DeserializeObject<Core.Entities.Hospital[]>(entities);
            _hospitals.DeleteRange(entityResult);         // selete entities
            var result = await _hospitals.SaveAllAsync();
            return (result) ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();

        }



        public IActionResult RedirectToPageMaster => RedirectToPage("Index");
    }
}
