using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.Areas.Admin.TagHelpers
{

    [HtmlTargetElement(Attributes = "is-open")]
    public class OpenMenu : TagHelper
    {
        [HtmlAttributeName("open")]
        public string open { get; set; }
        public string pageName { get; set; }
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            pageName = ViewContext.RouteData.Values["page"].ToString();
            var pagecustom = pageName.Split("/")[1].ToLower();
            var result = (pagecustom.Equals(open.ToLower()));
            output.Attributes.SetAttribute("class", result ? "nav-item menu-is-opening menu-open" : "nav-item");
        }
    }
}