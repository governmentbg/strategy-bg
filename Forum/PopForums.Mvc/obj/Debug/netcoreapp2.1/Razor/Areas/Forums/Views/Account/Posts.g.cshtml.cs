#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9a8d59116d74e7dd93cf02afc9422151956a655"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Account_Posts), @"mvc.1.0.view", @"/Areas/Forums/Views/Account/Posts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Account/Posts.cshtml", typeof(AspNetCore.Areas_Forums_Views_Account_Posts))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9a8d59116d74e7dd93cf02afc9422151956a655", @"/Areas/Forums/Views/Account/Posts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Account_Posts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedTopicContainer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("controllerName", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("actionName", "Posts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "pagination pagerLinks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("moreTextClass", "morePager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("currentTextClass", "currentPager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("imagePath", "/lib/PopForums/", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Forum", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Topic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::PopForums.Mvc.Areas.Forums.TagHelpers.PagerLinksTagHelper __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper;
        private global::PopForums.Mvc.Areas.Forums.TagHelpers.TopicReadIndicatorTagHelper __PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
  
    ViewBag.Title = ViewBag.PostUserName + "'s " + PopForums.Resources.Posts;
    Layout = "~/Areas/Forums/Views/Shared/PopForumsMaster.cshtml";
    var user = UserRetrievalShim.GetUser(Context);
    var profile = UserRetrievalShim.GetProfile(Context);

