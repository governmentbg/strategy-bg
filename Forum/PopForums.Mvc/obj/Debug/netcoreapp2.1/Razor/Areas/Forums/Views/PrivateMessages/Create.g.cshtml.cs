#pragma checksum "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc287ff11f76432c080c762858a10d3d6a978107"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Forums_Views_PrivateMessages_Create), @"mvc.1.0.view", @"/Areas/Forums/Views/PrivateMessages/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Forums/Views/PrivateMessages/Create.cshtml", typeof(AspNetCore.Areas_Forums_Views_PrivateMessages_Create))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc287ff11f76432c080c762858a10d3d6a978107", @"/Areas/Forums/Views/PrivateMessages/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d5ec50b492d0ac5f784d62580bff0edbd26d79a", @"/Areas/Forums/Views/_ViewImports.cshtml")]
    public class Areas_Forums_Views_PrivateMessages_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
  
	ViewBag.Title = PopForums.Resources.NewPM;
	Layout = "~/Areas/Forums/Views/Shared/PopForumsMaster.cshtml";

#line default
#line hidden
            BeginContext(113, 1, true);
            WriteLiteral("\n");
            EndContext();
            DefineSection("HeaderContent", async() => {
                BeginContext(138, 1428, true);
                WriteLiteral(@"
	<script type=""text/javascript"" language=""javascript"">
		$(function () {
			var toText = $(""#ToText"");
			var toList = $(""#ToList"");
			toText.on(""keyup"", function() {
				var q = $(this).val();
				if (q.length > 1) {
					$.getJSON(PopForums.areaPath + ""/PrivateMessages/GetNames"", { id: q })
						.done(function (data) {
						toList.empty();
						$.each(data, function(i, item) {
							toList.append('<li><a href=""#"" data-userID=""' + item.userID + '"" class=""callout toItem"">' + item.value + '</a></li>');
						});
					});
				} else {
					toList.empty();
				}
			});

			$(document).on(""click"", "".toItem"", function () {
				var item = $(this);
				var userID = item.attr(""data-userID"");
				var label = '<div data-userID=""' + userID + '"" class=""label label-primary toLabel"">' + item[0].innerHTML + ' <span class=""glyphicon glyphicon-remove toLabelX""></span></div>';
				$(""#PMToBox"").append(label);
				toList.empty();
				toText.val("""");
				$(""#ToModal"").modal(""hide"");
				serializeIDs();
			});

			$(documen");
                WriteLiteral(@"t).on(""click"", "".toLabelX"", function () {
				$(this).parent().remove();
				serializeIDs();
			});

			$(""#ToModal"").on(""shown.bs.modal"", function() {
				$(""#ToText"").focus();
			});

			serializeIDs();
		});

		function serializeIDs() {
			var items = $(""#PMToBox div"");
			var ids = [];
			items.each(function () { ids.push($(this).attr(""data-userID"")); });
			$(""#UserIDs"").val(ids);
		}
	</script>
");
                EndContext();
            }
            );
            BeginContext(1568, 12, true);
            WriteLiteral("\n<div>\n\t<h1>");
            EndContext();
            BeginContext(1581, 25, false);
#line 60 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
   Write(PopForums.Resources.NewPM);

#line default
#line hidden
            EndContext();
            BeginContext(1606, 108, true);
            WriteLiteral("</h1>\n\t<ul id=\"TopBreadcrumb\" class=\"breadcrumb\">\n\t\t<li><span class=\"glyphicon glyphicon-chevron-up\"></span>");
            EndContext();
            BeginContext(1714, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b4ce2182d41475c809801de3a60758d", async() => {
                BeginContext(1759, 26, false);
#line 62 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                                                                                                       Write(PopForums.Resources.Forums);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1789, 12, true);
            WriteLiteral("</li>\n\t\t<li>");
            EndContext();
            BeginContext(1801, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d8ab72e641f94497a43b1f186d55374b", async() => {
                BeginContext(1824, 35, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                             Write(PopForums.Resources.PrivateMessages);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1863, 21, true);
            WriteLiteral("</li>\n\t</ul>\n</div>\n\n");
            EndContext();
#line 67 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
 if (ViewBag.Warning != null)
{

#line default
#line hidden
            BeginContext(1915, 30, true);
            WriteLiteral(" <p class=\"bg-danger callout\">");
            EndContext();
            BeginContext(1946, 15, false);
#line 68 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                          Write(ViewBag.Warning);

#line default
#line hidden
            EndContext();
            BeginContext(1961, 5, true);
            WriteLiteral("</p> ");
            EndContext();
#line 68 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                                                    }

#line default
#line hidden
            BeginContext(1968, 317, true);
            WriteLiteral(@"
<div class=""modal fade"" id=""ToModal"" tabindex=""-1"" role=""dialog"">
	<div class=""modal-dialog modal-sm"">
		<div class=""modal-content"">
			<div class=""modal-header"">
				<button type=""button"" class=""close"" data-dismiss=""modal""><span>&times;</span><span class=""sr-only"">Close</span></button>
				<h4 class=""modal-title"">");
            EndContext();
            BeginContext(2286, 22, false);
#line 75 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                                   Write(PopForums.Resources.To);

#line default
#line hidden
            EndContext();
            BeginContext(2308, 99, true);
            WriteLiteral("</h4>\n\t\t\t</div>\n\t\t\t<div class=\"modal-body\">\n\t\t\t\t<input id=\"ToText\" type=\"text\" class=\"form-control\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 2407, "\"", 2448, 1);
#line 78 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
WriteAttributeValue("", 2421, PopForums.Resources.Search, 2421, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2449, 253, true);
            WriteLiteral(" />\n\t\t\t\t<div id=\"ToResultList\">\n\t\t\t\t\t<ul id=\"ToList\" class=\"list-unstyled\"></ul>\n\t\t\t\t</div>\n\t\t\t</div>\n\t\t\t<div class=\"modal-footer\">\n\t\t\t\t<button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\">Close</button>\n\t\t\t</div>\n\t\t</div>\n\t</div>\n</div>\n\n");
            EndContext();
            BeginContext(2702, 1000, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ad4531df6aa4188a919fa32dd3d5626", async() => {
                BeginContext(2722, 196, true);
                WriteLiteral("\n\t<input type=\"hidden\" id=\"UserIDs\" name=\"UserIDs\"/>\n\t<div role=\"form\">\n\t\t<div class=\"form-group\">\n\t\t\t<label><input type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#ToModal\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2918, "\"", 2949, 1);
#line 94 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
WriteAttributeValue("", 2926, PopForums.Resources.To, 2926, 23, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2950, 54, true);
                WriteLiteral("/></label>\n\t\t\t<div id=\"PMToBox\" class=\"form-control\">\n");
                EndContext();
#line 96 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                 if (ViewBag.TargetUserID != null)
				{

#line default
#line hidden
                BeginContext(3049, 23, true);
                WriteLiteral("\t\t\t\t\t<div data-userid=\"");
                EndContext();
                BeginContext(3073, 20, false);
#line 98 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                                 Write(ViewBag.TargetUserID);

#line default
#line hidden
                EndContext();
                BeginContext(3093, 38, true);
                WriteLiteral("\" class=\"label label-primary toLabel\">");
                EndContext();
                BeginContext(3132, 22, false);
#line 98 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                                                                                            Write(ViewBag.TargetUserName);

#line default
#line hidden
                EndContext();
                BeginContext(3154, 65, true);
                WriteLiteral(" <span class=\"glyphicon glyphicon-remove toLabelX\"></span></div>\n");
                EndContext();
#line 99 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
				}

#line default
#line hidden
                BeginContext(3225, 70, true);
                WriteLiteral("\t\t\t</div>\n\t\t</div>\n\t\t<div class=\"form-group\">\n\t\t\t<label for=\"Subject\">");
                EndContext();
                BeginContext(3296, 27, false);
#line 103 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                            Write(PopForums.Resources.Subject);

#line default
#line hidden
                EndContext();
                BeginContext(3323, 143, true);
                WriteLiteral("</label>\n\t\t\t<input type=\"text\" id=\"Subject\" name=\"Subject\" class=\"form-control\"/>\n\t\t</div>\n\t\t<div class=\"form-group\">\n\t\t\t<label for=\"FullText\">");
                EndContext();
                BeginContext(3467, 27, false);
#line 107 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
                             Write(PopForums.Resources.Message);

#line default
#line hidden
                EndContext();
                BeginContext(3494, 132, true);
                WriteLiteral("</label>\n\t\t\t<textarea id=\"FullText\" name=\"FullText\" class=\"form-control\"></textarea>\n\t\t</div>\n\t\t<input id=\"SendButton\" type=\"submit\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3626, "\"", 3659, 1);
#line 110 "C:\Projects\Strategy\newSingleSite\Forum\PopForums.Mvc\Areas\Forums\Views\PrivateMessages\Create.cshtml"
WriteAttributeValue("", 3634, PopForums.Resources.Send, 3634, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3660, 35, true);
                WriteLiteral(" class=\"btn btn-primary\"/>\n\t</div>\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
