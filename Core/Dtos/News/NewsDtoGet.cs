using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.News
{
    public  class NewsDtoGet: BaseEntity
    {
        [Required(ErrorMessage = "Please enter this filed")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter this filed")]
        public string TitleAr { get; set; }
        [Required(ErrorMessage = "Please enter this filed")]
        public string description { get; set; }
        [Required(ErrorMessage = "Please enter this filed")]
        public string descriptionAr { get; set; }
        public IEnumerable<NewsImageGet> NewsImages { get; set; }

    }
}
