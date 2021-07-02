using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Departments
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {  
        private readonly IRepositoryApp<Department> _department;
        private readonly IMapper mapper;
        private readonly IRepositoryApp<Hospital> _hospital;
        private readonly CulutureServices _culuture;

        public IndexModel(
             IRepositoryApp<Department> Department,
          IRepositoryApp<Hospital> Hospital,
          CulutureServices culutureServices,
        IMapper Mapper)
        {
            _department = Department;
            _hospital = Hospital;
            _culuture = culutureServices;
            mapper = Mapper;
        }

        public string lang { get; set; }
        [BindProperty]
        public IEnumerable<IGrouping<string , DepartmentListDtoUser>> departmets{ get; set; }
    public async Task OnGetAsync()
            {
            var departments =await _department.GetAllAsync(a=>a.Hospital);
            var departmentDto = mapper.Map<IEnumerable<DepartmentListDtoUser>>(departments);
            lang = _culuture.GetCulture();
            if (lang == "ar")
                getDeptarmentAr(departmentDto);
            else
                getDeptarmentEn(departmentDto);
             }

     
        public void getDeptarmentAr(IEnumerable<DepartmentListDtoUser> depts)
        {
            departmets = depts.GroupBy(a => a.HospitalNameAr);

        }
    public void getDeptarmentEn(IEnumerable<DepartmentListDtoUser> depts)
    {
        departmets = depts.GroupBy(a => a.HospitalName);

    }
}
    }
