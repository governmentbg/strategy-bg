#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d453e6d56c997ecc726060d66408cc5fe792ab06"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_Index), @"mvc.1.0.view", @"/Views/News/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/News/Index.cshtml", typeof(AspNetCore.Views_News_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d453e6d56c997ecc726060d66408cc5fe792ab06", @"/Views/News/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_News_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
  
    ViewData["Title"] = Localizer["MENU_NEWS"];
    ViewData["SectionTitle"] = ViewData["Title"];

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(181, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 226, "\"", 260, 1);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
WriteAttributeValue("", 233, Url.Action("Index","Home"), 233, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(261, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(263, 22, false);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                           Write(Localizer["HOME_LINK"]);

#line default
#line hidden
                EndContext();
                BeginContext(285, 18, true);
                WriteLiteral("</a>\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 303, "\"", 330, 1);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
WriteAttributeValue("", 310, Url.Action("Index"), 310, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(331, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(333, 17, false);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                    Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(350, 18, true);
                WriteLiteral("</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(371, 66, true);
            WriteLiteral("<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n");
            EndContext();
            BeginContext(563, 155, true);
            WriteLiteral("        <div class=\"col-md-12\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12 body cat-combos search-form-container round-right\">\r\n");
            EndContext();
            BeginContext(977, 74, true);
            WriteLiteral("                    <input type=\"hidden\" id=\"categoryId\" name=\"categoryId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1051, "\"", 1078, 1);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
WriteAttributeValue("", 1059, ViewBag.categoryID, 1059, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1079, 77, true);
            WriteLiteral(">\r\n                    <input type=\"hidden\" id=\"categoryNM\" name=\"categoryNM\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1156, "\"", 1185, 1);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
WriteAttributeValue("", 1164, ViewBag.categoryName, 1164, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1186, 166, true);
            WriteLiteral(">\r\n                    <div class=\"form-group col-lg-6 col-md-12 col-sm-12\">\r\n                        <label>Търсене по наименование</label>\r\n                        ");
            EndContext();
            BeginContext(1353, 63, false);
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                   Write(Html.TextBox("searchTerm", "", new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1416, 239, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <section>\r\n                <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n            </section>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1672, 700, true);
                WriteLiteral(@"
    <script>

        $(function () {
            var _dt;
            $('.cat-combos select').change(function () {
                setTimeout(function () {
                    setBreadcrumb();
                    _dt.ajax.reload();
                }, 100);
            });
            $('.cat-combos input').keyup(function () {
                setTimeout(function () {
                    setBreadcrumb();
                    _dt.ajax.reload();
                }, 100);
            });



            setTimeout(function () {
                setBreadcrumb();
                _dt  = $('#mainTable').DataTable({
                     ""ajax"": {
                         ""url"": '");
                EndContext();
                BeginContext(2373, 22, false);
#line 64 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                            Write(Url.Action("LoadData"));

#line default
#line hidden
                EndContext();
                BeginContext(2395, 905, true);
                WriteLiteral(@"',
                         data: function (d) {
                             d.categoryId = $('#categoryId').val();
                             d.searchTerm = $('#searchTerm').val();
                         },
                         ""type"": ""POST""
                     },
                     fnDrawCallback: function (settings) {
                         $('.dataTables_paginate').toggle(settings.fnRecordsDisplay() > 0);
                     },
                    filter: false,
                    ""pageLength"": 15,
                    ""order"": [[0, ""asc""]],
                     ""columns"": [
                         {
                             data: ""title"",
                             name: 'title',
                             title: 'Наименование',
                             render: function (data, type, item, meta) {
                                 var url = '");
                EndContext();
                BeginContext(3301, 36, false);
#line 83 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                       Write(Url.Action("View",new { id = "123"}));

#line default
#line hidden
                EndContext();
                BeginContext(3337, 681, true);
                WriteLiteral(@"'.replace('123', item.id);
                                 var target = '_self';
                                 if (item.rssPostLink) {
                                     url = item.rssPostLink;
                                     var target = '_blank';
                                 }
                                 var content = '<table><tr><td><a href=""' + url + '"" class=""dt-article-item"" target=""' + target+'"">' ;
                                 var textClass = """";
                                 if (item.mainImageFileId) {
                                     content += '<div class=""list-image"">';
                                     var imgUrl = '");
                EndContext();
                BeginContext(4019, 138, false);
#line 93 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                              Write(Html.Raw(Url.Action("ViewImage","FileCdn",new { area="",sourceType=GlobalConstants.SourceTypes.Library_ImagesThumbs,max=100})+"&sourceId"));

#line default
#line hidden
                EndContext();
                BeginContext(4157, 981, true);
                WriteLiteral(@"=' + item.mainImageFileId;
                                     content += '<img src=""' + imgUrl + '"" /></div></a></td><td><a href=""' + url + '"" class=""dt-article-item"">';
                                     textClass=""has-image"";
                                 }
                                 content += '<div class=""' + textClass + '"">' + unescape(item.title) + '</div>';
                                 content += '</a></td></tr></table>';

                                 return content;
                             },
                             sortable: true
                         },

                         {
                             data: ""categoryName"",
                             name: ""categoryName"",
                             title: 'Категория',
                             className: ""dt-head-center"",
                              render: function (data, type, item, meta) {
                                  var catUrl = '");
                EndContext();
                BeginContext(5140, 19, false);
#line 111 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                            Write(Url.Action("Index"));

#line default
#line hidden
                EndContext();
                BeginContext(5160, 554, true);
                WriteLiteral(@"?category='+item.categoryId;
                                  var a = '<a href=""' + catUrl + '"">&nbsp;' + item.categoryName;
                                  return a;
                             },
                             sortable: true
                         }
                        ]
                });
            }, 200);
        });
        function setBreadcrumb() {
            var category = $('#categoryId').val();
            var categoryName = $('#categoryNM').val();
            var initialBreadcrumb = '/ <a href=""");
                EndContext();
                BeginContext(5715, 26, false);
#line 124 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                           Write(Url.Action("Index","Home"));

#line default
#line hidden
                EndContext();
                BeginContext(5741, 2, true);
                WriteLiteral("\">");
                EndContext();
                BeginContext(5744, 22, false);
#line 124 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                                                        Write(Localizer["HOME_LINK"]);

#line default
#line hidden
                EndContext();
                BeginContext(5766, 16, true);
                WriteLiteral("</a> / <a href=\"");
                EndContext();
                BeginContext(5783, 19, false);
#line 124 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                                                                                               Write(Url.Action("Index"));

#line default
#line hidden
                EndContext();
                BeginContext(5802, 135, true);
                WriteLiteral("\">Новини</a>\';\r\n\r\n            if (category > 0) {\r\n                \r\n                var breadcrumb = initialBreadcrumb + \' / <a href=\"");
                EndContext();
                BeginContext(5938, 19, false);
#line 128 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\Index.cshtml"
                                                             Write(Url.Action("Index"));

#line default
#line hidden
                EndContext();
                BeginContext(5957, 236, true);
                WriteLiteral("?category=\' + category + \'\">\' + categoryName + \'</a>\';\r\n\r\n                $(\'.breadcrumbs\').html(breadcrumb);\r\n            } else {\r\n                $(\'.breadcrumbs\').html(initialBreadcrumb);\r\n            }\r\n        }\r\n    </script>\r\n\r\n");
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