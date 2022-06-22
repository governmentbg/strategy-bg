#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee612f337665b71965ebdc66c381e5535904ed02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PCSubjectsPDF), @"mvc.1.0.view", @"/Views/Shared/_PCSubjectsPDF.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_PCSubjectsPDF.cshtml", typeof(AspNetCore.Views_Shared__PCSubjectsPDF))]
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
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Domain;

#line default
#line hidden
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels;

#line default
#line hidden
#line 4 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels.Account;

#line default
#line hidden
#line 5 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels.Portal;

#line default
#line hidden
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.ViewModels.MulticriteriaAnalysis;

#line default
#line hidden
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using WebCommon.TagHelpers;

#line default
#line hidden
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using WebCommon.Models;

#line default
#line hidden
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Models.Context;

#line default
#line hidden
#line 11 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Domain.Class;

#line default
#line hidden
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee612f337665b71965ebdc66c381e5535904ed02", @"/Views/Shared/_PCSubjectsPDF.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PCSubjectsPDF : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Models.ViewModels.PCSubjectsModels.PCSubjectsListViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
  
    Layout = "~/Views/Shared/_LayoutQuestionary.cshtml";
    ViewData["Title"] = "Списък на физическите и юридическите лица съгласно ЗНА";

#line default
#line hidden
            BeginContext(221, 454, true);
            WriteLiteral(@"
<section class=""content"">
    <h2>Списък на физическите и юридическите лица съгласно ЗНА</h2>
    <table border=""1"">
        <tr>
            <th>Име</th>
            <th>Вид лице</th>
            <th>ЕИК</th>
            <th>Дата на договор</th>
            <th>Възложител</th>
            <th>Възнаграждение за извършените услуги в лева</th>
            <th>с ДДС</th>
            <th>Описание на извършените услуги</th>
        </tr>

");
            EndContext();
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
         foreach (var item in Model)
        {
            

#line default
#line hidden
            BeginContext(737, 16, false);
#line 23 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<tr>"));

#line default
#line hidden
            EndContext();
            BeginContext(768, 39, false);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<td>" + @item.Name + "</td>"));

#line default
#line hidden
            EndContext();
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
                                                    
            if (@item.IsUL == 1)
            {
                

#line default
#line hidden
            BeginContext(875, 23, false);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
           Write(Html.Raw("<td>ЮЛ</td>"));

#line default
#line hidden
            EndContext();
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
                                        
            }
            else
            {
                

#line default
#line hidden
            BeginContext(965, 23, false);
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
           Write(Html.Raw("<td>ФЛ</td>"));

#line default
#line hidden
            EndContext();
#line 31 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
                                        
            }
            

#line default
#line hidden
            BeginContext(1018, 38, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<td>" + @item.EIK + "</td>"));

#line default
#line hidden
            EndContext();
            BeginContext(1071, 46, false);
#line 34 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<td>" + @item.DatePayment + "</td>"));

#line default
#line hidden
            EndContext();
            BeginContext(1132, 55, false);
#line 35 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<td>" + @item.ContractingAuthority + "</td>"));

#line default
#line hidden
            EndContext();
            BeginContext(1202, 87, false);
#line 36 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<td>" + ((@item.PaymentVaPaymentIncludeVAT == true) ? "ДА" : "НЕ") + "</td>"));

#line default
#line hidden
            EndContext();
            BeginContext(1304, 61, false);
#line 37 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<td align='right'>" + @item.PaymentValue + "</td>"));

#line default
#line hidden
            EndContext();
            BeginContext(1380, 54, false);
#line 38 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("<td>" + @item.ActivityDescription + "</td>"));

#line default
#line hidden
            EndContext();
            BeginContext(1449, 17, false);
#line 39 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
       Write(Html.Raw("</tr>"));

#line default
#line hidden
            EndContext();
#line 39 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PCSubjectsPDF.cshtml"
                              
        }

#line default
#line hidden
            BeginContext(1479, 28, true);
            WriteLiteral("\r\n    </table>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Models.ViewModels.PCSubjectsModels.PCSubjectsListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591