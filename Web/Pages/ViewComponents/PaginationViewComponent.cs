using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.helpers.pagination;
using Web.Models;

namespace Web.Pages.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public  IViewComponentResult Invoke(PaginationConfig paginationConfig)
        {
             
            return View(paginationConfig);
        }
    }
}
