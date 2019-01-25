#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68d8b561412af22941ac15d14ebc7ac74bfb82e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Admin_ErrorLog), @"mvc.1.0.view", @"/Areas/Forums/Views/Admin/ErrorLog.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Admin/ErrorLog.cshtml", typeof(AspNetCore.Areas_Forums_Views_Admin_ErrorLog))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
#line 7 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\_ViewImports.cshtml"
using System.Threading.Tasks;

#line default
#line hidden
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\_ViewImports.cshtml"
using PopForums.Extensions;

#line default
#line hidden
#line 2 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\_ViewImports.cshtml"
using PopForums.Models;

#line default
#line hidden
#line 3 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\_ViewImports.cshtml"
using PopForums.Services;

#line default
#line hidden
#line 4 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\_ViewImports.cshtml"
using PopForums.Mvc.Areas.Forums.Controllers;

#line default
#line hidden
#line 5 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\_ViewImports.cshtml"
using PopForums.Mvc.Areas.Forums.Models;

#line default
#line hidden
#line 6 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\_ViewImports.cshtml"
using PopForums.Mvc.Areas.Forums.Services;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d8b561412af22941ac15d14ebc7ac74bfb82e7", @"/Areas/Forums/Views/Admin/ErrorLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Admin_ErrorLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ErrorLogEntry>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAllErrorLog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("actionName", "ErrorLog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("controllerName", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "pagination pagerLinks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteErrorLog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::PopForums.Mvc.Areas.Forums.TagHelpers.PagerLinksTagHelper __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
  
    ViewBag.PageTitle = PopForums.Resources.ErrorLog;
    Layout = "~/Areas/Forums/Views/Admin/AdminMaster.cshtml";

#line default
#line hidden
            BeginContext(148, 5, true);
            WriteLiteral("\n<h1>");
            EndContext();
            BeginContext(154, 28, false);
#line 7 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
Write(PopForums.Resources.ErrorLog);

#line default
#line hidden
            EndContext();
            BeginContext(182, 7, true);
            WriteLiteral("</h1>\n\n");
            EndContext();
            BeginContext(189, 160, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbcbdbbe38044814977f0638311858b0", async() => {
                BeginContext(240, 25, true);
                WriteLiteral("\n\t<p><input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 265, "\"", 309, 1);
#line 10 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
WriteAttributeValue("", 273, PopForums.Resources.DeleteAllErrors, 273, 36, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(310, 32, true);
                WriteLiteral(" class=\"btn btn-primary\" /></p>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(349, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            BeginContext(351, 148, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pf-pagerlinks", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6c4f6563bd2e427f9b782e58beccd5c0", async() => {
            }
            );
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper = CreateTagHelper<global::PopForums.Mvc.Areas.Forums.TagHelpers.PagerLinksTagHelper>();
            __tagHelperExecutionContext.Add(__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ActionName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ControllerName = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#line 13 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.PagerContext = ((PagerContext)ViewData["PagerContext"]);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("pagerContext", __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.PagerContext, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.Class = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(499, 2, true);
            WriteLiteral("\n\n");
            EndContext();
#line 15 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
 foreach(var error in Model) {


#line default
#line hidden
            BeginContext(533, 7, true);
            WriteLiteral("\t<p>\n\t\t");
            EndContext();
            BeginContext(540, 178, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1eb06d1a6ba49d08df6ab1d59ecd14b", async() => {
                BeginContext(588, 24, true);
                WriteLiteral("\n\t\t\t<input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 612, "\"", 647, 1);
#line 19 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
WriteAttributeValue("", 620, PopForums.Resources.Delete, 620, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(648, 27, true);
                WriteLiteral(" class=\"btn btn-primary\" />");
                EndContext();
                BeginContext(676, 32, false);
#line 19 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
                                                                                          Write(Html.Hidden("id", error.ErrorID));

#line default
#line hidden
                EndContext();
                BeginContext(708, 3, true);
                WriteLiteral("\n\t\t");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(718, 6, true);
            WriteLiteral("\n\t\t<b>");
            EndContext();
            BeginContext(725, 14, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
      Write(error.Severity);

#line default
#line hidden
            EndContext();
            BeginContext(739, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(742, 15, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
                       Write(error.TimeStamp);

#line default
#line hidden
            EndContext();
            BeginContext(757, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(761, 13, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
                                          Write(error.Message);

#line default
#line hidden
            EndContext();
            BeginContext(774, 11, true);
            WriteLiteral("</b>\n\t</p>\n");
            EndContext();
            BeginContext(786, 18, true);
            WriteLiteral("\t<p class=\"small\">");
            EndContext();
            BeginContext(805, 52, false);
#line 24 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
                Write(Html.Raw(error.StackTrace.Replace("\r\n", "<br />")));

#line default
#line hidden
            EndContext();
            BeginContext(857, 5, true);
            WriteLiteral("</p>\n");
            EndContext();
            BeginContext(863, 18, true);
            WriteLiteral("\t<p class=\"small\">");
            EndContext();
            BeginContext(882, 46, false);
#line 26 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"
                Write(Html.Raw(error.Data.Replace("\r\n", "<br />")));

#line default
#line hidden
            EndContext();
            BeginContext(928, 5, true);
            WriteLiteral("</p>\n");
            EndContext();
            BeginContext(934, 8, true);
            WriteLiteral("\t<hr />\n");
            EndContext();
#line 29 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ErrorLog.cshtml"

}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ErrorLogEntry>> Html { get; private set; }
    }
}
#pragma warning restore 1591
