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
    [HtmlTargetElement("display-horizontal", Attributes = "for")]
    public class DisplayInlineTagHelper : BaseTagHelper
    {
        [HtmlAttributeName("format")]
        public string Format { get; set; }

        public DisplayInlineTagHelper(IHtmlGenerator _iHtmlGenerator) : base(_iHtmlGenerator)
        {
            Format = "dd.MM.yyyy";
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                TagBuilder labelDiv = new TagBuilder("div");
                labelDiv.AddCssClass("col-lg-4 col-md-6");

                TagBuilder labelElement = MakeLabel(For, ViewContext, Label, new { @class = "control-label" });
                labelDiv.InnerHtml.AppendHtml(labelElement);

                TagBuilder valueDiv = new TagBuilder("div");
                valueDiv.AddCssClass("col-lg-8 col-md-6");


                // Създаване на основния елемент  
                TagBuilder displayElement = new TagBuilder("b");
                if (For.Model is DateTime && For.Model != null)
                {
                    displayElement.InnerHtml.AppendHtml(((DateTime)For.Model).ToString(this.Format));
                }
                else
                {
                    displayElement.InnerHtml.AppendHtml(For.Model?.ToString());
                }

                valueDiv.InnerHtml.AppendHtml(displayElement);

                output.TagName = "div";
                output.Attributes.Add("class", "row");
                //output.TagMode = TagMode.SelfClosing;
                output.Content.AppendHtml(labelDiv);
                output.Content.AppendHtml(valueDiv);
            }
            catch (Exception ex)
            {
                //ErrorHelper.WriteToLog("TextBoxTagHelper.cs", ex);
            }
            base.Process(context, output);
        }

    }
}
