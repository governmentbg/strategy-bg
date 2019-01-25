#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d47dfa83556ed58be5ab705a5ec19d330fdab705"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_UsedDocuments), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/UsedDocuments.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/UsedDocuments.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared_UsedDocuments))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d47dfa83556ed58be5ab705a5ec19d330fdab705", @"/Areas/Admin/Views/Shared/UsedDocuments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_UsedDocuments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FileCDN.Models.FileSelect>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 196, true);
            WriteLiteral("<fieldset>\r\n    <div id=\"fileList-container\">\r\n\r\n    </div>\r\n</fieldset>\r\n<script>\r\n    $(function () {\r\n        LoadAttachedFiles();\r\n    });\r\n    function LoadAttachedFiles() {\r\n        $.post(\'");
            EndContext();
            BeginContext(231, 33, false);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
           Write(Url.Action("GetFileList", "Ajax"));

#line default
#line hidden
            EndContext();
            BeginContext(264, 29, true);
            WriteLiteral("\',\r\n            { sourceType:");
            EndContext();
            BeginContext(295, 16, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                     Write(Model.SourceType);

#line default
#line hidden
            EndContext();
            BeginContext(312, 11, true);
            WriteLiteral(", sourceId:");
            EndContext();
            BeginContext(325, 14, false);
#line 13 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                                                   Write(Model.SourceID);

#line default
#line hidden
            EndContext();
            BeginContext(340, 91, true);
            WriteLiteral("},\r\n            function (data) {\r\n                var canAdd = true;\r\n                if (");
            EndContext();
            BeginContext(433, 35, false);
#line 16 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                Write(Model.SingleFile ? "true" : "false");

#line default
#line hidden
            EndContext();
            BeginContext(469, 368, true);
            WriteLiteral(@" && data.length > 0) {
                    canAdd = false;
                }
                var model = {
                    items : data,
                    canAdd: canAdd
                };
                $('#fileList-container').html(TemplateToHtml(""#fileListTemplate"", model));
            });
    }

    function chooseFile() {
        var url = '");
            EndContext();
            BeginContext(838, 107, false);
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
              Write(Html.Raw(Url.Action("Select","Library",new { source_type = GlobalConstants.SourceTypes.Library_Documents})));

#line default
#line hidden
            EndContext();
            BeginContext(945, 140, true);
            WriteLiteral("\';\r\n        ShowPlainDialogFromAction(\'Избери документ\', url);\r\n    }\r\n    function libSelectDocument(fileId, fileTitle) {\r\n        $.post(\'");
            EndContext();
            BeginContext(1086, 36, false);
#line 32 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
           Write(Url.Action("AppendUsedFile", "Ajax"));

#line default
#line hidden
            EndContext();
            BeginContext(1122, 29, true);
            WriteLiteral("\',\r\n            { sourceType:");
            EndContext();
            BeginContext(1153, 16, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                     Write(Model.SourceType);

#line default
#line hidden
            EndContext();
            BeginContext(1170, 11, true);
            WriteLiteral(", sourceId:");
            EndContext();
            BeginContext(1183, 14, false);
#line 33 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                                                   Write(Model.SourceID);

#line default
#line hidden
            EndContext();
            BeginContext(1198, 320, true);
            WriteLiteral(@",fileId:fileId},
            function (data) {
                LoadAttachedFiles();
            });

        $('.plainModal').hide();
    }
    function removeFile(fileId, fileTitle) {
        if (!confirm('Потвърди премахването на файла: ' + fileTitle)) {
            return false;
        }
        $.post('");
            EndContext();
            BeginContext(1519, 36, false);
#line 44 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
           Write(Url.Action("RemoveUsedFile", "Ajax"));

#line default
#line hidden
            EndContext();
            BeginContext(1555, 29, true);
            WriteLiteral("\',\r\n            { sourceType:");
            EndContext();
            BeginContext(1586, 16, false);
#line 45 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                     Write(Model.SourceType);

#line default
#line hidden
            EndContext();
            BeginContext(1603, 11, true);
            WriteLiteral(", sourceId:");
            EndContext();
            BeginContext(1616, 14, false);
#line 45 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                                                   Write(Model.SourceID);

#line default
#line hidden
            EndContext();
            BeginContext(1631, 413, true);
            WriteLiteral(@",fileId:fileId},
            function (data) {
                LoadAttachedFiles();
                
            });
    }
</script>
<script type=""text/x-handlebars-template"" id=""fileListTemplate"">
    <div class=""row"">
        {{#each items}}
        <div class=""col-lg-6 col-md-12 used-file-block"">
            <div class=""row"">
                <div class=""col-lg-10"">
                    <a href=""");
            EndContext();
            BeginContext(2045, 65, false);
#line 58 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Shared\UsedDocuments.cshtml"
                        Write(Html.Raw(Url.Action("DownloadFile", "FileCdn", new { area = ""})));

#line default
#line hidden
            EndContext();
            BeginContext(2110, 725, true);
            WriteLiteral(@"?id={{fileId}}"">
                        <b>{{fileTitle}}</b>
                        <br />
                        {{fileName}}
                    </a>
                </div>
                <div class=""col-lg-2 used-file-remove-button"">
                    <a href=""#"" onclick=""removeFile('{{fileId}}','{{fileTitle}}');return false;"" class=""btn btn-xs btn-danger"" title=""Премахни""><i class=""fa fa-remove""></i></a>
                </div>
            </div>
        </div>
        {{/each}}
    </div>
    {{#if canAdd}}
    <div class=""used-file-add-button"">
        <a href=""#"" onclick=""chooseFile();"" class=""btn btn-sm btn-success""><i class=""fa fa-plus""></i> Добави</a>
    </div>
    {{/if}}
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FileCDN.Models.FileSelect> Html { get; private set; }
    }
}
#pragma warning restore 1591
