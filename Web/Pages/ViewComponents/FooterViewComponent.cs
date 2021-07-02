using AutoMapper;
using Core.Dtos_User.Home;
using Core.Entities;
using Core.Interfaces;
 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.ViewComponents
{
    public class FooterViewComponent: ViewComponent
    {
        private readonly IRepositoryApp<GeneralSetting> generalSetting;
        private readonly IMapper mapper;

        public FooterViewComponent(IRepositoryApp<GeneralSetting> GeneralSetting, IMapper Mapper)
        {
            generalSetting = GeneralSetting;
            mapper = Mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footer = await generalSetting.FirstAsync();
            var footerDto = mapper.Map<HeaderFooterDetailsDto>(footer);
            return View(footerDto);
        }
    }
}