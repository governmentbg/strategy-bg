#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1260f0909b14254130b2acae4ae54e385e7c8a45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Forums/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Forums_Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1260f0909b14254130b2acae4ae54e385e7c8a45", @"/Areas/Forums/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategorizedForumContainer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkAllForumsRead", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Forum", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("imagePath", "/lib/PopForums/", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::PopForums.Mvc.Areas.Forums.TagHelpers.ForumReadIndicatorTagHelper __PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
  
    ViewBag.Title = Model.ForumTitle;
    Layout = "~/Areas/Forums/Views/Shared/PopForumsMaster.cshtml";
    var user = UserRetrievalShim.GetUser(Context);
    var profile = UserRetrievalShim.GetProfile(Context);


#line default
#line hidden
            BeginContext(360, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Днес обществото решава";
    ViewData["SectionTitle"] = ViewData["Title"];

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(492, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 537, "\"", 571, 1);
#line 18 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
WriteAttributeValue("", 544, Url.Action("Index","Home"), 544, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(572, 63, true);
                WriteLiteral(">Начало</a>\r\n        / <a href=\"#\">Днес обществото решава</a>\r\n");
                EndContext();
#line 20 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
         if (ViewBag.category > 0)
        {
            

#line default
#line hidden
                BeginContext(700, 3, true);
                WriteLiteral(" / ");
                EndContext();
                BeginContext(704, 20, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                Write(ViewBag.categoryName);

#line default
#line hidden
                EndContext();
#line 22 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                 
        }

#line default
#line hidden
                BeginContext(744, 12, true);
                WriteLiteral("    </div>\r\n");
                EndContext();
            }
            );
            DefineSection("HeaderContent", async() => {
                BeginContext(782, 128, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(function () {\r\n            PopForums.homeSetup();\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(913, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
 if (user != null)
{

#line default
#line hidden
            BeginContext(1012, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1016, 201, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a09c5463ab434803ae31d6799d51c42a", async() => {
                BeginContext(1100, 30, true);
                WriteLiteral("\r\n        <input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1130, "\"", 1176, 1);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
WriteAttributeValue("", 1138, PopForums.Resources.MarkAllForumsRead, 1138, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1177, 33, true);
                WriteLiteral(" class=\"btn btn-primary\" />\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 40 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = false;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1217, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 43 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1222, 58, true);
            WriteLiteral("\r\n<table class=\"table dataTable no-footer\">\r\n    <tbody>\r\n");
            EndContext();
#line 60 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
         foreach (var category in Model.CategoryDictionary)
        {

#line default
#line hidden
            BeginContext(2561, 69, true);
            WriteLiteral("            <tr class=\"bg-primary\">\r\n                <td colspan=\"2\">");
            EndContext();
            BeginContext(2631, 18, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                           Write(category.Key.Title);

#line default
#line hidden
            EndContext();
            BeginContext(2649, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 65 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
            foreach (var forum in category.Value)
            {

#line default
#line hidden
            BeginContext(2741, 34, true);
            WriteLiteral("                <tr data-forumid=\"");
            EndContext();
            BeginContext(2776, 13, false);
#line 67 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                             Write(forum.ForumID);

#line default
#line hidden
            EndContext();
            BeginContext(2789, 49, true);
            WriteLiteral("\">\r\n                    <td class=\"newIndicator\">");
            EndContext();
            BeginContext(2838, 187, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "719242ccfab24d329bcce5fca829a69b", async() => {
                BeginContext(2918, 103, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pf-forumReadIndicator", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "28ad22897acb4185bcae36200d958faa", async() => {
                }
                );
                __PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper = CreateTagHelper<global::PopForums.Mvc.Areas.Forums.TagHelpers.ForumReadIndicatorTagHelper>();
                __tagHelperExecutionContext.Add(__PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper);
#line 68 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper.Forum = forum;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("forum", __PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper.Forum, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 68 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper.CategorizedForumContainer = Model;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("categorizedForumContainer", __PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper.CategorizedForumContainer, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __PopForums_Mvc_Areas_Forums_TagHelpers_ForumReadIndicatorTagHelper.ImagePath = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-urlName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 68 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                 WriteLiteral(forum.UrlName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["urlName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-urlName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["urlName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3025, 57, true);
            WriteLiteral("</td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3082, 147, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ae50d688bd44c56b21d458d12590bd1", async() => {
                BeginContext(3162, 47, true);
                WriteLiteral("<p class=\"section col-lg-3 col-md-6 col-sm-12\">");
                EndContext();
                BeginContext(3210, 11, false);
#line 70 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                  Write(forum.Title);

#line default
#line hidden
                EndContext();
                BeginContext(3221, 4, true);
                WriteLiteral("</p>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-urlName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 70 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                            WriteLiteral(forum.UrlName);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["urlName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-urlName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["urlName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3229, 29, true);
            WriteLiteral("\r\n                        <p>");
            EndContext();
            BeginContext(3259, 17, false);
#line 71 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                      Write(forum.Description);

#line default
#line hidden
            EndContext();
            BeginContext(3276, 99, true);
            WriteLiteral("</p>\r\n                        <small class=\"pull-right forumDetails\">\r\n                            ");
            EndContext();
            BeginContext(3376, 26, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                       Write(PopForums.Resources.Topics);

#line default
#line hidden
            EndContext();
            BeginContext(3402, 32, true);
            WriteLiteral(": <span @*class=\"topicCount\" *@>");
            EndContext();
            BeginContext(3435, 31, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                  Write(forum.TopicCount.ToString("N0"));

#line default
#line hidden
            EndContext();
            BeginContext(3466, 10, true);
            WriteLiteral("</span> | ");
            EndContext();
            BeginContext(3477, 25, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                            Write(PopForums.Resources.Posts);

#line default
#line hidden
            EndContext();
            BeginContext(3502, 26, true);
            WriteLiteral(": <span class=\"postCount\">");
            EndContext();
            BeginContext(3529, 30, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                                                Write(forum.PostCount.ToString("N0"));

#line default
#line hidden
            EndContext();
            BeginContext(3559, 10, true);
            WriteLiteral("</span> | ");
            EndContext();
            BeginContext(3570, 24, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                                                                                         Write(PopForums.Resources.Last);

#line default
#line hidden
            EndContext();
            BeginContext(3594, 45, true);
            WriteLiteral(": <span class=\"lastPostTime fTime\" data-utc=\"");
            EndContext();
            BeginContext(3640, 32, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                                                                                                                                                               Write(forum.LastPostTime.ToString("o"));

#line default
#line hidden
            EndContext();
            BeginContext(3672, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(3675, 67, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                  Write(TimeFormattingService.GetFormattedTime(forum.LastPostTime, profile));

#line default
#line hidden
            EndContext();
            BeginContext(3742, 8, true);
            WriteLiteral("</span> ");
            EndContext();
            BeginContext(3751, 22, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                              Write(PopForums.Resources.By);

#line default
#line hidden
            EndContext();
            BeginContext(3773, 28, true);
            WriteLiteral(" <span class=\"lastPostName\">");
            EndContext();
            BeginContext(3802, 18, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                 Write(forum.LastPostName);

#line default
#line hidden
            EndContext();
            BeginContext(3820, 93, true);
            WriteLiteral("</span>\r\n                        </small>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 77 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(3939, 41, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<div>\r\n    <h3>");
            EndContext();
            BeginContext(3981, 31, false);
#line 83 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
   Write(PopForums.Resources.UsersOnline);

#line default
#line hidden
            EndContext();
            BeginContext(4012, 24, true);
            WriteLiteral("</h3>\r\n    <p>\r\n        ");
            EndContext();
            BeginContext(4037, 25, false);
#line 85 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
   Write(PopForums.Resources.Total);

#line default
#line hidden
            EndContext();
            BeginContext(4062, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(4065, 18, false);
#line 85 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                               Write(ViewBag.TotalUsers);

#line default
#line hidden
            EndContext();
#line 85 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                        foreach (var u in (List<PopForums.Models.User>)ViewBag.OnlineUsers)
        {

#line default
#line hidden
            BeginContext(4168, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(4177, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0351bf7111c94f239c25c351ea60dcf5", async() => {
                BeginContext(4256, 6, false);
#line 86 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                 Write(u.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 86 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                               WriteLiteral(u.UserID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
#line 86 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                 }

#line default
#line hidden
            BeginContext(4269, 17, true);
            WriteLiteral("    </p>\r\n    <p>");
            EndContext();
            BeginContext(4287, 31, false);
#line 88 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
  Write(PopForums.Resources.TotalTopics);

#line default
#line hidden
            EndContext();
            BeginContext(4318, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(4321, 18, false);
#line 88 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                    Write(ViewBag.TopicCount);

#line default
#line hidden
            EndContext();
            BeginContext(4339, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(4342, 30, false);
#line 88 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                         Write(PopForums.Resources.TotalPosts);

#line default
#line hidden
            EndContext();
            BeginContext(4372, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(4375, 17, false);
#line 88 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                          Write(ViewBag.PostCount);

#line default
#line hidden
            EndContext();
            BeginContext(4392, 2, true);
            WriteLiteral(", ");
            EndContext();
            BeginContext(4395, 35, false);
#line 88 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                              Write(PopForums.Resources.RegisteredUsers);

#line default
#line hidden
            EndContext();
            BeginContext(4430, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(4433, 23, false);
#line 88 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Home\Index.cshtml"
                                                                                                                                                    Write(ViewBag.RegisteredUsers);

#line default
#line hidden
            EndContext();
            BeginContext(4456, 14, true);
            WriteLiteral("</p>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ITimeFormattingService TimeFormattingService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserRetrievalShim UserRetrievalShim { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategorizedForumContainer> Html { get; private set; }
    }
}
#pragma warning restore 1591
