#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cade7a5612054d839e2f3db74ad310f3c4ccd7e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StrategicDocument_Index), @"mvc.1.0.view", @"/Views/StrategicDocument/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/StrategicDocument/Index.cshtml", typeof(AspNetCore.Views_StrategicDocument_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cade7a5612054d839e2f3db74ad310f3c4ccd7e7", @"/Views/StrategicDocument/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_StrategicDocument_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
  
    ViewData["Title"] = Localizer["MENU_STRATEGIC_DOCUMENTS"];
    ViewData["SectionTitle"] = ViewData["Title"];
    int munincipalityId = (int)(ViewBag.MunicipalityId ?? -1);

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(260, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 305, "\"", 339, 1);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
WriteAttributeValue("", 312, Url.Action("Index","Home"), 312, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(340, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(342, 22, false);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                           Write(Localizer["HOME_LINK"]);

#line default
#line hidden
                EndContext();
                BeginContext(364, 28, true);
                WriteLiteral("</a>\r\n        / <a href=\"#\">");
                EndContext();
                BeginContext(393, 37, false);
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                 Write(Localizer["MENU_STRATEGIC_DOCUMENTS"]);

#line default
#line hidden
                EndContext();
                BeginContext(430, 18, true);
                WriteLiteral("</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(451, 227, true);
            WriteLiteral("<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12 body cat-combos search-form-container\" >\r\n            <div class=\"form-group col-lg-2 col-md-4 col-sm-6\" >\r\n                <label>");
            EndContext();
            BeginContext(679, 38, false);
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                  Write(Localizer["SD_FILTER_MASTER_CATEGORY"]);

#line default
#line hidden
            EndContext();
            BeginContext(717, 26, true);
            WriteLiteral("</label>\r\n                ");
            EndContext();
            BeginContext(744, 119, false);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
           Write(Html.DropDownList("CategoryMasterId", (IEnumerable<SelectListItem>)ViewBag.catMasters, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(863, 124, true);
            WriteLiteral("\r\n            </div>\r\n            <div id=\"natCat\" class=\"form-group col-lg-2 col-md-4 col-sm-6\"  >\r\n                <label>");
            EndContext();
            BeginContext(988, 28, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                  Write(Localizer["FILTER_CATEGORY"]);

#line default
#line hidden
            EndContext();
            BeginContext(1016, 26, true);
            WriteLiteral("</label>\r\n                ");
            EndContext();
            BeginContext(1043, 114, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
           Write(Html.DropDownList("CategoryId", (IEnumerable<SelectListItem>)ViewBag.catNational, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1157, 173, true);
            WriteLiteral("\r\n            </div>\r\n            <div id=\"districtCat\">\r\n                <div id=\"districtCat\" class=\"form-group col-lg-2 col-md-4 col-sm-6\"  >\r\n                    <label>");
            EndContext();
            BeginContext(1331, 24, false);
#line 26 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                      Write(Localizer["FILTER_AREA"]);

#line default
#line hidden
            EndContext();
            BeginContext(1355, 30, true);
            WriteLiteral("</label>\r\n                    ");
            EndContext();
            BeginContext(1386, 114, false);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
               Write(Html.DropDownList("DistrictId", (IEnumerable<SelectListItem>)ViewBag.catDistrict, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 124, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group col-lg-2 col-md-4 col-sm-6\"  >\r\n                    <label>");
            EndContext();
            BeginContext(1625, 32, false);
#line 30 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                      Write(Localizer["FILTER_MUNICIPALITY"]);

#line default
#line hidden
            EndContext();
            BeginContext(1657, 30, true);
            WriteLiteral("</label>\r\n                    ");
            EndContext();
            BeginContext(1688, 100, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
               Write(Html.DropDownList("MunicipalityId", GlobalConstants.EmptyComboList, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1788, 136, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group col-lg-2 col-md-4 col-sm-6\"  >\r\n                <label>");
            EndContext();
            BeginContext(1925, 24, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                  Write(Localizer["FILTER_SHOW"]);

#line default
#line hidden
            EndContext();
            BeginContext(1949, 26, true);
            WriteLiteral("</label>\r\n                ");
            EndContext();
            BeginContext(1976, 114, false);
#line 36 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
           Write(Html.DropDownList("validState", (IEnumerable<SelectListItem>)ViewBag.validStates, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2090, 114, true);
            WriteLiteral("\r\n\r\n            </div>\r\n            <div class=\"form-group col-lg-3 col-md-4 col-sm-6\"  >\r\n                <label>");
            EndContext();
            BeginContext(2205, 27, false);
#line 40 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                  Write(Localizer["FILTER_BY_NAME"]);

#line default
#line hidden
            EndContext();
            BeginContext(2232, 26, true);
            WriteLiteral("</label>\r\n                ");
            EndContext();
            BeginContext(2259, 63, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
           Write(Html.TextBox("searchTerm", "", new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2322, 307, true);
            WriteLiteral(@"
            </div>
       
            <div class=""rss-export-search-form col-lg-1 col-md-1 col-sm-1""  >
             
                <table>
                    <tr>
                        <td>
                            <button type=""button"" class=""form-control btn btn-info"" onclick=""exp();"">");
            EndContext();
            BeginContext(2630, 29, false);
#line 49 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                                                                                Write(Localizer["SD_BUTTON_EXPORT"]);

#line default
#line hidden
            EndContext();
            BeginContext(2659, 122, true);
            WriteLiteral("</button>\r\n                   \r\n\r\n                        </td>\r\n                        <td style=\"padding-left:4px\">\r\n\r\n");
            EndContext();
#line 55 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                             if (ViewBag.RssLink != null)

                            {


#line default
#line hidden
            BeginContext(2875, 97, true);
            WriteLiteral("                                <div class=\'demopadding\'>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2972, "\"", 2995, 1);
#line 60 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
WriteAttributeValue("", 2979, ViewBag.RssLink, 2979, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2996, 158, true);
            WriteLiteral(" target=\"_blank\" id=\"rssLink\" title=\"RSS\"><div class=\'toplink-icon social rss\'><i class=\'fa fa-rss\'></i></div></a>\r\n\r\n                                </div>\r\n");
            EndContext();
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"

                            }

#line default
#line hidden
            BeginContext(3187, 308, true);
            WriteLiteral(@"                        </td>

                    </tr>
                </table>
                    
               
                
            </div>
        

        </div>
    </div>
    <table id=""mainTable"" class=""table"" cellspacing=""0""></table>
</div>
<div id=""popupDiv""></div>


");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(3512, 137, true);
                WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n            $(\'#CategoryMasterId\').change(function () {\r\n                if ($(this).val() === \'");
                EndContext();
                BeginContext(3650, 40, false);
#line 86 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                  Write(GlobalConstants.Categories.Type_National);

#line default
#line hidden
                EndContext();
                BeginContext(3690, 517, true);
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
                BeginContext(4208, 54, false);
#line 99 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                            Write(Url.Action("GetComboCategories","Ajax",new { area=""}));

#line default
#line hidden
                EndContext();
                BeginContext(4262, 47, true);
                WriteLiteral("\', { masterCat: $(this).val(), municipalityId: ");
                EndContext();
                BeginContext(4310, 15, false);
#line 99 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                                                                                                                                  Write(munincipalityId);

#line default
#line hidden
                EndContext();
                BeginContext(4325, 880, true);
                WriteLiteral(@"  });
            }).trigger('change');

            $('.cat-combos select').each(function (i, e) {
                $(e).change(function () {
                    setTimeout(function () {
                        updateRss();
                        setBreadcrumb();
                        dt.ajax.reload();
                    }, 100);
                });
            });
            $('.cat-combos #searchTerm').keyup(function () {
                if ($(this).val().length >= 3)
                    setTimeout(function () {
                        updateRss();
                        dt.ajax.reload();
                    }, 100);

            });


            var dt;
            setTimeout(function () {
                setBreadcrumb();
                dt = $('#mainTable').DataTable({
                    ""ajax"": {
                        ""url"": '");
                EndContext();
                BeginContext(5206, 22, false);
#line 126 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                           Write(Url.Action("LoadData"));

#line default
#line hidden
                EndContext();
                BeginContext(5228, 1303, true);
                WriteLiteral(@"',
                        data: function (d) {
                            d.categoryMasterId = $('#CategoryMasterId').val();
                            d.categoryId = $('#CategoryId').val();
                            if ($('#districtCat').is(':visible')) {
                                d.categoryId = $('#DistrictId').val();
                                d.municipalityId = $('#MunicipalityId').val();
                            }
                            d.validState = $('#validState').val();
                            d.searchTerm = $('#searchTerm').val();
                        },
                        ""type"": ""POST""
                    },
                    //""oLanguage"": {
                    //    ""sEmptyTable"": ""My Custom Message On Empty Table""
                    //},
                    fnDrawCallback: function (settings) {
                        $('.dataTables_paginate').toggle(settings.fnRecordsDisplay() > 0);
                    },
                    filter: fa");
                WriteLiteral(@"lse,
                    ""columns"": [
                        {
                            data: ""title"",
                            title: 'Наименование',
                            render: function (data, type, item, meta) {
                                var url = '");
                EndContext();
                BeginContext(6532, 36, false);
#line 151 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                      Write(Url.Action("View",new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(6568, 531, true);
                WriteLiteral(@"'.replace('666', item.id);
                                var btn = '<a href=""' + url + '"">' + item.title + '</a>';
                                return btn;
                            }
                        },
                 {
                     data: ""categoryText"",
                     name: ""categoryText"",
                     title: 'Категория',
                     className: ""dt-head-center"",
                      render: function (data, type, item, meta) {
                          var imgSrc = '");
                EndContext();
                BeginContext(7100, 37, false);
#line 162 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                   Write(Url.Content("~/img/categories/1.png"));

#line default
#line hidden
                EndContext();
                BeginContext(7137, 1645, true);
                WriteLiteral(@"'.replace('1.png', item.categoryImagePath);
                          var img = '<table><tr><td><div class=""tbl-img-cell""><img src=""' + imgSrc + '""></div></td><td align=left>' + item.categoryText+""</td></tr></table>"";
                          return img;
                     },
                     sortable: true
                 },
                        //{
                        //    data: ""createDate"",
                        //    title: 'Дата на публикуване',
                        //    orderDataType: 'date',
                        //    ""render"": function (value) {
                        //        return JsonBGdate(value);
                        //    }
                        //}
                        //
                        {
                            data: ""documentDate"",
                            title: 'Дата на приемане',
                            className: ""dt-head-center"",
                            render: function (data, type, item, meta) {
           ");
                WriteLiteral(@"                     {
                                    if (item.documentDate) {
                                        return JsonBGdate(item.documentDate);
                                    } else {
                                        return ""Не е указано"";
                                    }
                                }
                            }
                        },
                        {
                            data: ""validToText"",
                            className: ""dt-head-center"",
                            title: 'Валиден до'

                        }
");
                EndContext();
                BeginContext(9226, 616, true);
                WriteLiteral(@"                    ]

                });
            }, 200);

        function updateRss() {
                var el = $('#rssLink');
                var categoryMasterId = $('#CategoryMasterId').val();
            var categoryId = $('#CategoryId').val();
            var municipalityId = $('#MunicipalityId').val();
                if ($('#districtCat').is(':visible')) {
                    categoryId = $('#DistrictId').val();
                    //municipalityId = $('#MunicipalityId').val();
                }

                validState = $('#validState').val();

                var url = '");
                EndContext();
                BeginContext(9843, 36, false);
#line 224 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                      Write(Url.Action("GetDocumentFeed", "Rss"));

#line default
#line hidden
                EndContext();
                BeginContext(9879, 37, true);
                WriteLiteral("\' +\r\n                    \'?type=\' + \'");
                EndContext();
                BeginContext(9917, 30, false);
#line 225 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                           Write(RssFeedType.StrategicDocuments);

#line default
#line hidden
                EndContext();
                BeginContext(9947, 953, true);
                WriteLiteral(@"' +
                    '&categoryMasterId=' + categoryMasterId +
                    '&categoryId=' + categoryId +
                    '&municipalityId=' + municipalityId +
                    '&validState=' + validState;

                el.attr('href', url);
        }

        function setBreadcrumb() {
                var categoryMasterId = $('#CategoryMasterId').val();
                var categoryMasterText = $('#CategoryMasterId  option:selected').text();
                var categoryId = $('#CategoryId').val();
                var categoryText = $('#CategoryId  option:selected').text();
                var municipalityId = $('#MunicipalityId').val();
                var munincipalityText = $('#MunicipalityId  option:selected').text();
                var districtId = $('#DistrictId').val();
                var districtText = $('#DistrictId  option:selected').text();

            var initialBreadcrumb = '/ <a href=""");
                EndContext();
                BeginContext(10901, 26, false);
#line 244 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                           Write(Url.Action("Index","Home"));

#line default
#line hidden
                EndContext();
                BeginContext(10927, 24, true);
                WriteLiteral("\">Начало</a> / <a href=\"");
                EndContext();
                BeginContext(10952, 19, false);
#line 244 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                                                                                              Write(Url.Action("index"));

#line default
#line hidden
                EndContext();
                BeginContext(10971, 1407, true);
                WriteLiteral(@""">Стратегически документи</a>';
                var breadcrumb = initialBreadcrumb + generateBreadcrumbLink(categoryMasterText, categoryMasterId);

                if ($('#natCat').is(':visible')) {
                    if (categoryId > 0) {
                        breadcrumb += generateBreadcrumbLink(categoryText, categoryMasterId, categoryId);
                    }
                } else {
                    if (districtId > 0) {
                        breadcrumb += generateBreadcrumbLink(districtText, categoryMasterId, categoryId, districtId);
                        if (municipalityId != districtId) {
                            breadcrumb += generateBreadcrumbLink(munincipalityText, categoryMasterId, categoryId, districtId, municipalityId);
                        }
                    }
                }

                $('.breadcrumbs').html(breadcrumb);
            }

            function generateBreadcrumbLink(text, categoryMasterId, categoryId, districtId, municipalityId) {
   ");
                WriteLiteral(@"             var queryString = (categoryMasterId ? ('categoryMasterId=' + categoryMasterId) : '') +
                    (categoryId ? ('&categoryId=' + categoryId) : '') +
                        (districtId ? ('&districtId=' + districtId) : '') +
                            (municipalityId ? ('&municipalityId=' + municipalityId) : '');


                return ' / <a href=""");
                EndContext();
                BeginContext(12379, 19, false);
#line 270 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                               Write(Url.Action("Index"));

#line default
#line hidden
                EndContext();
                BeginContext(12398, 311, true);
                WriteLiteral(@"?' + queryString + '"">' + text + '</a>'
            }

        //dt.order([2, 'desc']).draw();
        //$('.dt-reload').click(function () {
        //    dt.ajax.reload();
        //});
    });



        function exp() {

            $.ajax({
                type: 'GET',
                url: '");
                EndContext();
                BeginContext(12710, 46, false);
#line 285 "C:\Projects\Strategy\newSingleSite\Domain\Views\StrategicDocument\Index.cshtml"
                 Write(Url.Action("ExportChoice","StrategicDocument"));

#line default
#line hidden
                EndContext();
                BeginContext(12756, 178, true);
                WriteLiteral("\',\r\n                success: function (data) {\r\n                        ShowDialog(\'Експорт\', data);\r\n                    }\r\n                });\r\n        }\r\n\r\n    </script>\r\n\r\n\r\n");
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