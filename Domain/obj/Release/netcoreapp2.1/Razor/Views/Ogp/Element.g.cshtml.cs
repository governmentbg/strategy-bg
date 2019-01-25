#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "966dbd96d0ea137ac462e6d79001d1b6d04c9ea9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ogp_Element), @"mvc.1.0.view", @"/Views/Ogp/Element.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ogp/Element.cshtml", typeof(AspNetCore.Views_Ogp_Element))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
using Models.ViewModels.Ogp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"966dbd96d0ea137ac462e6d79001d1b6d04c9ea9", @"/Views/Ogp/Element.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a9a60c20537480d66fd9d2d41d1eec08c8ef00", @"/Views/_ViewImports.cshtml")]
    public class Views_Ogp_Element : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PlanVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_OgpLeftMenu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
  
    ViewData["SectionTitle"] = Model.Plan.Title;
    var estimations = (IQueryable<EstimationVM>)ViewBag.estimations;

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(193, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 238, "\"", 272, 1);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
WriteAttributeValue("", 245, Url.Action("Index","Home"), 245, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(273, 13, true);
                WriteLiteral(">Начало</a>\r\n");
                EndContext();
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
         if (Model.Parent != null)
        {

#line default
#line hidden
                BeginContext(333, 29, true);
                WriteLiteral("            <span>/</span> <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 362, "\"", 419, 1);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
WriteAttributeValue("", 369, Url.Action("Element",new { id = Model.Parent.Id}), 369, 50, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(420, 19, true);
                WriteLiteral(">\r\n                ");
                EndContext();
                BeginContext(440, 28, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
           Write(Html.Raw(Model.Parent.Title));

#line default
#line hidden
                EndContext();
                BeginContext(468, 20, true);
                WriteLiteral("\r\n            </a>\r\n");
                EndContext();
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
        }

#line default
#line hidden
                BeginContext(499, 12, true);
                WriteLiteral("    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(514, 100, true);
            WriteLiteral("\r\n<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n");
            EndContext();
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
             if (estimations.Any())
            {


#line default
#line hidden
            BeginContext(668, 190, true);
            WriteLiteral("                <div class=\"aside row\">\r\n                    <div class=\"title\">\r\n                        Оценки\r\n                    </div>\r\n                    <ul class=\"list--default\">\r\n");
            EndContext();
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                         foreach (var estimation in estimations)
                        {
                            var urlView = Url.Action("Estimation", new { id = estimation.Id });

#line default
#line hidden
            BeginContext(1048, 68, true);
            WriteLiteral("                            <li>\r\n                                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1116, "\"", 1131, 1);
#line 34 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
WriteAttributeValue("", 1123, urlView, 1123, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1132, 42, true);
            WriteLiteral(">\r\n                                    <b>");
            EndContext();
            BeginContext(1175, 29, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                                  Write(estimation.EstimationTypeName);

#line default
#line hidden
            EndContext();
            BeginContext(1204, 87, true);
            WriteLiteral(":</b>\r\n                                    <br />\r\n                                    ");
            EndContext();
            BeginContext(1292, 16, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                               Write(estimation.Title);

#line default
#line hidden
            EndContext();
            BeginContext(1308, 75, true);
            WriteLiteral("\r\n                                </a>\r\n                            </li>\r\n");
            EndContext();
#line 40 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                        }

#line default
#line hidden
            BeginContext(1410, 51, true);
            WriteLiteral("                    </ul>\r\n                </div>\r\n");
            EndContext();
#line 43 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"

            }

#line default
#line hidden
            BeginContext(1478, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(1490, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "23d2a6f5cc0e48d19d6f37be38e65668", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 45 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = ("91023");

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1540, 89, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-9 body\">\r\n            <h2>\r\n                ");
            EndContext();
            BeginContext(1630, 26, false);
#line 49 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
           Write(Html.Raw(Model.Plan.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1656, 21, true);
            WriteLiteral("\r\n            </h2>\r\n");
            EndContext();
#line 51 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
             if (!string.IsNullOrEmpty(Model.Plan.StateName))
            {

#line default
#line hidden
            BeginContext(1755, 42, true);
            WriteLiteral("                <h4>\r\n                    ");
            EndContext();
            BeginContext(1798, 20, false);
#line 54 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
               Write(Model.Plan.StateName);

#line default
#line hidden
            EndContext();
            BeginContext(1818, 25, true);
            WriteLiteral("\r\n                </h4>\r\n");
            EndContext();
#line 56 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1891, 42, true);
            WriteLiteral("                <h4>\r\n                    ");
            EndContext();
            BeginContext(1934, 26, false);
#line 60 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
               Write(Model.Plan.ElementTypeName);

#line default
#line hidden
            EndContext();
            BeginContext(1960, 25, true);
            WriteLiteral("\r\n                </h4>\r\n");
            EndContext();
#line 62 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
            }

#line default
#line hidden
            BeginContext(2000, 49, true);
            WriteLiteral("\r\n            <p class=\"title\">\r\n                ");
            EndContext();
            BeginContext(2050, 32, false);
#line 65 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
           Write(Html.Raw(Model.Plan.Description));

#line default
#line hidden
            EndContext();
            BeginContext(2082, 32, true);
            WriteLiteral("\r\n            </p>\r\n            ");
            EndContext();
            BeginContext(2115, 145, false);
#line 67 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
       Write(await Component.InvokeAsync("FileList", new { sourceType = GlobalConstants.SourceTypes.NationalPlanElementsDocuments, sourceId = Model.Plan.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2260, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 68 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
             if (Model.SubElements.Any())
            {

#line default
#line hidden
            BeginContext(2320, 116, true);
            WriteLiteral("                <table class=\"table table-bordered table--documents table--stripped\">\r\n                    <tbody>\r\n");
            EndContext();
#line 72 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                         foreach (var element in Model.SubElements)
                        {
                            var urlView = Url.Action("Element", new { id = element.Id });

#line default
#line hidden
            BeginContext(2623, 129, true);
            WriteLiteral("                            <tr>\r\n                                <td style=\"width:150px;\">\r\n                                    ");
            EndContext();
            BeginContext(2753, 23, false);
#line 77 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                               Write(element.ElementTypeName);

#line default
#line hidden
            EndContext();
            BeginContext(2776, 117, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2893, "\"", 2908, 1);
#line 80 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
WriteAttributeValue("", 2900, urlView, 2900, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2909, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2911, 23, false);
#line 80 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                                                  Write(Html.Raw(element.Title));

#line default
#line hidden
            EndContext();
            BeginContext(2934, 176, true);
            WriteLiteral("</a>\r\n                                </td>\r\n                                <td style=\"width:120px;\" class=\"text--center align-middle\">\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3110, "\"", 3125, 1);
#line 83 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
WriteAttributeValue("", 3117, urlView, 3117, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3126, 117, true);
            WriteLiteral("><i class=\"fa fa-search\"></i> преглед</a>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 86 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
                        }

#line default
#line hidden
            BeginContext(3270, 56, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
            EndContext();
#line 89 "C:\Projects\Strategy\newSingleSite\Domain\Views\Ogp\Element.cshtml"
            }

#line default
#line hidden
            BeginContext(3341, 36, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PlanVM> Html { get; private set; }
    }
}
#pragma warning restore 1591