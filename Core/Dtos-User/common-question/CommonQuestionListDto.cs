using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos_User.common_question
{
    public class CommonQuestionListDto : BaseEntity
    {
        public string Title { get; set; }

        public string TitleAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
    }
}
