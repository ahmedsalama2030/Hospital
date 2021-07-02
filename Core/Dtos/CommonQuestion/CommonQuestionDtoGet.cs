using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.CommonQuestion
{
   public  class CommonQuestionDtoGet : BaseEntity
    {
        [Required(ErrorMessage = "field-required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string TitleAr { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string description { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string descriptionAr { get; set; }
    }
}
