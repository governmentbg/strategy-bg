#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6f0ce4163ea6eb5acc80f0f27ae66d2b2cc30d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_Admin_EditUserSearch), @"mvc.1.0.view", @"/Areas/Forums/Views/Admin/EditUserSearch.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/Admin/EditUserSearch.cshtml", typeof(AspNetCore.Areas_Forums_Views_Admin_EditUserSearch))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6f0ce4163ea6eb5acc80f0f27ae66d2b2cc30d8", @"/Areas/Forums/Views/Admin/EditUserSearch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_Admin_EditUserSearch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUserSearch", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
  
    ViewBag.PageTitle = PopForums.Resources.EditUser + " - " + PopForums.Resources.Search;
    Layout = "~/Areas/Forums/Views/Admin/AdminMaster.cshtml";

#line default
#line hidden
            BeginContext(177, 5, true);
            WriteLiteral("\n<h2>");
            EndContext();
            BeginContext(183, 28, false);
#line 8 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
Write(PopForums.Resources.EditUser);

#line default
#line hidden
            EndContext();
            BeginContext(211, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(215, 26, false);
#line 8 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
                               Write(PopForums.Resources.Search);

#line default
#line hidden
            EndContext();
            BeginContext(241, 7, true);
            WriteLiteral("</h2>\n\n");
            EndContext();
            BeginContext(248, 586, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00791b39021644748b3326cb1b54dbae", async() => {
                BeginContext(316, 84, true);
                WriteLiteral("\n\t<input type=\"text\" name=\"SearchText\" class=\"form-control\" />\n\t<input type=\"submit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 400, "\"", 435, 1);
#line 12 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
WriteAttributeValue("", 408, PopForums.Resources.Search, 408, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(436, 33, true);
                WriteLiteral(" class=\"btn btn-primary\"/><br/>\n\t");
                EndContext();
                BeginContext(470, 79, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
Write(Html.RadioButton("SearchType", "Name", new {id = "Name", @checked = "checked"}));

#line default
#line hidden
                EndContext();
                BeginContext(549, 18, true);
                WriteLiteral("<label for=\"Name\">");
                EndContext();
                BeginContext(568, 24, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
                                                                                                 Write(PopForums.Resources.Name);

#line default
#line hidden
                EndContext();
                BeginContext(592, 10, true);
                WriteLiteral("</label>\n\t");
                EndContext();
                BeginContext(603, 59, false);
#line 14 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
Write(Html.RadioButton("SearchType", "Email", new {id = "Email"}));

#line default
#line hidden
                EndContext();
                BeginContext(662, 19, true);
                WriteLiteral("<label for=\"Email\">");
                EndContext();
                BeginContext(682, 25, false);
#line 14 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
                                                                              Write(PopForums.Resources.Email);

#line default
#line hidden
                EndContext();
                BeginContext(707, 10, true);
                WriteLiteral("</label>\n\t");
                EndContext();
                BeginContext(718, 57, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
Write(Html.RadioButton("SearchType", "Role", new {id = "Role"}));

#line default
#line hidden
                EndContext();
                BeginContext(775, 18, true);
                WriteLiteral("<label for=\"Role\">");
                EndContext();
                BeginContext(794, 24, false);
#line 15 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
                                                                           Write(PopForums.Resources.Role);

#line default
#line hidden
                EndContext();
                BeginContext(818, 9, true);
                WriteLiteral("</label>\n");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(834, 6, true);
            WriteLiteral("\n\n<p>\n");
            EndContext();
#line 19 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
     if (Model != null)
	{
		foreach (var user in Model)
		{

#line default
#line hidden
            BeginContext(898, 3, true);
            WriteLiteral("\t\t\t");
            EndContext();
            BeginContext(901, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04804cb7959f42e5af849ffea74a587e", async() => {
                BeginContext(955, 9, false);
#line 23 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
                                                            Write(user.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 23 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
                                       WriteLiteral(user.UserID);

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
            BeginContext(968, 7, true);
            WriteLiteral("<br />\n");
            EndContext();
#line 24 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\Admin\EditUserSearch.cshtml"
		}
	}

#line default
#line hidden
            BeginContext(982, 4, true);
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
