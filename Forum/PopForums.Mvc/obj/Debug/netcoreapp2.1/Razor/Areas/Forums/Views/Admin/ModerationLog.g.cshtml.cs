#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2e43e05716b3737439463b23c7fcb40e6ceb801"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Admin_ModerationLog), @"mvc.1.0.view", @"/Areas/Forums/Views/Admin/ModerationLog.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Admin/ModerationLog.cshtml", typeof(AspNetCore.Areas_Forums_Views_Admin_ModerationLog))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2e43e05716b3737439463b23c7fcb40e6ceb801", @"/Areas/Forums/Views/Admin/ModerationLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Admin_ModerationLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ModerationLogEntry>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(130, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 5 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
  
    ViewBag.PageTitle = PopForums.Resources.ModerationLog;
    Layout = "~/Areas/Forums/Views/Admin/AdminMaster.cshtml";
	var profile = UserRetrievalShim.GetProfile(Context);

#line default
#line hidden
            BeginContext(311, 5, true);
            WriteLiteral("\n<h1>");
            EndContext();
            BeginContext(317, 33, false);
#line 11 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
Write(PopForums.Resources.ModerationLog);

#line default
#line hidden
            EndContext();
            BeginContext(350, 7, true);
            WriteLiteral("</h1>\n\n");
            EndContext();
#line 13 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(385, 56, true);
            WriteLiteral("\t<div role=\"form\">\n\t\t<div class=\"form-group\">\n\t\t\t<label>");
            EndContext();
            BeginContext(442, 29, false);
#line 17 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
              Write(PopForums.Resources.StartDate);

#line default
#line hidden
            EndContext();
            BeginContext(471, 12, true);
            WriteLiteral("</label>\n\t\t\t");
            EndContext();
            BeginContext(484, 60, false);
