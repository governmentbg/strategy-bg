#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f87403529f64aee8dcdffc04a9aca1f570ff8a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_PCSubjects_ListPCSubjects), @"mvc.1.0.view", @"/Areas/Admin/Views/PCSubjects/ListPCSubjects.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/PCSubjects/ListPCSubjects.cshtml", typeof(AspNetCore.Areas_Admin_Views_PCSubjects_ListPCSubjects))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f87403529f64aee8dcdffc04a9aca1f570ff8a6", @"/Areas/Admin/Views/PCSubjects/ListPCSubjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_PCSubjects_ListPCSubjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddPCSubject", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
  
    ViewData["Title"] = "Списък на физическите и юридическите лица съгласно ЗНА";

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(111, 45, true);
                WriteLiteral("\r\n    <ul class=\"breadcrumb\">\r\n        <li><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 156, "\"", 190, 1);
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
WriteAttributeValue("", 163, Url.Action("Index","Home"), 163, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(191, 32, true);
                WriteLiteral(">Начало</a></li>\r\n        <li><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 223, "\"", 273, 1);
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
WriteAttributeValue("", 230, Url.Action("ListPCSubjects", "PCSubjects"), 230, 43, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(274, 38, true);
                WriteLiteral(">Списък на ФЛ/ЮЛ</a></li>\r\n    </ul>\r\n");
                EndContext();
            }
            );
            BeginContext(315, 66, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"pull-left\">\r\n        ");
            EndContext();
            BeginContext(381, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52203b75c7b64aa6a9d565a443463f75", async() => {
                BeginContext(443, 11, true);
                WriteLiteral("Добави лице");
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
            BeginContext(458, 197, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"search-form\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div>\r\n                    <span>Вид лице</span>\r\n                    ");
            EndContext();
            BeginContext(656, 129, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
               Write(Html.DropDownList("PCSubjectsTypeID", (IEnumerable<SelectListItem>)ViewBag.PCSubjectsTypeID_ddl, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(785, 107, true);
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    <span>Име</span>\r\n                    ");
            EndContext();
            BeginContext(893, 59, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
               Write(Html.TextBox("name", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(952, 155, true);
            WriteLiteral("\r\n                </div>\r\n                <div id=\"eik_div\">\r\n                    <div>\r\n                        <span>ЕИК</span>\r\n                        ");
            EndContext();
            BeginContext(1108, 58, false);
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
                   Write(Html.TextBox("eik", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1166, 393, true);
            WriteLiteral(@"
                    </div>
                </div>
                <div>
                    <span>&nbsp;</span>
                    <button type=""button"" class=""btn btn-primary dt-reload""><i class=""fa fa-search""></i> Търсене</button>
                </div>
            </div>
        </div>
    </div>

    <table id=""mainTable"" class=""table"" cellspacing=""0""></table>
</section>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1576, 166, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n         var dt  = $(\'#mainTable\').DataTable({\r\n             searching: false,\r\n             \"ajax\": {\r\n                 \"url\": \'");
                EndContext();
                BeginContext(1743, 32, false);
#line 49 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
                    Write(Url.Action("LoadDataPCSubjects"));

#line default
#line hidden
                EndContext();
                BeginContext(1775, 2159, true);
                WriteLiteral(@"',
                 data: function (d) {
                     d.name = $(""#name"").val();
                     d.eik = $(""#eik"").val();
                     d.pcSubjectsTypeID = $(""#PCSubjectsTypeID"").val();
                 },
                 ""type"": ""POST""
             },
             fnDrawCallback: function (settings) {
                 $(this).parent().toggle(settings.fnRecordsDisplay() > 0);
             },
             ""columns"": [
                 {
                     data: ""name"",
                     title: 'Име',
                     sortable: true,
                     searchable: true
                 },
                 {
                     data: ""isUL"",
                     title: 'Вид лице',
                     sortable: false,
                     searchable: false,
                     className: ""text-center"",
                     ""render"": function (value) {
                         return value == ""1"" ? 'ЮЛ' : 'ФЛ';
                     }
                 }");
                WriteLiteral(@",
                 {
                     data: ""eik"",
                     title: 'ЕИК',
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""datePayment"",
                     title: 'Дата на плащане',
                     sortable: true,
                     searchable: false,
                     ""render"": function (value) {
                         return JsonBGdate(value);
                     }
                 },
                 {
                     data: ""paymentValue"",
                     title: 'Възнаграждение за извършените дейности',
                     sortable: true,
                     searchable: false
                 },
                 {
                     data: ""activityDescription"",
                     title: 'Извършени дейности',
                     sortable: false,
                     searchable: false
                 },
                 {
                ");
                WriteLiteral("     data: \"id\",\r\n                     \"render\": function (value) {\r\n                         var updateUrl = \'");
                EndContext();
                BeginContext(3935, 46, false);
#line 107 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PCSubjects\ListPCSubjects.cshtml"
                                     Write(Url.Action("EditPCSubjects",new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(3981, 841, true);
                WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-warning"">Редакция</a>';
                         return updButton;
                     },
                     sortable: false,
                     searchable: false
                 }
             ],
        });

        $('button.dt-reload').click(function () {
            dt.ajax.reload();
        }).trigger('click');

        $('#PCSubjectsTypeID').change(function () {
            if ($('#PCSubjectsTypeID').val() == ""-1"" || $('#PCSubjectsTypeID').val() == ""1"") {
                $('#eik_div').show();
            }
            else {
                $('#eik_div').hide();
                $('#eik').val("""");
            }

            dt.ajax.reload();
        });

        });
    </script>

");
                EndContext();
            }
            );
            BeginContext(4825, 2, true);
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
