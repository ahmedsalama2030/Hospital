using AutoMapper;
using Core.Dtos_User.hospital;
using Core.Entities;
using Core.Interfaces;
 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.helpers.pagination;

namespace Web.Pages.ViewComponents
{
    public class HospitalsViewComponent : ViewComponent
    {
        private readonly IRepositoryApp<Hospital> hospital;
        private readonly IMapper mapper;

        public HospitalsViewComponent(IRepositoryApp<Hospital> Hospital, IMapper Mapper)
        {
            hospital = Hospital;
            mapper = Mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
             var hospitals =   hospital.GetAll();
            PaginationParam paginationParam = new PaginationParam();
            paginationParam.PageSize = 6;
              var PagedList = await PagedList<Hospital>.CreateAsync(hospitals, paginationParam.pageNumber, paginationParam.PageSize);
            var hospitalDto = mapper.Map<IEnumerable<HospitalGetlDto>>(PagedList);

            ViewBag.pagination = new PaginationHeader(
                                     PagedList.CurrentPage,
                                      PagedList.PageSize,
                                      PagedList.TotalItems,
                                      PagedList.TotalPages);
           
            
            return View(hospitalDto);
        }
    }
}