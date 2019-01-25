using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCommon.TagHelpers
{
    /// <summary>
    /// <div class="form-group">
    /// <label class="control-label" for="{Name}">{Label}</label>
    /// <input class="form-control" data-val="true" data-val-required="Трябва да се попълни полето '{Name}'" id="{Name}" name="{Name}" placeholder="{Label}" type="{Type}">
    /// <span class="text-danger field-validation-valid" data-valmsg-for="{Name}" data-valmsg-replace="true"></span>
    /// </div>
    /// </summary>
    [HtmlTargetElement("textbox", Attributes = "for")]
    public class TextBoxTagHelper : BaseTagHelper
    {
        [HtmlAttributeName("type")]
        public string Type { get; set; }

        public TextBoxTagHelper(IHtmlGenerator _iHtmlGenerator) : base(_iHtmlGenerator)
        {
            this.Type = "text";
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {

                // Създаване на основния елемент ('TextBox')     
                TagBuilder inputElement = null;
                if (this.Type == "textarea")
                {
                    inputElement = MakeTextArea(For, ViewContext, null, new { @class = "form-control " + this.EditClass });
                }
                else
                {
                    inputElement = MakeTextBox(For, ViewContext, null, new { @class = "form-control " + this.EditClass });
                }
                inputElement.Attributes.Add("placeholder", string.IsNullOrEmpty(Label) ? For.Metadata.DisplayName : Label);
                DisableElement(ref inputElement, Disabled);
                inputElement.Attributes["type"] = this.Type;

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
                //ErrorHelper.WriteToLog("TextBoxTagHelper.cs", ex);
            }
            base.Process(context, output);
        }

    }
}
