using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Web.Areas.Admin.helper;
using Web.Areas.Admin.Pages.Models;

namespace Web.Areas.Admin.Pages.Clinic_schedual
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp< ClinicSchedul> _clinic;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;


        public IndexModel(
          IRepositoryApp<ClinicSchedul> ClinicName,
          IMapper mapper,
          CulutureServices lang ,
                          IAuthorizationService authorizationService,

        MessageResult MessageResult

        )

        {
             _clinic = ClinicName;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            AuthorizationService = authorizationService;

        }
        [BindProperty]
        public IEnumerable<ClinicSchedul> clinicScheduls { get; set; }
        public string lang { get; set; }
        public int length { get; set; }
        public async Task OnGetAsync()
        {
            lang = _lang.GetCulture();
            clinicScheduls  = await _clinic.GetAllAsync();
            length = clinicScheduls.Count();
            clinicScheduls=clinicScheduls.Take(10);
         }
        public async Task<JsonResult> OnGetNewsListAsync(RequestQuery query)
        {
            var  dataFilter = await _clinic.GetAllAsync();
            var total = dataFilter.Count();
            var totalFilter = total;
            // filter 
            if (!string.IsNullOrEmpty(query.filterText) && !string.IsNullOrEmpty(query.filterType))
            {
                if (query.filterType == "name")
                {
                    dataFilter = dataFilter.Where(a => a.ClinicName.StartsWith(query.filterText) || a.ClinicNameAr.StartsWith(query.filterText));
                     
                }
                totalFilter = dataFilter.Count();

            }
            

             dataFilter = dataFilter.Skip(query.start).Take(query.length);
            if (query.sortDirection == "asc")
                dataFilter.OrderBy(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));
            else
                dataFilter.OrderByDescending(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));

            var result = new DataTableRespone<ClinicSchedul>()
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
                return BadRequest();
            var entityResult = JsonConvert.DeserializeObject<ClinicSchedul[]>(entities);
            _clinic.DeleteRange(entityResult);         // selete entities
            var result = await _clinic.SaveAllAsync();
            return result ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();

        }



        public IActionResult RedirectToPageMaster => RedirectToPage("Index");
    }
}
