using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos.CommonQuestion;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Admin.helper;

namespace Web.Areas.Admin.Pages.CommonQuestions
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class CreateModel : PageModel
    {
        private readonly IRepositoryApp<CommonQuestion> _commonQuestion;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;


        public CreateModel(
         IRepositoryApp<CommonQuestion> commonQuestion,
         IMapper mapper,
         CulutureServices lang,
                         IAuthorizationService authorizationService,

         MessageResult MessageResult 

       )

        {
            _commonQuestion = commonQuestion;
            _mapper = mapper;
            _lang = lang;
            _messageResult = MessageResult;
            AuthorizationService = authorizationService;


        }
        [BindProperty]
        public CommonQuestionDtoGet commonQuestion { get; set; }

        public string lang { get; set; }
        public void OnGet()
        {
            lang = _lang.GetCulture();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                #region remove in production
                var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
                if (policyCheck.Succeeded)
                    return _messageResult.failureResultSave("You do not have permission");
                #endregion
                var CommonQuestionResult = _mapper.Map<CommonQuestion> (commonQuestion);
                _commonQuestion.Add(CommonQuestionResult);
                var result = await _commonQuestion.SaveAllAsync();
                return (result) ? _messageResult.SucessResultSave() : _messageResult.failureResultSave();
            }
            else
                return _messageResult.failureResultField();
        }





    }
}
