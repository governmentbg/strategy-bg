#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13a429a52325b74a0ed65b0b128e80de59c33a9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Users/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Users_Index))]
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
#line 7 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\_ViewImports.cshtml"
using Models.Context;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13a429a52325b74a0ed65b0b128e80de59c33a9e", @"/Areas/Admin/Views/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "true", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "false", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Users\Index.cshtml"
  
    ViewData["Title"] = "Потребители";

#line default
#line hidden
            BeginContext(47, 33, true);
            WriteLiteral("<section class=\"content\">\r\n\r\n    ");
            EndContext();
            BeginContext(80, 126, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "104ae207a1bd40febdd330b7ccd9f560", async() => {
                BeginContext(138, 64, true);
                WriteLiteral("<i class=\"fa fa-user-plus\"></i>  Регистрирай вътрешен потребител");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(206, 191, true);
            WriteLiteral("\r\n\r\n    <div class=\"search-form\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div>\r\n                    <span>Вид потребител</span>\r\n                    ");
            EndContext();
            BeginContext(398, 110, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Users\Index.cshtml"
               Write(Html.DropDownList("userType", (IEnumerable<SelectListItem>)ViewBag.userTypes, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(508, 109, true);
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    <span>Имена</span>\r\n                    ");
            EndContext();
            BeginContext(618, 63, false);
#line 17 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Users\Index.cshtml"
               Write(Html.TextBox("fullName", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(681, 121, true);
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    <span>Потребителско име</span>\r\n                    ");
            EndContext();
            BeginContext(803, 63, false);
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Users\Index.cshtml"
               Write(Html.TextBox("userName", null, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(866, 216, true);
            WriteLiteral("\r\n                </div>\r\n                <div>\r\n                    <span>Потвърдени/Непотвърдени</span>\r\n                    <select id=\"isApproved\" name=\"isApproved\" class=\"form-control\">\r\n                        ");
            EndContext();
            BeginContext(1082, 25, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "586e84d611874475bd7cef3be79a02b1", async() => {
                BeginContext(1090, 8, true);
                WriteLiteral("Изберете");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1107, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(1133, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2620a4a5799c414cb7e76b420f2be038", async() => {
                BeginContext(1154, 10, true);
                WriteLiteral("Потвърдени");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1173, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(1199, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d59634f18d6a46b3ae6152070e90f354", async() => {
                BeginContext(1221, 12, true);
                WriteLiteral("Непотвърдени");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1242, 396, true);
            WriteLiteral(@"
                    </select>
                </div>
                <div>
                    <span>&nbsp;</span>
                    <button type=""submit"" class=""btn btn-primary dt-reload""><i class=""fa fa-search""></i> Търсене</button>
                </div>
            </div>
        </div>
    </div>

    <table id=""mainTable"" class=""table"" cellspacing=""0""></table>
</section>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1655, 134, true);
                WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n         var dt  = $(\'#mainTable\').DataTable({\r\n             \"ajax\": {\r\n                 \"url\": \'");
                EndContext();
                BeginContext(1790, 22, false);
#line 46 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Users\Index.cshtml"
                    Write(Url.Action("LoadData"));

#line default
#line hidden
                EndContext();
                BeginContext(1812, 991, true);
                WriteLiteral(@"',
                 data: function (d) {
                     d.userType = $('#userType').val();
                     d.fullName = $('#fullName').val();
                     d.userName = $('#userName').val();
                     d.isApproved = $('#isApproved').val();
                 },
                 ""type"": ""POST""
             },
             ""columns"": [
                 {
                     data: ""userType"",
                     title: 'Вид'
                 },
                 {
                     data: ""fullName"",
                     title: 'Имена'
                 },
                 {
                     data: ""userName"",
                     title: 'Потребител'
                 },
                 {
                     data: ""email"",
                     title: 'Имейл'
                 },
                 {
                     data: null,
                     ""render"": function (item) {
                         var updateUrl = '");
                EndContext();
                BeginContext(2804, 38, false);
#line 75 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Users\Index.cshtml"
                                     Write(Url.Action("Update",new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(2842, 800, true);
                WriteLiteral(@"'.replace('666', item.userId);
                         var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-warning"">Редакция</a>';
                         return updButton;
                     },
                     sortable: false
                 }
             ],
             filter: false,
             ""order"": [[0, ""asc""]],
             rowCallback: function (row, data) {
                 if (data[""isActive""] === false) {
                     $(row).addClass(""disabled"");
                 }
                 if (data[""isConfirmed""] === false) {
                     $(row).addClass(""unconfirmed"");
                 }
             }
        });
        $('.dt-reload').click(function () {
            dt.ajax.reload();
        });
    });

    </script>

");
                EndContext();
            }
            );
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
