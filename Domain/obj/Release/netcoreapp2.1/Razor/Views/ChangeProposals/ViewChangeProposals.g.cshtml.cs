#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcbe6a3cc9007db018a8c16182c93d3b930bb0c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ChangeProposals_ViewChangeProposals), @"mvc.1.0.view", @"/Views/ChangeProposals/ViewChangeProposals.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ChangeProposals/ViewChangeProposals.cshtml", typeof(AspNetCore.Views_ChangeProposals_ViewChangeProposals))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcbe6a3cc9007db018a8c16182c93d3b930bb0c5", @"/Views/ChangeProposals/ViewChangeProposals.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a9a60c20537480d66fd9d2d41d1eec08c8ef00", @"/Views/_ViewImports.cshtml")]
    public class Views_ChangeProposals_ViewChangeProposals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModels.ChangeProposalsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FillQuestionaryBySourceType", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Questionary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
  
    ViewData["Title"] = "Законодателнa инициативa";
    ViewData["SectionTitle"] = ViewData["Title"];

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(183, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 228, "\"", 263, 1);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
WriteAttributeValue("", 235, Url.Action("Index", "Home"), 235, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(264, 25, true);
                WriteLiteral(">Начало</a>\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 289, "\"", 349, 1);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
WriteAttributeValue("", 296, Url.Action("ListChangeProposals", "ChangeProposals"), 296, 53, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(350, 106, true);
                WriteLiteral(">Списък със законодателни инициативи</a>\r\n        / <a href=\"#\">Законодателнa инициативa</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(459, 165, true);
            WriteLiteral("\r\n<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"body col-lg-8 col-md-12 col-lg-offset-2\">\r\n            <h2>\r\n                ");
            EndContext();
            BeginContext(625, 21, false);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
           Write(Html.Raw(Model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(646, 68, true);
            WriteLiteral("\r\n            </h2>\r\n            <p class=\"title\">\r\n                ");
            EndContext();
            BeginContext(715, 20, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
           Write(Html.Raw(Model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(735, 407, true);
            WriteLiteral(@"
            </p>
            <!-- TABLE DATES -->
            <div class=""row"">
                <div class=""col-md-5"">
                    <table class=""table table-bordered table--dates table--stripped"">
                        <tbody>
                            <!-- LOOP -->
                            <tr>
                                <td>Група:</td>
                                <td>");
            EndContext();
            BeginContext(1143, 24, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
                               Write(Model.CategoryMasterText);

#line default
#line hidden
            EndContext();
            BeginContext(1167, 70, true);
            WriteLiteral("</td>\r\n                            </tr>                            \r\n");
            EndContext();
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
                             if (Model.IsRejected)
                            {

#line default
#line hidden
            BeginContext(1320, 324, true);
            WriteLiteral(@"                                <tr>
                                    <td>Отказана:</td>
                                    <td>ДА</td>
                                </tr>
                                <tr>
                                    <td>Причина за отказ:</td>
                                    <td>");
            EndContext();
            BeginContext(1645, 17, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
                                   Write(Model.AdminRemark);

#line default
#line hidden
            EndContext();
            BeginContext(1662, 46, true);
            WriteLiteral("</td>\r\n                                </tr>\r\n");
            EndContext();
#line 43 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
                            }

#line default
#line hidden
            BeginContext(1739, 130, true);
            WriteLiteral("                            <tr>\r\n                                <td>Последна промяна:</td>\r\n                                <td>");
            EndContext();
            BeginContext(1870, 55, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
                               Write(Model.DateModified.ToString(GlobalConstants.DateFormat));

#line default
#line hidden
            EndContext();
            BeginContext(1925, 247, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <!-- END LOOP -->\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n            <!-- END TABLE DATES -->\r\n            ");
            EndContext();
            BeginContext(2173, 126, false);
#line 54 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
       Write(await Component.InvokeAsync("FileList", new { sourceType = GlobalConstants.SourceTypes.ChangeProposals, sourceId = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(2299, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 56 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
             if ((bool)ViewBag.HasQuestionary)
            {

#line default
#line hidden
            BeginContext(2366, 62, true);
            WriteLiteral("                <div class=\"form-group\">\r\n                    ");
            EndContext();
            BeginContext(2428, 231, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78d53af4eb2849d6b637737f8c26e0fd", async() => {
                BeginContext(2632, 23, true);
                WriteLiteral("Анкета към инициативата");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sourceTypeID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 59 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
                                                                                                         WriteLiteral(GlobalConstants.SourceTypes.ChangeProposals);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sourceTypeID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sourceTypeID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sourceTypeID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 59 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
                                                                                                                                                                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sourceId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sourceId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sourceId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2659, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 61 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ViewChangeProposals.cshtml"
            }

#line default
#line hidden
            BeginContext(2700, 34, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModels.ChangeProposalsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
