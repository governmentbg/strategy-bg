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
    [HtmlTargetElement("display", Attributes = "for")]
    public class DisplayTagHelper : BaseTagHelper
    {
        public DisplayTagHelper(IHtmlGenerator _iHtmlGenerator) : base(_iHtmlGenerator)
        {

        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {

                // Създаване на основния елемент ('TextBox')     
                TagBuilder displayElement = new TagBuilder("p");
                displayElement.AddCssClass("text-muted");
                displayElement.InnerHtml.AppendHtml(For.Model?.ToString());


                // Създаване на Label елемента           
                TagBuilder labelElement = MakeLabel(For, ViewContext, Label, new { @class = "control-label" });

                output.TagName = "div";
                //output.Attributes.Add("class", "form-group");
                string classAttr = String.Format("form-group {0}", Class);
                output.Attributes.Add("class", classAttr);
                //output.Attributes.Add("style", "float:left; margin-right:20px;");

                output.Content.AppendHtml(labelElement);

                output.Content.AppendHtml(displayElement);

            }
            catch (Exception ex)
            {
                //ErrorHelper.WriteToLog("TextBoxTagHelper.cs", ex);
            }
            base.Process(context, output);
        }

    }
}
