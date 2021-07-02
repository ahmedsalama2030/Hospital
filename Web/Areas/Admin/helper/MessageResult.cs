using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Resources;

namespace Web.Areas.Admin.helper
{
    public class MessageResult
    {

        private readonly IStringLocalizer<Resource> _localizer;
        public MessageResult(IStringLocalizer<Resource> Localizer)

        {
            _localizer = Localizer;

        }
        public JsonResult SucessResultSave()
        {
            return new JsonResult(new { code = 200, data = _localizer["succss save"].Value });

        }
        public JsonResult SucessResultSaveUrl(string url)
        {
            return new JsonResult(new {  url= url, data = _localizer["login sucessfully"].Value });

        }
        public JsonResult SucessResultDelete(string id)
        {
            return new JsonResult(new { code = 200, data = _localizer["succss save"].Value ,id= id });

        }
        public JsonResult failureResultField()
        {
            return new JsonResult(new { code = 400, data = _localizer["some field error"].Value });

        }
        public JsonResult failureResultSave()
        {
            return new JsonResult(new { code = 400, data = _localizer["error save"].Value });

        }
        public JsonResult failureResultSave(string msg)
        {
            return new JsonResult(new { code = 400, data = _localizer[msg].Value });

        }
        public JsonResult failureRoleSave()
        {
            return new JsonResult(new { code = 400, data = _localizer["user add but error role save "].Value });

        }
        public JsonResult failureRoleSave(string msg)
        {
            return new JsonResult(new { code = 400, data = _localizer[msg].Value });

        }
        public JsonResult NoChanges()
        {
            return new JsonResult(new { code = 400, data = _localizer["no changes"].Value });

        }
        public JsonResult SaveChanges(bool state)
        {
            return state ? SucessResultSave() : failureResultSave();

        }
        public JsonResult failureResultStateChange()
        {
            return new JsonResult(new { code = 400, data = _localizer["no update found"].Value });

        }
        public JsonResult failureIdNotFound()
        {
            return new JsonResult(new { code = 400, data = _localizer["id not found"].Value });

        }
    }
}
