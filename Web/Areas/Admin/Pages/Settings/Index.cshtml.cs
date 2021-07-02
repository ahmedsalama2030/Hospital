using System;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.settings;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Areas.Admin.helper;

namespace Web.Areas.Admin.Pages.Settings
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<GeneralSetting> _generalSetting;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private IWebHostEnvironment _ihostingEnvironment;
        private readonly IAuthorizationService AuthorizationService;

        public IndexModel(
         IRepositoryApp<GeneralSetting> generalSetting,
          IMapper mapper,
         CulutureServices lang,
         MessageResult MessageResult,
           IAuthorizationService authorizationService,

        IWebHostEnvironment ihostingEnvironment


       )

        {
            _generalSetting = generalSetting;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            _ihostingEnvironment = ihostingEnvironment;
            AuthorizationService = authorizationService;


        }
        [BindProperty]
        public GeneralSettingsDtoGet settings { get; set; }
        public IFormFile SiteLogophoto { get; set; }
        [BindProperty]
        public IFormFile ManagerPhoto { get; set; }

        public string lang { get; set; }
        public void OnGet()
        {
            lang = _lang.GetCulture();
            var settingResult = HttpContext.Items["entity"] as GeneralSetting;
            settings = _mapper.Map<GeneralSettingsDtoGet>(settingResult);
        }
        public async Task<ActionResult> OnPostAsync()
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            var settingResult = HttpContext.Items["entity"] as GeneralSetting;
            var settingResultUpdate = _mapper.Map(settings, settingResult);
            if (SiteLogophoto != null)
            {
                if (!string.IsNullOrEmpty(settingResult.SiteLogoPath))
                    settingResult.SiteLogoPath.DeleteImageOnDisk(_ihostingEnvironment);
                settingResultUpdate.SiteLogoPath =(await SiteLogophoto.SaveImageOnDisk(_ihostingEnvironment, "setting")).Path.ToString();
            }
            if (ManagerPhoto != null)
            {
                if (!string.IsNullOrEmpty(settingResult.ManegerPhotoPath))
                    settingResult.ManegerPhotoPath.DeleteImageOnDisk(_ihostingEnvironment);
                settingResultUpdate.ManegerPhotoPath =(await ManagerPhoto.SaveImageOnDisk(_ihostingEnvironment, "setting")).Path.ToString();
            }
            if (settingResult == null)
                _generalSetting.Add(settingResultUpdate);
            else
                _generalSetting.Update(settingResultUpdate);
            var result = await _generalSetting.SaveAllAsync();
            return (result ? _messageResult.SucessResultSave() : _messageResult.failureResultStateChange());

        }
        public async Task<IActionResult> OnGetDeleteSiteImageAsync()
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            var setting = HttpContext.Items["entity"] as GeneralSetting;
            if (setting == null)
                return _messageResult.failureIdNotFound();
            setting.SiteLogoPath.DeleteImageOnDisk(_ihostingEnvironment);
            setting.SiteLogoPath = "";
            _generalSetting.Update(setting);
            var result = await _generalSetting.SaveAllAsync();
            return (result) ? _messageResult.SucessResultDelete("sitelogo") : _messageResult.failureResultSave();

        }
        //managerPhoto
        public async Task<IActionResult> OnGetDeleteManagerImageAsync(Guid photoId)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            var setting = HttpContext.Items["entity"] as GeneralSetting;
            if (setting == null)
                return _messageResult.failureIdNotFound();
            setting.SiteLogoPath.DeleteImageOnDisk(_ihostingEnvironment);
            setting.ManegerPhotoPath = "";
            _generalSetting.Update(setting);
            var result = await _generalSetting.SaveAllAsync();
            return (result) ? _messageResult.SucessResultDelete("managerPhoto") : _messageResult.failureResultSave();

        }

        // delete images

        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                   PageHandlerExecutionDelegate next)

        {

            if (!context.ModelState.IsValid)
            {
                context.Result = _messageResult.failureResultField();
                return;
            }
            var entity = await _generalSetting.FirstAsync();

            context.HttpContext.Items.Add("entity", entity);
            await next.Invoke();
        }

    }
}

