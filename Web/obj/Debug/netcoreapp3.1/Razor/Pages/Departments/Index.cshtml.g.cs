#pragma checksum "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a769dc0beabb1022fcbf7a6f38a7fe9d96a2adb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Departments_Index), @"mvc.1.0.razor-page", @"/Pages/Departments/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a769dc0beabb1022fcbf7a6f38a7fe9d96a2adb", @"/Pages/Departments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c09a557a2d1ada9b6bb35fac99d90af34696451f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Departments_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_coverPage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
  
    var title = "departments";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8a769dc0beabb1022fcbf7a6f38a7fe9d96a2adb6334", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 6 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = title;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<section class=\"departments organize-section section-settings\">\r\n    <div class=\"container\" id=\"update\">\r\n");
#nullable restore
#line 10 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
         foreach (var hospital in Model.departmets)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"container-box animate\" data-animate=\"zoomIn\">\r\n                <h2><span>");
#nullable restore
#line 13 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
                     Write(Localizer["hospital"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 13 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
                                            Write(hospital.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h2>\r\n                <div class=\"content\">\r\n");
#nullable restore
#line 15 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
                     foreach (var dept in hospital)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"box\">\r\n                            <div class=\"icon\"><i class=\"fas fa-stethoscope\"></i></div>\r\n                            <div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a769dc0beabb1022fcbf7a6f38a7fe9d96a2adb9299", async() => {
                WriteLiteral("\r\n                                    <h3>");
#nullable restore
#line 21 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
                                    Write(Model.lang == "en" ? dept.Name : dept.NameAr);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n                                    <p>");
#nullable restore
#line 22 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
                                   Write(Model.lang == "en" ? dept.description.Substring(1,100)  : dept.descriptionAr.Substring(1, 100)   );

#line default
#line hidden
#nullable disable
                WriteLiteral(" ...</p>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
                                                        WriteLiteral(dept.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div> \r\n");
#nullable restore
#line 26 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 29 "D:\projects\Hospital\Web\Pages\Departments\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web.Pages.Departments.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Web.Pages.Departments.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Web.Pages.Departments.IndexModel>)PageContext?.ViewData;
        public Web.Pages.Departments.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
