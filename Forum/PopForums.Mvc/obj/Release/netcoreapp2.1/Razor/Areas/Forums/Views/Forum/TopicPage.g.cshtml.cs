#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acfb7adcd7cc20f2737c498603ea461bc015631f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Forum_TopicPage), @"mvc.1.0.view", @"/Areas/Forums/Views/Forum/TopicPage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Forum/TopicPage.cshtml", typeof(AspNetCore.Areas_Forums_Views_Forum_TopicPage))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acfb7adcd7cc20f2737c498603ea461bc015631f", @"/Areas/Forums/Views/Forum/TopicPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Forum_TopicPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TopicContainer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("controllerName", "Forum", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("actionName", "Topic", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", "pagination pagerLinks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("moreTextClass", "morePager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("currentTextClass", "currentPager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::PopForums.Mvc.Areas.Forums.TagHelpers.PagerLinksTagHelper __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
  
	var user = UserRetrievalShim.GetUser(Context);
	var profile = UserRetrievalShim.GetProfile(Context);
	var routeParameters = new Dictionary<string, object> {{"id", Model.Topic.UrlName}};

#line default
#line hidden
            BeginContext(312, 6, true);
            WriteLiteral("<div>\n");
            EndContext();
#line 10 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
 foreach (var post in Model.Posts)
{
	

#line default
#line hidden
            BeginContext(357, 252, false);
#line 12 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
Write(await Html.PartialAsync("~/Areas/Forums/Views/Forum/PostItem.cshtml", new PostItemContainer { Post = post, VotedPostIDs = Model.VotedPostIDs, Signatures = Model.Signatures, Avatars = Model.Avatars, User = user, Profile = profile, Topic = Model.Topic }));

#line default
#line hidden
            EndContext();
#line 12 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
                                                                                                                                                                                                                                                                 ;
}

#line default
#line hidden
            BeginContext(613, 257, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pf-pagerLinks", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "689b932a265049bbaba03f9aa88d4aed", async() => {
            }
            );
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper = CreateTagHelper<global::PopForums.Mvc.Areas.Forums.TagHelpers.PagerLinksTagHelper>();
            __tagHelperExecutionContext.Add(__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ControllerName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.ActionName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 14 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.PagerContext = Model.PagerContext;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("pagerContext", __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.PagerContext, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.Class = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.MoreTextClass = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.CurrentTextClass = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#line 14 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.Low = ViewBag.Low;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("low", __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.Low, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 14 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.High = ViewBag.High;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("high", __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.High, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 14 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
__PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.RouteParameters = routeParameters;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("routeParameters", __PopForums_Mvc_Areas_Forums_TagHelpers_PagerLinksTagHelper.RouteParameters, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(870, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(872, 83, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
Write(Html.Hidden("LastPostID", Model.Posts.Last().PostID, new { @class = "lastPostID" }));

#line default
#line hidden
            EndContext();
            BeginContext(955, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(957, 84, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Forum\TopicPage.cshtml"
Write(Html.Hidden("PageCount", Model.PagerContext.PageCount, new { @class = "pageCount" }));

#line default
#line hidden
            EndContext();
            BeginContext(1041, 7, true);
            WriteLiteral("\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TopicContainer> Html { get; private set; }
    }
}
#pragma warning restore 1591