#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33a7c7673f3a800a164b66b8e028b78855497dd5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_GroupUsers_Users), @"mvc.1.0.view", @"/Areas/Admin/Views/GroupUsers/Users.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/GroupUsers/Users.cshtml", typeof(AspNetCore.Areas_Admin_Views_GroupUsers_Users))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33a7c7673f3a800a164b66b8e028b78855497dd5", @"/Areas/Admin/Views/GroupUsers/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_GroupUsers_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GroupUserVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
  
    ViewData["Title"] = "Потребители в група " + Model.Organization;

#line default
#line hidden
            DefineSection("breadcrumbs", async() => {
                BeginContext(118, 48, true);
                WriteLiteral("\r\n\r\n    <ul class=\"breadcrumb \">\r\n        <li><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 166, "\"", 200, 1);
#line 8 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
WriteAttributeValue("", 173, Url.Action("Index","Home"), 173, 27, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(201, 61, true);
                WriteLiteral("><i class=\"fa fa-home\"></i> Начало</a></li>\r\n\r\n        <li><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 262, "\"", 302, 1);
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
WriteAttributeValue("", 269, Url.Action("Index","GroupUsers"), 269, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(303, 42, true);
                WriteLiteral(">Потребителски групи</a></li>\r\n    </ul>\r\n");
                EndContext();
            }
            );
            BeginContext(348, 64, true);
            WriteLiteral("<section class=\"content\">\r\n    <div class=\"pull-left\">\r\n        ");
            EndContext();
            BeginContext(412, 141, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4b3cddc18784cc8be6dc38d68fcf811", async() => {
                BeginContext(523, 26, true);
                WriteLiteral("Регистрирай нов потребител");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-groupId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 15 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
                                                               WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["groupId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-groupId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["groupId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(553, 92, true);
            WriteLiteral("\r\n    </div>\r\n    <table id=\"mainTable\" class=\"table\" cellspacing=\"0\"></table>\r\n</section>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(662, 164, true);
                WriteLiteral("\r\n    <script>\r\n        var dt = {};\r\n        $(function () {\r\n            dt = $(\'#mainTable\').DataTable({\r\n                \"ajax\": {\r\n                    \"url\": \'");
                EndContext();
                BeginContext(827, 28, false);
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
                       Write(Url.Action("Users_LoadData"));

#line default
#line hidden
                EndContext();
                BeginContext(855, 83, true);
                WriteLiteral("\',\r\n                    data: function (d) {\r\n                        d.groupId = \'");
                EndContext();
                BeginContext(939, 8, false);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
                                Write(Model.Id);

#line default
#line hidden
                EndContext();
                BeginContext(947, 537, true);
                WriteLiteral(@"';
                    },
                    ""type"": ""POST""
                },
                ""columns"": [
                    {
                        data: ""userFullName"",
                        title: 'Имена'
                    },
                    {
                        data: ""userEmail"",
                        title: 'Имейл'
                    },
                    {
                        data: null,
                        ""render"": function (item) {
                            var updateUrl = '");
                EndContext();
                BeginContext(1485, 46, false);
#line 43 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
                                        Write(Url.Action("Update","Users",new { id = "666"}));

#line default
#line hidden
                EndContext();
                BeginContext(1531, 767, true);
                WriteLiteral(@"'.replace('666', item.userId);
                            var updButton = '<a href=""' + updateUrl + '"" class=""btn btn-warning"">Редакция на потребител</a>';

                            //var remButton = '&nbsp;<a href=""#"" class=""btn btn-danger"" onclick=""if(!confirm(\'Потвърди премахването на потребителя!\')){return false;} RemoveUser(' + item.groupUserId + ',' + item.userId + ');"">Премахни</a>';
                            var remButton = TemplateToHtml('#btnRemoveTemplate', item);
                            return updButton + remButton;
                        },
                        sortable: false
                    }
                ]
            });

         });
         function RemoveUser(groupId,userId) {
            var url = '");
                EndContext();
                BeginContext(2299, 33, false);
#line 57 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\GroupUsers\Users.cshtml"
                  Write(Url.Action("Remove","GroupUsers"));

#line default
#line hidden
                EndContext();
                BeginContext(2332, 573, true);
                WriteLiteral(@"';
            requestContent(url, { groupId: groupId, userId: userId }, function (result) {
                if (result === 'True') {
                    document.location.reload();
                }
            });
        }

    </script>
    <script type=""text/x-handlebars-template"" id=""btnRemoveTemplate"">
        &nbsp;
        <a href=""#"" class=""btn btn-danger""
           onclick=""if (!confirm('Потвърди премахването на потребителя!')) { return false; } RemoveUser({{ groupUserId }}, {{ userId }});"">
            Премахни
        </a>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GroupUserVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
