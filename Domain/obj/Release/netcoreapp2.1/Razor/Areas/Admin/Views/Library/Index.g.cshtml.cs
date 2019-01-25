#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48358a41c20831a9fa77b6a0a83ddcb777ffc068"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Library_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Library/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Library/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Library_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48358a41c20831a9fa77b6a0a83ddcb777ffc068", @"/Areas/Admin/Views/Library/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Library_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
  
    SourceTypeVM sourceType = GlobalConstants.GetSourceType((int)ViewBag.source_type);
    ViewData["Title"] = sourceType.ListName;

#line default
#line hidden
            BeginContext(141, 198, true);
            WriteLiteral("<section class=\"content\">\r\n    <div class=\"row\">\r\n        <div class=\"col-lg-4 col-md-6 col-sm-12\">\r\n            <div class=\"box box-success\">\r\n                <div class=\"box-header with-border\">\r\n");
            EndContext();
            BeginContext(425, 251, true);
            WriteLiteral("                    <div id=\"tree\"></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-lg-8 col-md-6 col-sm-12\">\r\n            <div class=\"box box-success\">\r\n                <div class=\"box-header with-border\">\r\n");
            EndContext();
            BeginContext(749, 148, true);
            WriteLiteral("                    <div>\r\n                        <a href=\"#\" id=\"addFileButton\" class=\"btn btn-success\" onclick=\"addFile(); return false;\">Добави ");
            EndContext();
            BeginContext(898, 21, false);
#line 20 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                                                                                                                    Write(sourceType.SingleName);

