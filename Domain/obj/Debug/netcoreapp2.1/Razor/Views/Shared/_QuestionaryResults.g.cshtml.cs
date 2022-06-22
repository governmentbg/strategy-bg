#pragma checksum "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "447ae8810e3e2981de30e8a4772e4c5ef4c8de0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__QuestionaryResults), @"mvc.1.0.view", @"/Views/Shared/_QuestionaryResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_QuestionaryResults.cshtml", typeof(AspNetCore.Views_Shared__QuestionaryResults))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"447ae8810e3e2981de30e8a4772e4c5ef4c8de0c", @"/Views/Shared/_QuestionaryResults.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf1412ad68915763abac5573310d172851b2661", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__QuestionaryResults : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Models.ViewModels.Questionary.QuestionaryResultsListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/google.loader.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(70, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
  
    ViewData["Title"] = "Резултати от проведена Анкета";

    var titleSize = 12 - Model.PossibleAnswers.Count() - 6;
    var j = 0;
    var k = 0;

    

#line default
#line hidden
#line 10 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
     foreach (var question in Model.Questions)
    {
        

#line default
#line hidden
            BeginContext(295, 113, false);
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
   Write(Html.Raw("<span id='questionId" + k.ToString() + "' style='display: none'>" + question.Id.ToString() + "</span>"));

#line default
#line hidden
            EndContext();
#line 12 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                                                                                                                          
        k++;
    }

#line default
#line hidden
            BeginContext(434, 90, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-1\">\r\n    </div>\r\n    <div class=\"col-md-11\">\r\n");
            EndContext();
#line 21 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
         if (Model.Questions.Count() > 0)
        {
            

#line default
#line hidden
#line 25 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                    
        }

#line default
#line hidden
            BeginContext(849, 12, true);
            WriteLiteral("        <h2>");
            EndContext();
            BeginContext(862, 22, false);
#line 27 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
       Write(Model.QuestionaryTitle);

#line default
#line hidden
            EndContext();
            BeginContext(884, 19, true);
            WriteLiteral("</h2>\r\n        <h4>");
            EndContext();
            BeginContext(904, 39, false);
#line 28 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
       Write(Html.Raw(@Model.QuestionaryDescription));

#line default
#line hidden
            EndContext();
            BeginContext(943, 58, true);
            WriteLiteral("</h4>\r\n\r\n    </div>\r\n</div>\r\n\r\n<section class=\"content\">\r\n");
            EndContext();
