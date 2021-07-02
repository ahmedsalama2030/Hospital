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
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Admin.helper;

namespace Web.Areas.Admin.Pages.CommonQuestions
{
    [Authorize(Policy = "AllowUserAdmin")]
    public class EditModel : PageModel
    {
        private readonly IRepositoryApp<CommonQuestion> _commonQuestion;
        private readonly IMapper _mapper;
        private readonly CulutureServices _lang;
        private readonly MessageResult _messageResult;
        private readonly IAuthorizationService AuthorizationService;


        public EditModel(
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
        public void OnGet(Guid Id)
        {
            lang = _lang.GetCulture();
            var commonQuestionGet = HttpContext.Items["entity"] as CommonQuestion;
            commonQuestion = _mapper.Map<CommonQuestionDtoGet>(commonQuestionGet);

        }
        public async Task<IActionResult> OnPostAsync(Guid Id)
        {
            #region remove in production
            var policyCheck = await AuthorizationService.AuthorizeAsync(User, "user");
            if (policyCheck.Succeeded)
                return _messageResult.failureResultSave("You do not have permission");
            #endregion
            if (Id != commonQuestion.Id)
                return _messageResult.failureResultSave();
            var question = HttpContext.Items["entity"] as CommonQuestion;
            question = _mapper.Map(commonQuestion, question);
            return (_commonQuestion.checkState(question, "Modified")) ? _messageResult.SaveChanges(await _commonQuestion.SaveAllAsync()) : _messageResult.failureResultStateChange();

        }

        public async override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                     PageHandlerExecutionDelegate next)

        {
            if (!context.ModelState.IsValid)
            {
                context.Result = _messageResult.failureResultField();
                return;
            }
            Guid Id = Guid.Empty;
            Id = Guid.Parse(context.HttpContext.Request.RouteValues["id"].ToString());
            var entity = await _commonQuestion.SingleOrDefaultAsync(a=>a.Id==Id);
            if (entity == null)
            {
                context.Result = Redirect("/Error");
                return;
            }
            context.HttpContext.Items.Add("entity", entity);
            await next.Invoke();
        }


    }
}
