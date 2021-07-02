using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.Department;
using Core.Dtos.Doctor;
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

namespace Web.Areas.Admin.Pages.Doctors
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {

        private readonly IRepositoryApp<Doctor> _doctor;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IWebHostEnvironment ihostingEnvironment;
        private readonly IAuthorizationService AuthorizationService;

        public IndexModel(
         IRepositoryApp<Doctor> doctor,
         IMapper mapper,
         CulutureServices lang,
         MessageResult MessageResult,
         IWebHostEnvironment ihostingEnvironment,
                         IAuthorizationService authorizationService


       )

        {
            _doctor = doctor;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            this.ihostingEnvironment = ihostingEnvironment;
            AuthorizationService = authorizationService;

        }
        [BindProperty]
        public IEnumerable<DoctorDtoList> Doctors { get; set; }
        public string lang { get; set; }
        public int length { get; set; }
        public async Task OnGetAsync()
        {
            lang = _lang.GetCulture();
            var DoctorResult = await _doctor.GetAllAsync(a => a.Department);
            length = DoctorResult.Count();
            DoctorResult = DoctorResult.Take(10);
            Doctors = _mapper.Map<IEnumerable<DoctorDtoList>>(DoctorResult);
        }
        public async Task<JsonResult> OnGetNewsListAsync(RequestQuery query)
        {
            var dataFilter = await _doctor.GetAllAsync(a => a.Department);
            var total = dataFilter.Count();
            var totalFilter = total;
            // filter 
            if (!string.IsNullOrEmpty(query.filterText) && !string.IsNullOrEmpty(query.filterType))
            {
                if (query.filterType == "name")
                    dataFilter = dataFilter.Where(a => a.Name.StartsWith(query.filterText) || a.NameAr.StartsWith(query.filterText));
                else if (query.filterType == "department")
                    dataFilter = dataFilter.Where(a => a.Department.Name.StartsWith(query.filterText) || a.Department.NameAr.StartsWith(query.filterText));
                else if (query.filterType == "university")
                    dataFilter = dataFilter.Where(a => a.University.StartsWith(query.filterText) || a.UniversityAr.StartsWith(query.filterText));
                else if (query.filterType == "isConsultant")
                    dataFilter = dataFilter.Where(a => a.IsConsultant == true);
                totalFilter = dataFilter.Count();
            }
            dataFilter = dataFilter.Skip(query.start).Take(query.length);
            Doctor x = dataFilter.FirstOrDefault();
            var xxx = query.sortColumnName.ToCapitalize();
            var dd = x.GetType().GetProperty(xxx).Name;

            if (query.sortDirection == "asc")
                dataFilter.OrderBy(a => a.GetType().GetProperty(xxx).Name);
            else
                dataFilter.OrderByDescending(a => a.GetType().GetProperty(query.sortColumnName.ToCapitalize()).Name);
            var Doctors = _mapper.Map<IEnumerable<DoctorDtoList>>(dataFilter);

            var result = new DataTableRespone<DoctorDtoList>()
            {
                draw = query.draw,      // number draw 
                recordsFiltered = totalFilter,  // record filter
                recordsTotal = total, // total recordd
                data = Doctors,     //   data 
                lang = _lang.GetCulture()  // lang

            };
            return new JsonResult(result);


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
            var entityResult = JsonConvert.DeserializeObject<Doctor[]>(entities);
            DeleteDoctorImage(entityResult);
             _doctor.DeleteRange(entityResult);         // selete entities
            var result = await _doctor.SaveAllAsync();
            return result ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();

        }
        public void DeleteDoctorImage(Doctor[] doctors)
        {
            foreach (var doctor in doctors)
            {
                if (!string.IsNullOrEmpty(doctor.PhotoPath))
                       doctor.PhotoPath.DeleteImageOnDisk(ihostingEnvironment);
             }
        }


    }
}
