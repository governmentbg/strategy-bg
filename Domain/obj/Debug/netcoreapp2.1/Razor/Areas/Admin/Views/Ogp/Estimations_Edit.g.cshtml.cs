#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f753cd8f261e86996f2b3179e4e005ac9c791d51"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Ogp_Estimations_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Ogp/Estimations_Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Ogp/Estimations_Edit.cshtml", typeof(AspNetCore.Areas_Admin_Views_Ogp_Estimations_Edit))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Domain;

#line default
#line hidden
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.ViewModels;

#line default
#line hidden
#line 4 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.ViewModels.Account;

#line default
#line hidden
#line 5 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.Context.Account;

#line default
#line hidden
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using WebCommon.TagHelpers;

#line default
#line hidden
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.Context;

#line default
#line hidden
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
using Models.Context.Ogp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f753cd8f261e86996f2b3179e4e005ac9c791d51", @"/Areas/Admin/Views/Ogp/Estimations_Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Ogp_Estimations_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NationalPlanEstimations>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Estimations", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-elementId", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "UsedDocuments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::WebCommon.TagHelpers.DropDownListTagHelper __WebCommon_TagHelpers_DropDownListTagHelper;
        private global::WebCommon.TagHelpers.TextBoxTagHelper __WebCommon_TagHelpers_TextBoxTagHelper;
        private global::WebCommon.TagHelpers.CheckBoxTagHelper __WebCommon_TagHelpers_CheckBoxTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
  
    if (Model.Id > 0)
    {
        ViewData["Title"] = "Редакция на оценка";
    }
    else
    {
        ViewData["Title"] = "Добавяне на оценка";
    }

#line default
#line hidden
            BeginContext(229, 113, true);
            WriteLiteral("<section class=\"content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-6 col-md-8 col-sm-12\">\r\n            ");
            EndContext();
            BeginContext(342, 1507, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c10576f3ec474c9a8e5517aae9346e0a", async() => {
                BeginContext(395, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(413, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e1dc7f4800b4fd1b61b6b1cc4714793", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
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
                BeginContext(479, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(497, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ff96fff1596d4f7b85a0b43e3fe33bb4", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(533, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(551, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "088c58513abc478bb534769678704efa", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 19 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ParentID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(593, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                 if (Model.ParentID > 0)
                {

#line default
#line hidden
                BeginContext(656, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(676, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ddl", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60f416765a5847fab36e23bef7ddcb72", async() => {
                }
                );
                __WebCommon_TagHelpers_DropDownListTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.DropDownListTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_DropDownListTagHelper);
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ElementID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_DropDownListTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.Data = ViewBag.planElements;

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
                BeginContext(732, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(754, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d3b9ba657147434498d76e164b812f5f", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 23 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EstimationTypeId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(804, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                }
                else
                {

#line default
#line hidden
                BeginContext(866, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(886, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "553a457c5e8145c095e7a866729f9841", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ElementID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(929, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(951, 56, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ddl", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e07b549d7d1743358d1b73f0fa783bc7", async() => {
                }
                );
                __WebCommon_TagHelpers_DropDownListTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.DropDownListTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_DropDownListTagHelper);
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EstimationTypeId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_DropDownListTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.Data = ViewBag.types;

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
                BeginContext(1007, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 29 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                }

#line default
#line hidden
                BeginContext(1028, 16, true);
                WriteLiteral("                ");
                EndContext();
                BeginContext(1044, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06289ad491294669922dc626562d70a8", async() => {
                }
                );
                __WebCommon_TagHelpers_TextBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.TextBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_TextBoxTagHelper);
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__WebCommon_TagHelpers_TextBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Title);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_TextBoxTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __WebCommon_TagHelpers_TextBoxTagHelper.Type = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1091, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1109, 53, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad5550227e8a4500ad36f4e9e9122111", async() => {
                }
                );
                __WebCommon_TagHelpers_TextBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.TextBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_TextBoxTagHelper);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__WebCommon_TagHelpers_TextBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Description);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_TextBoxTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __WebCommon_TagHelpers_TextBoxTagHelper.Type = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1162, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1180, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02339e0bc2f64c95bb103b0ac4a6d811", async() => {
                }
                );
                __WebCommon_TagHelpers_CheckBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.CheckBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_CheckBoxTagHelper);
#line 32 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__WebCommon_TagHelpers_CheckBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IsActive);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_CheckBoxTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1216, 136, true);
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    <input type=\"submit\" value=\"Запис\" class=\"btn btn-success btn-flat\" />\r\n");
                EndContext();
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                     if (Model.ParentID > 0)
                    {

#line default
#line hidden
                BeginContext(1421, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(1445, 130, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45455990a802438399b470508255aa9f", async() => {
                    BeginContext(1566, 5, true);
                    WriteLiteral("Назад");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-elementId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["elementId"] = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-parentId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                                                                                    WriteLiteral(Model.ParentID);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["parentId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-parentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["parentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1575, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 38 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(1649, 24, true);
                WriteLiteral("                        ");
                EndContext();
                BeginContext(1673, 108, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23a508aabc0247b8991aecc0aec41f1b", async() => {
                    BeginContext(1772, 5, true);
                    WriteLiteral("Назад");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-elementId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 41 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                                                             WriteLiteral(Model.ElementID);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["elementId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-elementId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["elementId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1781, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 42 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                    }

#line default
#line hidden
                BeginContext(1806, 36, true);
                WriteLiteral("                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginWriteTagHelperAttribute();
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
                  WriteLiteral(ViewBag.actionName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1849, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 47 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
     if (Model.Id > 0)
    {

#line default
#line hidden
            BeginContext(1910, 125, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <h4>Прикачени документи</h4>\r\n                ");
            EndContext();
            BeginContext(2035, 168, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ba2698c75de541f7bbb10133d3c965e1", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#line 52 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (new FileCDN.Models.FileSelect() { SourceType = GlobalConstants.SourceTypes.PlanEstimations, SourceID = Model.Id.ToString() });

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
            BeginContext(2203, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 55 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\Estimations_Edit.cshtml"
    }

#line default
#line hidden
            BeginContext(2248, 12, true);
            WriteLiteral("</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2277, 114, true);
                WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n            $(\'#Description\').summernote();\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NationalPlanEstimations> Html { get; private set; }
    }
}
#pragma warning restore 1591
