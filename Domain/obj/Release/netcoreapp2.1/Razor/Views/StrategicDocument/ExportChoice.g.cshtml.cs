#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\ExportChoice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "791aeab2b46a09fcf172a3517f21acdd2d353b5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StrategicDocument_ExportChoice), @"mvc.1.0.view", @"/Views/StrategicDocument/ExportChoice.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/StrategicDocument/ExportChoice.cshtml", typeof(AspNetCore.Views_StrategicDocument_ExportChoice))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"791aeab2b46a09fcf172a3517f21acdd2d353b5d", @"/Views/StrategicDocument/ExportChoice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_StrategicDocument_ExportChoice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModels.Portal.StrategicDocumentExportChoiceVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExportChoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "StrategicDocument", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("target", new global::Microsoft.AspNetCore.Html.HtmlString("_blank"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::WebCommon.TagHelpers.DropDownListTagHelper __WebCommon_TagHelpers_DropDownListTagHelper;
        private global::WebCommon.TagHelpers.DatePickerHelper __WebCommon_TagHelpers_DatePickerHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\ExportChoice.cshtml"
  
    Layout = null;

#line default
#line hidden
            BeginContext(92, 47, true);
            WriteLiteral("<div class=\"container-fluid information\">\r\n    ");
            EndContext();
            BeginContext(139, 883, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd35315edf1840aea403b0cc1e413724", async() => {
                BeginContext(236, 122, true);
                WriteLiteral("\r\n        <div class=\"col-md-12 body\">\r\n            <div class=\"form-group col-lg-4 col-md-6 col-sm-12\">\r\n                ");
                EndContext();
                BeginContext(358, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ddl", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6bfa82b53ed4ac0bd242144c4ae7f94", async() => {
                }
                );
                __WebCommon_TagHelpers_DropDownListTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.DropDownListTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_DropDownListTagHelper);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\ExportChoice.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.CategoryMasterId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_DropDownListTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\ExportChoice.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.Data = ViewBag.catMasters;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("data", __WebCommon_TagHelpers_DropDownListTagHelper.Data, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(419, 103, true);
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-lg-2 col-md-4 col-sm-6\">\r\n                ");
                EndContext();
                BeginContext(522, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("date-picker", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c43f5efa22b4921bd7629b3767bc84e", async() => {
                }
                );
                __WebCommon_TagHelpers_DatePickerHelper = CreateTagHelper<global::WebCommon.TagHelpers.DatePickerHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_DatePickerHelper);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\ExportChoice.cshtml"
__WebCommon_TagHelpers_DatePickerHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.FromDate);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_DatePickerHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(564, 103, true);
                WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group col-lg-2 col-md-4 col-sm-6\">\r\n                ");
                EndContext();
                BeginContext(667, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("date-picker", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae65b0e656c24add8f31687015a6d5fd", async() => {
                }
                );
                __WebCommon_TagHelpers_DatePickerHelper = CreateTagHelper<global::WebCommon.TagHelpers.DatePickerHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_DatePickerHelper);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\ExportChoice.cshtml"
__WebCommon_TagHelpers_DatePickerHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ToDate);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_DatePickerHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(707, 308, true);
                WriteLiteral(@"
            </div>
            <div class=""form-group col-lg-2 col-md-4 col-sm-6  "">
                <label class=""control-label""> </label>
                <button type=""submit"" class=""form-control btn btn-info""><i class=""fa fa-file-pdf-o""></i> Експорт</button>
            </div>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1022, 90, true);
            WriteLiteral("\r\n</div>\r\n<script>\r\n    $(function () {\r\n        AttachUIpluggins();\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModels.Portal.StrategicDocumentExportChoiceVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
