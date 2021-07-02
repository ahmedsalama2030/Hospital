using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.News;
using Core.Dtos_User.News;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.helpers.extensions;
using Web.helpers.pagination;

namespace Web.Pages.News
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<Core.Entities.News> _new;
        private readonly IMapper _mapper;
        private readonly CulutureServices _culuture;

        public IndexModel(
             IRepositoryApp<Core.Entities.News> news,
           CulutureServices culutureServices,
        IMapper Mapper)
        {
            _new = news;
            _culuture = culutureServices;
            _mapper = Mapper;
        }

        public string lang { get; set; }
        public IEnumerable<NewsUserListDto> news { get; set; }
        public PaginationHeader pagination { get; set; }
        public async Task OnGetAsync()
        {
            lang = _culuture.GetCulture();
           var newsResult  =   _new.GetAll(a => a.NewsImages);
            newsResult.OrderBy(a => a.CreatedDate);
            PaginationParam paginationParam = new PaginationParam();
            paginationParam.PageSize = 6;
            var PagedList = await PagedList<Core.Entities.News>.CreateAsync(newsResult, paginationParam.pageNumber, paginationParam.PageSize);
             pagination = new PaginationHeader(
                                   PagedList.CurrentPage,
                                    PagedList.PageSize,
                                    PagedList.TotalItems,
                                    PagedList.TotalPages);
            news = _mapper.Map<IEnumerable<NewsUserListDto>>(newsResult);

        }
        public async Task<IActionResult> OnPostAsync(PaginationParam paginationParam)
        {

            var newsResult = _new.GetAll(a => a.NewsImages);
            paginationParam.PageSize = 6;
            var PagedList = await PagedList<Core.Entities.News>.CreateAsync(newsResult, paginationParam.pageNumber, paginationParam.PageSize);
            Response.AddPagination(PagedList.CurrentPage, PagedList.PageSize, PagedList.TotalItems, PagedList.TotalPages);

            var returnFinal = _mapper.Map<IEnumerable<NewsUserListDto>>(PagedList); ;

            return Partial("_pagination", returnFinal);
        }
    }
}
