#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b46f0d0ddaa8b5b75c780913283c274001ae9011"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Questionary_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Questionary/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Questionary/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Questionary_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b46f0d0ddaa8b5b75c780913283c274001ae9011", @"/Areas/Admin/Views/Questionary/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Questionary_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml"
  
    ViewData["Title"] = "Анкети";

#line default
#line hidden
            BeginContext(42, 66, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"pull-left\">\r\n        ");
            EndContext();
            BeginContext(108, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "22ade646175444f785a3d96bef33adf4", async() => {
                BeginContext(161, 18, true);
                WriteLiteral("Добави нова анкета");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(183, 92, true);
            WriteLiteral("\r\n    </div>\r\n    <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(292, 134, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n         var dt  = $(\'#mainTable\').DataTable({\r\n             \"ajax\": {\r\n                 \"url\": \'");
                EndContext();
                BeginContext(427, 22, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml"
                    Write(Url.Action("LoadData"));

#line default
#line hidden
                EndContext();
                BeginContext(449, 1637, true);
                WriteLiteral(@"',
                 data: function (d) { },
                 //    d.active = $('#cboxActive').is(':checked');
                 //    d.confirmed = $('#cboxConfirmed').is(':checked');
                 //},
                 ""type"": ""POST""
             },
             fnDrawCallback: function (settings) {
                 $(this).parent().toggle(settings.fnRecordsDisplay() > 0);
             },
             ""columns"": [
                 {
                     data: ""title"",
                     title: 'Заглавие',
                     sortable: true,
                     searchable: true
                 },
                 {
                     data: ""description"",
                     title: 'Описание',
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""openningDate"",
                     title: 'Начало',
                     sortable: true,
                     searchable: false,
         ");
                WriteLiteral(@"            ""render"": function (value) {
                         return JsonBGdate(value);
                     }
                 },
                 {
                     data: ""closingDate"",
                     title: 'Край',
                     sortable: true,
                     searchable: false,
                     ""render"": function (value) {
                         return JsonBGdate(value);
                     }
                 },
                 {
                     data: ""id"",
                     ""render"": function (value) {
                         var updateUrl = '");
                EndContext();
                BeginContext(2087, 36, false);
#line 60 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml"
                                     Write(Url.Action("Edit",new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(2123, 452, true);
                WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-warning"">Редакция</a>';
                         return updButton;
                     },
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""id"",
                     ""render"": function (value) {
                         var updateUrl = '");
                EndContext();
                BeginContext(2576, 63, false);
#line 70 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml"
                                     Write(Url.Action("IndexQuestions",new { questionaryHeaderId = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(2639, 448, true);
                WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-info"">Въпроси</a>';
                         return updButton;
                     },
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""id"",
                     ""render"": function (value) {
                         var updateUrl = '");
                EndContext();
                BeginContext(3088, 62, false);
#line 80 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml"
                                     Write(Url.Action("IndexAnswers", new { questionaryHeaderId = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(3150, 452, true);
                WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-primary"">Отговори</a>';
                         return updButton;
                     },
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""id"",
                     ""render"": function (value) {
                         var updateUrl = '");
                EndContext();
                BeginContext(3603, 65, false);
#line 90 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml"
                                     Write(Url.Action("FillQuestionary", new { questionaryHeaderId = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(3668, 451, true);
                WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-success"">Попълни</a>';
                         return updButton;
                     },
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""id"",
                     ""render"": function (value) {
                         var updateUrl = '");
                EndContext();
                BeginContext(4120, 67, false);
#line 100 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Questionary\Index.cshtml"
                                     Write(Url.Action("QuestionaryResults",new { questionaryHeaderId = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(4187, 399, true);
                WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-danger"">Резултати</a>';
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
            BeginContext(4589, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
