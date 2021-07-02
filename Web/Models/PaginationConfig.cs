using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.helpers.pagination;

namespace Web.Models
{
    public class PaginationConfig
    {
        public PaginationHeader paginationHeader { get; set; }
        public string Url { get; set; }
        public int LengthPage { get; set; }
        public bool ShowInfo { get; set; }
     }
}
