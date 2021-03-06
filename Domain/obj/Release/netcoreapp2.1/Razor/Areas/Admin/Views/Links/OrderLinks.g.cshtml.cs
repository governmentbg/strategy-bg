#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7537ef309e04dd34cf57280f7d4e48e7c5b529e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Links_OrderLinks), @"mvc.1.0.view", @"/Areas/Admin/Views/Links/OrderLinks.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Links/OrderLinks.cshtml", typeof(AspNetCore.Areas_Admin_Views_Links_OrderLinks))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7537ef309e04dd34cf57280f7d4e48e7c5b529e", @"/Areas/Admin/Views/Links/OrderLinks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Links_OrderLinks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
  
    ViewData["Title"] = "Подреди връзки";
    int lang = ViewBag.lang;

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(101, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 146, "\"", 180, 1);
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
WriteAttributeValue("", 153, Url.Action("Index","Home"), 153, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(181, 25, true);
                WriteLiteral(">Начало</a>\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 206, "\"", 246, 1);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
WriteAttributeValue("", 213, Url.Action("ListLinks", "Links"), 213, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(247, 34, true);
                WriteLiteral(">Списък с връзки</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(284, 64, true);
            WriteLiteral("<div>\r\n    &nbsp;&nbsp;\r\n    <span>Категория връзки</span>\r\n    ");
            EndContext();
            BeginContext(349, 127, false);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
Write(Html.DropDownList("LinksCategoryID", (IEnumerable<SelectListItem>)ViewBag.LinksCategoryID_ddl, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(476, 119, true);
            WriteLiteral("\r\n</div>\r\n\r\n<section class=\"content\">\r\n    <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n</section>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(612, 179, true);
                WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n            var dt = $(\'#mainTable\').DataTable({\r\n                \"bSort\": false,\r\n                \"ajax\": {\r\n                    \"url\": \'");
                EndContext();
                BeginContext(792, 27, false);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
                       Write(Url.Action("LoadDataLinks"));

#line default
#line hidden
                EndContext();
                BeginContext(819, 192, true);
                WriteLiteral("\',\r\n                    data: function (d) {\r\n                        d.linksCategoryId = $(\"#LinksCategoryID\").val();\r\n                        d.active = 1;\r\n                        d.lang = ");
                EndContext();
                BeginContext(1012, 12, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
                            Write(ViewBag.lang);

#line default
#line hidden
                EndContext();
                BeginContext(1024, 635, true);
                WriteLiteral(@";
                    },
                    ""type"": ""POST""
                },
                fnDrawCallback: function (settings) {
                    $(this).parent().toggle(settings.fnRecordsDisplay() > 0);
                },
                ""columns"": [
                    {
                        data: ""title"",
                        title: 'Име',
                        sortable: true,
                        searchable: true
                    },
                    {
                        data: ""id"",
                        ""render"": function (value) {
                            var updateUrl = '");
                EndContext();
                BeginContext(1660, 68, false);
#line 48 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
                                        Write(Url.Action("OrderLinksUp", new { id = "666", lang = @ViewBag.lang }));

#line default
#line hidden
                EndContext();
                BeginContext(1728, 487, true);
                WriteLiteral(@"'.replace('666', value);
                            var updButton = '<a href=""' + updateUrl + '"" class=""glyphicon glyphicon-arrow-up""></a>';
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
                BeginContext(2216, 70, false);
#line 58 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Links\OrderLinks.cshtml"
                                        Write(Url.Action("OrderLinksDown", new { id = "666", lang = @ViewBag.lang }));

#line default
#line hidden
                EndContext();
                BeginContext(2286, 506, true);
                WriteLiteral(@"'.replace('666', value);
                            var updButton = '<a href=""' + updateUrl + '"" class=""glyphicon glyphicon-arrow-down""></a>';
                            return updButton;
                        },
                        sortable: false,
                        searchable: false
                    }
                ],
            });

            $('#LinksCategoryID').change(function () {
                dt.ajax.reload();
            });

        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(2795, 2, true);
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
