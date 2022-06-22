#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fe35ffa5666a9be7866228d4cb09c0bac7cd892"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fe35ffa5666a9be7866228d4cb09c0bac7cd892", @"/Views/PCSubjects/ListPCSubjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_PCSubjects_ListPCSubjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
  
    ViewData["Title"] = "Списък на изпълнители по ЗНА";
    ViewData["SectionTitle"] = ViewData["Title"];

#line default
#line hidden
            BeginContext(115, 35, true);
            WriteLiteral("<div class=\"breadcrumbs\">\r\n    / <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 150, "\"", 184, 1);
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
WriteAttributeValue("", 157, Url.Action("Index","Home"), 157, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(185, 421, true);
            WriteLiteral(@">Начало</a>
    / <a href=""#"">Списък на физическите и юридическите лица съгласно ЗНА</a>
</div>

<section class=""content"">
    <div class=""container-fluid information"">
        <div class=""row"">
            <div class=""col-md-12 body cat-combos search-form-container"">
                <div class=""form-group col-lg-2  col-lg-4 col-sm-6"">
                    <label>Тип на изпълнител</label>
                    ");
            EndContext();
            BeginContext(607, 129, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
               Write(Html.DropDownList("PCSubjectsTypeID", (IEnumerable<SelectListItem>)ViewBag.PCSubjectsTypeID_ddl, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(736, 172, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group col-lg-2  col-lg-4 col-sm-6\">\r\n                    <label>Търси по изпълнител</label>\r\n                    ");
            EndContext();
            BeginContext(909, 59, false);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
               Write(Html.TextBox("name", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(968, 213, true);
            WriteLiteral("\r\n                </div>\r\n                <div id=\"eik_div\">\r\n                    <div class=\"form-group col-lg-2  col-lg-4 col-sm-6\">\r\n                        <label>Търси по ЕИК</label>\r\n                        ");
            EndContext();
            BeginContext(1182, 58, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
                   Write(Html.TextBox("eik", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1240, 222, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div>\r\n                    <div class=\"form-group col-lg-3  col-lg-5 col-sm-7\">\r\n                        <label>&nbsp;</label>\r\n                        ");
            EndContext();
            BeginContext(1463, 154, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
                   Write(Html.ActionLink("Справка на всички изпълнители", "PCSubjectsPDF", "PCSubjects", null, new { @class = "form-control btn btn-default" , @target = "_blank"}));

#line default
#line hidden
            EndContext();
            BeginContext(1617, 182, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1816, 163, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n        var dt = $(\'#mainTable\').DataTable({\r\n            searching: false,\r\n             \"ajax\": {\r\n                 \"url\": \'");
                EndContext();
                BeginContext(1980, 32, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
                    Write(Url.Action("LoadDataPCSubjects"));

#line default
#line hidden
                EndContext();
                BeginContext(2012, 693, true);
                WriteLiteral(@"',
                 data: function (d) {
                     d.name = $(""#name"").val();
                     d.eik = $(""#eik"").val();
                     d.pcSubjectsTypeID = $(""#PCSubjectsTypeID"").val();
                 },
                 ""type"": ""POST""
             },
             fnDrawCallback: function (settings) {
                 $('.dataTables_paginate').toggle(settings.fnRecordsDisplay() > 0);
             },
            filter: false,
            ""columns"": [

                {
                     data: ""name"",
                     title: 'Изпълнител',
                     render: function (data, type, item, meta) {
                         var url = '");
                EndContext();
                BeginContext(2706, 36, false);
#line 64 "C:\Projects\Strategy\newSingleSite\Domain\Views\PCSubjects\ListPCSubjects.cshtml"
                               Write(Url.Action("View",new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(2742, 3517, true);
                WriteLiteral(@"'.replace('666', item.id);
                         var btn = '<a href=""' + url + '"">' + item.name + '</a>';
                         return btn;

                         }

                 },
                 {
                     data: ""isUL"",
                     title: 'ЮЛ / ФЛ',
                     sortable: false,
                     searchable: false,
                     className: ""text-center"",
                     ""render"": function (value) {
                         return value == ""1"" ? 'ЮЛ' : 'ФЛ';
                     }
                },
                {
                    data: ""contractingAuthority"",
                    title: 'Възложител',
                    sortable: true,
                    searchable: false
                },
                 //{
                 //    data: ""eik"",
                 //    title: 'ЕИК',
                 //    sortable: false,
                 //    searchable: false
                 //},
                 {
           ");
                WriteLiteral(@"          data: ""datePayment"",
                     title: 'Дата на договор',
                     sortable: true,
                     searchable: false,
                     ""render"": function (value) {
                         return JsonBGdate(value);
                     }
                 },
                 {
                     data: ""paymentValue"",
                     title: 'Цена на договора',
                     sortable: true,
                     searchable: false,
                     className: ""text-right"",
                 },
                 //{
                 //    data: ""paymentValue"",
                 //    title: 'с ДДС',
                 //    sortable: true,
                 //    searchable: false,
                 //    className: ""text-center"",
                 //    ""render"": function (value) {
                 //        return value == ""1"" ? 'ДА' : 'НЕ';
                 //    }
                 //},
                 //{
                 //    data: ");
                WriteLiteral(@"""activityDescription"",
                 //    title: 'Описание на извършените услуги',
                 //    sortable: false,
                 //    searchable: false
                 ////},
                 {
                     data: ""filesForDownload"",
                     title: 'Файл',
                     sortable: false,
                     searchable: false,
                     ""render"": function (value) {
                         return value;
                     }

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
");
                WriteLiteral(@"
        $('#name').keyup(function () {
            if ($(this).val().length >= 3)
                setTimeout(function () {
                    dt.ajax.reload();
                }, 100);

        });

        $('#eik').keyup(function () {
            if ($(this).val().length >= 3)
                setTimeout(function () {
                    dt.ajax.reload();
                }, 100);

        });

        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(6262, 2, true);
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