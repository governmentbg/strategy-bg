#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "176663f1bfb3e14e21cae18fcb3e1e6e0f27536c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StrategicDocument__PdfExport), @"mvc.1.0.view", @"/Views/StrategicDocument/_PdfExport.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/StrategicDocument/_PdfExport.cshtml", typeof(AspNetCore.Views_StrategicDocument__PdfExport))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"176663f1bfb3e14e21cae18fcb3e1e6e0f27536c", @"/Views/StrategicDocument/_PdfExport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_StrategicDocument__PdfExport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModels.Portal.StrategicDocumentPDFVM>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(83, 35, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            EndContext();
            BeginContext(118, 893, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cf28d6e3f7347d8984b43828f5bb3c7", async() => {
                BeginContext(124, 880, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <style>
        body {
            font-family: ""Verdana"";
            color: #4a4a4a;
        }

        a {
            text-decoration: none;           
        }

        .catTitle {
            font-size: 1.2em;
            font-style: italic;
        }

        table {
            border: none;
            padding: 5px;
            width:100%;
        }

            table .col1 {
                width: 5%;
                padding-right: 10px;
                text-align: right;
            }

            table .col2 {
                width: 70%;
            }
            table .col2.file {
                padding-left:20px;
            }

            table .col3 {
                width: 25%;
            }
            table tr.link {
                color:#548aad
            }
    </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1011, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1013, 1341, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d39e045b74e148b19cc2e3eae8501a48", async() => {
                BeginContext(1019, 10, true);
                WriteLiteral("\r\n    <h2>");
                EndContext();
                BeginContext(1030, 11, false);
#line 52 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
   Write(Model.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1041, 7, true);
                WriteLiteral("</h2>\r\n");
                EndContext();
#line 53 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
     foreach (var cat in Model.CategoryRows.Where(x => x.LinkRows.Any()))
    {
        int i = 0;

#line default
#line hidden
                BeginContext(1150, 42, true);
                WriteLiteral("        <div class=\"catTitle\">Категория : ");
                EndContext();
                BeginContext(1193, 9, false);
#line 56 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                     Write(cat.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1202, 25, true);
                WriteLiteral("</div>\r\n        <table>\r\n");
                EndContext();
#line 58 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
             foreach (var doc in cat.LinkRows)
            {
                i++;

#line default
#line hidden
                BeginContext(1312, 72, true);
                WriteLiteral("                <tr class=\"link\">\r\n                    <td class=\"col1\">");
                EndContext();
                BeginContext(1385, 1, false);
#line 62 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(1386, 46, true);
                WriteLiteral("</td>\r\n                    <td class=\"col2\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1432, "\"", 1503, 1);
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
WriteAttributeValue("", 1439, Url.Action("View","StrategicDocument",new { area="",id=doc.Id}), 1439, 64, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1504, 2, true);
                WriteLiteral("> ");
                EndContext();
                BeginContext(1507, 9, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                                                                                            Write(doc.Title);

#line default
#line hidden
                EndContext();
                BeginContext(1516, 61, true);
                WriteLiteral("</a></td>\r\n                    <td class=\"col3\">валиден до : ");
                EndContext();
                BeginContext(1579, 79, false);
#line 64 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                              Write(doc.ValidTo.Year >= 2100 ? "Не е указан срок" : doc.ValidTo.ToString("yyyy г."));

#line default
#line hidden
                EndContext();
                BeginContext(1659, 30, true);
                WriteLiteral("</td>\r\n                </tr>\r\n");
                EndContext();
#line 66 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                if (doc.Files != null)
                {
                    foreach (var docFile in doc.Files)
                    {
                        i++;

#line default
#line hidden
                BeginContext(1857, 76, true);
                WriteLiteral("                        <tr >\r\n                            <td class=\"col1\">");
                EndContext();
                BeginContext(1934, 1, false);
#line 72 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                        Write(i);

#line default
#line hidden
                EndContext();
                BeginContext(1935, 52, true);
                WriteLiteral("</td>\r\n                            <td class=\"col2\">");
                EndContext();
                BeginContext(1988, 13, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                        Write(docFile.Title);

#line default
#line hidden
                EndContext();
                BeginContext(2001, 66, true);
                WriteLiteral(" </td>\r\n                            <td class=\"col3\">валиден до : ");
                EndContext();
                BeginContext(2069, 87, false);
#line 74 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                                      Write(docFile.ValidTo.Year >= 2100 ? "Не е указан срок" : docFile.ValidTo.ToString("yyyy г."));

#line default
#line hidden
                EndContext();
                BeginContext(2157, 38, true);
                WriteLiteral("</td>\r\n                        </tr>\r\n");
                EndContext();
#line 76 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                    }
                }
            }

#line default
#line hidden
                BeginContext(2252, 18, true);
                WriteLiteral("        </table>\r\n");
                EndContext();
#line 80 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
    }

#line default
#line hidden
                BeginContext(2277, 42, true);
                WriteLiteral("    <h3>Брой на документите в справката : ");
                EndContext();
                BeginContext(2320, 20, false);
#line 81 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\_PdfExport.cshtml"
                                     Write(Model.DocumentsCount);

#line default
#line hidden
                EndContext();
                BeginContext(2340, 7, true);
                WriteLiteral("</h3>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2354, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModels.Portal.StrategicDocumentPDFVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
