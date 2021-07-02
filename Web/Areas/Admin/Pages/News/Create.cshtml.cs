using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Common;
using Core.Dtos.News;
using Core.Entities;
using Core.Interfaces;
 using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Web.Areas.Admin.helper;
using Web.Resources;

namespace Web.Areas.Admin.Pages.News
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IRepositoryApp<Core.Entities.News> _news;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _ihostingEnvironment;
        private readonly CulutureServices _lang;
        private readonly IStringLocalizer<Resource> _localizer;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;

        public CreateModel(
               IWebHostEnvironment ihostingEnvironment,
               IRepositoryApp<Core.Entities.News> news,

        CulutureServices lang,
                IConfiguration config,
               IStringLocalizer<Resource> Localizer,
                        MessageResult MessageResult,
                IAuthorizationService authorizationService,

                IMapper Mapper)
        {
            _news = news;
            _mapper = Mapper;
            _ihostingEnvironment = ihostingEnvironment;
            _lang = lang;
            _localizer = Localizer;
            _messageResult = MessageResult;
            AuthorizationService = authorizationService;

        }



        [BindProperty]
    public NewsDtoPost NewsPost { get; set; }
    [BindProperty]
     public IFormFileCollection photosUpload { get; set; }

    public string lang { get; set; }
    public void OnGet()
    {

        lang = _lang.GetCulture();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
                // get files photos
                #region remove in production
                var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
                if (policyCheck.Succeeded)
                    return _messageResult.failureResultSave("You do not have permission");
                #endregion
                // check cout photo
                if (photosUpload.Count() <= 0)
                return new JsonResult(new { code = 400, data = _localizer["image required"].Value });
            //get path and save image physical ==> extiention method
            var paths =await photosUpload.SaveImagesOnDisk(_ihostingEnvironment, "news");
            // map object
            var newsResult = _mapper.Map<Core.Entities.News>(NewsPost);
            // map images paths
            newsResult.NewsImages = _mapper.Map<List<NewsImage>>(paths);
            _news.Add(newsResult);
            var result = await _news.SaveAllAsync();
            if (result)
                return _messageResult.SucessResultSave();
            else
                return _messageResult.failureResultSave();  
        }
        else
            return _messageResult.failureResultField(); ;


    }





}
}
