#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6910560b095f95f35a00a58d23cf045420205648"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Article_View), @"mvc.1.0.view", @"/Views/Article/View.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Article/View.cshtml", typeof(AspNetCore.Views_Article_View))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6910560b095f95f35a00a58d23cf045420205648", @"/Views/Article/View.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Article_View : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ArticleVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_OgpAgenda", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_OgpLeftMenu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
  
    ViewData["SectionTitle"] = "Партньорство за открито управление";

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(116, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 161, "\"", 195, 1);
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
WriteAttributeValue("", 168, Url.Action("Index","Home"), 168, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(196, 25, true);
                WriteLiteral(">Начало</a>\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 221, "\"", 248, 1);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
WriteAttributeValue("", 228, Url.Action("Index"), 228, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(249, 35, true);
                WriteLiteral(">Новини и събития</a>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(287, 114, true);
            WriteLiteral("\r\n\r\n<div class=\"container-fluid information\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-3\">\r\n            ");
            EndContext();
            BeginContext(401, 29, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce27835bd8e34d62860e5bef27bd5abd", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(430, 61, true);
            WriteLiteral("\r\n        </div>\r\n\r\n        <div class=\"col-md-6 body\">\r\n\r\n\r\n");
            EndContext();
#line 22 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
             if (!string.IsNullOrEmpty(Model.MainImageFileId))
            {

#line default
#line hidden
            BeginContext(570, 69, true);
            WriteLiteral("                <div class=\"article-image\">\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 639, "\"", 737, 1);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
WriteAttributeValue("", 645, Html.Raw(Url.Action("ViewImage","FileCdn",new { area="",id=Model.MainImageFileId,max=400})), 645, 92, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(738, 29, true);
            WriteLiteral(" />\r\n                </div>\r\n");
            EndContext();
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
            }

#line default
#line hidden
            BeginContext(782, 34, true);
            WriteLiteral("            <h3>\r\n                ");
            EndContext();
            BeginContext(817, 21, false);
#line 29 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
           Write(Html.Raw(Model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(838, 55, true);
            WriteLiteral("\r\n            </h3>\r\n            <h4>\r\n                ");
            EndContext();
            BeginContext(894, 52, false);
#line 32 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
           Write(Model.EventDate.ToString(GlobalConstants.DateFormat));

#line default
#line hidden
            EndContext();
            BeginContext(946, 68, true);
            WriteLiteral("\r\n            </h4>\r\n            <p class=\"title\">\r\n                ");
            EndContext();
            BeginContext(1015, 23, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
           Write(Html.Raw(Model.Content));

#line default
#line hidden
            EndContext();
            BeginContext(1038, 32, true);
            WriteLiteral("\r\n            </p>\r\n            ");
            EndContext();
            BeginContext(1071, 122, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
       Write(await Component.InvokeAsync("FileList", new { sourceType = GlobalConstants.SourceTypes.Partnership, sourceId = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1193, 400, true);
            WriteLiteral(@"
            <!-- TABLE DATES -->
            <div class=""row"">
                <div class=""col-md-5"">
                    <table class=""table table-bordered table--dates table--stripped"">
                        <tbody>
                            <!-- LOOP -->
                            <tr>
                                <td>Последна промяна:</td>
                                <td>");
            EndContext();
            BeginContext(1594, 55, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
                               Write(Model.LastModified.ToString(GlobalConstants.DateFormat));

#line default
#line hidden
            EndContext();
            BeginContext(1649, 295, true);
            WriteLiteral(@"</td>
                            </tr>
                            <!-- END LOOP -->
                        </tbody>
                    </table>
                </div>
            </div>
            <!-- END TABLE DATES -->
        </div>
        <div class=""col-md-3"">
            ");
            EndContext();
            BeginContext(1944, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "512db20680fa440492873c3b2260cfc7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 56 "C:\Projects\Strategy\newSingleSite\Domain\Views\Article\View.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = ("91023");

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1994, 59, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- END COMMENTS -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ArticleVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
