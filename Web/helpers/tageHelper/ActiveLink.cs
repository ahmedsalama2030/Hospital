

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Web.helpers.tageHelper
{
    public static  class ActiveLink
    {
        public static string IsActive(this IHtmlHelper html,
                                 string control )
        {
            var routeData = html.ViewContext.RouteData;
             var routeControl = (string)routeData.Values["controller"];
             // both must match
             var returnActive = (control == routeControl.ToLower());
             return returnActive ? "active" : "";
        }
    }
}
