#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangViewString.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "abc30fa377208c36befad0d07c6347c8366585b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_LangViewString), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/LangViewString.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/LangViewString.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared_LangViewString))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangViewString.cshtml"
using Models;

#line default
#line hidden
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.Context;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"abc30fa377208c36befad0d07c6347c8366585b4", @"/Areas/Admin/Views/Shared/LangViewString.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_LangViewString : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangViewString.cshtml"
  
    string lang = Model;

#line default
#line hidden
            BeginContext(63, 26, true);
            WriteLiteral("<span class=\"lang-name\">\r\n");
            EndContext();
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangViewString.cshtml"
     foreach (var item in GlobalConstants.SelectLangs())
    {

        if (item.Lang == lang)
        {
            

#line default
#line hidden
            BeginContext(217, 19, true);
            WriteLiteral(" Съдържанието е на ");
            EndContext();
            BeginContext(237, 10, false);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangViewString.cshtml"
                                Write(item.Title);

#line default
#line hidden
            EndContext();
            BeginContext(247, 1, true);
            WriteLiteral(" ");
            EndContext();
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\LangViewString.cshtml"
                                                        
        }
    }

#line default
#line hidden
            BeginContext(275, 7, true);
            WriteLiteral("</span>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
