using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.News
{ 
    [AllowAnonymous]
        public class DetailsModel : PageModel
        {
            private readonly IRepositoryApp<Core.Entities.News> _new;
            private readonly IMapper _mapper;
            private readonly CulutureServices _culuture;

            public DetailsModel(
                 IRepositoryApp<Core.Entities.News> news ,
               CulutureServices culutureServices,
            IMapper Mapper)
            {
                _new = news;
                _culuture = culutureServices;
                _mapper = Mapper;
            }

            public string lang { get; set; }
            public Core.Entities.News news { get; set; }
            public async Task OnGetAsync(Guid id)
            {
            lang = _culuture.GetCulture();
                news = await _new.SingleOrDefaultAsync(s => s.Id == id, a => a.NewsImages);
            }
        }

    }
