using AutoMapper;
using Core.Dtos_User.Sliders;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages.ViewComponents
{
    public class SlidersViewComponent: ViewComponent
    {
        private readonly IRepositoryApp<Slider> slider;
        private readonly IMapper mapper;

        public SlidersViewComponent(IRepositoryApp<Slider> Slider,IMapper Mapper)
        {
            slider = Slider;
            mapper = Mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders =await slider.GetAllAsync();
            var slidersDto=mapper.Map<IEnumerable<SliderDto>>(sliders);
              return View(slidersDto);
        }
    }
}
