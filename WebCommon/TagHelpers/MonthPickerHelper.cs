using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCommon.Extensions;

namespace WebCommon.TagHelpers
{
    /// <summary>
    /// <div class="form-group">
    /// <label class="control-label" for="{Name}">{Label}</label>
    /// <input class="form-control" data-val="true" data-val-required="Трябва да се попълни полето '{Name}'" id="{Name}" name="{Name}" placeholder="{Label}" type="{Type}">
    /// <span class="text-danger field-validation-valid" data-valmsg-for="{Name}" data-valmsg-replace="true"></span>
    /// </div>
    /// </summary>
    [HtmlTargetElement("month-picker", Attributes = "for")]
    public class MonthPickerHelper : BaseTagHelper
    {
        public MonthPickerHelper(IHtmlGenerator _iHtmlGenerator) : base(_iHtmlGenerator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {

                // Създаване на основния елемент ('DatePicker')     
                TagBuilder inputElement = null;

                inputElement = MakeTextBox(For, ViewContext, "{0:MMMM, yyyy}", new { @class = "form-control month-picker" });

                if (!string.IsNullOrEmpty(inputElement.Attributes["value"]))
                {

                    inputElement.Attributes["value"] = inputElement.Attributes["value"].FirstLetterUpperCase();
                }

                inputElement.Attributes.Add("placeholder", string.IsNullOrEmpty(Label) ? For.Metadata.DisplayName : Label);
                DisableElement(ref inputElement, Disabled);

                // Създаване на 'Span' елемента             
                TagBuilder SpanElement = ValidationSpan(For, ViewContext, new { @class = "text-danger field-validation-valid" });

                // Създаване на Label елемента           
                TagBuilder labelElement = MakeLabel(For, ViewContext, Label, new { @class = "control-label" });

                output.TagName = "div";
                //output.Attributes.Add("class", "form-group");
                string classAttr = String.Format("form-group {0}", Class);
                output.Attributes.Add("class", classAttr);
                //output.Attributes.Add("style", "float:left; margin-right:20px;");


                output.Content.AppendHtml(labelElement);

                output.Content.AppendHtml(inputElement);
                output.Content.AppendHtml(SpanElement);

            }
            catch (Exception ex)
            {
            }
            base.Process(context, output);
        }

    }
}
