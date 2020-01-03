#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "694c10b847f1dbbcd2169577c0930076577fabba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_IndexOldWithGrid), @"mvc.1.0.view", @"/Views/News/IndexOldWithGrid.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/News/IndexOldWithGrid.cshtml", typeof(AspNetCore.Views_News_IndexOldWithGrid))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"694c10b847f1dbbcd2169577c0930076577fabba", @"/Views/News/IndexOldWithGrid.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_News_IndexOldWithGrid : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
  
    ViewData["Title"] = Localizer["MENU_NEWS"];
    ViewData["SectionTitle"] = ViewData["Title"];

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(181, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 226, "\"", 260, 1);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
WriteAttributeValue("", 233, Url.Action("Index","Home"), 233, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(261, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(263, 22, false);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                           Write(Localizer["HOME_LINK"]);

#line default
#line hidden
                EndContext();
                BeginContext(285, 18, true);
                WriteLiteral("</a>\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 303, "\"", 330, 1);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
WriteAttributeValue("", 310, Url.Action("Index"), 310, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(331, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(333, 17, false);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                    Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(350, 18, true);
                WriteLiteral("</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(371, 238, true);
            WriteLiteral("<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12 body cat-combos\">\r\n            <div class=\"form-group col-lg-4 col-md-4 col-sm-6\">\r\n                <label>Категория</label>\r\n                ");
            EndContext();
            BeginContext(610, 113, false);
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
           Write(Html.DropDownList("categoryId", (IEnumerable<SelectListItem>)ViewBag.categories, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(723, 146, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group col-lg-2 col-md-4 col-sm-6\">\r\n                <label>Заглавие</label>\r\n                ");
            EndContext();
            BeginContext(870, 63, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
           Write(Html.TextBox("searchTerm", "", new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(933, 128, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <section>\r\n        <div id=\"gridview\"></div>\r\n    </section>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1078, 437, true);
                WriteLiteral(@"
    <script>
        $(function () {
            $('.cat-combos select').change(function () {
                setBreadcrumb();
                LoadData();
            });
            $('.cat-combos input').keyup(function () {
                setBreadcrumb();
                LoadData();
            }).trigger('keyup');
        });
        function LoadData() {
            $('#gridview').gridView({
                url: '");
                EndContext();
                BeginContext(1517, 26, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                  Write(Url.Action("LoadDataGrid"));

#line default
#line hidden
                EndContext();
                BeginContext(1544, 278, true);
                WriteLiteral(@"',
                data: {
                    category: $('#categoryId').val(),
                    searchTerm: $('#searchTerm').val()
                },
                size_selector: false,
                size:8,
                filter: false,
                lang:'");
                EndContext();
                BeginContext(1823, 12, false);
#line 54 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                 Write(ViewBag.lang);

#line default
#line hidden
                EndContext();
                BeginContext(1835, 271, true);
                WriteLiteral(@"',
                template: '#newsTemplate',
                empty_text: 'Няма намерени елементи.'
            });

        }

        function setBreadcrumb() {
            var category = $('#categoryId').val();
            var initialBreadcrumb = '/ <a href=""");
                EndContext();
                BeginContext(2107, 26, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                           Write(Url.Action("Index","Home"));

#line default
#line hidden
                EndContext();
                BeginContext(2133, 2, true);
                WriteLiteral("\">");
                EndContext();
                BeginContext(2136, 22, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                                                        Write(Localizer["HOME_LINK"]);

#line default
#line hidden
                EndContext();
                BeginContext(2158, 16, true);
                WriteLiteral("</a> / <a href=\"");
                EndContext();
                BeginContext(2175, 19, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                                                                                               Write(Url.Action("Index"));

#line default
#line hidden
                EndContext();
                BeginContext(2194, 195, true);
                WriteLiteral("\">Новини</a>\';\r\n\r\n            if (category > 0) {\r\n                var categoryName = $(\'#categoryId  option:selected\').text();\r\n                var breadcrumb = initialBreadcrumb + \' / <a href=\"");
                EndContext();
                BeginContext(2390, 19, false);
#line 67 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                                             Write(Url.Action("Index"));

#line default
#line hidden
                EndContext();
                BeginContext(2409, 504, true);
                WriteLiteral(@"?category=' + category + '"">' + categoryName + '</a>';

                $('.breadcrumbs').html(breadcrumb);
            } else {
                $('.breadcrumbs').html(initialBreadcrumb);
            }
        }
    </script>
    <script type=""text/x-handlebars-template"" id=""newsTemplate"">
        <div class=""col-lg-3 col-md-4 col-sm-6 col-xs-12"">
            <article class=""article--news image--left"">
                <a {{#if isRss}} href=""{{rssPostLink}}"" target=""_blank"" {{else}} href=""");
                EndContext();
                BeginContext(2914, 18, false);
#line 78 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                                                                  Write(Url.Action("View"));

#line default
#line hidden
                EndContext();
                BeginContext(2932, 142, true);
                WriteLiteral("?id={{id}}\" {{/if}}>\r\n                    {{#if mainImageFileId}}\r\n                    <div class=\"image\">\r\n                        <img src=\"");
                EndContext();
                BeginContext(3075, 137, false);
#line 81 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                             Write(Html.Raw(Url.Action("ViewImage","FileCdn",new { area="",sourceType=GlobalConstants.SourceTypes.Library_ImagesThumbs,max=75})+"&sourceId"));

#line default
#line hidden
                EndContext();
                BeginContext(3212, 157, true);
                WriteLiteral("={{mainImageFileId}}\">\r\n                    </div>\r\n                    {{else}}\r\n                    <div class=\"image\">\r\n                        <img src=\"");
                EndContext();
                BeginContext(3370, 38, false);
#line 85 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                             Write(Url.Content("~/img/defaults/news.jpg"));

#line default
#line hidden
                EndContext();
                BeginContext(3408, 338, true);
                WriteLiteral(@""">
                    </div>
                    {{/if}}
                    <h4 class=""title"">
                        {{{title}}}
                    </h4>
                    <p class=""date"">{{eventDateTXT}}</p>
                </a>
                <p class=""type""><i class=""fa fa-folder"" title=""Категория""></i>&nbsp;<a href=""");
                EndContext();
                BeginContext(3747, 19, false);
#line 93 "C:\Projects\Strategy\newSingleSite\Domain\Views\News\IndexOldWithGrid.cshtml"
                                                                                        Write(Url.Action("Index"));

#line default
#line hidden
                EndContext();
                BeginContext(3766, 170, true);
                WriteLiteral("?category={{categoryId}}\" title=\"Преглед на всички новини в категория: {{categoryName}}\">{{categoryName}}</a></p>\r\n            </article>\r\n        </div>\r\n    </script>\r\n");
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
