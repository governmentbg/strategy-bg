#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45930e10ff3ce3ed07169e7d200bcdd95fd7cf7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Publication_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Publication/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Publication/Edit.cshtml", typeof(AspNetCore.Areas_Admin_Views_Publication_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45930e10ff3ce3ed07169e7d200bcdd95fd7cf7e", @"/Areas/Admin/Views/Publication/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Publication_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.Context.Legacy.Publications>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("edit-class", "summernote", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("text-class", "label label-primary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("text-class", "label label-warning", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("text-class", "label label-danger", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "UsedImages", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "UsedDocuments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::WebCommon.TagHelpers.TextBoxTagHelper __WebCommon_TagHelpers_TextBoxTagHelper;
        private global::WebCommon.TagHelpers.DropDownListTagHelper __WebCommon_TagHelpers_DropDownListTagHelper;
        private global::WebCommon.TagHelpers.DatePickerHelper __WebCommon_TagHelpers_DatePickerHelper;
        private global::WebCommon.TagHelpers.CheckBoxTagHelper __WebCommon_TagHelpers_CheckBoxTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
  
    ViewData["Title"] = "Публикации";

#line default
#line hidden
            BeginContext(91, 106, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-8 col-md-12\">\r\n            ");
            EndContext();
            BeginContext(197, 1112, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b530d33fccf343abbaf5f4d6f966478b", async() => {
                BeginContext(236, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(254, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b7c5e18ba194a9ab507fd9023860c05", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
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
                BeginContext(320, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(338, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "252c5f67b386456ba25505874d674cc1", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
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
                BeginContext(374, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(392, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4911a44a68ee4b59817a2d4e1b1395cb", async() => {
                }
                );
                __WebCommon_TagHelpers_TextBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.TextBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_TextBoxTagHelper);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
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
                BeginContext(439, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(457, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ddl", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3bf51a2482ca4078b4bf86763b0be42d", async() => {
                }
                );
                __WebCommon_TagHelpers_DropDownListTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.DropDownListTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_DropDownListTagHelper);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.PublicationCategoryId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_DropDownListTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_DropDownListTagHelper.Data = ViewBag.categories;

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
                BeginContext(523, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(541, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("date-picker", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e4a06ad76633471fa2a32a701e47e752", async() => {
                }
                );
                __WebCommon_TagHelpers_DatePickerHelper = CreateTagHelper<global::WebCommon.TagHelpers.DatePickerHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_DatePickerHelper);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_DatePickerHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Date);

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
                BeginContext(579, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(597, 70, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eec2d392beff42df948478f254ed4689", async() => {
                }
                );
                __WebCommon_TagHelpers_TextBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.TextBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_TextBoxTagHelper);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_TextBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Text);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_TextBoxTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __WebCommon_TagHelpers_TextBoxTagHelper.Type = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __WebCommon_TagHelpers_TextBoxTagHelper.EditClass = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(667, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(685, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e75b4e37b71b4bd398ec028fdc952f68", async() => {
                }
                );
                __WebCommon_TagHelpers_CheckBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.CheckBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_CheckBoxTagHelper);
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_CheckBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IsMainTopic);

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
                BeginContext(724, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(742, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba43a84b8af74f58ae01c85b453c44c1", async() => {
                }
                );
                __WebCommon_TagHelpers_CheckBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.CheckBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_CheckBoxTagHelper);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_CheckBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IsOnMainPage);

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
                BeginContext(782, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(800, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f906081991194a15adeb72057e085598", async() => {
                }
                );
                __WebCommon_TagHelpers_CheckBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.CheckBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_CheckBoxTagHelper);
#line 19 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_CheckBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IsActive);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_CheckBoxTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __WebCommon_TagHelpers_CheckBoxTagHelper.TextClass = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(869, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(887, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8953f3dfc7724478853e5ea078f2ae84", async() => {
                }
                );
                __WebCommon_TagHelpers_CheckBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.CheckBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_CheckBoxTagHelper);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_CheckBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IsApproved);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_CheckBoxTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __WebCommon_TagHelpers_CheckBoxTagHelper.TextClass = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(958, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(976, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("checkbox", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6aa0eededb6b4f4185b66180f9b7565d", async() => {
                }
                );
                __WebCommon_TagHelpers_CheckBoxTagHelper = CreateTagHelper<global::WebCommon.TagHelpers.CheckBoxTagHelper>();
                __tagHelperExecutionContext.Add(__WebCommon_TagHelpers_CheckBoxTagHelper);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__WebCommon_TagHelpers_CheckBoxTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IsDeleted);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("for", __WebCommon_TagHelpers_CheckBoxTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __WebCommon_TagHelpers_CheckBoxTagHelper.TextClass = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1045, 156, true);
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    <input type=\"submit\" value=\"Запис\" class=\"btn btn-success btn-flat\" />\r\n                    ");
                EndContext();
                BeginContext(1201, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "baecba6b839a4eda9f2ef5e2f9d2911a", async() => {
                    BeginContext(1255, 5, true);
                    WriteLiteral("Назад");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1264, 38, true);
                WriteLiteral("\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginWriteTagHelperAttribute();
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
                  WriteLiteral(ViewBag.actionName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1309, 32, true);
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n");
            EndContext();
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
     if (Model.Id > 0)
    {

#line default
#line hidden
            BeginContext(1372, 125, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-lg-6\">\r\n                <h4>Основно изображение</h4>\r\n                ");
            EndContext();
            BeginContext(1497, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "bf7e4ae2e1dc4d829162330fa6897e66", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (new FileCDN.Models.FileSelect() { SourceType = GlobalConstants.SourceTypes.PublicationsImages, SourceID = Model.Id.ToString(),SingleFile=true });

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
            BeginContext(1681, 120, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-lg-6\">\r\n                <h4>Прикачени документи</h4>\r\n                ");
            EndContext();
            BeginContext(1801, 165, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "86792d0058644f2cb806d62a6bc7a78f", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
#line 39 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (new FileCDN.Models.FileSelect() { SourceType = GlobalConstants.SourceTypes.Publications, SourceID = Model.Id.ToString() });

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
            BeginContext(1966, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 42 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Publication\Edit.cshtml"
    }

#line default
#line hidden
            BeginContext(2011, 14, true);
            WriteLiteral("</section>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2042, 122, true);
                WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n            var snEditor = $(\'#Text\').summernote();\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(2167, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.Context.Legacy.Publications> Html { get; private set; }
    }
}
#pragma warning restore 1591