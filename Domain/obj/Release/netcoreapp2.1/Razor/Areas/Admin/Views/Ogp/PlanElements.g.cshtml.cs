#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d91c1c312bc4cdb20ccdee24345c4044611d7512"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Ogp_PlanElements), @"mvc.1.0.view", @"/Areas/Admin/Views/Ogp/PlanElements.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Ogp/PlanElements.cshtml", typeof(AspNetCore.Areas_Admin_Views_Ogp_PlanElements))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
using Models.Context.Ogp;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d91c1c312bc4cdb20ccdee24345c4044611d7512", @"/Areas/Admin/Views/Ogp/PlanElements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Ogp_PlanElements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlanElements_Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
  
    ViewData["Title"] = "Елементи";
    NationalPlanElements parent = (NationalPlanElements)ViewBag.parent;
    if (parent != null)
    {
        ViewData["Title"] += " към " + parent.Title;
    }


#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(260, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
     if (parent != null)
    {

#line default
#line hidden
                BeginContext(295, 52, true);
                WriteLiteral("        <ul class=\"breadcrumb \">\r\n            <li><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 347, "\"", 381, 1);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
WriteAttributeValue("", 354, Url.Action("PlanElements"), 354, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(382, 63, true);
                WriteLiteral("><i class=\"fa fa-home\"></i> Начало</a></li>\r\n            <li><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 445, "\"", 504, 1);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
WriteAttributeValue("", 452, Url.Action("PlanElements_Edit",new { id=parent.Id}), 452, 52, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(505, 34, true);
                WriteLiteral("><i class=\"fa fa-arrow-left\"></i> ");
                EndContext();
                BeginContext(540, 12, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
                                                                                                           Write(parent.Title);

#line default
#line hidden
                EndContext();
                BeginContext(552, 26, true);
                WriteLiteral("</a></li>\r\n        </ul>\r\n");
                EndContext();
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
    }

#line default
#line hidden
            }
            );
            BeginContext(588, 64, true);
            WriteLiteral("<section class=\"content\">\r\n    <div class=\"pull-left\">\r\n        ");
            EndContext();
            BeginContext(652, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d928dba30514b42a2518f44af559826", async() => {
                BeginContext(757, 33, true);
                WriteLiteral("<i class=\"fa fa-plus\"></i> Добави");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-parentId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
                                                 WriteLiteral(ViewBag.parentId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["parentId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-parentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["parentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(794, 92, true);
            WriteLiteral("\r\n    </div>\r\n    <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(903, 130, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n        var dt = $(\'#mainTable\').DataTable({\r\n            \"ajax\": {\r\n                \"url\": \'");
                EndContext();
                BeginContext(1034, 35, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
                   Write(Url.Action("PlanElements_LoadData"));

#line default
#line hidden
                EndContext();
                BeginContext(1069, 76, true);
                WriteLiteral("\',\r\n                data: function (d) {\r\n                    d.parentId = \'");
                EndContext();
                BeginContext(1146, 16, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
                             Write(ViewBag.parentId);

#line default
#line hidden
                EndContext();
                BeginContext(1162, 781, true);
                WriteLiteral(@"';
                },
                ""type"": ""POST""
            },
            fnDrawCallback: function (settings) {
                $(this).parent().toggle(settings.fnRecordsDisplay() > 0);
            },
            ""columns"": [
                {
                    data: ""title"",
                    title: 'Наименование'
                },
                {
                    data: ""elementTypeName"",
                    title: 'Тип'
                },
                {
                    data: ""stateName"",
                    //orderData: ""stateId"",
                    title: 'Статус'
                },
                {
                    data: null,
                    ""render"": function (item) {
                        var subItemUrl = '");
                EndContext();
                BeginContext(1944, 51, false);
#line 57 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
                                     Write(Url.Action("PlanElements", new { parentId = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(1995, 213, true);
                WriteLiteral("\'.replace(\'666\', item.id);\r\n                        var subItemButton = \'<a href=\"\' + subItemUrl + \'\" class=\"btn btn-info\"><i class=\"fa fa-search\"></i> Под-елементи</a>\';\r\n                        var updateUrl = \'");
                EndContext();
                BeginContext(2209, 50, false);
#line 59 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Ogp\PlanElements.cshtml"
                                    Write(Url.Action("PlanElements_Edit", new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(2259, 346, true);
                WriteLiteral(@"'.replace('666', item.id);
                        var updButton = '&nbsp;&nbsp;<a href=""' + updateUrl + '"" class=""btn btn-warning"">Редакция</a>';
                        return subItemButton + updButton;
                    },
                    sortable: false
                }
            ]
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
