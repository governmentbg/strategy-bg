#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71f93567e4bb3a78ad1aa5dde046105c072ddd64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Account_ViewProfile), @"mvc.1.0.view", @"/Areas/Forums/Views/Account/ViewProfile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Account/ViewProfile.cshtml", typeof(AspNetCore.Areas_Forums_Views_Account_ViewProfile))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71f93567e4bb3a78ad1aa5dde046105c072ddd64", @"/Areas/Forums/Views/Account/ViewProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Account_ViewProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DisplayProfile>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PrivateMessages", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmailUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Posts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(120, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 5 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
  
	ViewBag.Title = PopForums.Resources.Profile + " - " + Model.Name;
	Layout = "~/Areas/Forums/Views/Shared/PopForumsMaster.cshtml";
	var profile = UserRetrievalShim.GetProfile(Context);

#line default
#line hidden
            DefineSection("HeaderContent", async() => {
                BeginContext(335, 1, true);
                WriteLiteral("\n");
                EndContext();
            }
            );
            BeginContext(338, 12, true);
            WriteLiteral("\n<div>\n\t<h1>");
            EndContext();
            BeginContext(351, 10, false);
#line 14 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
   Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(361, 109, true);
            WriteLiteral("</h1>\n\t<ul id=\"TopBreadcrumb\" class=\"breadcrumb\">\n\t\t<li><span class=\"glyphicon glyphicon-chevron-up\"></span> ");
            EndContext();
            BeginContext(470, 91, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e047fc3a66c4e3b84975a44eaaeb8d8", async() => {
                BeginContext(531, 26, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                                                                        Write(PopForums.Resources.Forums);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#line 16 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
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
            BeginContext(561, 168, true);
            WriteLiteral("</li>\n\t</ul>\n</div>\n\n<div id=\"Profile\">\n\t<ul class=\"nav nav-tabs\" role=\"tablist\" id=\"ProfileTabs\">\n\t\t<li class=\"active\"><a href=\"#Details\" role=\"tab\" data-toggle=\"tab\">");
            EndContext();
            BeginContext(730, 27, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                      Write(PopForums.Resources.Profile);

#line default
#line hidden
            EndContext();
            BeginContext(757, 69, true);
            WriteLiteral("</a></li>\n\t\t<li><a href=\"#ActivityFeed\" role=\"tab\" data-toggle=\"tab\">");
            EndContext();
            BeginContext(827, 32, false);
#line 23 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                            Write(PopForums.Resources.ActivityFeed);

#line default
#line hidden
            EndContext();
            BeginContext(859, 119, true);
            WriteLiteral("</a></li>\n\t</ul>\n\t<div class=\"tab-content\">\n\t\t<div id=\"Details\" class=\"tab-pane active\">\n\t\t\t<dl class=\"dl-horizontal\">\n");
            EndContext();
#line 28 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (Model.ShowDetails)
				{

#line default
#line hidden
            BeginContext(1012, 9, true);
            WriteLiteral("\t\t\t\t\t<dt>");
            EndContext();
            BeginContext(1022, 27, false);
#line 30 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                   Write(PopForums.Resources.Contact);

#line default
#line hidden
            EndContext();
            BeginContext(1049, 22, true);
            WriteLiteral("</dt>\n\t\t\t\t\t<dd>\n\t\t\t\t\t\t");
            EndContext();
            BeginContext(1071, 147, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34e369a7bc28449fa78c66fb725c512b", async() => {
                BeginContext(1157, 57, false);
#line 32 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                                                        Write(String.Format(PopForums.Resources.SendNamePM, Model.Name));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                                  WriteLiteral(Model.UserID);

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
            BeginContext(1218, 12, true);
            WriteLiteral("<br/>\n\t\t\t\t\t\t");
            EndContext();
            BeginContext(1230, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51f168c4bedc4ad9bdd83d50961a4915", async() => {
                BeginContext(1311, 60, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                                                   Write(String.Format(PopForums.Resources.SendNameEmail, Model.Name));

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 33 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                             WriteLiteral(Model.UserID);

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
            BeginContext(1375, 12, true);
            WriteLiteral("\n\t\t\t\t\t</dd>\n");
            EndContext();
#line 35 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(1393, 27, true);
            WriteLiteral("\t\t\t\t\n\t\t\t\t<dt></dt>\n\t\t\t\t<dd>");
            EndContext();
            BeginContext(1420, 185, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "134bd0efa1b5476d910064da61ada47f", async() => {
                BeginContext(1498, 102, false);
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                                            Write(String.Format(PopForums.Resources.NamePosts, Model.Name) + " (" + Model.PostCount.ToString("N0") + ")");

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                     WriteLiteral(Model.UserID);

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
            BeginContext(1605, 19, true);
            WriteLiteral("</dd>\n\t\t\t\t\n\t\t\t\t<dt>");
            EndContext();
            BeginContext(1625, 26, false);
#line 40 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
               Write(PopForums.Resources.Joined);

#line default
#line hidden
            EndContext();
            BeginContext(1651, 14, true);
            WriteLiteral("</dt>\n\t\t\t\t<dd>");
            EndContext();
            BeginContext(1666, 61, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
               Write(TimeFormattingService.GetFormattedTime(Model.Joined, profile));

#line default
#line hidden
            EndContext();
            BeginContext(1727, 7, true);
            WriteLiteral("</dd>\n\n");
            EndContext();
#line 43 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (Model.Dob.HasValue)
				{

#line default
#line hidden
            BeginContext(1769, 9, true);
            WriteLiteral("\t\t\t\t\t<dt>");
            EndContext();
            BeginContext(1779, 28, false);
#line 45 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                   Write(PopForums.Resources.Birthday);

#line default
#line hidden
            EndContext();
            BeginContext(1807, 15, true);
            WriteLiteral("</dt>\n\t\t\t\t\t<dd>");
            EndContext();
            BeginContext(1823, 29, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                   Write(Model.Dob.Value.ToString("D"));

#line default
#line hidden
            EndContext();
            BeginContext(1852, 6, true);
            WriteLiteral("</dd>\n");
            EndContext();
#line 47 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(1864, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 49 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (!String.IsNullOrWhiteSpace(Model.Location))
				{

#line default
#line hidden
            BeginContext(1928, 9, true);
            WriteLiteral("\t\t\t\t\t<dt>");
            EndContext();
            BeginContext(1938, 28, false);
#line 51 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                   Write(PopForums.Resources.Location);

#line default
#line hidden
            EndContext();
            BeginContext(1966, 15, true);
            WriteLiteral("</dt>\n\t\t\t\t\t<dd>");
            EndContext();
            BeginContext(1982, 14, false);
#line 52 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                   Write(Model.Location);

#line default
#line hidden
            EndContext();
            BeginContext(1996, 6, true);
            WriteLiteral("</dd>\n");
            EndContext();
#line 53 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(2008, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 55 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (!String.IsNullOrWhiteSpace(Model.Facebook))
				{

#line default
#line hidden
            BeginContext(2068, 34, true);
            WriteLiteral("\t\t\t\t\t<dt>Facebook</dt>\n\t\t\t\t\t<dd><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2102, "\"", 2145, 2);
            WriteAttributeValue("", 2109, "https://facebook.com/", 2109, 21, true);
#line 58 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
WriteAttributeValue("", 2130, Model.Facebook, 2130, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2146, 38, true);
            WriteLiteral(" target=\"_blank\">https://facebook.com/");
            EndContext();
            BeginContext(2185, 14, false);
#line 58 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                                                       Write(Model.Facebook);

#line default
#line hidden
            EndContext();
            BeginContext(2199, 10, true);
            WriteLiteral("</a></dd>\n");
            EndContext();
#line 59 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(2215, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 61 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (!String.IsNullOrWhiteSpace(Model.Twitter))
				{

#line default
#line hidden
            BeginContext(2274, 33, true);
            WriteLiteral("\t\t\t\t\t<dt>Twitter</dt>\n\t\t\t\t\t<dd><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2307, "\"", 2348, 2);
            WriteAttributeValue("", 2314, "https://twitter.com/", 2314, 20, true);
#line 64 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
WriteAttributeValue("", 2334, Model.Twitter, 2334, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2349, 22, true);
            WriteLiteral(" target=\"_blank\">&#64;");
            EndContext();
            BeginContext(2372, 13, false);
#line 64 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                                     Write(Model.Twitter);

#line default
#line hidden
            EndContext();
            BeginContext(2385, 10, true);
            WriteLiteral("</a></dd>\n");
            EndContext();
#line 65 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(2401, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 67 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (!String.IsNullOrWhiteSpace(Model.Web))
				{

#line default
#line hidden
            BeginContext(2460, 9, true);
            WriteLiteral("\t\t\t\t\t<dt>");
            EndContext();
            BeginContext(2470, 23, false);
#line 69 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                   Write(PopForums.Resources.Web);

#line default
#line hidden
            EndContext();
            BeginContext(2493, 17, true);
            WriteLiteral("</dt>\n\t\t\t\t\t<dd><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2510, "\"", 2527, 1);
#line 70 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
WriteAttributeValue("", 2517, Model.Web, 2517, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2528, 17, true);
            WriteLiteral(" target=\"_blank\">");
            EndContext();
            BeginContext(2546, 9, false);
#line 70 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                        Write(Model.Web);

#line default
#line hidden
            EndContext();
            BeginContext(2555, 10, true);
            WriteLiteral("</a></dd>\n");
            EndContext();
#line 71 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(2571, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 73 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (!String.IsNullOrWhiteSpace(Model.YahooMessenger))
				{

#line default
#line hidden
            BeginContext(2641, 41, true);
            WriteLiteral("\t\t\t\t\t<dt>Yahoo Messenger</dt>\n\t\t\t\t\t<dd><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2682, "\"", 2723, 2);
            WriteAttributeValue("", 2689, "ymsgr:sendIM?", 2689, 13, true);
#line 76 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
WriteAttributeValue("", 2702, Model.YahooMessenger, 2702, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2724, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2726, 20, false);
#line 76 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                Write(Model.YahooMessenger);

#line default
#line hidden
            EndContext();
            BeginContext(2746, 10, true);
            WriteLiteral("</a></dd>\n");
            EndContext();
#line 77 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(2762, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 79 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (!String.IsNullOrWhiteSpace(Model.Icq))
				{

#line default
#line hidden
            BeginContext(2821, 29, true);
            WriteLiteral("\t\t\t\t\t<dt>ICQ</dt>\n\t\t\t\t\t<dd><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2850, "\"", 2886, 2);
            WriteAttributeValue("", 2857, "http://wwp.icq.com/", 2857, 19, true);
#line 82 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
WriteAttributeValue("", 2876, Model.Icq, 2876, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2887, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2889, 9, false);
#line 82 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                           Write(Model.Icq);

#line default
#line hidden
            EndContext();
            BeginContext(2898, 10, true);
            WriteLiteral("</a></dd>\n");
            EndContext();
#line 83 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(2914, 5, true);
            WriteLiteral("\t\t\t\t\n");
            EndContext();
#line 85 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                 if (Model.AvatarID.HasValue)
				{

#line default
#line hidden
            BeginContext(2959, 9, true);
            WriteLiteral("\t\t\t\t\t<dt>");
            EndContext();
            BeginContext(2969, 26, false);
#line 87 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                   Write(PopForums.Resources.Avatar);

#line default
#line hidden
            EndContext();
            BeginContext(2995, 19, true);
            WriteLiteral("</dt>\n\t\t\t\t\t<dd><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3014, "\"", 3079, 1);
#line 88 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
WriteAttributeValue("", 3020, Url.Action("Avatar", "Image", new { id = Model.AvatarID }), 3020, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3080, 51, true);
            WriteLiteral(" alt=\"Avatar image\" class=\"img-responsive\" /></dd>\n");
            EndContext();
#line 89 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
				}

#line default
#line hidden
            BeginContext(3137, 15, true);
            WriteLiteral("\t\t\t\t\n\t\t\t</dl>\n\n");
            EndContext();
#line 93 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
             if (Model.ImageID.HasValue && Model.IsImageApproved)
			{

#line default
#line hidden
            BeginContext(3214, 37, true);
            WriteLiteral("\t\t\t\t<div class=\"col-xs-12\">\n\t\t\t\t\t<img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3251, "\"", 3318, 1);
#line 96 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
WriteAttributeValue("", 3257, Url.Action("UserImage", "Image", new { id = Model.ImageID }), 3257, 61, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3319, 55, true);
            WriteLiteral(" alt=\"User image\" class=\"img-responsive\" />\n\t\t\t\t</div>\n");
            EndContext();
#line 98 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
			}

#line default
#line hidden
            BeginContext(3379, 53, true);
            WriteLiteral("\t\t</div>\n\n\t\t<div id=\"ActivityFeed\" class=\"tab-pane\">\n");
            EndContext();
#line 102 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
             foreach (var item in Model.Feed)
			{

#line default
#line hidden
            BeginContext(3474, 34, true);
            WriteLiteral("\t\t\t\t<div class=\"bg-info callout\">\n");
            EndContext();
#line 105 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                     if (item.Points > 0)
					{

#line default
#line hidden
            BeginContext(3542, 52, true);
            WriteLiteral("\t\t\t\t\t\t<div class=\"activityFeedPoints center-block\">+");
            EndContext();
            BeginContext(3595, 11, false);
#line 107 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                                                 Write(item.Points);

#line default
#line hidden
            EndContext();
            BeginContext(3606, 7, true);
            WriteLiteral("</div>\n");
            EndContext();
#line 108 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
					}

#line default
#line hidden
            BeginContext(3620, 10, true);
            WriteLiteral("\t\t\t\t\t<div>");
            EndContext();
            BeginContext(3631, 22, false);
#line 109 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                    Write(Html.Raw(item.Message));

#line default
#line hidden
            EndContext();
            BeginContext(3653, 42, true);
            WriteLiteral("</div>\n\t\t\t\t\t<div class=\"text-right small\">");
            EndContext();
            BeginContext(3696, 63, false);
#line 110 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
                                             Write(TimeFormattingService.GetFormattedTime(item.TimeStamp, profile));

#line default
#line hidden
            EndContext();
            BeginContext(3759, 18, true);
            WriteLiteral("</div>\n\t\t\t\t</div>\n");
            EndContext();
#line 112 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Account\ViewProfile.cshtml"
			}

#line default
#line hidden
            BeginContext(3782, 23, true);
            WriteLiteral("\t\t</div>\n\t</div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DisplayProfile> Html { get; private set; }
    }
}
#pragma warning restore 1591