#line 18 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
       Write(Html.TextBox("start", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(544, 47, true);
            WriteLiteral("\n\t\t</div>\n\t\t<div class=\"form-group\">\n\t\t\t<label>");
            EndContext();
            BeginContext(592, 27, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
              Write(PopForums.Resources.EndDate);

#line default
#line hidden
            EndContext();
            BeginContext(619, 12, true);
            WriteLiteral("</label>\n\t\t\t");
            EndContext();
            BeginContext(632, 58, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
       Write(Html.TextBox("end", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(690, 32, true);
            WriteLiteral("\n\t\t</div>\n\t\t<input type=\"submit\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 722, "\"", 757, 1);
#line 24 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
WriteAttributeValue("", 730, PopForums.Resources.Search, 730, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(758, 36, true);
            WriteLiteral(" class=\"btn btn-primary\" />\n\t</div>\n");
            EndContext();
#line 26 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
}

#line default
#line hidden
            BeginContext(796, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 28 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(819, 75, true);
            WriteLiteral("\t<table class=\"table table-hover\" style=\"margin-top: 20px;\">\n\t\t<tr>\n\t\t\t<th>");
            EndContext();
            BeginContext(895, 29, false);
#line 32 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
           Write(PopForums.Resources.EventTime);

#line default
#line hidden
            EndContext();
            BeginContext(924, 13, true);
            WriteLiteral("</th>\n\t\t\t<th>");
            EndContext();
            BeginContext(938, 24, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
           Write(PopForums.Resources.Name);

#line default
#line hidden
            EndContext();
            BeginContext(962, 13, true);
            WriteLiteral("</th>\n\t\t\t<th>");
            EndContext();
            BeginContext(976, 24, false);
#line 34 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
           Write(PopForums.Resources.Type);

#line default
#line hidden
            EndContext();
            BeginContext(1000, 13, true);
            WriteLiteral("</th>\n\t\t\t<th>");
            EndContext();
            BeginContext(1014, 27, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
           Write(PopForums.Resources.TopicID);

#line default
#line hidden
            EndContext();
            BeginContext(1041, 13, true);
            WriteLiteral("</th>\n\t\t\t<th>");
            EndContext();
            BeginContext(1055, 26, false);
#line 36 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
           Write(PopForums.Resources.PostID);

#line default
#line hidden
            EndContext();
            BeginContext(1081, 14, true);
            WriteLiteral("</th>\n\t\t</tr>\n");
            EndContext();
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
         foreach (var entry in Model)
		{

#line default
#line hidden
            BeginContext(1131, 36, true);
            WriteLiteral("\t\t\t<tr>\n\t\t\t\t<td class=\"text-nowrap\">");
            EndContext();
            BeginContext(1168, 64, false);
#line 41 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
                                   Write(TimeFormattingService.GetFormattedTime(entry.TimeStamp, profile));

#line default
#line hidden
            EndContext();
            BeginContext(1232, 14, true);
            WriteLiteral("</td>\n\t\t\t\t<td>");
            EndContext();
            BeginContext(1247, 124, false);
#line 42 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
               Write(Html.ActionLink(entry.UserName, "ViewProfile", AccountController.Name, new { id = entry.UserID }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
            BeginContext(1371, 14, true);
            WriteLiteral("</td>\n\t\t\t\t<td>");
            EndContext();
            BeginContext(1386, 20, false);
#line 43 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
               Write(entry.ModerationType);

#line default
#line hidden
            EndContext();
            BeginContext(1406, 14, true);
            WriteLiteral("</td>\n\t\t\t\t<td>");
            EndContext();
            BeginContext(1421, 13, false);
#line 44 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
               Write(entry.TopicID);

#line default
#line hidden
            EndContext();
            BeginContext(1434, 15, true);
            WriteLiteral("</td>\n\t\t\t\t<td>\n");
            EndContext();
#line 46 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
                     if (entry.PostID.HasValue)
					{
						

#line default
#line hidden
            BeginContext(1496, 140, false);
#line 48 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
                   Write(Html.ActionLink(entry.PostID.Value.ToString(), "PostLink", ForumController.Name, new { id = entry.PostID.Value }, new { target = "_blank" }));

#line default
#line hidden
            EndContext();
#line 48 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
                                                                                                                                                                     
					}

#line default
#line hidden
            BeginContext(1644, 19, true);
            WriteLiteral("\t\t\t\t</td>\n\t\t\t</tr>\n");
            EndContext();
#line 52 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
			if (!String.IsNullOrEmpty(entry.Comment) || !String.IsNullOrEmpty(entry.Comment))
			{

#line default
#line hidden
            BeginContext(1753, 80, true);
            WriteLiteral("\t\t\t\t<tr>\n\t\t\t\t\t<td colspan=\"5\" style=\"border-bottom: solid 1px black;\">\n\t\t\t\t\t\t<p>");
            EndContext();
            BeginContext(1834, 27, false);
#line 56 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
                      Write(PopForums.Resources.Comment);

#line default
#line hidden
            EndContext();
            BeginContext(1861, 2, true);
            WriteLiteral(": ");
            EndContext();
            BeginContext(1864, 13, false);
#line 56 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
                                                    Write(entry.Comment);

#line default
#line hidden
            EndContext();
            BeginContext(1877, 11, true);
            WriteLiteral("</p>\n\t\t\t\t\t\t");
            EndContext();
            BeginContext(1889, 23, false);
#line 57 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
                   Write(Html.Raw(entry.OldText));

#line default
#line hidden
            EndContext();
            BeginContext(1912, 22, true);
            WriteLiteral("\n\t\t\t\t\t</td>\n\t\t\t\t</tr>\n");
            EndContext();
#line 60 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
			}
		}

#line default
#line hidden
            BeginContext(1943, 10, true);
            WriteLiteral("\t</table>\n");
            EndContext();
#line 63 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\ModerationLog.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserRetrievalShim UserRetrievalShim { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ITimeFormattingService TimeFormattingService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ModerationLogEntry>> Html { get; private set; }
    }
}
#pragma warning restore 1591