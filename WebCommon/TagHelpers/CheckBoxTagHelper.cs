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
    [HtmlTargetElement("checkbox", Attributes = "for")]
    public class CheckBoxTagHelper : BaseTagHelper
    {
        [HtmlAttributeName("text-class")]
        public string TextClass { get; set; }
        public CheckBoxTagHelper(IHtmlGenerator _iHtmlGenerator) : base(_iHtmlGenerator)
        {

        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {

                // Създаване на основния елемент ('TextBox')     
                TagBuilder inputElement = MakeCheckBox(For, ViewContext, null);
                DisableElement(ref inputElement, Disabled);

                //// Създаване на 'Span' елемента             
                //TagBuilder SpanElement = ValidationSpan(For, ViewContext, new { @class = "text-danger field-validation-valid" });


                TagBuilder lblContainer = new TagBuilder("label");
                TagBuilder spanText = new TagBuilder("span");
                spanText.InnerHtml.Append(GetDisplayName(For, Label));
                lblContainer.InnerHtml.AppendHtml(inputElement);
                lblContainer.InnerHtml.AppendHtml(spanText);
                lblContainer.AddCssClass("control-label");


                TagBuilder divContainer = new TagBuilder("div");
                divContainer.AddCssClass("checkbox " + (TextClass ?? ""));
                divContainer.InnerHtml.AppendHtml(lblContainer);

                output.TagName = "div";
                //output.Attributes.Add("class", "form-group");
                string classAttr = String.Format("form-group {0}", Class);
                output.Attributes.Add("class", classAttr);
                //output.Attributes.Add("style", "float:left; margin-right:20px;");

                output.Content.AppendHtml(divContainer);

                ////Ако няма дефиниран tooltip към елемента
                //if (string.IsNullOrEmpty(this.Info))
                //{
                //output.Content.AppendHtml(inputElement);
                //                output.Content.AppendHtml(SpanElement);
                //}
                //else
                //{
                //    var infoContainer = this.MakeInputGroup();
                //    infoContainer.InnerHtml.AppendHtml(inputElement);
                //    infoContainer.InnerHtml.AppendHtml(SpanElement);
                //    output.Content.AppendHtml(infoContainer);
                //}

                //if (AddHidden)
                //    // Създаване на 'Hidden' елемент за основния елемент
                //    output.Content.AppendHtml(tagService.HiddenFor(For, ViewContext, null));

            }
            catch (Exception ex)
            {
                //ErrorHelper.WriteToLog("TextBoxTagHelper.cs", ex);
            }
            base.Process(context, output);
        }

    }
}
