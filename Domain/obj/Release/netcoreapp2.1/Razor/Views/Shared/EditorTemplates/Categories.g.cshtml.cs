#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a36bbf0f29b9ab43a4b060135ba54951ad868a62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_Categories), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/Categories.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/EditorTemplates/Categories.cshtml", typeof(AspNetCore.Views_Shared_EditorTemplates_Categories))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a36bbf0f29b9ab43a4b060135ba54951ad868a62", @"/Views/Shared/EditorTemplates/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a9a60c20537480d66fd9d2d41d1eec08c8ef00", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(12, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
  
    var fieldName = ViewData.TemplateInfo.HtmlFieldPrefix.Replace(".", "_") + "_category";

#line default
#line hidden
            BeginContext(113, 32, true);
            WriteLiteral("\r\n<div class=\"form-group\">\r\n    ");
            EndContext();
            BeginContext(145, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0a22b296cfde4f16aebbd125f0b1d94d", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(199, 12, true);
            WriteLiteral("\r\n    <input");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 211, "\"", 226, 1);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
WriteAttributeValue("", 216, fieldName, 216, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(227, 50, true);
            WriteLiteral(" class=\"form-control\" style=\"z-index:999\" />\r\n    ");
            EndContext();
            BeginContext(277, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fecc7983e148493496e7944c2209d2e3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

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
            BeginContext(317, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(323, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e538ab6aa6be4ee58408390bb5efe221", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(384, 33, true);
            WriteLiteral("\r\n</div>\r\n\r\n<script>\r\n    if (!!\'");
            EndContext();
            BeginContext(418, 5, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
      Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(423, 5, true);
            WriteLiteral("\' && ");
            EndContext();
            BeginContext(429, 5, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
                 Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(434, 40, true);
            WriteLiteral(" > 0) {\r\n        loadAutoCompleteValue(\'");
            EndContext();
            BeginContext(475, 5, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
                          Write(Model);

#line default
#line hidden
            EndContext();
            BeginContext(480, 698, true);
            WriteLiteral(@"');
    }

    $.widget('custom.autocomplete_category', $.ui.autocomplete, {
        _renderMenu: function _renderMenu(ul, items) {
            var that = this;
            var category = '';
            $.each(items, function (index, item) {
                if (item.category !== category) {
                    ul.append('<li class=""ui-autocomplete-category ui-state-disabled"" aria-label=""' + item.category + '"">' + item.category + '</li>');
                    category = item.category;
                }
                that._renderItemData(ul, item);
            });
        }
    });

    window.location_storage_activity = window.location_storage_activity || {};

    $('#");
            EndContext();
            BeginContext(1179, 9, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
   Write(fieldName);

#line default
#line hidden
            EndContext();
            BeginContext(1188, 351, true);
            WriteLiteral(@"').autocomplete_category({
        minLength: 2,
        delay: 0,
        source: function source(request, response) {
            var _window = window,
                location_storage = _window.location_storage_activity;

            if (!!location_storage[request.term]) return response(location_storage[request.term]);
            $.get('");
            EndContext();
            BeginContext(1540, 70, false);
#line 43 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
              Write(Url.Action("SearchCategory", "Ajax", new { area = "", query = "666" }));

#line default
#line hidden
            EndContext();
            BeginContext(1610, 1187, true);
            WriteLiteral(@"'.replace('666', encodeURIComponent(request.term))).done(function (success) {
                location_storage[request.term] = success.data;
                return response(success.data);
            }).fail(function (errors) {
                console.log(errors);
            });
        },
        select: function select(event, ui) {
            if (ui.item != null) {
                ui.item.value = ui.item.category + ', ' + ui.item.label;
                var input_hidden = event.target.parentElement.querySelector('input[type=""hidden""]');
                input_hidden.value = ui.item.id;
            }
        }
    }).change(function () {
        var input = this;
        if (!input.value || input.value < 2) {
            var input_hidden = input.parentElement.querySelector('input[type=""hidden""]');
            input_hidden.value = '';
        }
    }).blur(function () {
        var input = this;
        if (!input.value || input.value < 2) {
            var input_hidden = input.parentEl");
            WriteLiteral("ement.querySelector(\'input[type=\"hidden\"]\');\r\n            input_hidden.value = \'\';\r\n        }\r\n    });\r\n\r\n    function loadAutoCompleteValue(id) {\r\n        $.get(\'");
            EndContext();
            BeginContext(2798, 64, false);
#line 72 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
          Write(Url.Action("GetCategory", "Ajax", new { area = "", id = "666" }));

#line default
#line hidden
            EndContext();
            BeginContext(2862, 80, true);
            WriteLiteral("\'.replace(\'666\', id))\r\n            .done(function (data) {\r\n                $(\'#");
            EndContext();
            BeginContext(2943, 9, false);
#line 74 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\EditorTemplates\Categories.cshtml"
               Write(fieldName);

#line default
#line hidden
            EndContext();
            BeginContext(2952, 156, true);
            WriteLiteral("\').val(data.label + \', \' + data.category);\r\n            }).fail(function (errors) {\r\n                console.log(errors);\r\n            });\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591