#line 50 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
     if (Model.Questions.Count() == 0)
    {

#line default
#line hidden
            BeginContext(1654, 80, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                ");
            EndContext();
            BeginContext(1735, 54, false);
#line 54 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
           Write(Html.Raw("По текущата анкета няма получени отговори."));

#line default
#line hidden
            EndContext();
            BeginContext(1789, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 57 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(1851, 234, true);
            WriteLiteral("        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"data\">\r\n                    <table border=\"0\" width=\"100%\">\r\n                        <tr>\r\n                            <td width=\"50%\"></td>\r\n");
            EndContext();
#line 66 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                             foreach (var possibleAnswer in Model.PossibleAnswers)
                            {

#line default
#line hidden
            BeginContext(2200, 74, true);
            WriteLiteral("                                <td>\r\n                                    ");
            EndContext();
            BeginContext(2275, 31, false);
#line 69 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                               Write(Html.Raw(possibleAnswer.Answer));

#line default
#line hidden
            EndContext();
            BeginContext(2306, 41, true);
            WriteLiteral("\r\n                                </td>\r\n");
            EndContext();
#line 71 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                            }

#line default
#line hidden
            BeginContext(2378, 33, true);
            WriteLiteral("                        </tr>\r\n\r\n");
            EndContext();
#line 74 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                         foreach (var question in Model.Questions)
                        {

#line default
#line hidden
            BeginContext(2506, 120, true);
            WriteLiteral("                            <tr>\r\n                                <td width=\"50%\">\r\n                                    ");
            EndContext();
            BeginContext(2627, 88, false);
#line 78 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                               Write(Html.Raw("<span id='questionText" + j + "'>" + question.QuestionDescription + "</span>"));

#line default
#line hidden
            EndContext();
            BeginContext(2715, 41, true);
            WriteLiteral("\r\n                                </td>\r\n");
            EndContext();
#line 80 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                                 foreach (var answer in question.answers.Where(x => x.QuestionId == question.Id))
                                {

#line default
#line hidden
            BeginContext(2906, 82, true);
            WriteLiteral("                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2989, 81, false);
#line 83 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                                   Write(Html.Raw(answer.AnswersCheckedCount + " / " + answer.AnswersCheckedPercent + "%"));

#line default
#line hidden
            EndContext();
            BeginContext(3070, 45, true);
            WriteLiteral("\r\n                                    </td>\r\n");
            EndContext();
#line 85 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                                }

#line default
#line hidden
            BeginContext(3150, 35, true);
            WriteLiteral("                            </tr>\r\n");
            EndContext();
#line 87 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                            j++;
                        }

#line default
#line hidden
            BeginContext(3246, 30, true);
            WriteLiteral("                    </table>\r\n");
            EndContext();
            BeginContext(4162, 60, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 108 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"

    }

#line default
#line hidden
            BeginContext(4231, 48, true);
            WriteLiteral("    <div style=\"width:100%;padding-left:10%;\">\r\n");
            EndContext();
#line 111 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
         for (int i = 0; i < Model.Questions.Count(); i++)
        {
            

#line default
#line hidden
            BeginContext(4363, 57, false);
#line 113 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
       Write(Html.Raw("<div id='piechart" + i.ToString() + "'></div>"));

#line default
#line hidden
            EndContext();
#line 113 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                                                                      
        }

#line default
#line hidden
            BeginContext(4433, 28, true);
            WriteLiteral("    </div>\r\n\r\n</section>\r\n\r\n");
            EndContext();
            BeginContext(4461, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc2c6a4cf567474182a2bd3b896ee9b4", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4529, 383, true);
            WriteLiteral(@"
<script type=""text/javascript"">
        // Load google charts
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        // Draw the chart and set the chart values
        function drawChart() {
            // Create our data table out of JSON data loaded from server.
            for (var i = 0; i < ");
            EndContext();
            BeginContext(4913, 23, false);
#line 128 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                           Write(Model.Questions.Count());

#line default
#line hidden
            EndContext();
            BeginContext(4936, 77, true);
            WriteLiteral("; i++) {\r\n                var jsonData = $.ajax({\r\n                    url: \'");
            EndContext();
            BeginContext(5014, 39, false);
#line 130 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                     Write(Url.Action("QuestinaryResultsLoadData"));

#line default
#line hidden
            EndContext();
            BeginContext(5053, 80, true);
            WriteLiteral("\',\r\n                    data: {\r\n                        \'questionaryHeaderId\': ");
            EndContext();
            BeginContext(5134, 25, false);
#line 132 "C:\Projects\Strategy\newSingleSite\Domain\Views\Shared\_QuestionaryResults.cshtml"
                                          Write(Model.QuestionaryHeaderId);

#line default
#line hidden
            EndContext();
            BeginContext(5159, 1468, true);
            WriteLiteral(@",
                        'questionaryQuestionId': $(""#questionId"" + i).html()
                    },
                    ""type"": ""POST"",
                    dataType: ""json"",
                    async: false,
                    success: function (data) {
                        data3 = getData(data);
                    }
                }).responseText;

                // Optional; add a title and set the width and height of the chart
                var text = $(""#questionText"" + i.toString()).html();
                var options = { 'title': text, 'width': 550, 'height': 400 };

                // Display the chart inside the <div> element with id=""piechart""
                var chart_div = document.getElementById('piechart' + i.toString());
                var chart = new google.visualization.PieChart(chart_div);

                chart.draw(data3, options);
            }
        }

        function getData(chart_data) {
            var jsonData = chart_data;
            var data ");
            WriteLiteral(@"= new google.visualization.DataTable();
            data.addColumn('string', 'ColumnName');
            data.addColumn('number', 'Value');
            $.each(jsonData, function (i, jsonData) {
                var columnName = jsonData.columnName;
                var columnValue = parseFloat($.trim(jsonData.value));
                data.addRows([[columnName, columnValue]]);
            });
            return data;
    }
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Models.ViewModels.Questionary.QuestionaryResultsListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591