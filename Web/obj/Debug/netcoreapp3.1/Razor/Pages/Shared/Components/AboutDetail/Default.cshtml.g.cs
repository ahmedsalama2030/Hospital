#pragma checksum "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd6e67745238d20e9e182270fd529a7a25e52d08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared_Components_AboutDetail_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/AboutDetail/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd6e67745238d20e9e182270fd529a7a25e52d08", @"/Pages/Shared/Components/AboutDetail/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c09a557a2d1ada9b6bb35fac99d90af34696451f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_AboutDetail_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContactUsDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml"
   
    var culture = CulutureServices.GetCulture();   //  get culture name from  services

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"detail\">\r\n    <h2>");
#nullable restore
#line 6 "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml"
   Write(Localizer["contactdetails"].Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <p>  ");
#nullable restore
#line 7 "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml"
     Write(culture == "en"? Model.AboutUs : Model.AboutUsAr);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n    <ul>\r\n        <li>\r\n            <i class=\"fas fa-map-marker-alt\"></i>\r\n            <span>");
#nullable restore
#line 11 "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml"
              Write(culture == "en"? Model.Address : Model.AddressAr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </li>\r\n        <li>\r\n            <i class=\"fas fa-phone-alt \"></i>\r\n            <span>");
#nullable restore
#line 15 "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml"
             Write(Model.PhoneNumbermain);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </li>\r\n        <li>\r\n            <i class=\"fas fa-envelope\"></i>\r\n            <span>");
#nullable restore
#line 19 "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml"
             Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </li>\r\n    </ul>\r\n\r\n    <iframe");
            BeginWriteAttribute("src", " src=\"", 686, "\"", 719, 1);
#nullable restore
#line 23 "D:\projects\Hospital\Web\Pages\Shared\Components\AboutDetail\Default.cshtml"
WriteAttributeValue("", 692, Url.Content(Model.MapPath), 692, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"100%\" height=\"350\" style=\"border:0;\"");
            BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 764, "\"", 782, 0);
            EndWriteAttribute();
            WriteLiteral(" loading=\"lazy\"></iframe>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactUsDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
