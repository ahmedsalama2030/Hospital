using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.helper
{
    public static class DeleteImageDisk
    {
        public static bool DeleteImageOnDisk(this string  paths, IWebHostEnvironment _ihostingEnvironment)
        {
           
                var path = Path.Combine(_ihostingEnvironment.WebRootPath, paths);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else
                    return false;
            
            return true;
        }
    }
}
