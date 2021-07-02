using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class News : BaseEntity
    {
        public string MainPhoto { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        public ICollection<NewsImage> NewsImages { get; set; }

    }
}
