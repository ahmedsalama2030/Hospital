using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web.Areas.Admin.helper;
using Web.Areas.Admin.Pages.Models;
 namespace Web.Areas.Admin.Pages.News
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<Core.Entities.News> _news;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private IWebHostEnvironment _ihostingEnvironment;
        private readonly IRepositoryApp<NewsImage> _newsImage;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public IndexModel(
            IRepositoryApp<Core.Entities.News> news,
            IMapper mapper,
            CulutureServices lang,
            IRepositoryApp<NewsImage> NewsImage,
            MessageResult MessageResult,
        IAuthorizationService authorizationService,

            IWebHostEnvironment ihostingEnvironment)

        {
            _ihostingEnvironment = ihostingEnvironment;
            _newsImage = NewsImage;
            _news = news;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            AuthorizationService = authorizationService;


        }
        public IEnumerable<Core.Entities.News> News { get; set; }
        public string lang { get; set; }
        public int length { get; set; }

        public async Task OnGetAsync()
        {
             lang = _lang.GetCulture();
            var NewsResult = await _news.GetAllAsync();
             length = NewsResult.Count();
            NewsResult = NewsResult.Take(10);
            News = _mapper.Map<IEnumerable<Core.Entities.News>>(NewsResult);
        }

        public async Task<JsonResult> OnGetNewsListAsync(RequestQuery query)
        {
             
            var  dataFilter = await _news.GetAllAsync();
            var total = dataFilter.Count(); 
            // filter 
            if (!string.IsNullOrEmpty(query.filterText)&& !string.IsNullOrEmpty(query.filterType))
            {
                 if (query.filterType == "title")
                {
                    dataFilter = await _news.GetAllAsync(a => a.Title.StartsWith(query.filterText) || a.TitleAr.StartsWith(query.filterText));

                }
                else  
                 dataFilter = await _news.GetAllAsync(a => a.description.StartsWith(query.filterText) || a.descriptionAr.StartsWith(query.filterText));
                 }
            {
                if (query.filterType == "title")
                 dataFilter = dataFilter.Where(a => a.Title.StartsWith(query.filterText) || a.TitleAr.StartsWith(query.filterText));
                 // filter complete

            }

            dataFilter =   dataFilter.Skip(query.start).Take(query.length);
            if (query.sortDirection == "asc")
                dataFilter.OrderBy(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));
            else
                dataFilter.OrderByDescending(a => a.GetType().GetProperty(query.sortColumnName).GetValue(a));

            var result = new DataTableRespone<Core.Entities.News>()
            {
                draw = query.draw,      // number draw 
                recordsFiltered = total,  // record filter
                recordsTotal = dataFilter.Count(), // total recordd
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
            var entityResult = JsonConvert.DeserializeObject<Core.Entities.News[]>(entities);
            var imageResult=  await DeleteImagesAsync(entityResult) ;  // delete images
               _news.DeleteRange(entityResult) ;         // selete entities
            var result = imageResult? await _news.SaveAllAsync():false;
            return (result) ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();

        }

        public async Task<bool> DeleteImagesAsync(Core.Entities.News[] news)
        {
            var deleteImageResult = false;
            foreach (var item in news)
            {
                var images = await _newsImage.GetAllAsync(a => a.NewsId == item.Id);
                if (images != null)
                    deleteImageResult = images.Select(a => a.Path).ToArray().DeleteImagesOnDisk(_ihostingEnvironment);
            }
            return deleteImageResult;
        }

 
       
    }


}
