#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd8b9fed933159c4d2325c474ad0ec6d3f8680ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Questionary_IndexQuestions), @"mvc.1.0.view", @"/Areas/Admin/Views/Questionary/IndexQuestions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Questionary/IndexQuestions.cshtml", typeof(AspNetCore.Areas_Admin_Views_Questionary_IndexQuestions))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd8b9fed933159c4d2325c474ad0ec6d3f8680ae", @"/Areas/Admin/Views/Questionary/IndexQuestions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Questionary_IndexQuestions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddQuestion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
  
    ViewData["Title"] = "Въпроси към анкета";

#line default
#line hidden
            BeginContext(51, 116, true);
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-md-1\">\r\n        </div>\r\n        <div class=\"col-md-11\">\r\n            ");
            EndContext();
            BeginContext(168, 24, false);
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
       Write(ViewBag.QuestionaryTitle);

#line default
#line hidden
            EndContext();
            BeginContext(192, 30, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
    var questionaryHeaderId = (int)ViewBag.QuestionaryHeaderId;

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(311, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 356, "\"", 390, 1);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
WriteAttributeValue("", 363, Url.Action("Index","Home"), 363, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(391, 25, true);
                WriteLiteral(">Начало</a>\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 416, "\"", 458, 1);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
WriteAttributeValue("", 423, Url.Action("Index", "Questionary"), 423, 35, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(459, 32, true);
                WriteLiteral(">Анкети-списък</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(494, 66, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"pull-left\">\r\n        ");
            EndContext();
            BeginContext(560, 135, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77178e6933c541f7875ec7523d27274d", async() => {
                BeginContext(674, 17, true);
                WriteLiteral("Добави нов въпрос");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-questionaryHeaderId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
                                                                                        WriteLiteral(questionaryHeaderId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["questionaryHeaderId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-questionaryHeaderId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["questionaryHeaderId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(695, 92, true);
            WriteLiteral("\r\n    </div>\r\n    <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(804, 134, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n         var dt  = $(\'#mainTable\').DataTable({\r\n             \"ajax\": {\r\n                 \"url\": \'");
                EndContext();
                BeginContext(939, 31, false);
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
                    Write(Url.Action("LoadDataQuestions"));

#line default
#line hidden
                EndContext();
                BeginContext(970, 88, true);
                WriteLiteral("\',\r\n                 data: function (d) {\r\n                     d.questionaryHeaderId = ");
                EndContext();
                BeginContext(1059, 19, false);
#line 32 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
                                        Write(questionaryHeaderId);

#line default
#line hidden
                EndContext();
                BeginContext(1078, 785, true);
                WriteLiteral(@"
                 },
                 ""type"": ""POST""
             },
             fnDrawCallback: function (settings) {
                 $(this).parent().toggle(settings.fnRecordsDisplay() > 0);
             },
             ""columns"": [
                 {
                     data: ""orderNum"",
                     title: '№',
                     sortable: true,
                     searchable: false
                 },
                 {
                     data: ""description"",
                     title: 'Въпрос',
                     sortable: true,
                     searchable: true
                 },
                 {
                     data: ""id"",
                     ""render"": function (value) {
                         var updateUrl = '");
                EndContext();
                BeginContext(1864, 45, false);
#line 55 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\IndexQuestions.cshtml"
                                     Write(Url.Action("EditQuestion", new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(1909, 397, true);
                WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-warning"">Редакция</a>';
                         return updButton;
                     },
                     sortable: false,
                     searchable: false
                 }
             ],
             ""order"": [[0, ""asc""]],
        });
    });

    </script>
");
                EndContext();
            }
            );
            BeginContext(2309, 104, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"pull-left\">\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(2413, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1235c7f0b3dc469ba5ded889c67d6fcc", async() => {
                BeginContext(2467, 5, true);
                WriteLiteral("Назад");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
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
            BeginContext(2476, 42, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591