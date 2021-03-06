#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21286404c026e3810ca924ec864f7183eebc628f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_LangSelect), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/LangSelect.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/LangSelect.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared_LangSelect))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Domain;

#line default
#line hidden
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.ViewModels;

#line default
#line hidden
#line 4 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.ViewModels.Account;

#line default
#line hidden
#line 5 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.Context.Account;

#line default
#line hidden
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using WebCommon.TagHelpers;

#line default
#line hidden
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
using Models;

#line default
#line hidden
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.Context;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21286404c026e3810ca924ec864f7183eebc628f", @"/Areas/Admin/Views/Shared/LangSelect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_LangSelect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
  
    int lang = Model;
    var addValues = (ICollection<KeyValuePair<string, string>>)ViewData["addValues"];

#line default
#line hidden
            BeginContext(144, 7, true);
            WriteLiteral("<div>\r\n");
            EndContext();
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
            BeginContext(189, 45, true);
            WriteLiteral("        <input type=\"hidden\" name=\"lang\" />\r\n");
            EndContext();
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
         if (addValues != null)
        {
            foreach (var item in addValues)
            {

#line default
#line hidden
            BeginContext(338, 36, true);
            WriteLiteral("                <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 374, "\"", 390, 1);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
WriteAttributeValue("", 381, item.Key, 381, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 391, "\"", 410, 1);
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
WriteAttributeValue("", 399, item.Value, 399, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(411, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
            }
        }

#line default
#line hidden
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
         foreach (var item in GlobalConstants.SelectLangs())
        {
            var btnClass = "btn-default";
            if (item.LangId == lang)
            {
                btnClass = "btn-primary";
            }

#line default
#line hidden
            BeginContext(669, 23, true);
            WriteLiteral("            <a href=\"#\"");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 692, "\"", 720, 3);
            WriteAttributeValue("", 700, "submit", 700, 6, true);
            WriteAttributeValue(" ", 706, "btn", 707, 4, true);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
WriteAttributeValue(" ", 710, btnClass, 711, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(721, 12, true);
            WriteLiteral(" data-lang=\"");
            EndContext();
            BeginContext(734, 11, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
                                                           Write(item.LangId);

#line default
#line hidden
            EndContext();
            BeginContext(745, 1, true);
            WriteLiteral("\"");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 746, "\"", 783, 4);
            WriteAttributeValue("", 754, "Покажи", 754, 6, true);
            WriteAttributeValue(" ", 760, "данните", 761, 8, true);
            WriteAttributeValue(" ", 768, "на", 769, 3, true);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
WriteAttributeValue(" ", 771, item.Title, 772, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(784, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(786, 19, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
                                                                                                               Write(item.Lang.ToUpper());

#line default
#line hidden
            EndContext();
            BeginContext(805, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 26 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
        }

#line default
#line hidden
#line 26 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangSelect.cshtml"
         
    }

#line default
#line hidden
            BeginContext(829, 267, true);
            WriteLiteral(@"    <br />
</div>
<script>
    $(function () {
        $('a.submit').click(function () {
            var lang = $(this).data('lang');
            $(this).parents('form:first').find('input[type=""hidden""][name=""lang""]').val(lang);
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
