#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a09998c6600732e0cb38a73074d15e8dc41898d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_PageLink_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/PageLink/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/PageLink/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_PageLink_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a09998c6600732e0cb38a73074d15e8dc41898d6", @"/Areas/Admin/Views/PageLink/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_PageLink_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PageLink>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
  
    var page = (Page)ViewBag.page;

    ViewData["Title"] = "Линкове към страница";

#line default
#line hidden
            BeginContext(124, 35, true);
            WriteLiteral("<section class=\"content\">\r\n    <h4>");
            EndContext();
            BeginContext(161, 10, false);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
    Write(page.Title);

#line default
#line hidden
            EndContext();
            BeginContext(172, 84, true);
            WriteLiteral("</h4>\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-6 col-md-12\">\r\n            ");
            EndContext();
            BeginContext(256, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "054a6925616044ca89d7458e9cd9db80", async() => {
                BeginContext(330, 6, true);
                WriteLiteral("Добави");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pageId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
                                       WriteLiteral(page.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(340, 367, true);
            WriteLiteral(@"
            &nbsp;&nbsp;
            <a href=""#"" onclick=""selectPage(); return false;"" class=""btn btn-warning""><i class=""fa fa-file""></i> Добави от подчинени на страница</a>
            <table class=""table"">
                <tr>
                    <th>Наименование</th>
                    <th>Линк</th>
                    <th></th>
                </tr>
");
            EndContext();
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(772, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(827, 10, false);
#line 23 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
                       Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(837, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(873, 9, false);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
                       Write(item.Href);

#line default
#line hidden
            EndContext();
            BeginContext(882, 65, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(947, 88, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4597044c4f69497aa74daf2c585d0366", async() => {
                BeginContext(1023, 8, true);
                WriteLiteral("Редакция");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 26 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
                                                   WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1035, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 29 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1114, 122, true);
            WriteLiteral("            </table>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n<script>\r\n    function selectPage() {\r\n        var url = \'");
            EndContext();
            BeginContext(1237, 124, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
              Write(Html.Raw(Url.Action("Select","Page",new { pageType = page.PageTypeId, callbackName = "callbackSelectPage", lang=page.Lang})));

#line default
#line hidden
            EndContext();
            BeginContext(1361, 216, true);
            WriteLiteral("\';\r\n        ShowPlainDialogFromAction(\'Избери страница, за добавяне на връзки към подчинените и елементи\', url);\r\n    }\r\n    function callbackSelectPage(data) {\r\n        $(\'.plainModal\').hide();\r\n        var _url = \'");
            EndContext();
            BeginContext(1578, 36, false);
#line 42 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
               Write(Url.Action("InsertFromSelectedPage"));

#line default
#line hidden
            EndContext();
            BeginContext(1614, 46, true);
            WriteLiteral("\';\r\n        var _data = {\r\n            pageId:");
            EndContext();
            BeginContext(1662, 7, false);
#line 44 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
               Write(page.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1670, 63, true);
            WriteLiteral(",\r\n            contentId: data.contentId,\r\n            lang : \'");
            EndContext();
            BeginContext(1735, 9, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\PageLink\Index.cshtml"
                Write(page.Lang);

#line default
#line hidden
            EndContext();
            BeginContext(1745, 169, true);
            WriteLiteral("\'\r\n        };\r\n        postContent(_url, _data, function () {\r\n            window.location.href = window.location.href.replace(\'#\',\'\');\r\n         });\r\n    }\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PageLink>> Html { get; private set; }
    }
}
#pragma warning restore 1591