#line default
#line hidden
            EndContext();
            BeginContext(919, 695, true);
            WriteLiteral(@"</a>
                        <div id=""gridview"">Изберете папка</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<script>
    $(function () {
        $('#addFileButton').hide();
        $('#tree')
            .on('changed.jstree', function (e, data) {
                if (data.node.id == 'new') {
                    window.location.href = data.node.a_attr.href;
                } else {
                    selectedNode = data.node;
                    showFiles();
                }
            })
            .jstree({
                'core': {
                    'data': {
                        'url': '");
            EndContext();
            BeginContext(1615, 65, false);
#line 43 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                           Write(Url.Action("GetTreeViewData",new { source_type = sourceType.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1680, 1194, true);
            WriteLiteral(@"'
                    }
                }, 'contextmenu': {
                    'items': customMenu
                }
                , 'plugins': ['contextmenu']
            })
            .bind(""loaded.jstree"", function (event, data) {
                // you get two params - event & data - check the core docs for a detailed description
                $(this).jstree(""open_all"");
            });

    });
    function customMenu(node)
    {
        if (node.id == 'new') {
            return null;
        }
        var items = {
            'item1': {
                'label': 'Редакция',
                'action': function () {
                    window.location.href = node.a_attr.update;
                }
            },
            'item2': {
                'label': 'Добави под-папка',
                'icon' : 'fa fa-plus',
                'action': function () {
                    window.location.href = node.a_attr.sub;
                }
            }
        }


        ");
            WriteLiteral("return items;\r\n    }\r\n\r\n    var selectedNode = {};\r\n    function showFiles() {\r\n        $(\'#addFileButton\').show();\r\n        $(\'#gridview\').gridView({\r\n            url: \'");
            EndContext();
            BeginContext(2876, 50, false);
#line 85 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
              Write(Url.Action("GetFileList","FileCdn",new { area=""}));

#line default
#line hidden
            EndContext();
            BeginContext(2927, 53, true);
            WriteLiteral("\',\r\n            data: {\r\n                sourceType: ");
            EndContext();
            BeginContext(2982, 13, false);
#line 87 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                        Write(sourceType.Id);

#line default
#line hidden
            EndContext();
            BeginContext(2996, 111, true);
            WriteLiteral(",\r\n                sourceId: selectedNode.id\r\n            },\r\n            filter:true,\r\n            template: \'");
            EndContext();
            BeginContext(3109, 125, false);
#line 91 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                   Write((int)ViewBag.source_type == GlobalConstants.SourceTypes.Library_Images ? "#gridViewTemplateImages" : "#gridViewTemplateFiles");

#line default
#line hidden
            EndContext();
            BeginContext(3235, 125, true);
            WriteLiteral("\',\r\n            empty_text:\'Няма намерени елементи.\'\r\n        });\r\n    }\r\n    function addFile() {\r\n        var uploadUrl = \"");
            EndContext();
            BeginContext(3361, 142, false);
#line 96 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                    Write(Html.Raw(Url.Action("UploadFile","FileCdn",new { area = "",sourceType = (int)ViewBag.source_type , sourceId = 666,callback= "showFiles();" })));

#line default
#line hidden
            EndContext();
            BeginContext(3503, 126, true);
            WriteLiteral("\";\r\n        uploadUrl = uploadUrl.replace(\'666\', selectedNode.id);\r\n        //debugger;\r\n        ShowDialogFromAction(\'Добави ");
            EndContext();
            BeginContext(3630, 31, false);
#line 99 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                                Write(Html.Raw(sourceType.SingleName));

#line default
#line hidden
            EndContext();
            BeginContext(3661, 131, true);
            WriteLiteral(" в папка: \' + selectedNode.text, uploadUrl);\r\n    }\r\n    function removeFile(id) {\r\n        if (!confirm(\'Потвърди премахването на ");
            EndContext();
            BeginContext(3794, 31, false);
#line 102 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                                           Write(Html.Raw(sourceType.SingleName));

#line default
#line hidden
            EndContext();
            BeginContext(3826, 65, true);
            WriteLiteral("!\')) {\r\n            return false;\r\n        }\r\n        var url = \'");
            EndContext();
            BeginContext(3893, 53, false);
#line 105 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
               Write(Url.Action("DisableFile","FileCdn",new { area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(3947, 341, true);
            WriteLiteral(@"';
        $.post(url, {id:id}, function (content) {
            if (content == 'ok') {
                showFiles();
            };
        });
    }
</script>

<script type=""text/x-handlebars-template"" id=""gridViewTemplateFiles"">
    <div class=""gridview-item col-lg-4 file"" data-id=""{{id}}"">
        <div class=""title""><a href=""");
            EndContext();
            BeginContext(4290, 54, false);
#line 116 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                                Write(Url.Action("DownloadFile","FileCdn",new { area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(4345, 523, true);
            WriteLiteral(@"?id={{id}}"" title=""Изтегли""><i class=""glyphicon glyphicon-download""></i></a> {{#if fileTitle}}{{fileTitle}}{{else}}{{fileName}}{{/if}}</div>
        <div class=""file"">{{fileName}} <a href=""#"" onclick=""removeFile('{{id}}');return false;"" title=""Премахни""><i class=""glyphicon glyphicon-remove""></i></a></div>
        <div class=""date"">{{dateUploadedText}}</div>
    </div>
</script>

<script type=""text/x-handlebars-template"" id=""gridViewTemplateImages"">
    <div class=""gridview-item col-lg-3 img"">
        <a href=""");
            EndContext();
            BeginContext(4870, 51, false);
#line 124 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
             Write(Url.Action("ViewImage","FileCdn",new { area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(4922, 128, true);
            WriteLiteral("?id={{id}}\" title=\"{{#if fileTitle}}{{fileTitle}}{{else}}Няма въведено описание{{/if}}\" target=\"_blank\">\r\n            <img src=\"");
            EndContext();
            BeginContext(5052, 111, false);
#line 125 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                  Write(Url.Action("ViewImage","FileCdn",new {area = "",sourceType = GlobalConstants.SourceTypes.Library_ImagesThumbs}));

#line default
#line hidden
            EndContext();
            BeginContext(5164, 87, true);
            WriteLiteral("&sourceId={{id}}\" class=\"preview\" />\r\n        </a>\r\n        <div class=\"file\"><a href=\"");
            EndContext();
            BeginContext(5253, 54, false);
#line 127 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Index.cshtml"
                               Write(Url.Action("DownloadFile","FileCdn",new { area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(5308, 308, true);
            WriteLiteral(@"?id={{id}}"" title=""Изтегли""><i class=""glyphicon glyphicon-download""></i></a> {{fileName}} <a href=""#"" onclick=""removeFile('{{id}}');return false;"" title=""Премахни"" class=""danger""><i class=""glyphicon glyphicon-remove""></i></a></div>
        <div class=""date"">{{dateUploadedText}}</div>
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
