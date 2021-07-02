using Microsoft.AspNetCore.Http;
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Web.Areas.Admin.helper
{
    public class RequestQuery
    {
        public int length { get; set; }
        public int start { get; set; }
        public int draw { get; set; }
        public int sortColumnId { get; set; }
        public string sortColumnName { get; set; }
        public string sortDirection { get; set; }
        public string filterType { get; set; }
        public string filterText { get; set; }

      
    }
}
