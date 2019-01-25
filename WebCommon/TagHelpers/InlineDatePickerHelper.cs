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
    [HtmlTargetElement("inline-date-picker", Attributes = "for")]
    public class InlineDatePickerHelper : BaseTagHelper
    {

        public InlineDatePickerHelper(IHtmlGenerator _iHtmlGenerator) : base(_iHtmlGenerator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            try
            {

                // Създаване на основния елемент ('DatePicker')     
                TagBuilder inputElement = null;

                inputElement = MakeTextBox(For, ViewContext, "{0:dd.MM.yyyy}", new { @class = "form-control date-picker" });
                DateTime? model = (DateTime?)For.Model;
                if (model.HasValue && model.Value.Year <= 1900)
                {
                    inputElement.Attributes["value"] = string.Empty;
                }

                inputElement.Attributes.Add("placeholder", string.IsNullOrEmpty(Label) ? For.Metadata.DisplayName : Label);
                DisableElement(ref inputElement, Disabled);

                output.Content.AppendHtml(inputElement);

            }
            catch (Exception ex)
            {
            }
            base.Process(context, output);
        }

    }
}
