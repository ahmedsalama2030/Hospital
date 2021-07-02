using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class NewsImage: BaseEntity
    {
 
        public string Path { get; set; }
        public bool isMain { get; set; }
        public Guid NewsId { get; set; }
        public News News { get; set; }
    }
}
