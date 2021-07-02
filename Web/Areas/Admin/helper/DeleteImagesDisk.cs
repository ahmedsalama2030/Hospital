using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.helper
{
    public static class DeleteImagesDisk
    {
        public static bool DeleteImagesOnDisk(this string[] paths, IWebHostEnvironment _ihostingEnvironment)
        {
            foreach (var pathNew in paths)
            {
                var path = Path.Combine(_ihostingEnvironment.WebRootPath, pathNew);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else
                    return false;
            }
            return true;
        }
    }
}
