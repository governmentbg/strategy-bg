#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fd98e726cf5278bc1ed512c2fea7ad8a2cbc7cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MulticriteriaAnalysis_Index), @"mvc.1.0.view", @"/Views/MulticriteriaAnalysis/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MulticriteriaAnalysis/Index.cshtml", typeof(AspNetCore.Views_MulticriteriaAnalysis_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fd98e726cf5278bc1ed512c2fea7ad8a2cbc7cf", @"/Views/MulticriteriaAnalysis/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_MulticriteriaAnalysis_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModels.MulticriteriaAnalysis.MulticriteriaAnalysisVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-inactive btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "mcaCalculate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(1052, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1126, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
  
    ViewData["Title"] = "Оценка на въздействието ";
    ViewData["SectionTitle"] = ViewData["Title"];

#line default
#line hidden
            BeginContext(1239, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("breadcrumbs", async() => {
                BeginContext(1262, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1307, "\"", 1341, 1);
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
WriteAttributeValue("", 1314, Url.Action("Index","Home"), 1314, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1342, 74, true);
                WriteLiteral(">Начало</a>\r\n        / <a href=\"#\">Мултикритериен анализ</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(1419, 118, true);
            WriteLiteral("\r\n\r\n<section class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-3\">\r\n            ");
            EndContext();
            BeginContext(1538, 145, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
       Write(await Component.InvokeAsync("MasterPage", new { pageTypeId = GlobalConstants.PageTypes.OV, display = "menu", title = "Оценка на въздействието" }));

#line default
#line hidden
            EndContext();
            BeginContext(1683, 62, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-lg-9\">\r\n            ");
            EndContext();
            BeginContext(1745, 1022, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2dcee521890f4d54adaa19aa6d0ca6b2", async() => {
                BeginContext(1788, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1806, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6f02e8474094f06a8d8100b3281ac33", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 50 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1872, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1891, 43, false);
#line 51 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
           Write(Html.HiddenFor(m => m.TotalAssessmentValue));

#line default
#line hidden
                EndContext();
                BeginContext(1934, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1953, 35, false);
#line 52 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
           Write(Html.EditorFor(m => m.AnalysisDate));

#line default
#line hidden
                EndContext();
                BeginContext(1988, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(2007, 29, false);
#line 53 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
           Write(Html.EditorFor(m => m.Remark));

#line default
#line hidden
                EndContext();
                BeginContext(2036, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(2055, 31, false);
#line 54 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
           Write(Html.EditorFor(m => m.Criteria));

#line default
#line hidden
                EndContext();
                BeginContext(2086, 77, true);
                WriteLiteral("\r\n\r\n                <span class=\"calculatorActivityId\">\r\n                    ");
                EndContext();
                BeginContext(2164, 43, false);
#line 57 "C:\Projects\Strategy\newSingleSite\Domain\Views\MulticriteriaAnalysis\Index.cshtml"
               Write(Html.EditorFor(m => m.TotalAssessmentValue));

#line default
#line hidden
                EndContext();
                BeginContext(2207, 185, true);
                WriteLiteral("\r\n                </span>\r\n\r\n                <div class=\"form-group\">\r\n                    <input type=\"submit\" value=\"Изчисли\" class=\"btn btn-primary btn-flat\" />\r\n                    ");
                EndContext();
                BeginContext(2392, 65, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19d5ca22788d4cb69dccbd6130bebe07", async() => {
                    BeginContext(2448, 5, true);
                    WriteLiteral("Назад");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2457, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(2724, 36, true);
                WriteLiteral("                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2767, 52, true);
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2836, 450, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $(""#btnPDF"").click(function () {
                $(""#form1"").submit(function () {
                    setTimeout('$(""#form2"").submit();', 10);
                    return false;
                });
            });
        });

        $(function () {
            $('.calculatorActivityId :input').attr(""disabled"", true);
        });
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModels.MulticriteriaAnalysis.MulticriteriaAnalysisVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
