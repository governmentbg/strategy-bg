#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d00ad4bd199c8ed434a1ff75e056dff98ba40482"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Library_Select), @"mvc.1.0.view", @"/Areas/Admin/Views/Library/Select.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Library/Select.cshtml", typeof(AspNetCore.Areas_Admin_Views_Library_Select))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d00ad4bd199c8ed434a1ff75e056dff98ba40482", @"/Areas/Admin/Views/Library/Select.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec689d54487eca61e3f158b7f8d73212d01bdb46", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Library_Select : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
  
    SourceTypeVM sourceType = GlobalConstants.GetSourceType((int)ViewBag.source_type);

#line default
#line hidden
            BeginContext(95, 1495, true);
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-4 col-md-6 col-sm-12"">
        <div class=""box box-success"">
            <div class=""box-header with-border"" style=""max-height:75vh;overflow-y:scroll;"">
                <div id=""tree""></div>
            </div>
        </div>
    </div>
    <div class=""col-lg-8 col-md-6 col-sm-12"">
        <div class=""box box-success"">
            <div class=""box-header with-border"">
                <div style=""max-height:75vh;overflow-y:scroll;"">

                    <div id=""gridview"">Изберете папка</div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""pull-right"">
            <a href=""#"" id=""divAddbtn"" onclick=""addFile(); return false;"" class=""btn btn-success"" style=""display:none;""><i class=""fa fa-plus""></i> Добави нов файл</a>
            &nbsp;&nbsp;
            <button type=""button"" class=""btn btn-default modal-hide"">Отказ</button>

        </div>
    </div>
<");
            WriteLiteral(@"/div>
<script>
    $('#tree')
        .on('changed.jstree', function (e, data) {
            selectedNode = data.node;
            showFiles();
            $('#divAddbtn').show();
        })
        .on('ready.jstree', function (e, data) {
            //alert('ready');
            data.instance.redraw(true);
            $(this).jstree(""open_all"");
        })
        .jstree({
            'core': {
                'data': {
                    'url': '");
            EndContext();
            BeginContext(1591, 106, false);
#line 49 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
                       Write(Html.Raw(Url.Action("GetTreeViewData", "Library", new { source_type = sourceType.Id, selectOnly = true })));

#line default
#line hidden
            EndContext();
            BeginContext(1697, 161, true);
            WriteLiteral("\'\r\n                }\r\n            }\r\n        });\r\n\r\n    var selectedNode = {};\r\n    function showFiles() {\r\n        $(\'#gridview\').gridView({\r\n            url: \'");
            EndContext();
            BeginContext(1860, 54, false);
#line 57 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
              Write(Url.Action("GetFileList","FileCdn", new { area = "" }));

#line default
#line hidden
            EndContext();
            BeginContext(1915, 53, true);
            WriteLiteral("\',\r\n            data: {\r\n                sourceType: ");
            EndContext();
            BeginContext(1970, 13, false);
#line 59 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
                        Write(sourceType.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1984, 112, true);
            WriteLiteral(",\r\n                sourceId: selectedNode.id\r\n            },\r\n            filter: true,\r\n            template: \'");
            EndContext();
            BeginContext(2098, 129, false);
#line 63 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
                   Write((int)ViewBag.source_type == GlobalConstants.SourceTypes.Library_Images ? "#gridViewTemplateImages" : "#gridViewTemplateDocuments");

#line default
#line hidden
            EndContext();
            BeginContext(2228, 213, true);
            WriteLiteral("\',\r\n            empty_text:\'Няма намерени елементи.\'\r\n        });\r\n    }\r\n    function addFile() {\r\n        if (!selectedNode || !selectedNode.id) {\r\n            return false;\r\n        }\r\n        var uploadUrl = \"");
            EndContext();
            BeginContext(2442, 142, false);
#line 71 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
                    Write(Html.Raw(Url.Action("UploadFile","FileCdn",new { area = "",sourceType = (int)ViewBag.source_type , sourceId = 666,callback= "showFiles();" })));

#line default
#line hidden
            EndContext();
            BeginContext(2584, 105, true);
            WriteLiteral("\";\r\n        uploadUrl = uploadUrl.replace(\'666\', selectedNode.id);\r\n        ShowDialogFromAction(\'Добави ");
            EndContext();
            BeginContext(2690, 31, false);
#line 73 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
                                Write(Html.Raw(sourceType.SingleName));

#line default
#line hidden
            EndContext();
            BeginContext(2721, 824, true);
            WriteLiteral(@" в папка: ' + selectedNode.text, uploadUrl);
    }
</script>
<script type=""text/x-handlebars-template"" id=""gridViewTemplateDocuments"">
    <div class=""gridview-item col-lg-4 file"" data-id=""{{id}}"">
        <a href=""#"" onclick=""libSelectDocument('{{id}}','{{#if fileTitle}}{{fileTitle}}{{else}}{{fileName}}{{/if}}');return false;"" title=""Избери"">
            <div class=""title"">{{#if fileTitle}}{{fileTitle}}{{else}}{{fileName}}{{/if}} </div>
            <div class=""file"">{{fileName}}</div>
            <div class=""date"">{{dateUploadedText}}</div>
        </a>
    </div>
</script>

<script type=""text/x-handlebars-template"" id=""gridViewTemplateImages"">
    <div class=""gridview-item col-lg-4 img"">
        <a href=""#"" onclick=""libSelectImage('{{id}}','{{fileTitle}}')"" title=""Избери"">
            <img src=""");
            EndContext();
            BeginContext(3547, 112, false);
#line 89 "C:\Projects\Strategy\newSingleSite\Domain\Areas\Admin\Views\Library\Select.cshtml"
                  Write(Url.Action("ViewImage","FileCdn",new { area = "",sourceType = GlobalConstants.SourceTypes.Library_ImagesThumbs}));

#line default
#line hidden
            EndContext();
            BeginContext(3660, 167, true);
            WriteLiteral("&sourceId={{id}}\" />\r\n\r\n            <div class=\"file\">{{fileName}}</div>\r\n            <div class=\"date\">{{dateUploadedText}}</div>\r\n        </a>\r\n    </div>\r\n</script>");
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
