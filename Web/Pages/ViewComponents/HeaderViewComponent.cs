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
    public class HeaderViewComponent: ViewComponent
    {
        private readonly IRepositoryApp<GeneralSetting> generalSetting;
        private readonly IMapper mapper;

        public HeaderViewComponent(IRepositoryApp<GeneralSetting> GeneralSetting, IMapper Mapper)
        {
            generalSetting = GeneralSetting;
            mapper = Mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var header = await generalSetting.FirstAsync();
            var headerDto = mapper.Map<HeaderFooterDetailsDto>(header);
            return View(headerDto);
        }
    }
}