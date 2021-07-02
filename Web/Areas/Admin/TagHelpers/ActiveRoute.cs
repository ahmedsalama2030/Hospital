using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
 
 
namespace Web.Areas.Admin.TagHelpers
{
    [HtmlTargetElement(Attributes = "is-active")]
    public class ActiveRoute: TagHelper
    {
        [HtmlAttributeName("asp-page")]
        public string Page { get; set; }
        public string pageName { get; set; }
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            pageName = ViewContext.RouteData.Values["page"].ToString();
            var result = (Page.ToString() == pageName.ToString());
            output.Attributes.SetAttribute("class", result ? "nav-link active" : "nav-link");
         }
        }
}
