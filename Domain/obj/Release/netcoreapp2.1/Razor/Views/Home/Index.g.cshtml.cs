#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09a50fd5b9f0263de026effaef426f9e28aae5c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Domain;

#line default
#line hidden
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels;

#line default
#line hidden
#line 4 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels.Account;

#line default
#line hidden
#line 5 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels.Portal;

#line default
#line hidden
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels.MulticriteriaAnalysis;

#line default
#line hidden
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using WebCommon.TagHelpers;

#line default
#line hidden
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using WebCommon.Models;

#line default
#line hidden
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.Context;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09a50fd5b9f0263de026effaef426f9e28aae5c9", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a9a60c20537480d66fd9d2d41d1eec08c8ef00", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
  
    Layout = "~/Views/Shared/_LayoutPublicMain.cshtml";

#line default
#line hidden
            DefineSection("head", async() => {
                BeginContext(78, 124, true);
                WriteLiteral("\r\n    <style>\r\n        .section .image img {\r\n            width: auto;\r\n            height: auto;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(205, 1689, true);
            WriteLiteral(@"<!-- IMAGES  -->
<div class=""image__wrapper--swiper"">
    <div class=""swiper-container"">
        <div class=""swiper-wrapper"">
            <!-- LOOP -->
            <div class=""head__image swiper-slide"">
                <div class=""image__wrapper""
                     style=""background-image:url(dist/assets/123.png)"">
                </div>
                <div class=""title__wrapper"">
                    <div class=""logo"">
                        <img src=""dist/assets/Coat_of_arms_of_Bulgaria.svg"" alt=""Герб"" />
                    </div>
                    <div class=""title"">
                        <h3>ПАРТНЬОРСТВО В УПРАВЛЕНИЕТО</h3>
                    </div>
                </div>
            </div>
            <!-- END LOOP -->
            <div class=""head__image swiper-slide"">
                <div class=""image__wrapper""
                     style=""background-image:url(dist/assets/123.png)"">
                </div>
                <div class=""title__wrapper"">
                    <d");
            WriteLiteral(@"iv class=""logo"">
                        <img src=""dist/assets/Coat_of_arms_of_Bulgaria.svg"" alt=""Герб"" />
                    </div>
                    <div class=""title"">
                        <h3>СТРАТЕГИЧЕСКИ ДОКУМЕНТИ</h3>
                    </div>
                </div>
            </div>
        </div>
        <!-- Add Arrows -->
        <div class=""swiper-button-next swiper-button-white""></div>
        <div class=""swiper-button-prev swiper-button-white""></div>
    </div>
</div>
<!-- END IMAGES  -->


<section class=""section__wrapper"">
    <div class=""row"">
        <div class=""section col-lg-3 col-md-6 col-sm-12"">
            ");
            EndContext();
            BeginContext(1895, 78, false);
#line 56 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("PublicConsultationWidget", new { loadCount = 5 }));

#line default
#line hidden
            EndContext();
            BeginContext(1973, 89, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"section col-lg-3 col-md-6 col-sm-12\">\r\n            ");
            EndContext();
            BeginContext(2063, 78, false);
#line 59 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("StrategicDocumentsWidget", new { loadCount = 5 }));

#line default
#line hidden
            EndContext();
            BeginContext(2141, 89, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"section col-lg-3 col-md-6 col-sm-12\">\r\n            ");
            EndContext();
            BeginContext(2231, 89, false);
#line 62 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("ArticleWidget", new { view = "Publication", loadCount = 5 }));

#line default
#line hidden
            EndContext();
            BeginContext(2320, 89, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"section col-lg-3 col-md-6 col-sm-12\">\r\n            ");
            EndContext();
            BeginContext(2410, 82, false);
#line 65 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("ArticleWidget", new { view = "News", loadCount = 5 }));

#line default
#line hidden
            EndContext();
            BeginContext(2492, 248, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>\r\n<section class=\"section__wrapper\" style=\"width:100%\">\r\n    <div class=\"row\">\r\n        <div class=\"section col-lg-3 col-md-6 col-sm-12\">\r\n            <p class=\"type\">ОЦЕНКА НА ВЪЗДЕЙСТВИЕТО</p>\r\n            ");
            EndContext();
            BeginContext(2741, 95, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
       Write(await Component.InvokeAsync("MasterPage", new { pageTypeId = GlobalConstants.PageTypes.Pages }));

#line default
#line hidden
            EndContext();
            BeginContext(2836, 77, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"section col-lg-3 col-md-6 col-sm-12\">\r\n");
            EndContext();
            BeginContext(3018, 89, true);
            WriteLiteral("        </div>\r\n        <div class=\"section col-lg-3 col-md-6 col-sm-12\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3107, "\"", 3176, 1);
#line 79 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
WriteAttributeValue("", 3114, Url.Action("ListPCSubjects", "PCSubjects", new { area = "" }), 3114, 62, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3177, 119, true);
            WriteLiteral(">СПИСЪК НА ЛИЦАТА ПО ЗНА</a>\r\n        </div>\r\n        <div class=\"section col-lg-3 col-md-6 col-sm-12\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3296, "\"", 3375, 1);
#line 82 "C:\Projects\Strategy\newSingleSite\Domain\Views\Home\Index.cshtml"
WriteAttributeValue("", 3303, Url.Action("ListChangeProposals", "ChangeProposals", new { area = "" }), 3303, 72, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3376, 75, true);
            WriteLiteral(">ЗАКОНОДАТЕЛНИ ИНИЦИАТИВИ</a>\r\n        </div>\r\n\r\n    </div>\r\n</section>\r\n\r\n");
            EndContext();
            BeginContext(5421, 60, true);
            WriteLiteral("\r\n<div class=\"spacer\"></div>\r\n<!-- END ARTICLES & NEWS -->\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591