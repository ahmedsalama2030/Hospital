#pragma checksum "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37d9a7cf16856dade87c8e24b723187103ef9f1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Home_Components_Sliders_Default), @"mvc.1.0.view", @"/Pages/Home/Components/Sliders/Default.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Web.Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Builder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Web.helpers.tageHelper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Core.Dtos_User.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Core.Dtos_User.Doctor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Core.Dtos_User.hospital;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Core.Dtos_User.Sliders;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Core.Dtos_User.ContactUs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Web.helpers.pagination;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\projects\Hospital\Web\Pages\_ViewImports.cshtml"
using Infrastructure.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37d9a7cf16856dade87c8e24b723187103ef9f1e", @"/Pages/Home/Components/Sliders/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c09a557a2d1ada9b6bb35fac99d90af34696451f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Home_Components_Sliders_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SliderDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml"
  
    var slideCount = 1;
    var culture = CulutureServices.GetCulture();   //  get culture name from  services
 

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"slides\">\r\n");
#nullable restore
#line 7 "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml"
     foreach (var slider in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 233, "\"", 284, 3);
            WriteAttributeValue("", 241, "slide", 241, 5, true);
#nullable restore
#line 9 "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml"
WriteAttributeValue(" ", 246, slideCount++ == 1 ? "active" : "", 247, 36, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 283, "", 284, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-url=\"");
#nullable restore
#line 9 "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml"
                                                                      Write(Url.Content("~/" + slider.Path));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <div></div>\r\n            <div  class=\"  animate introduction\" data-animate=\"zoomIn\"  >\r\n                <h3> ");
#nullable restore
#line 12 "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml"
                 Write(culture == "en" ? slider.Title : slider.TitleAr);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </h3>\r\n                <p>\r\n                    ");
#nullable restore
#line 14 "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml"
                Write(culture == "en" ? slider.Text : slider.TextAr);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 18 "D:\projects\Hospital\Web\Pages\Home\Components\Sliders\Default.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    \r\n    </section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CulutureServices CulutureServices { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<Resource> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SliderDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