#line default
#line hidden
            DefineSection("HeaderContent", async() => {
                BeginContext(416, 136, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        $(function () {\r\n            PopForums.topicPreviewSetup();\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
            DefineSection("breadcrumbs", async() => {
                BeginContext(576, 45, true);
                WriteLiteral("\r\n    <div class=\"breadcrumbs\">\r\n        / <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 621, "\"", 655, 1);
#line 19 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
WriteAttributeValue("", 628, Url.Action("Index","Home"), 628, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(656, 23, true);
                WriteLiteral(">Начало</a>\r\n        / ");
                EndContext();
                BeginContext(679, 72, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "afd53928d8f7486faa34d901119e69fa", async() => {
                    BeginContext(739, 8, true);
                    WriteLiteral("Дискусии");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                BeginWriteTagHelperAttribute();
#line 20 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                 WriteLiteral(HomeController.Name);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(751, 12, true);
                WriteLiteral("\r\n        / ");
                EndContext();
                BeginContext(764, 67, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
     Write(String.Format(@PopForums.Resources.NamePosts, ViewBag.PostUserName));

#line default
#line hidden
                EndContext();
                BeginContext(831, 14, true);
                WriteLiteral("\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(848, 24, true);
            WriteLiteral("    <div>\r\n        <h1> ");
            EndContext();
            BeginContext(873, 67, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
        Write(String.Format(@PopForums.Resources.NamePosts, ViewBag.PostUserName));

#line default
#line hidden
            EndContext();
            BeginContext(940, 26, true);
            WriteLiteral(" </ h1 >\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(966, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pf-pagerLinks", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3831154ee239479cb8d09129ad7724f1", async() => {
            }
            );
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper = CreateTagHelper<global::PopForums.Mvc.Areas.Forums.TagHelpers.PagerLinksTagHelper>();
            __tagHelperExecutionContext.Add(__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ControllerName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ActionName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 27 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.PagerContext = Model.PagerContext;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("pagerContext", __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.PagerContext, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.Class = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.MoreTextClass = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.CurrentTextClass = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1150, 64, true);
            WriteLiteral("\r\n    <table id=\"TopicList\" class=\"table dataTable no-footer\">\r\n");
            EndContext();
#line 29 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
         foreach (var topic in Model.Topics)
        {

#line default
#line hidden
            BeginContext(1271, 16, true);
            WriteLiteral("            <tr ");
            EndContext();
#line 31 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                 if (topic.IsDeleted) { 

#line default
#line hidden
            BeginContext(1317, 19, true);
            WriteLiteral(" class=\"bg-danger\" ");
            EndContext();
#line 31 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                         }

#line default
#line hidden
            BeginContext(1345, 15, true);
            WriteLiteral(" data-topicid=\"");
            EndContext();
            BeginContext(1361, 13, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                    Write(topic.TopicID);

#line default
#line hidden
            EndContext();
            BeginContext(1374, 45, true);
            WriteLiteral("\">\r\n                <td class=\"newIndicator\">");
            EndContext();
            BeginContext(1419, 176, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f4bb163f89e44f73b3350a044dd61166", async() => {
                BeginContext(1494, 97, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pf-topicReadIndicator", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "54a5bcc8bc7b42d0a75e9b6f3dab15ce", async() => {
                }
                );
                __PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper = CreateTagHelper<global::PopForums.Mvc.Areas.Forums.TagHelpers.TopicReadIndicatorTagHelper>();
                __tagHelperExecutionContext.Add(__PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper);
#line 32 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper.Topic = topic;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("topic", __PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper.Topic, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 32 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper.PagedTopicContainer = Model;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("pagedTopicContainer", __PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper.PagedTopicContainer, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper.ImagePath = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                        WriteLiteral(topic.UrlName);

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
            BeginContext(1595, 49, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1645, 90, false);
#line 34 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
               Write(Html.ActionLink(topic.Title, "Topic", "Forum", new { id = topic.UrlName, page = 1 }, null));

#line default
#line hidden
            EndContext();
            BeginContext(1735, 73, true);
            WriteLiteral(" <span class=\"topicPreviewButton glyphicon glyphicon-chevron-right twirl\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1808, "\"", 1849, 1);
#line 34 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
WriteAttributeValue("", 1816, PopForums.Resources.PreviewTopic, 1816, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1850, 15, true);
            WriteLiteral(" data-topicid=\"");
            EndContext();
            BeginContext(1866, 13, false);
#line 34 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                            Write(topic.TopicID);

#line default
#line hidden
            EndContext();
            BeginContext(1879, 35, true);
            WriteLiteral("\"></span>\r\n                    <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1914, "\"", 1947, 2);
            WriteAttributeValue("", 1919, "TopicPreview", 1919, 12, true);
#line 35 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
WriteAttributeValue("", 1931, topic.TopicID, 1931, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1948, 115, true);
            WriteLiteral(" class=\"topicPreview\"></div>\r\n                    <small class=\"pull-right forumDetails\">\r\n                        ");
            EndContext();
            BeginContext(2064, 29, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                   Write(PopForums.Resources.StartedBy);

#line default
#line hidden
            EndContext();
            BeginContext(2093, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(2096, 19, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                   Write(topic.StartedByName);

#line default
#line hidden
            EndContext();
            BeginContext(2115, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2117, 22, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                        Write(PopForums.Resources.In);

#line default
#line hidden
            EndContext();
            BeginContext(2139, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2141, 32, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                Write(Model.ForumTitles[topic.ForumID]);

#line default
#line hidden
            EndContext();
            BeginContext(2173, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2177, 25, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                    Write(PopForums.Resources.Views);

#line default
#line hidden
            EndContext();
            BeginContext(2202, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(2205, 15, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                Write(topic.ViewCount);

#line default
#line hidden
            EndContext();
            BeginContext(2220, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2224, 27, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                   Write(PopForums.Resources.Replies);

#line default
#line hidden
            EndContext();
            BeginContext(2251, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(2254, 16, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                 Write(topic.ReplyCount);

#line default
#line hidden
            EndContext();
            BeginContext(2270, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2274, 24, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                     Write(PopForums.Resources.Last);

#line default
#line hidden
            EndContext();
            BeginContext(2298, 45, true);
            WriteLiteral(": <span class=\"lastPostTime fTime\" data-utc=\"");
            EndContext();
            BeginContext(2344, 32, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                           Write(topic.LastPostTime.ToString("o"));

#line default
#line hidden
            EndContext();
            BeginContext(2376, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(2379, 67, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                                                              Write(TimeFormattingService.GetFormattedTime(topic.LastPostTime, profile));

#line default
#line hidden
            EndContext();
            BeginContext(2446, 8, true);
            WriteLiteral("</span> ");
            EndContext();
            BeginContext(2455, 22, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                          Write(PopForums.Resources.By);

#line default
#line hidden
            EndContext();
            BeginContext(2477, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2479, 18, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                  Write(topic.LastPostName);

#line default
#line hidden
            EndContext();
            BeginContext(2497, 74, true);
            WriteLiteral("\r\n                    </small>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
        }

#line default
#line hidden
            BeginContext(2582, 14, true);
            WriteLiteral("    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedTopicContainer> Html { get; private set; }
    }
}
#pragma warning restore 1591
