#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc16e7119a6cb9bd2d384a54d6c154f1172e1684"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__DocumentExport), @"mvc.1.0.view", @"/Views/Shared/_DocumentExport.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_DocumentExport.cshtml", typeof(AspNetCore.Views_Shared__DocumentExport))]
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
#line 4 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
using Domain.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc16e7119a6cb9bd2d384a54d6c154f1172e1684", @"/Views/Shared/_DocumentExport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__DocumentExport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DocumentExportViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
  Layout = "~/Views/Shared/_ExportLayout.cshtml";

#line default
#line hidden
            BeginContext(116, 103, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-5 col-lg-6 body\">\r\n            <h2>\r\n                ");
            EndContext();
            BeginContext(220, 33, false);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
           Write(Html.Raw(Model.ConsultationTitle));

#line default
#line hidden
            EndContext();
            BeginContext(253, 23, true);
            WriteLiteral("\r\n            </h2>\r\n\r\n");
            EndContext();
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
             foreach (var version in Model.Versions)
            {

#line default
#line hidden
            BeginContext(345, 20, true);
            WriteLiteral("                <h3>");
            EndContext();
            BeginContext(400, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(402, 21, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                                   Write(version.DocumentTitle);

#line default
#line hidden
            EndContext();
            BeginContext(423, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                 if (version.AttachedFiles.Any())
                {

#line default
#line hidden
            BeginContext(500, 292, true);
            WriteLiteral(@"                    <div class=""title"">Прикачени файлове</div>
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <table class=""table table-bordered table--documents table--stripped"">
                                <tbody>
");
            EndContext();
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                     foreach (var item in version.AttachedFiles)
                                    {


#line default
#line hidden
            BeginContext(915, 220, true);
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <div class=\"icon\">\r\n                                                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1135, "\"", 1179, 1);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
WriteAttributeValue("", 1141, item.FileName.GetFileExtensionImage(), 1141, 38, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1180, 215, true);
            WriteLiteral(" alt=\"\">\r\n                                                </div>\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            EndContext();
            BeginContext(1396, 24, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                           Write(Html.Raw(item.FileTitle));

#line default
#line hidden
            EndContext();
            BeginContext(1420, 100, true);
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>\r\n");
            EndContext();
#line 34 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"

                                    }

#line default
#line hidden
            BeginContext(1561, 140, true);
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 40 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                }

#line default
#line hidden
            BeginContext(1722, 68, true);
            WriteLiteral("                <div class=\"row  comments\" id=\"commentsContainer\">\r\n");
            EndContext();
#line 43 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                     if (version.Comments.Any())
                    {

#line default
#line hidden
            BeginContext(1863, 153, true);
            WriteLiteral("                        <div class=\"col-md-12 comment\">\r\n                            <div class=\"title\">Коментари</div>\r\n                        </div>\r\n");
            EndContext();
#line 48 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                         foreach (var item in version.Comments)
                        {

#line default
#line hidden
            BeginContext(2108, 97, true);
            WriteLiteral("                            <div class=\"col-md-12 comment\">\r\n                                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2205, "\"", 2271, 2);
            WriteAttributeValue("", 2213, "panel", 2213, 5, true);
#line 51 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
WriteAttributeValue(" ", 2218, item.TookIntoConsideration ? "panel-success" : "", 2219, 52, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2272, 132, true);
            WriteLiteral(">\r\n                                    <div class=\"panel-heading\">\r\n                                        <h3 class=\"panel-title\">");
            EndContext();
            BeginContext(2405, 10, false);
#line 53 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                                           Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2415, 51, true);
            WriteLiteral("</h3>\r\n                                    </div>\r\n");
            EndContext();
#line 55 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                     if (!String.IsNullOrEmpty(item.PageTag))
                                    {

#line default
#line hidden
            BeginContext(2584, 131, true);
            WriteLiteral("                                        <div class=\"panel-body\">\r\n                                            <strong>Към</strong> ");
            EndContext();
            BeginContext(2716, 12, false);
#line 58 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                                            Write(item.PageTag);

#line default
#line hidden
            EndContext();
            BeginContext(2728, 50, true);
            WriteLiteral("\r\n                                        </div>\r\n");
            EndContext();
#line 60 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                    }

#line default
#line hidden
            BeginContext(2817, 62, true);
            WriteLiteral("\r\n                                    <div class=\"panel-body\">");
            EndContext();
            BeginContext(2880, 19, false);
#line 62 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                                       Write(Html.Raw(item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(2899, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                     if (!String.IsNullOrEmpty(item.TookIntoConsiderationReason))
                                    {

#line default
#line hidden
            BeginContext(3045, 114, true);
            WriteLiteral("                                        <div class=\"panel-body\">\r\n                                            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 3159, "\"", 3229, 1);
#line 66 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
WriteAttributeValue("", 3167, item.TookIntoConsideration ? "text-success" : "text-danger", 3167, 62, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3230, 61, true);
            WriteLiteral(">\r\n                                                Коментара ");
            EndContext();
            BeginContext(3293, 41, false);
#line 67 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                                      Write(item.TookIntoConsideration ? "е" : "не е");

#line default
#line hidden
            EndContext();
            BeginContext(3335, 163, true);
            WriteLiteral(" взет под внимание <i class=\"fa fa-arrow-circle-o-down\"></i>\r\n                                            </div>\r\n                                            <div>");
            EndContext();
            BeginContext(3499, 32, false);
#line 69 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                            Write(item.TookIntoConsiderationReason);

#line default
#line hidden
            EndContext();
            BeginContext(3531, 56, true);
            WriteLiteral("</div>\r\n                                        </div>\r\n");
            EndContext();
#line 71 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                    }

#line default
#line hidden
            BeginContext(3626, 123, true);
            WriteLiteral("                                    <div class=\"panel-footer\">\r\n                                        <span class=\"name\">");
            EndContext();
            BeginContext(3750, 13, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                                      Write(item.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(3763, 8, true);
            WriteLiteral("</span> ");
            EndContext();
            BeginContext(3772, 44, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                                                                            Write(item.Publish.ToString("dd.MM.yyyy HH:mm:ss"));

#line default
#line hidden
            EndContext();
            BeginContext(3816, 122, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
            EndContext();
#line 77 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                        }

#line default
#line hidden
#line 77 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
                         

                    }

#line default
#line hidden
            BeginContext(3990, 24, true);
            WriteLiteral("                </div>\r\n");
            EndContext();
#line 81 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_DocumentExport.cshtml"
            }

#line default
#line hidden
            BeginContext(4029, 26, true);
            WriteLiteral("        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DocumentExportViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
