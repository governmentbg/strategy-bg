#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82cc03cec05c9e43a6c1aea1440bd43da689ac4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UserMessages), @"mvc.1.0.view", @"/Views/Shared/_UserMessages.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_UserMessages.cshtml", typeof(AspNetCore.Views_Shared__UserMessages))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82cc03cec05c9e43a6c1aea1440bd43da689ac4d", @"/Views/Shared/_UserMessages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UserMessages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(15, 31, true);
            WriteLiteral("\r\n<div id=\"messageContainer\">\r\n");
            EndContext();
#line 4 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
     if (TempData[GlobalConstants.UserMessages.Danger] != null)
    {

#line default
#line hidden
            BeginContext(118, 294, true);
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-sm-12"">
                <div class=""alert alert-danger no-margin-bottom"">
                    <button data-dismiss=""alert"" class=""close"">×</button>
                    <i class=""glyphicon glyphicon-ban-circle""></i>
                    ");
            EndContext();
            BeginContext(413, 55, false);
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
               Write(Html.Raw(TempData[GlobalConstants.UserMessages.Danger]));

#line default
#line hidden
            EndContext();
            BeginContext(468, 62, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
    }

#line default
#line hidden
            BeginContext(537, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
     if (TempData[GlobalConstants.UserMessages.Warning] != null)
    {

#line default
#line hidden
            BeginContext(612, 297, true);
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-sm-12"">
                <div class=""alert alert-warning no-margin-bottom"">
                    <button data-dismiss=""alert"" class=""close"">×</button>
                    <i class=""glyphicon glyphicon-warning-sign""></i>
                    ");
            EndContext();
            BeginContext(910, 56, false);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
               Write(Html.Raw(TempData[GlobalConstants.UserMessages.Warning]));

#line default
#line hidden
            EndContext();
            BeginContext(966, 62, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
    }

#line default
#line hidden
            BeginContext(1035, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
     if (TempData[GlobalConstants.UserMessages.Success] != null)
    {

#line default
#line hidden
            BeginContext(1110, 290, true);
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-sm-12"">
                <div class=""alert alert-success no-margin-bottom"">
                    <button data-dismiss=""alert"" class=""close"">×</button>
                    <i class=""glyphicon glyphicon-check""></i>
                    ");
            EndContext();
            BeginContext(1401, 56, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
               Write(Html.Raw(TempData[GlobalConstants.UserMessages.Success]));

#line default
#line hidden
            EndContext();
            BeginContext(1457, 62, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 41 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_UserMessages.cshtml"
    }

#line default
#line hidden
            BeginContext(1526, 8, true);
            WriteLiteral("</div>\r\n");
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
