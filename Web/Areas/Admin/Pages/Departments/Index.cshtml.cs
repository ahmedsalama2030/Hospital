using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.Department;
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

namespace Web.Areas.Admin.Pages.Departments
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {

        private readonly IRepositoryApp<Department> _Department;
        private readonly IRepositoryApp<DepartmentImages> _departmentImages;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IWebHostEnvironment ihostingEnvironment;
        private readonly IAuthorizationService AuthorizationService;


        public IndexModel(
         IRepositoryApp<Department> Department,
         IRepositoryApp<DepartmentImages> DepartmentImages,
         IMapper mapper,
         CulutureServices lang,
         MessageResult MessageResult,
                         IAuthorizationService authorizationService,

          IWebHostEnvironment ihostingEnvironment


       )

        {
            _Department = Department;
            _departmentImages = DepartmentImages;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            this.ihostingEnvironment = ihostingEnvironment;
            AuthorizationService = authorizationService;

        }
        [BindProperty]
        public IEnumerable<DepartmentDtoGet> Departments { get; set; }
        public string lang { get; set; }
        public int length { get; set; }
        public async Task OnGetAsync()
        {
            lang = _lang.GetCulture();
            var DepartmentsResult = await _Department.GetAllAsync();
            length = DepartmentsResult.Count();
            DepartmentsResult = DepartmentsResult.Take(10);
            Departments = _mapper.Map<IEnumerable<DepartmentDtoGet>>(DepartmentsResult);
        }
        public async Task<JsonResult> OnGetNewsListAsync(RequestQuery query)
        {
              var dataFilter = await _Department.GetAllAsync();
             var total = dataFilter.Count();
            var totalFilter = total;

            // filter 
            if (!string.IsNullOrEmpty(query.filterText) && !string.IsNullOrEmpty(query.filterType))
            {
                if (query.filterType == "name")
                  dataFilter = dataFilter.Where(a => a.Name.StartsWith(query.filterText) || a.NameAr.StartsWith(query.filterText));
                else
                    dataFilter = dataFilter.Where(a => a.description.StartsWith(query.filterText) || a.descriptionAr.StartsWith(query.filterText));
                total = dataFilter.Count();
            }
            dataFilter = dataFilter.Skip(query.start).Take(query.length);
            if (query.sortDirection == "asc")
                dataFilter.OrderBy(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));
            else
                dataFilter.OrderByDescending(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));

            var result = new DataTableRespone<DepartmentDtoGet>()
            {
                draw = query.draw,      // number draw 
                recordsFiltered = totalFilter,  // record filter
                recordsTotal = total, // total recordd
                data = _mapper.Map<IEnumerable<DepartmentDtoGet>>(dataFilter),     //   data 
                
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
            var entityResult = JsonConvert.DeserializeObject<Department[]>(entities);
             await deletePhotoAsync(entityResult);
            _Department.DeleteRange(entityResult);         // selete entities
            var result = await _Department.SaveAllAsync();
            return result ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();

        }
        public async Task deletePhotoAsync(Department[] deptartment)
        {
            foreach (var dept in deptartment)
            {
              var deptImage=await  _departmentImages.GetAllAsync(a=>a.DepartmentId==dept.Id);
              var paths = deptImage.Select(a=>a.Path).ToArray().DeleteImagesOnDisk(ihostingEnvironment);
            }

        }

     }
}
