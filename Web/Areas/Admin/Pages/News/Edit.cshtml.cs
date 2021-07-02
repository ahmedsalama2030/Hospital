using System;
using System.Collections.Generic;
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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
 using Web.Areas.Admin.helper;
using Web.Resources;

namespace Web.Areas.Admin.Pages.News
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class EditModel : PageModel
    {
        private readonly IRepositoryApp<Core.Entities.News> _news;
        private readonly IRepositoryApp<NewsImage> _newsImage;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _ihostingEnvironment;
        private  readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IStringLocalizer<Resource> _localizer;
        private readonly IAuthorizationService AuthorizationService;

        public EditModel(
               IWebHostEnvironment ihostingEnvironment,
               IRepositoryApp<Core.Entities.News> news,
               IRepositoryApp<NewsImage> NewsImage,
               CulutureServices lang,
               MessageResult MessageResult,
               IStringLocalizer<Resource> Localizer,
                 IAuthorizationService authorizationService,


               IMapper Mapper)
        {
            _news = news;
            _newsImage = NewsImage;
            _mapper = Mapper;
            _ihostingEnvironment = ihostingEnvironment;
            _lang = lang;
            _messageResult = MessageResult;
            _localizer = Localizer;
            AuthorizationService = authorizationService;


        }
        public  string lang { get; set; }

        [BindProperty]
        public Guid Id { get; set; }
        [BindProperty]
        public NewsDtoGet news { get; set; }
        [BindProperty]
        public Guid NewsImageId { get; set; }
        [BindProperty]
        public IFormFileCollection photosUpload { get; set; }
        public   void OnGet(Guid id)
        {
             var newsResult = HttpContext.Items["entity"] as Core.Entities.News;
             news = _mapper.Map<NewsDtoGet>(newsResult);
            lang = _lang.GetCulture();
           }
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (ModelState.IsValid)
            {
                #region remove in production
                var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
                if (policyCheck.Succeeded)
                    return _messageResult.failureResultSave("You do not have permission");
                #endregion
                ICollection<NewsImageGet> NewsImages = null;
                // 1-  get news entity :-
                var newsEntity = HttpContext.Items["entity"] as Core.Entities.News;
                 // 2-  get news images entity :-
                var newsImageGet = _mapper.Map<List<NewsImageGet>>(newsEntity.NewsImages);
                if (newsImageGet != null)
                    NewsImages = changeIsMain(newsImageGet); // 3-  change is main property :-
                newsImageGet= await  SaveImagesAsync(photosUpload,   newsImageGet); // 4-  save images with proxy :-
                news.NewsImages = newsImageGet; // 5-  update news images entity :-
                  _mapper.Map(news, newsEntity); // 6-  map to get new entity final and update disconnecting ef :-
                var result = await _news.SaveAllAsync();
                return (result) ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();
            }
            else
                return _messageResult.failureResultSave();

        }
        // delete images
        public async Task<IActionResult> OnGetDeleteImageAsync(Guid Id, Guid photoId)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (Id == null)
                return _messageResult.failureResultSave();
            var image = await _newsImage.GetByIdAsync(photoId);
            var deleteHard = image.Path.DeleteImageOnDisk(_ihostingEnvironment);
            _newsImage.Delete(image);
            var result = deleteHard? await _newsImage.SaveAllAsync():false;
            return (result) ? _messageResult.SucessResultDelete(image.Id.ToString()) : _messageResult.failureResultSave();
              }
        // change Is Main :-
        public ICollection<NewsImageGet> changeIsMain(List<NewsImageGet> newsImagesResult)
        {

            foreach (var image in newsImagesResult)
            {
                if (image.Id == NewsImageId)
                    image.isMain = true;
                else
                    image.isMain = false;
            }
            return newsImagesResult;


        }
        // Save Images  proxy:-
        public async Task<List<NewsImageGet>> SaveImagesAsync(IFormFileCollection photos,   List<NewsImageGet> NewsImages)
        {
            List<ImagesPath> Paths = null;
            if (photos.Count() > 0 && NewsImages.Count < 4)
            {
                Paths = await photos.SaveImagesOnDisk(_ihostingEnvironment, "news");
                NewsImages.AddRange(_mapper.Map<List<NewsImageGet>>(Paths));
            }
            return NewsImages;


        }

 

        // filter Id Of page 
        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                      PageHandlerExecutionDelegate next)

        {
            Guid Id = Guid.Empty;
            Id = Guid.Parse(context.HttpContext.Request.RouteValues["id"].ToString());
            var entity = await _news.SingleOrDefaultAsync(i => i.Id == Id, a => a.NewsImages);
            if (entity == null)
            {
                context.Result = Redirect("/Error");
                return;
            }
            context.HttpContext.Items.Add("entity", entity);
            await next.Invoke();
        }
         

    }
    }
