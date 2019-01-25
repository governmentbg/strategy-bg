#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee709b89a98c5802ab44640f189496be5341548e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PCSubjects_ListPCSubjects), @"mvc.1.0.view", @"/Views/PCSubjects/ListPCSubjects.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PCSubjects/ListPCSubjects.cshtml", typeof(AspNetCore.Views_PCSubjects_ListPCSubjects))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee709b89a98c5802ab44640f189496be5341548e", @"/Views/PCSubjects/ListPCSubjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a9a60c20537480d66fd9d2d41d1eec08c8ef00", @"/Views/_ViewImports.cshtml")]
    public class Views_PCSubjects_ListPCSubjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
  
    ViewData["Title"] = "Списък на физическите и юридическите лица съгласно ЗНА";

#line default
#line hidden
            BeginContext(90, 35, true);
            WriteLiteral("<div class=\"breadcrumbs\">\r\n    / <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 125, "\"", 159, 1);
#line 5 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
WriteAttributeValue("", 132, Url.Action("Index","Home"), 132, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(160, 309, true);
            WriteLiteral(@">Начало</a>
    / <a href=""#"">Списък на физическите и юридическите лица съгласно ЗНА</a>
</div>

<section class=""content"">
    <div class=""search-form"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div>
                    <span>Вид лице</span>
                    ");
            EndContext();
            BeginContext(470, 129, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
               Write(Html.DropDownList("PCSubjectsTypeID", (IEnumerable<SelectListItem>)ViewBag.PCSubjectsTypeID_ddl, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(599, 107, true);
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    <span>Име</span>\r\n                    ");
            EndContext();
            BeginContext(707, 59, false);
#line 19 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
               Write(Html.TextBox("name", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(766, 155, true);
            WriteLiteral("\r\n                </div>\r\n                <div id=\"eik_div\">\r\n                    <div>\r\n                        <span>ЕИК</span>\r\n                        ");
            EndContext();
            BeginContext(922, 58, false);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
                   Write(Html.TextBox("eik", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(980, 349, true);
            WriteLiteral(@"
                    </div>
                </div>
                <div>
                    <span>&nbsp;</span>
                    <button type=""button"" class=""btn btn-primary dt-reload""><i class=""fa fa-search""></i> Търсене</button>
                </div>
                <div>
                    <span>&nbsp;</span>
                    ");
            EndContext();
            BeginContext(1330, 103, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
               Write(Html.ActionLink("PDF eкспорт", "PCSubjectsPDF", "PCSubjects", null, new { @class = "btn btn-default" }));

#line default
#line hidden
            EndContext();
            BeginContext(1433, 154, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1604, 163, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n        var dt = $(\'#mainTable\').DataTable({\r\n            searching: false,\r\n             \"ajax\": {\r\n                 \"url\": \'");
                EndContext();
                BeginContext(1768, 32, false);
#line 47 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
                    Write(Url.Action("LoadDataPCSubjects"));

#line default
#line hidden
                EndContext();
                BeginContext(1800, 2548, true);
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
                     sortable: false,
                     searchable: false
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
                ");
                WriteLiteral(@" },
                 {
                     data: ""eik"",
                     title: 'ЕИК',
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""datePayment"",
                     title: 'Дата на плащане',
                     sortable: false,
                     searchable: false,
                     ""render"": function (value) {
                         return JsonBGdate(value);
                     }
                 },
                 {
                     data: ""paymentValue"",
                     title: 'Възнаграждение за извършените дейности',
                     sortable: false,
                     searchable: false
                 },
                 {
                     data: ""activityDescription"",
                     title: 'Извършени дейности',
                     sortable: false,
                     searchable: false
                 }
             ],
        });

 ");
                WriteLiteral(@"       $('button.dt-reload').click(function () {
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
            BeginContext(4351, 2, true);
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
