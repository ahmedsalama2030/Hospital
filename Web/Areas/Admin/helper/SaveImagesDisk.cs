using Core.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.helper
{
    public static  class SaveImagesDisk
    {
          public static async Task <List<ImagesPath> > SaveImagesOnDisk(this IFormFileCollection photos, IWebHostEnvironment _ihostingEnvironment, string folder)
        {
             List<ImagesPath> newPaths = new List<ImagesPath>();

            if (photos != null && photos.Count > 0)
            {
                foreach (IFormFile photo in photos)
                {
                     var newPath = _ihostingEnvironment.WebRootPath + "\\imageUpload\\" + folder;
                    if (!(Directory.Exists(newPath)))
                        Directory.CreateDirectory(newPath);
                    var name = Path.GetRandomFileName() + Path.GetExtension(photo.FileName);
                    var path = Path.Combine(newPath, name).ToLower();
                    var stream = new FileStream(path, FileMode.Create);
                     await photo.CopyToAsync(stream);
                   await stream.DisposeAsync();
                    newPaths.Add(new ImagesPath { Path = "imageUpload/" + folder + "/" + name });
                }
            }
            return  await Task.FromResult( newPaths);
        }
    
    public static async Task<ImagesPath> SaveImageOnDisk(this IFormFile photo, IWebHostEnvironment _ihostingEnvironment, string folder)
    {
         ImagesPath newPath = null;

        if (photo != null && photo.Length > 0)
        {
            var newPathResult = _ihostingEnvironment.WebRootPath + "\\imageUpload\\" + folder;
            if (!(Directory.Exists(newPathResult)))
                Directory.CreateDirectory(newPathResult);
            var name = Path.GetRandomFileName() + Path.GetExtension(photo.FileName);
            var path = Path.Combine(newPathResult, name).ToLower();
            var stream = new FileStream(path, FileMode.Create);
           await photo.CopyToAsync(stream);
           await stream.DisposeAsync();
            newPath = new ImagesPath { Path = "imageUpload/" + folder + "/" + name };

        }
            return  await Task.FromResult(newPath);
    }
    }
}

 
