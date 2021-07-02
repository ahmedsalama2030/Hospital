using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos.News
{
    public class NewsImageGet : BaseEntity
    {
        public string Path { get; set; }
        public bool isMain { get; set; }
        public Guid NewsId { get; set; }
     }
}
