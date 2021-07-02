using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.helper
{
    public static  class MCollections<T> where T:class
    {
     public static ICollection<T> AddRange(  ICollection<T> source,   ICollection<T> destination)
        {
            foreach (var item in destination)
            {
                source.Add(item);
            }
            return source;
        }
    }
}
