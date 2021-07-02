using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
 
 
namespace Web.pages.TagHelpers
{
    [HtmlTargetElement(Attributes = "is-active-user")]
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
            pageName = ViewContext.RouteData.Values["page"].ToString().ToLower();
            Page = Page.ToString().ToLower();
            var result = (Page == pageName);
            output.Attributes.SetAttribute("class", result ? "active" : "");
         }
        }
}
