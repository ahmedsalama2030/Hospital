using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.helper
{
    public static  class StringExtensions
    {
        public static  string ToCapitalize(this string data) { 
            // Check for empty string.
        if (string.IsNullOrEmpty(data))
        {
            return string.Empty;
        }
        // Return char and concat substring.
        return char.ToUpper(data[0]) + data.Substring(1);

        }
    }
}
