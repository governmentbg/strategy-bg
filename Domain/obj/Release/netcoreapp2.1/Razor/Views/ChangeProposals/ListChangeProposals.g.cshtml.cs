#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f3ed665e78a01f1c9fd0e18274982098c29017a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ChangeProposals_ListChangeProposals), @"mvc.1.0.view", @"/Views/ChangeProposals/ListChangeProposals.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ChangeProposals/ListChangeProposals.cshtml", typeof(AspNetCore.Views_ChangeProposals_ListChangeProposals))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f3ed665e78a01f1c9fd0e18274982098c29017a", @"/Views/ChangeProposals/ListChangeProposals.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7a9a60c20537480d66fd9d2d41d1eec08c8ef00", @"/Views/_ViewImports.cshtml")]
    public class Views_ChangeProposals_ListChangeProposals : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Models.ViewModels.ChangeProposalsListViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
  
    ViewData["Title"] = "Списък със законодателни инициативи";
    ViewData["SectionTitle"] = ViewData["Title"];

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(204, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 249, "\"", 284, 1);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
WriteAttributeValue("", 256, Url.Action("Index", "Home"), 256, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(285, 25, true);
                WriteLiteral(">Начало</a>\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 310, "\"", 370, 1);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
WriteAttributeValue("", 317, Url.Action("ListChangeProposals", "ChangeProposals"), 317, 53, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(371, 54, true);
                WriteLiteral(">Списък със законодателни инициативи</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(428, 226, true);
            WriteLiteral("\r\n<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12 body\">\r\n            <div class=\"form-group col-lg-2  col-lg-2 col-sm-2\">\r\n                <label>Група</label>\r\n                ");
            EndContext();
            BeginContext(655, 119, false);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
           Write(Html.DropDownList("CategoryMasterId", (IEnumerable<SelectListItem>)ViewBag.catMasters, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(774, 158, true);
            WriteLiteral("\r\n            </div>\r\n            <div id=\"natCat\" class=\"form-group col-lg-2  col-lg-2 col-sm-3\">\r\n                <label>Категория</label>\r\n                ");
            EndContext();
            BeginContext(933, 114, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
           Write(Html.DropDownList("CategoryId", (IEnumerable<SelectListItem>)ViewBag.catNational, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1047, 210, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div id=\"districtCat\">\r\n                <div id=\"districtCat\" class=\"form-group col-lg-2  col-lg-2 col-sm-3\">\r\n                    <label>Област</label>\r\n                    ");
            EndContext();
            BeginContext(1258, 114, false);
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
               Write(Html.DropDownList("DistrictId", (IEnumerable<SelectListItem>)ViewBag.catDistrict, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1372, 159, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group col-lg-3  col-lg-2 col-sm-3\">\r\n                    <label>Община</label>\r\n                    ");
            EndContext();
            BeginContext(1532, 130, false);
#line 32 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
               Write(Html.DropDownList("MunicipalityId", (IEnumerable<SelectListItem>)@GlobalConstants.EmptyComboList, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1662, 568, true);
            WriteLiteral(@"
                </div>
            </div>

            <div class=""form-group col-lg-1  col-lg-1 col-sm-1"">
                <label>&nbsp; </label>
                <button type=""submit"" class=""form-control btn btn-primary dt-reload""><i class=""fa fa-search""></i> Търсене</button>
            </div>
        </div>
    </div>
    <table id=""mainTable"" class=""table"" cellspacing=""0""></table>
</div>

<script>
    $(function () {
        var dt = $('#mainTable').DataTable({
             searching: false,
             ""ajax"": {
                 ""url"": '");
            EndContext();
            BeginContext(2231, 37, false);
#line 50 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
                    Write(Url.Action("LoadDataChangeProposals"));

#line default
#line hidden
            EndContext();
            BeginContext(2268, 2274, true);
            WriteLiteral(@"',
                 data: function (d) {
                     d.categoryId = GetCategoryId();
                     d.isMunicipality = IsMunicipality();
                 },
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
                     data: ""categoryName"",
                     title: 'Категория/Община',
                     sortable: true,
                     searchable: true
                 },
                 {
                     data: ""dateCreated"",
                     title: 'Дата на създаване',
                     sortable: true,
                     searchable: false,
                     ""rend");
            WriteLiteral(@"er"": function (value) {
                         return JsonBGdate(value);
                     }
                 },
                 {
                     data: ""isActive"",
                     title: 'Активнa',
                     sortable: true,
                     searchable: false,
                     className: ""text-center"",
                     ""render"": function (value) {
                         return value == ""1"" ? 'ДА' : 'НЕ';
                     }
                 },
                 {
                     data: ""isRejected"",
                     title: 'Отказана',
                     sortable: true,
                     searchable: false,
                     className: ""text-center"",
                     ""render"": function (value) {
                         return value == ""1"" ? 'ДА' : 'НЕ';
                     }
                 },
                 {
                     data: ""adminRemark"",
                     title: 'Причина за отказ',
                   ");
            WriteLiteral("  sortable: true,\r\n                     searchable: true\r\n                 },\r\n                 {\r\n                     data: \"id\",\r\n                     \"render\": function (value) {\r\n                         var updateUrl = \'");
            EndContext();
            BeginContext(4543, 52, false);
#line 111 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
                                     Write(Url.Action("ViewChangeProposals", new { id = "666"}));

#line default
#line hidden
            EndContext();
            BeginContext(4595, 517, true);
            WriteLiteral(@"'.replace('666', value);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-info"">Преглед</a>';
                         return updButton;
                     },
                     sortable: false,
                     searchable: false
                 }
             ],
        });

        $('button.dt-reload').click(function () {
            dt.ajax.reload();
        });

        $('#CategoryMasterId').change(function () {
            if ($(this).val() === '");
            EndContext();
            BeginContext(5113, 38, false);
#line 126 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
                              Write(GlobalConstants.Category.Type_National);

#line default
#line hidden
            EndContext();
            BeginContext(5151, 467, true);
            WriteLiteral(@"') {
                $('#natCat').show();
                $('#districtCat').hide();
            } else {
                $('#natCat').hide();
                $('#districtCat').show();
            }
        }).trigger('change');

        $('#DistrictId').change(function () {
            if ($(this).val() === '-1') {
                $('#MunicipalityId').html('');
                return false;
            }
            requestCombo('#MunicipalityId', '");
            EndContext();
            BeginContext(5619, 54, false);
#line 140 "C:\Projects\Strategy\newSingleSite\Domain\Views\ChangeProposals\ListChangeProposals.cshtml"
                                        Write(Url.Action("GetComboCategories","Ajax",new { area=""}));

#line default
#line hidden
            EndContext();
            BeginContext(5673, 937, true);
            WriteLiteral(@"', { masterCat: $(this).val() });
        }).trigger('change');

        function GetCategoryId() {
            if ($('#natCat').is("":visible"")) {
                return $(""#CategoryId"").val();
            }
            else if ($(""#DistrictId"").val() == ""-1"") {
                return ""-1"";
            }
            else if ($(""#DistrictId"").val() == $(""#MunicipalityId"").val()) {
                return ""-"" + $(""#MunicipalityId"").val();
            }
            else {
                return $(""#MunicipalityId"").val();
            }
        }

        function IsMunicipality() {
            if ($('#natCat').is("":hidden"")) {
                return true;
            }
            else {
                return false;
            }
        }
    });
</script>

<style>
    .plainModal-content {
        left: 30% !important;
        top: 20% !important;
        width: 40% !important;
    }

    ");
            EndContext();
            BeginContext(6611, 212, true);
            WriteLiteral("@media screen and (max-width: 800px) {\r\n        .plainModal-content {\r\n            left: 10% !important;\r\n            top: 10% !important;\r\n            width: 80% !important;\r\n        }\r\n    }\r\n</style>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Models.ViewModels.ChangeProposalsListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591