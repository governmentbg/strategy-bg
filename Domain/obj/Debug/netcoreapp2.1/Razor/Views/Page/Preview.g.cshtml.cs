#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86639ea35f54cca6b24985107a9777d030d5b2e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Page_Preview), @"mvc.1.0.view", @"/Views/Page/Preview.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Page/Preview.cshtml", typeof(AspNetCore.Views_Page_Preview))]
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
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Domain.Class;

#line default
#line hidden
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86639ea35f54cca6b24985107a9777d030d5b2e5", @"/Views/Page/Preview.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Page_Preview : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Page>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 5 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
     if (Model.PageTypeId == GlobalConstants.PageTypes.OV)
    {
        ViewData["SectionTitle"] = Localizer["SECTION_ASSESSMENT"];
    }
    else
    {
        ViewData["SectionTitle"] = Model.Title;
    }

#line default
#line hidden
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
     

    var breadcrumbs = (IEnumerable<BreadcrumbVM>)ViewBag.breadcrumbs;

    var url = Url.Action("Preview", "Home", new { id = Model.ContentId, url = Model.Url }, (string)ViewBag.httpScheme);
    var parents = (IQueryable<PageVM>)ViewBag.parents;
    var rCol = "col-lg-9";
    if (Model.PageLinks?.Count() > 0)
    {
        rCol = "col-lg-6";
    }

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(713, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 758, "\"", 792, 1);
#line 26 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
WriteAttributeValue("", 765, Url.Action("Index","Home"), 765, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(793, 13, true);
                WriteLiteral(">Начало</a>\r\n");
                EndContext();
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
         foreach (var item in breadcrumbs)
        {

#line default
#line hidden
                BeginContext(861, 42, true);
                WriteLiteral("            <span>/</span>\r\n            <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 903, "\"", 919, 1);
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
WriteAttributeValue("", 910, item.Url, 910, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(920, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(922, 10, false);
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
                           Write(item.Title);

#line default
#line hidden
                EndContext();
                BeginContext(932, 6, true);
                WriteLiteral("</a>\r\n");
                EndContext();
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
        }

#line default
#line hidden
                BeginContext(949, 44, true);
                WriteLiteral("        <span>/</span>\r\n        <a href=\"#\">");
                EndContext();
                BeginContext(994, 11, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
               Write(Model.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1005, 18, true);
                WriteLiteral("</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(1026, 70, true);
            WriteLiteral("\r\n\r\n<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 40 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
         if (Model.PageTypeId == GlobalConstants.PageTypes.OV)
        {

#line default
#line hidden
            BeginContext(1171, 52, true);
            WriteLiteral("            <div class=\"col-lg-3\">\r\n                ");
            EndContext();
            BeginContext(1224, 145, false);
#line 43 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
           Write(await Component.InvokeAsync("MasterPage", new { pageTypeId = GlobalConstants.PageTypes.OV, display = "menu", title = "Оценка на въздействието" }));

#line default
#line hidden
            EndContext();
            BeginContext(1369, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 45 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
        }

#line default
#line hidden
            BeginContext(1402, 14, true);
            WriteLiteral("\r\n        <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1416, "\"", 1429, 1);
#line 47 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
WriteAttributeValue("", 1424, rCol, 1424, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1430, 19, true);
            WriteLiteral(">\r\n            <h3>");
            EndContext();
            BeginContext(1450, 11, false);
#line 48 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1461, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 49 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
             if (!string.IsNullOrEmpty(Model.SubTitle))
            {

#line default
#line hidden
            BeginContext(1540, 20, true);
            WriteLiteral("                <h4>");
            EndContext();
            BeginContext(1561, 14, false);
#line 51 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
               Write(Model.SubTitle);

#line default
#line hidden
            EndContext();
            BeginContext(1575, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
#line 52 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
            }

#line default
#line hidden
            BeginContext(1597, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1610, 23, false);
#line 53 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
       Write(Html.Raw(Model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(1633, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1783, 18, true);
            WriteLiteral("        </div>\r\n\r\n");
            EndContext();
#line 59 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
         if (Model.PageLinks?.Count() > 0)
        {


#line default
#line hidden
            BeginContext(1858, 125, true);
            WriteLiteral("            <div class=\"col-lg-3\">\r\n                <div class=\"aside row\">\r\n                    <ul class=\"list--default\">\r\n");
            EndContext();
#line 65 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
                         foreach (var item in Model.PageLinks)
                        {

#line default
#line hidden
            BeginContext(2074, 68, true);
            WriteLiteral("                            <li>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2142, "\"", 2159, 1);
#line 68 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
WriteAttributeValue("", 2149, item.Href, 2149, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2160, 39, true);
            WriteLiteral(">\r\n                                    ");
            EndContext();
            BeginContext(2200, 10, false);
#line 69 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
                               Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2210, 75, true);
            WriteLiteral("\r\n                                </a>\r\n                            </li>\r\n");
            EndContext();
#line 72 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
                        }

#line default
#line hidden
            BeginContext(2312, 71, true);
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 76 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"

        }

#line default
#line hidden
            BeginContext(2396, 24, true);
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2437, 115, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n        $(\'a[data-modal=\"true\"]\').click(function () {\r\n            var url = \'");
                EndContext();
                BeginContext(2553, 26, false);
#line 86 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
                  Write(Url.Action("ModalPreview"));

#line default
#line hidden
                EndContext();
                BeginContext(2579, 106, true);
                WriteLiteral("\';\r\n            var tag = $(this).data(\'tag\');\r\n            requestContent(url, {\r\n                lang: \'");
                EndContext();
                BeginContext(2686, 10, false);
#line 89 "C:\Projects\Strategy\newSingleSite\Domain\Views\Page\Preview.cshtml"
                  Write(Model.Lang);

#line default
#line hidden
                EndContext();
                BeginContext(2696, 239, true);
                WriteLiteral("\'\r\n                , id: $(this).data(\'contentid\')\r\n            }, function (data) {\r\n                ShowDialog(data.title, data.html, 1);\r\n                location.hash = \"#\" + tag;\r\n            });\r\n        });\r\n    });\r\n    </script>\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<CommonResources> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Page> Html { get; private set; }
    }
}
#pragma warning restore 1591