using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.Contact_us;
using Core.Dtos_User.ContactUs;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Web.Resources;

namespace Web.Pages.ContactUs
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<GeneralSetting> _setting;
        private readonly IRepositoryApp<Core.Entities.ContactUs> _contactUs;
        private readonly IMapper _mapper;
        private readonly CulutureServices _culuture;
        private readonly IStringLocalizer<Resource> _localizer;

        public IndexModel(
        IRepositoryApp<GeneralSetting> setting,
        IRepositoryApp<Core.Entities.ContactUs>  contactUs,
        CulutureServices culutureServices,
        IStringLocalizer<Resource> localizer,
        IMapper Mapper)
        {
            _setting = setting;
            _contactUs = contactUs;
            _culuture = culutureServices;
            _mapper = Mapper;
            _localizer = localizer;
        }
        [BindProperty]
        public ContactusRegisterDto ContactUs { get; set; }
        public GeneraDetail Details { get; set; }
        public string lang { get; set; }
        public async Task OnGetAsync()
        {
            var detail =await _setting.FirstAsync();
            Details = _mapper.Map<GeneraDetail>(detail);
            lang = _culuture.GetCulture();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var contact = _mapper.Map<Core.Entities.ContactUs>(ContactUs);
                _contactUs.Add(contact);
                var result = await _contactUs.SaveAllAsync();
                if (result)
                    return Content("<span  class='message-success'  >" + _localizer["sucess send"].Value + "</span>");
                else
                    return Content("<span  class='message-error'  >" + _localizer["failure send"].Value + "</span>");
            }
            return Content("<span  class='message-error'  >" + _localizer["some field error"].Value + "</span>");

        }
    }
}
