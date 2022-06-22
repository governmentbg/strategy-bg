#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98e29d8820d2089e730cb3c9ffb4ce8666b446e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ogp__Plan), @"mvc.1.0.view", @"/Views/Ogp/_Plan.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ogp/_Plan.cshtml", typeof(AspNetCore.Views_Ogp__Plan))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml"
using Models.ViewModels.Ogp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98e29d8820d2089e730cb3c9ffb4ce8666b446e9", @"/Views/Ogp/_Plan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Ogp__Plan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IQueryable<PlanItemVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml"
  
    var title = (string)ViewData["plan_title"];
    var state = (int)ViewData["plan_state"];

#line default
#line hidden
            BeginContext(163, 63, true);
            WriteLiteral("\r\n<div class=\"strat-container\">\r\n    <div class=\"strat--title\">");
            EndContext();
            BeginContext(227, 5, false);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml"
                         Write(title);

#line default
#line hidden
            EndContext();
            BeginContext(232, 143, true);
            WriteLiteral("</div>\r\n    <div class=\"strat--body\">\r\n\r\n\r\n        <table class=\"table table-bordered table--documents table--stripped\">\r\n            <tbody>\r\n");
            EndContext();
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml"
                 foreach (var plan in Model.Where(x => x.StateId == state))
                {
                    var urlView = Url.Action("Element", new { id = plan.Id });

#line default
#line hidden
            BeginContext(551, 86, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 637, "\"", 652, 1);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml"
WriteAttributeValue("", 644, urlView, 644, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(653, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(655, 20, false);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml"
                                          Write(Html.Raw(plan.Title));

#line default
#line hidden
            EndContext();
            BeginContext(675, 88, true);
            WriteLiteral("</a>\r\n                        </td>                        \r\n                    </tr>\r\n");
            EndContext();
#line 23 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\_Plan.cshtml"
                }

#line default
#line hidden
            BeginContext(782, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IQueryable<PlanItemVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591