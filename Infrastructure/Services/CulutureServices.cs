using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infrastructure.Services
{
    public class CulutureServices
    {
        public string GetCulture()
        {
            var Culture = CultureInfo.CurrentUICulture.Name;
            if (string.IsNullOrEmpty(Culture))
                return "en";
             return Culture;
        }
    }
}
