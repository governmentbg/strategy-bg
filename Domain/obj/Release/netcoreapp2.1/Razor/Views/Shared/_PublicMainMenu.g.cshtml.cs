#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e76209e88e359e813d69624a9bcfd642da0ad61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PublicMainMenu), @"mvc.1.0.view", @"/Views/Shared/_PublicMainMenu.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_PublicMainMenu.cshtml", typeof(AspNetCore.Views_Shared__PublicMainMenu))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e76209e88e359e813d69624a9bcfd642da0ad61", @"/Views/Shared/_PublicMainMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PublicMainMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
  
    string controller = (string)ViewBag.controllerName ?? "";

#line default
#line hidden
            BeginContext(123, 5, true);
            WriteLiteral("\r\n<li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 128, "\"", 196, 1);
            WriteAttributeValue("", 136, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
            if(controller == "PublicConsultation"){

#line default
#line hidden
                BeginContext(182, 6, true);
                WriteLiteral("active");
                EndContext();
#line 6 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                                      }

#line default
#line hidden
                PopWriter();
            }
            ), 136, 60, false);
            EndWriteAttribute();
            BeginContext(197, 9, true);
            WriteLiteral(">\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 206, "\"", 273, 1);
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
WriteAttributeValue("", 213, Url.Action("Index","PublicConsultation", new { area = "" }), 213, 60, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(274, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(276, 38, false);
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                                      Write(Localizer["MENU_PUBLIC_CONSULTATIONS"]);

#line default
#line hidden
            EndContext();
            BeginContext(314, 16, true);
            WriteLiteral("</a>\r\n</li>\r\n<li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 330, "\"", 397, 1);
            WriteAttributeValue("", 338, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
            if(controller == "StrategicDocument"){

#line default
#line hidden
                BeginContext(383, 6, true);
                WriteLiteral("active");
                EndContext();
#line 9 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                                     }

#line default
#line hidden
                PopWriter();
            }
            ), 338, 59, false);
            EndWriteAttribute();
            BeginContext(398, 9, true);
            WriteLiteral(">\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 407, "\"", 473, 1);
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
WriteAttributeValue("", 414, Url.Action("Index","StrategicDocument", new { area = "" }), 414, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(474, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(476, 37, false);
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                                     Write(Localizer["MENU_STRATEGIC_DOCUMENTS"]);

#line default
#line hidden
            EndContext();
            BeginContext(513, 18, true);
            WriteLiteral("</a>\r\n</li>\r\n\r\n<li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 531, "\"", 659, 1);
            WriteAttributeValue("", 539, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
            if(new string[]{"MulticriteriaAnalysis","Page","StandartForms","MSprogram"}.Contains(controller) ){

#line default
#line hidden
                BeginContext(645, 6, true);
                WriteLiteral("active");
                EndContext();
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                                                                                                  }

#line default
#line hidden
                PopWriter();
            }
            ), 539, 120, false);
            EndWriteAttribute();
            BeginContext(660, 9, true);
            WriteLiteral(">\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 669, "\"", 733, 1);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
WriteAttributeValue("", 676, Url.Action("LawPrograms","MSprogram", new { area = "" }), 676, 57, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(734, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(736, 31, false);
#line 14 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                                   Write(Localizer["SECTION_ASSESSMENT"]);

#line default
#line hidden
            EndContext();
            BeginContext(767, 18, true);
            WriteLiteral("</a>\r\n</li>\r\n\r\n<li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 785, "\"", 846, 1);
            WriteAttributeValue("", 793, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
            if(controller == "Publication"){

#line default
#line hidden
                BeginContext(832, 6, true);
                WriteLiteral("active");
                EndContext();
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                               }

#line default
#line hidden
                PopWriter();
            }
            ), 793, 53, false);
            EndWriteAttribute();
            BeginContext(847, 9, true);
            WriteLiteral(">\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 856, "\"", 916, 1);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
WriteAttributeValue("", 863, Url.Action("Index","Publication", new { area = "" }), 863, 53, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(917, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(919, 30, false);
#line 18 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                               Write(Localizer["MENU_PUBLICATIONS"]);

#line default
#line hidden
            EndContext();
            BeginContext(949, 16, true);
            WriteLiteral("</a>\r\n</li>\r\n<li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 965, "\"", 1019, 1);
            WriteAttributeValue("", 973, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
            if(controller == "News"){

#line default
#line hidden
                BeginContext(1005, 6, true);
                WriteLiteral("active");
                EndContext();
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                        }

#line default
#line hidden
                PopWriter();
            }
            ), 973, 46, false);
            EndWriteAttribute();
            BeginContext(1020, 9, true);
            WriteLiteral(">\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1029, "\"", 1082, 1);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
WriteAttributeValue("", 1036, Url.Action("Index","News", new { area = "" }), 1036, 46, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1083, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1085, 22, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                        Write(Localizer["MENU_NEWS"]);

#line default
#line hidden
            EndContext();
            BeginContext(1107, 16, true);
            WriteLiteral("</a>\r\n</li>\r\n<li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1123, "\"", 1179, 1);
            WriteAttributeValue("", 1131, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 23 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
            if(controller == "Forums"){

#line default
#line hidden
                BeginContext(1165, 6, true);
                WriteLiteral("active");
                EndContext();
#line 23 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                          }

#line default
#line hidden
                PopWriter();
            }
            ), 1131, 48, false);
            EndWriteAttribute();
            BeginContext(1180, 9, true);
            WriteLiteral(">\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1189, "\"", 1244, 1);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
WriteAttributeValue("", 1196, Url.Action("Index","Forums", new { area = "" }), 1196, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1245, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1247, 23, false);
#line 24 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                          Write(Localizer["MENU_FORUM"]);

#line default
#line hidden
            EndContext();
            BeginContext(1270, 16, true);
            WriteLiteral("</a>\r\n</li>\r\n<li");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1286, "\"", 1339, 1);
            WriteAttributeValue("", 1294, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#line 26 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
            if(controller == "Ogp"){

#line default
#line hidden
                BeginContext(1325, 6, true);
                WriteLiteral("active");
                EndContext();
#line 26 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                       }

#line default
#line hidden
                PopWriter();
            }
            ), 1294, 45, false);
            EndWriteAttribute();
            BeginContext(1340, 9, true);
            WriteLiteral(">\r\n    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1349, "\"", 1405, 1);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
WriteAttributeValue("", 1356, Url.Action("Index","Article", new { area = "" }), 1356, 49, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1406, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1408, 21, false);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_PublicMainMenu.cshtml"
                                                           Write(Localizer["MENU_OGP"]);

#line default
#line hidden
            EndContext();
            BeginContext(1429, 11, true);
            WriteLiteral("</a>\r\n</li>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<CommonResources> Localizer { get; private set; }
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
