#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "776f1e84fe015e348dc761fe28e6929e3e65052e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_PCSubjects_EditPCSubjects), @"mvc.1.0.view", @"/Areas/Admin/Views/PCSubjects/EditPCSubjects.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/PCSubjects/EditPCSubjects.cshtml", typeof(AspNetCore.Areas_Admin_Views_PCSubjects_EditPCSubjects))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"776f1e84fe015e348dc761fe28e6929e3e65052e", @"/Areas/Admin/Views/PCSubjects/EditPCSubjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_PCSubjects_EditPCSubjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModels.PCSubjectsModels.PCSubjectsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListPCSubjects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditPCSubjects", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
  
    ViewData["Title"] = "Лице съгласно ЗНА";

#line default
#line hidden
            BeginContext(118, 96, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-6\">\r\n            ");
            EndContext();
            BeginContext(214, 1476, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73b4b74387a844f384b949803a1be7ba", async() => {
                BeginContext(248, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(266, 66, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed3c06997abf425e8d0d16bbeb128ec6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
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
                BeginContext(332, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(351, 25, false);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
                EndContext();
                BeginContext(376, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(395, 34, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.HiddenFor(m => m.DateCreated));

#line default
#line hidden
                EndContext();
                BeginContext(429, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(448, 38, false);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.HiddenFor(m => m.CreatedByUserId));

#line default
#line hidden
                EndContext();
                BeginContext(486, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(505, 39, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.HiddenFor(m => m.ModifiedByUserId));

#line default
#line hidden
                EndContext();
                BeginContext(544, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(563, 35, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.HiddenFor(m => m.DateModified));

#line default
#line hidden
                EndContext();
                BeginContext(598, 107, true);
                WriteLiteral("\r\n\r\n                <div class=\"row\">\r\n                    <div class=\"col-lg-3\">\r\n                        ");
                EndContext();
                BeginContext(706, 38, false);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
                   Write(Html.LabelFor(m => m.IsUL, "Вид лице"));

#line default
#line hidden
                EndContext();
                BeginContext(744, 98, true);
                WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-lg-5\">\r\n                        ");
                EndContext();
                BeginContext(843, 77, false);
#line 23 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
                   Write(Html.DropDownList("IsUL", (List<SelectListItem>)ViewBag.PCSubjectsTypeID_ddl));

#line default
#line hidden
                EndContext();
                BeginContext(920, 112, true);
                WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n                <div id=\"eik_div\">\r\n                    ");
                EndContext();
                BeginContext(1033, 84, false);
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
               Write(Html.EditorFor(m => m.EIK, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
                EndContext();
                BeginContext(1117, 44, true);
                WriteLiteral("\r\n                </div>\r\n\r\n                ");
                EndContext();
                BeginContext(1162, 85, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.EditorFor(m => m.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
                EndContext();
                BeginContext(1247, 20, true);
                WriteLiteral("\r\n\r\n                ");
                EndContext();
                BeginContext(1268, 34, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.EditorFor(m => m.DatePayment));

#line default
#line hidden
                EndContext();
                BeginContext(1302, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1321, 35, false);
#line 34 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.EditorFor(m => m.PaymentValue));

#line default
#line hidden
                EndContext();
                BeginContext(1356, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(1375, 42, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
           Write(Html.EditorFor(m => m.ActivityDescription));

#line default
#line hidden
                EndContext();
                BeginContext(1417, 156, true);
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    <input type=\"submit\" value=\"Запис\" class=\"btn btn-success btn-flat\" />\r\n                    ");
                EndContext();
                BeginContext(1573, 72, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccef27c9d4714ba5b22b5347278d16ed", async() => {
                    BeginContext(1636, 5, true);
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
                BeginContext(1645, 38, true);
                WriteLiteral("\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1690, 42, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1749, 327, true);
                WriteLiteral(@"
    <script>
        $(function () {
            SetSubjectType();

            $('#IsUL').change(function () {
                SetSubjectType();
            });

            $(""#EIK"").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '");
                EndContext();
                BeginContext(2077, 47, false);
#line 56 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
                         Write(Url.Action("LoadDataPCSubjectsAutocompleteEIK"));

#line default
#line hidden
                EndContext();
                BeginContext(2124, 800, true);
                WriteLiteral(@"',
                        type: ""GET"",
                        dataType: ""json"",
                        data: { Prefix: request.term },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { name: item.name, value: item.eik, label: item.activityDescription };
                            }))
                        }
                    })
                },
                minLength: 3,
                select: function (event, ui) {
                    $(""#Name"").val(ui.item.name);
                }
            });

            $(""#Name"").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '");
                EndContext();
                BeginContext(2925, 48, false);
#line 76 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\EditPCSubjects.cshtml"
                         Write(Url.Action("LoadDataPCSubjectsAutocompleteName"));

#line default
#line hidden
                EndContext();
                BeginContext(2973, 928, true);
                WriteLiteral(@"',
                        type: ""GET"",
                        dataType: ""json"",
                        data: { Prefix: request.term },
                        success: function (data) {
                            response($.map(data, function (item) {
                                return { name: item.eik, value: item.name, label: item.activityDescription };
                            }))
                        }
                    })
                },
                minLength: 3,
                select: function (event, ui) {
                    $(""#EIK"").val(ui.item.name);
                }
            });
        });

        function SetSubjectType() {
            if ($('#IsUL').val() == ""1"") {
                $('#eik_div').show();
            }
            else {
                $('#eik_div').hide();
                $('#eik').val("""");
            }
        }
    </script>
");
                EndContext();
            }
            );
            BeginContext(3904, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModels.PCSubjectsModels.PCSubjectsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
