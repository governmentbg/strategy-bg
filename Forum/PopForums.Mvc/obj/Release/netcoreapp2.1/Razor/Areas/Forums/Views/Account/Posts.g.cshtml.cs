#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97b0465fb9c3d71d31f4da34cd3427f5b1f8a1d9"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97b0465fb9c3d71d31f4da34cd3427f5b1f8a1d9", @"/Areas/Forums/Views/Account/Posts.cshtml")]
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
            BeginContext(371, 1, true);
            WriteLiteral("\n");
            EndContext();
            DefineSection("HeaderContent", async() => {
                BeginContext(396, 98, true);
                WriteLiteral("\n<script type=\"text/javascript\">\n\t$(function () {\n\t\tPopForums.topicPreviewSetup();\n\t});\n</script>\n");
                EndContext();
            }
            );
            BeginContext(496, 12, true);
            WriteLiteral("\n<div>\n\t<h1>");
            EndContext();
            BeginContext(509, 20, false);
#line 20 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
   Write(ViewBag.PostUserName);

#line default
#line hidden
            EndContext();
            BeginContext(529, 3, true);
            WriteLiteral("\'s ");
            EndContext();
            BeginContext(533, 25, false);
#line 20 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                           Write(PopForums.Resources.Posts);

#line default
#line hidden
            EndContext();
            BeginContext(558, 109, true);
            WriteLiteral("</h1>\n\t<ul id=\"TopBreadcrumb\" class=\"breadcrumb\">\n\t\t<li><span class=\"glyphicon glyphicon-chevron-up\"></span> ");
            EndContext();
            BeginContext(667, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab527d6a736c4ab6a9db52374b78d1de", async() => {
                BeginContext(728, 26, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                        Write(PopForums.Resources.Forums);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#line 22 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
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
            BeginContext(758, 118, true);
            WriteLiteral("</li>\n\t</ul>\n\t<ul id=\"FixedBreadcrumb\" class=\"breadcrumb\">\n\t\t<li><span class=\"glyphicon glyphicon-chevron-up\"></span> ");
            EndContext();
            BeginContext(876, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a4b174620dd4b6193ed9304c9db5736", async() => {
                BeginContext(937, 26, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                        Write(PopForums.Resources.Forums);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#line 25 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
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
            BeginContext(967, 12, true);
            WriteLiteral("</li>\n\t\t<li>");
            EndContext();
            BeginContext(980, 20, false);
#line 26 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
       Write(ViewBag.PostUserName);

#line default
#line hidden
            EndContext();
            BeginContext(1000, 3, true);
            WriteLiteral("\'s ");
            EndContext();
            BeginContext(1004, 25, false);
#line 26 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                               Write(PopForums.Resources.Posts);

#line default
#line hidden
            EndContext();
            BeginContext(1029, 21, true);
            WriteLiteral("</li>\n\t</ul>\n</div>\n\n");
            EndContext();
            BeginContext(1050, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pf-pagerLinks", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f3b9b5e7f2d24819acb8e00c797d4f9e", async() => {
            }
            );
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper = CreateTagHelper<global::PopForums.Mvc.Areas.Forums.TagHelpers.PagerLinksTagHelper>();
            __tagHelperExecutionContext.Add(__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ControllerName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ActionName = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 30 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
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
            BeginContext(1234, 56, true);
            WriteLiteral("\n\n<table id=\"TopicList\" class=\"table grid table-hover\">\n");
            EndContext();
#line 33 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
     foreach (var topic in Model.Topics)
	{

#line default
#line hidden
            BeginContext(1331, 6, true);
            WriteLiteral("\t\t<tr ");
            EndContext();
#line 35 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
             if (topic.IsDeleted) { 

#line default
#line hidden
            BeginContext(1367, 19, true);
            WriteLiteral(" class=\"bg-danger\" ");
            EndContext();
#line 35 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                     }

#line default
#line hidden
            BeginContext(1395, 15, true);
            WriteLiteral(" data-topicid=\"");
            EndContext();
            BeginContext(1411, 13, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                Write(topic.TopicID);

#line default
#line hidden
            EndContext();
            BeginContext(1424, 31, true);
            WriteLiteral("\">\n\t\t\t<td class=\"newIndicator\">");
            EndContext();
            BeginContext(1455, 176, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a91279a0b484004bc9f5bf9e026d46c", async() => {
                BeginContext(1530, 97, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pf-topicReadIndicator", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3c23b57d7ed24068a44f3d1c4d9b3b5f", async() => {
                }
                );
                __PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper = CreateTagHelper<global::PopForums.Mvc.Areas.Forums.TagHelpers.TopicReadIndicatorTagHelper>();
                __tagHelperExecutionContext.Add(__PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper);
#line 36 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper.Topic = topic;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("topic", __PopForums_Mvc_Areas_Forums_TagHelpers_TopicReadIndicatorTagHelper.Topic, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 36 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
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
#line 36 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
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
            BeginContext(1631, 22, true);
            WriteLiteral("</td>\n\t\t\t<td>\n\t\t\t\t<h2>");
            EndContext();
            BeginContext(1654, 90, false);
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
               Write(Html.ActionLink(topic.Title, "Topic", "Forum", new { id = topic.UrlName, page = 1 }, null));

#line default
#line hidden
            EndContext();
            BeginContext(1744, 73, true);
            WriteLiteral(" <span class=\"topicPreviewButton glyphicon glyphicon-chevron-right twirl\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 1817, "\"", 1858, 1);
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
WriteAttributeValue("", 1825, PopForums.Resources.PreviewTopic, 1825, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1859, 15, true);
            WriteLiteral(" data-topicid=\"");
            EndContext();
            BeginContext(1875, 13, false);
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                            Write(topic.TopicID);

#line default
#line hidden
            EndContext();
            BeginContext(1888, 23, true);
            WriteLiteral("\"></span></h2>\n\t\t\t\t<div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1911, "\"", 1944, 2);
            WriteAttributeValue("", 1916, "TopicPreview", 1916, 12, true);
#line 39 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
WriteAttributeValue("", 1928, topic.TopicID, 1928, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1945, 78, true);
            WriteLiteral(" class=\"topicPreview\"></div>\n\t\t\t\t<small class=\"pull-right forumDetails\">\n\t\t\t\t\t");
            EndContext();
            BeginContext(2024, 29, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
               Write(PopForums.Resources.StartedBy);

#line default
#line hidden
            EndContext();
            BeginContext(2053, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(2056, 19, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                               Write(topic.StartedByName);

#line default
#line hidden
            EndContext();
            BeginContext(2075, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2077, 22, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                    Write(PopForums.Resources.In);

#line default
#line hidden
            EndContext();
            BeginContext(2099, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2101, 32, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                            Write(Model.ForumTitles[topic.ForumID]);

#line default
#line hidden
            EndContext();
            BeginContext(2133, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2137, 25, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                Write(PopForums.Resources.Views);

#line default
#line hidden
            EndContext();
            BeginContext(2162, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(2165, 15, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                            Write(topic.ViewCount);

#line default
#line hidden
            EndContext();
            BeginContext(2180, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2184, 27, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                               Write(PopForums.Resources.Replies);

#line default
#line hidden
            EndContext();
            BeginContext(2211, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(2214, 16, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                             Write(topic.ReplyCount);

#line default
#line hidden
            EndContext();
            BeginContext(2230, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2234, 24, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                 Write(PopForums.Resources.Last);

#line default
#line hidden
            EndContext();
            BeginContext(2258, 45, true);
            WriteLiteral(": <span class=\"lastPostTime fTime\" data-utc=\"");
            EndContext();
            BeginContext(2304, 32, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                       Write(topic.LastPostTime.ToString("o"));

#line default
#line hidden
            EndContext();
            BeginContext(2336, 2, true);
            WriteLiteral("\">");
            EndContext();
            BeginContext(2339, 67, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                                                          Write(TimeFormattingService.GetFormattedTime(topic.LastPostTime, profile));

#line default
#line hidden
            EndContext();
            BeginContext(2406, 8, true);
            WriteLiteral("</span> ");
            EndContext();
            BeginContext(2415, 22, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                      Write(PopForums.Resources.By);

#line default
#line hidden
            EndContext();
            BeginContext(2437, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2439, 18, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                              Write(topic.LastPostName);

#line default
#line hidden
            EndContext();
            BeginContext(2457, 31, true);
            WriteLiteral("\n\t\t\t\t</small>\n\t\t\t</td>\n\t\t</tr>\n");
            EndContext();
#line 45 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\Posts.cshtml"
	}

#line default
#line hidden
            BeginContext(2491, 9, true);
            WriteLiteral("</table>\n");
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
