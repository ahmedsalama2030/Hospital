using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.Department;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Departments
{
    [AllowAnonymous]

    public class DetailsModel : PageModel
    {
        private readonly IRepositoryApp<Department> _department;
        private readonly IMapper _mapper;
        private readonly CulutureServices _culuture;

        public DetailsModel(
             IRepositoryApp<Department> Department,
           CulutureServices culutureServices,
        IMapper Mapper)
        {
            _department = Department;
            _culuture = culutureServices;
            _mapper = Mapper;
        }

        public string lang { get; set; }
        public DepartmentDetailDto department { get; set; }
        public async Task OnGetAsync(Guid id)
        {
            lang = _culuture.GetCulture();
            var dept = await _department.SingleOrDefaultAsync(a => a.Id.Equals(id), a => a.Hospital, i => i.DepartmentImages, s => s.DepartmentServices);
            if (dept == null)
                RedirectToPage("/Departments/Index");
            department = _mapper.Map<DepartmentDetailDto>(dept);
        }
    }
}
