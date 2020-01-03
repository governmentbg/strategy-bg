#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc7b6a21af0933614452dcd9c021debed77bcee4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MSprogram_Programs), @"mvc.1.0.view", @"/Views/MSprogram/Programs.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MSprogram/Programs.cshtml", typeof(AspNetCore.Views_MSprogram_Programs))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc7b6a21af0933614452dcd9c021debed77bcee4", @"/Views/MSprogram/Programs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_MSprogram_Programs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
  
  int programType = (int)(ViewBag.programType);
  switch (programType)
  {
      case GlobalConstants.MSProgramTypes.Zakonodatelna:
          ViewData["ProgramTitle"] = Localizer["MS_PROGRAM_LAW"];
          break;
      case GlobalConstants.MSProgramTypes.Operativna:
          ViewData["ProgramTitle"] = Localizer["MS_PROGRAM_OP"];
          break;
  }

  ViewData["Title"] = "Оценка на въздействието";
  ViewData["SectionTitle"] = ViewData["Title"];



#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(551, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 596, "\"", 630, 1);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
WriteAttributeValue("", 603, Url.Action("Index","Home"), 603, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(631, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(633, 22, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
                                           Write(Localizer["HOME_LINK"]);

#line default
#line hidden
                EndContext();
                BeginContext(655, 28, true);
                WriteLiteral("</a>\r\n        / <a href=\"#\">");
                EndContext();
                BeginContext(684, 24, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
                 Write(ViewData["ProgramTitle"]);

#line default
#line hidden
                EndContext();
                BeginContext(708, 18, true);
                WriteLiteral("</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(729, 112, true);
            WriteLiteral("\r\n<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-3\">\r\n            ");
            EndContext();
            BeginContext(842, 145, false);
#line 29 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
       Write(await Component.InvokeAsync("MasterPage", new { pageTypeId = GlobalConstants.PageTypes.OV, display = "menu", title = "Оценка на въздействието" }));

#line default
#line hidden
            EndContext();
            BeginContext(987, 264, true);
            WriteLiteral(@"
        </div>
        <div class=""col-lg-9"">
            <div class=""row"">
                <div class=""col-lg-12 body cat-combos search-form-container"">
                    <div class=""form-group col-lg-3 col-md-4 col-sm-6"">
                        <label>");
            EndContext();
            BeginContext(1252, 27, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
                          Write(Localizer["FILTER_BY_NAME"]);

#line default
#line hidden
            EndContext();
            BeginContext(1279, 34, true);
            WriteLiteral("</label>\r\n                        ");
            EndContext();
            BeginContext(1314, 63, false);
#line 36 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
                   Write(Html.TextBox("searchTerm", "", new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1377, 186, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1580, 517, true);
                WriteLiteral(@"
    <script>
        $(function () {


         $('.cat-combos #searchTerm').keyup(function () {
                if ($(this).val().length >= 3 || $(this).val() === '')
                    setTimeout(function () {
                    dt.ajax.reload();
                }, 100);

            });

            var dt;
            setTimeout(function () {
                //setBreadcrumb();
                dt  = $('#mainTable').DataTable({
                    ""ajax"": {
                        ""url"": '");
                EndContext();
                BeginContext(2098, 31, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
                           Write(Url.Action("LoadData_Programs"));

#line default
#line hidden
                EndContext();
                BeginContext(2129, 87, true);
                WriteLiteral("\',\r\n                 data: function (d) {\r\n                            d.programType = ");
                EndContext();
                BeginContext(2218, 11, false);
#line 65 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
                                        Write(programType);

#line default
#line hidden
                EndContext();
                BeginContext(2230, 751, true);
                WriteLiteral(@";
                            d.searchTerm = $('#searchTerm').val();
                        },
                 ""type"": ""POST""
                       },

             fnDrawCallback: function (settings) {
                 $('.dataTables_paginate').toggle(settings.fnRecordsDisplay() > 0);
                    },
                    filter: false,
                    //""order"": [[3, ""desc""]],
                    //responsive: true,
             ""columns"": [
                 {
                     data: ""title"",
                     name: 'Title',
                     title: 'Наименование',
                     ""width"":""50%"",
                     render: function (data, type, item, meta) {
                         var url = '");
                EndContext();
                BeginContext(2982, 40, false);
#line 84 "C:\Projects\Strategy\newSingleSite\Domain\Views\MSprogram\Programs.cshtml"
                               Write(Url.Action("Projects",new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(3022, 317, true);
                WriteLiteral(@"'.replace('666', item.id);
                         var content = '<a href=""' + url + '"">' + item.title + '</a>';
                         return content;
                     },
                     sortable: true
                 }
             ]
            }, 200);
    });
        });
    </script>

");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<CommonResources> Localizer { get; private set; }
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
