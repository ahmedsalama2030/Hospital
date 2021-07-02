using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.Doctor;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.helpers.extensions;
using Web.helpers.pagination;

namespace Web.Pages.Doctors
{
    [AllowAnonymous]

    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<Doctor> _doctor;
        private readonly IMapper mapper;
         private readonly CulutureServices _culuture;

        public IndexModel(
          IRepositoryApp<Doctor> doctor,
           CulutureServices culutureServices,
        IMapper Mapper)
        {
            _doctor = doctor;
             _culuture = culutureServices;
            mapper = Mapper;
        }

        public string lang { get; set; }
        public IEnumerable<DoctorDtoListGet> Doctors { get; set; }
        public PaginationHeader  pagination { get; set; }
        [BindProperty]
        public string doctorname { get; set; }

        public async Task OnGetAsync()
        {
            var doctorResult = _doctor.GetAll(a=>a.Department);
            PaginationParam paginationParam = new PaginationParam();
            paginationParam.PageSize = 4;
            var PagedList = await PagedList<Doctor>.CreateAsync(doctorResult, paginationParam.pageNumber, paginationParam.PageSize);
            pagination = new PaginationHeader(
                                  PagedList.CurrentPage,
                                   PagedList.PageSize,
                                   PagedList.TotalItems,
                                   PagedList.TotalPages);
            Doctors = mapper.Map<IEnumerable<DoctorDtoListGet>>(PagedList); 

             
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var doctorResult = _doctor.GetAll();
             if(!string.IsNullOrEmpty(doctorname))
                  doctorResult = doctorResult.Where(a => a.Name.StartsWith(doctorname) || a.NameAr.StartsWith(doctorname));

            PaginationParam paginationParam = new PaginationParam();
            paginationParam.PageSize = 4;
            var PagedList = await PagedList<Doctor>.CreateAsync(doctorResult, paginationParam.pageNumber, paginationParam.PageSize);
            pagination = new PaginationHeader(
                                  PagedList.CurrentPage,
                                   PagedList.PageSize,
                                   PagedList.TotalItems,
                                   PagedList.TotalPages);
            Doctors = mapper.Map<IEnumerable<DoctorDtoListGet>>(PagedList);
            doctorname = doctorname;
            return Partial("_doctors", Doctors);
        }

        public async Task<IActionResult> OnPostFilterAsync(PaginationParam paginationParam)
        {

            var doctorResult = _doctor.GetAll();
            paginationParam.PageSize = 6;
            var PagedList = await PagedList<Doctor>.CreateAsync(doctorResult, paginationParam.pageNumber, paginationParam.PageSize);
            Response.AddPagination(PagedList.CurrentPage, PagedList.PageSize, PagedList.TotalItems, PagedList.TotalPages);
            var returnFinal = mapper.Map<IEnumerable<DoctorDtoListGet>>(PagedList); ;
            return Partial("_doctors", returnFinal);
        }
    }
}
