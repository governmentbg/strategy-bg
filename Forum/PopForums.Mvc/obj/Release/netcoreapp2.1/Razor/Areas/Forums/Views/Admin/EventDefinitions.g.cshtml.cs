#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3d881435df2722ff9d040e8d193005e5ef8480a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Admin_EventDefinitions), @"mvc.1.0.view", @"/Areas/Forums/Views/Admin/EventDefinitions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Admin/EventDefinitions.cshtml", typeof(AspNetCore.Areas_Forums_Views_Admin_EventDefinitions))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3d881435df2722ff9d040e8d193005e5ef8480a", @"/Areas/Forums/Views/Admin/EventDefinitions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Admin_EventDefinitions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PopForums.ScoringGame.EventDefinition>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
  
	ViewBag.PageTitle = PopForums.Resources.EventDefinitions;
    Layout = "~/Areas/Forums/Views/Admin/AdminMaster.cshtml";

#line default
#line hidden
            BeginContext(178, 5, true);
            WriteLiteral("\n<h1>");
            EndContext();
            BeginContext(184, 36, false);
#line 8 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
Write(PopForums.Resources.EventDefinitions);

#line default
#line hidden
            EndContext();
            BeginContext(220, 67, true);
            WriteLiteral("</h1>\n\n<table class=\"table table-hover\">\n\t<tr>\n\t\t<th>ID</th>\n\t\t<th>");
            EndContext();
            BeginContext(288, 31, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
       Write(PopForums.Resources.Description);

#line default
#line hidden
            EndContext();
            BeginContext(319, 81, true);
            WriteLiteral("</th>\n\t\t<th>Point Value</th>\n\t\t<th>Publish to Feed</th>\n\t\t<th>&nbsp;</th>\n\t</tr>\n");
            EndContext();
#line 18 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
            BeginContext(431, 12, true);
            WriteLiteral("\t<tr>\n\t\t<td>");
            EndContext();
            BeginContext(444, 22, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
       Write(item.EventDefinitionID);

#line default
#line hidden
            EndContext();
            BeginContext(466, 12, true);
            WriteLiteral("</td>\n\t\t<td>");
            EndContext();
            BeginContext(479, 16, false);
#line 22 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
       Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(495, 12, true);
            WriteLiteral("</td>\n\t\t<td>");
            EndContext();
            BeginContext(508, 15, false);
#line 23 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
       Write(item.PointValue);

#line default
#line hidden
            EndContext();
            BeginContext(523, 55, true);
            WriteLiteral("</td>\n\t\t<td><input type=\"checkbox\" disabled=\"disabled\" ");
            EndContext();
#line 24 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
                                                        if (item.IsPublishedToFeed) {

#line default
#line hidden
            BeginContext(614, 18, true);
            WriteLiteral("checked=\"checked\" ");
            EndContext();
#line 24 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
                                                                                                                    }

#line default
#line hidden
            BeginContext(640, 15, true);
            WriteLiteral("/></td>\n\t\t<td>\n");
            EndContext();
#line 26 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
             if (!PopForums.ScoringGame.EventDefinitionService.StaticEvents.ContainsKey(item.EventDefinitionID)) {
				using (Html.BeginForm("DeleteEvent", "Admin", new { id = item.EventDefinitionID })) {

#line default
#line hidden
            BeginContext(851, 68, true);
            WriteLiteral("\t\t\t\t\t<input type=\"submit\" value=\"Delete\" class=\"btn btn-primary\" />\n");
            EndContext();
#line 29 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
				}
			}

#line default
#line hidden
            BeginContext(930, 15, true);
            WriteLiteral("\t\t</td>\n\t</tr>\n");
            EndContext();
#line 33 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
}

#line default
#line hidden
            BeginContext(947, 30, true);
            WriteLiteral("</table>\n\n<h2>Add Event</h2>\n\n");
            EndContext();
#line 38 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
 using (Html.BeginForm("AddEvent", "Admin"))
{

#line default
#line hidden
            BeginContext(1024, 148, true);
            WriteLiteral("\t<div role=\"form\" class=\"form-horizontal\">\n\t\t<div class=\"form-group\">\n\t\t\t<label class=\"col-xs-4\">EventDefinitionID</label>\n\t\t\t<div class=\"col-xs-8\">");
            EndContext();
            BeginContext(1173, 80, false);
#line 43 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
                             Write(Html.TextBox("EventDefinitionID", String.Empty, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1253, 70, true);
            WriteLiteral("</div>\n\t\t</div>\n\t\t<div class=\"form-group\">\n\t\t\t<label class=\"col-xs-4\">");
            EndContext();
            BeginContext(1324, 31, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
                               Write(PopForums.Resources.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1355, 34, true);
            WriteLiteral("</label>\n\t\t\t<div class=\"col-xs-8\">");
            EndContext();
            BeginContext(1390, 74, false);
#line 47 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
                             Write(Html.TextBox("Description", String.Empty, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1464, 115, true);
            WriteLiteral("</div>\n\t\t</div>\n\t\t<div class=\"form-group\">\n\t\t\t<label class=\"col-xs-4\">Point Value</label>\n\t\t\t<div class=\"col-xs-3\">");
            EndContext();
            BeginContext(1580, 73, false);
#line 51 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
                             Write(Html.TextBox("PointValue", String.Empty, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1653, 129, true);
            WriteLiteral("</div>\n\t\t</div>\n\t\t<div class=\"form-group\">\n\t\t\t<div class=\"col-xs-push-4 col-xs-8\">\n\t\t\t\t<div class=\"checkbox\">\n\t\t\t\t\t<label>\n\t\t\t\t\t\t");
            EndContext();
            BeginContext(1783, 34, false);
#line 57 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
                   Write(Html.CheckBox("IsPublishedToFeed"));

#line default
#line hidden
            EndContext();
            BeginContext(1817, 137, true);
            WriteLiteral(" Publish to Feed\n\t\t\t\t\t</label>\n\t\t\t\t</div>\n\t\t\t</div>\n\t\t</div>\n\t\t<input type=\"submit\" value=\"Add Event\" class=\"btn btn-primary\" />\n\t</div>\n");
            EndContext();
#line 64 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EventDefinitions.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PopForums.ScoringGame.EventDefinition>> Html { get; private set; }
    }
}
#pragma warning restore 1591