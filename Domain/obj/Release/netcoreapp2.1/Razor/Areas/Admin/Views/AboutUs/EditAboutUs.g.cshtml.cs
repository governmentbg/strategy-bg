#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8b0ee35b7a863812a1031b3256e56acb6635660"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AboutUs_EditAboutUs), @"mvc.1.0.view", @"/Areas/Admin/Views/AboutUs/EditAboutUs.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/AboutUs/EditAboutUs.cshtml", typeof(AspNetCore.Areas_Admin_Views_AboutUs_EditAboutUs))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8b0ee35b7a863812a1031b3256e56acb6635660", @"/Areas/Admin/Views/AboutUs/EditAboutUs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AboutUs_EditAboutUs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModels.AboutUs.AboutUsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListAboutUs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "UsedDocuments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditAboutUs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
  
    ViewData["Title"] = "Контакт";

#line default
#line hidden
            BeginContext(96, 96, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-6\">\r\n            ");
            EndContext();
            BeginContext(192, 1483, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47bb9fd12bba48dbb81cda7f48c6769b", async() => {
                BeginContext(223, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(241, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68c13d1926054f9aa151586e4fcb0a9a", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
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
                BeginContext(307, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(326, 25, false);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
                EndContext();
                BeginContext(351, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(370, 34, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.HiddenFor(m => m.DateCreated));

#line default
#line hidden
                EndContext();
                BeginContext(404, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(423, 38, false);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.HiddenFor(m => m.CreatedByUserId));

#line default
#line hidden
                EndContext();
                BeginContext(461, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(480, 39, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.HiddenFor(m => m.ModifiedByUserId));

#line default
#line hidden
                EndContext();
                BeginContext(519, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(538, 35, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.HiddenFor(m => m.DateModified));

#line default
#line hidden
                EndContext();
                BeginContext(573, 20, true);
                WriteLiteral("\r\n\r\n                ");
                EndContext();
                BeginContext(594, 32, false);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.EditorFor(m => m.FirstName));

#line default
#line hidden
                EndContext();
                BeginContext(626, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(645, 31, false);
#line 19 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.EditorFor(m => m.LastName));

#line default
#line hidden
                EndContext();
                BeginContext(676, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(695, 28, false);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.EditorFor(m => m.Phone));

#line default
#line hidden
                EndContext();
                BeginContext(723, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(742, 28, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.EditorFor(m => m.Email));

#line default
#line hidden
                EndContext();
                BeginContext(770, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(789, 30, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.EditorFor(m => m.IsAdmin));

#line default
#line hidden
                EndContext();
                BeginContext(819, 20, true);
                WriteLiteral("\r\n\r\n                ");
                EndContext();
                BeginContext(840, 31, false);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.EditorFor(m => m.IsActive));

#line default
#line hidden
                EndContext();
                BeginContext(871, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(890, 32, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
           Write(Html.EditorFor(m => m.IsDeleted));

#line default
#line hidden
                EndContext();
                BeginContext(922, 168, true);
                WriteLiteral("\r\n\r\n                <div class=\"form-group\">\r\n                    <input id=\"save\" type=\"submit\" value=\"Запис\" class=\"btn btn-success btn-flat\" />\r\n                    ");
                EndContext();
                BeginContext(1090, 69, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62c4f2ad488744aca85d760b9b16bc08", async() => {
                    BeginContext(1150, 5, true);
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
                BeginContext(1159, 28, true);
                WriteLiteral("\r\n                </div>\r\n\r\n");
                EndContext();
#line 32 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
                 if (Model.Id > 0)
                {

#line default
#line hidden
                BeginContext(1242, 173, true);
                WriteLiteral("                    <div class=\"row\">\r\n                        <div class=\"col-lg-6\">\r\n                            <h4>Прикачени документи</h4>\r\n                            ");
                EndContext();
                BeginContext(1415, 160, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b5f3fdf381ab4aa7b17155cbef596566", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (new FileCDN.Models.FileSelect() { SourceType = GlobalConstants.SourceTypes.AboutUs, SourceID = Model.Id.ToString() });

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
                BeginContext(1575, 62, true);
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
                EndContext();
#line 40 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\AboutUs\EditAboutUs.cshtml"
                }

#line default
#line hidden
                BeginContext(1656, 12, true);
                WriteLiteral("            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1675, 42, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModels.AboutUs.AboutUsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591