using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos_User.common_question;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Common_Questions
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly IRepositoryApp<CommonQuestion> _question;
        private readonly IMapper _mapper;
         private readonly CulutureServices _culuture;

        public IndexModel(
             IRepositoryApp<CommonQuestion> question,
           CulutureServices culutureServices,
        IMapper Mapper)
        {
            _question = question;
             _culuture = culutureServices;
            _mapper = Mapper;
        }

        public string lang { get; set; }
        public IEnumerable<CommonQuestionListDto> questions { get; set; }
        public async Task OnGetAsync()
        {
            lang = _culuture.GetCulture();
            var questionsResult =await _question.GetAllAsync();
            questions = _mapper.Map<IEnumerable<CommonQuestionListDto>>(questionsResult);
        }
    }
}
