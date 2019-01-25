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
    [HtmlTargetElement("ddl", Attributes = "for")]
    public class DropDownListTagHelper : BaseTagHelper
    {
        public DropDownListTagHelper(IHtmlGenerator _iHtmlGenerator) : base(_iHtmlGenerator)
        {

        }

        [HtmlAttributeName("data")]
        public IEnumerable<SelectListItem> Data { get; set; }

        [HtmlAttributeName("description")]
        public string Description { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                // Взимане на текущо селектнатата стойност
                currentValues.Add(For.Model?.ToString());

                // Създаване на основния елемент ('Select')     
                TagBuilder SelectElement = MakeDropDown(For, ViewContext, Data, currentValues, new { @class = "form-control select" });
                //TagBuilder SelectElement = tagService.Select(For, ViewContext, Data, currentValues, new { @class = "form-control select2", style = "width: 100%;" });
                DisableElement(ref SelectElement, Disabled);

                // Създаване на 'Span' елемента             
                TagBuilder SpanElement = ValidationSpan(For, ViewContext, new { @class = "text-danger field-validation-valid" });

                // Създаване на Label елемента           
                TagBuilder labelElement = MakeLabel(For, ViewContext, Label, new { @class = "control-label" });

                // Създаване на контейнера за елемента
                output.TagName = "div";
                string classAttr = String.Format("form-group {0}", Class);
                output.Attributes.Add("class", classAttr);
                //output.Attributes.Add("style", "float:left; margin-right:20px;");

                // Създаване на DropDown елемента    
                output.Content.AppendHtml(labelElement);

                //Ако няма дефиниран tooltip към елемента
                //if (string.IsNullOrEmpty(this.Info))
                //{
                output.Content.AppendHtml(SelectElement);
                output.Content.AppendHtml(SpanElement);

                if (!string.IsNullOrEmpty(this.Description))
                {
                    TagBuilder descriptionElement = new TagBuilder("span");
                    descriptionElement.InnerHtml.Append(this.Description);
                    descriptionElement.AddCssClass("form-control-description");
                    output.Content.AppendHtml(descriptionElement);
                }
                //}
                //else
                //{
                //    var infoContainer = this.MakeInputGroup();
                //    infoContainer.InnerHtml.AppendHtml(SelectElement);
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
