using AutoMapper;
using Core.Dtos_User.ContactUs;
using Core.Entities;
using Core.Interfaces;
 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.ViewComponents
{
    public class AboutDetailViewComponent : ViewComponent
    {
         
            private readonly IRepositoryApp<GeneralSetting> generalSetting;
             private readonly IMapper mapper;
          public AboutDetailViewComponent(
                IRepositoryApp<GeneralSetting> GeneralSetting,
                 IMapper Mapper)
            {
                generalSetting = GeneralSetting;
                 mapper = Mapper;
            }
            public async Task<IViewComponentResult> InvokeAsync()
        {
           var general = await generalSetting.FirstAsync();
           var aboutus = mapper.Map<ContactUsDto>(general);
           return View(aboutus);
        }
    }
}