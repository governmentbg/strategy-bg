using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebCommon.TagHelpers
{
    public class BaseTagHelper : TagHelper
    {
        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }



        [HtmlAttributeName("label")]
        public string Label { get; set; }
        [HtmlAttributeName("class")]
        public string Class { get; set; }
        
        [HtmlAttributeName("edit-class")]
        public string EditClass { get; set; }
        [HtmlAttributeName("disabled")]
        public bool Disabled { get; set; }
        /// <summary>
        ///  ViewContext = Razor      
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public Collection<string> currentValues;

        protected IHtmlGenerator htmlGenerator { get; set; }
        public BaseTagHelper(IHtmlGenerator _iHtmlGenerator)
        {
            this.htmlGenerator = _iHtmlGenerator;
            this.currentValues = new Collection<string>();
        }

        /// <summary>
        /// Генерира 'TextBox' елемент
        /// </summary>
        /// <param name="_model">ModelExpression на елемента, за който се генерира 'TextBox' елемент</param>
        /// <param name="_viewContext">ViewContext на генерирания елемент as ViewContext<SelectListItem></param>       
        /// <param name="_format">Формат на полето на TextBox-a as String<SelectListItem></param>
        /// <param name="_htmlAtrributes">Html атрибути на генерирания елемент as ob]ect<SelectListItem></param>
        /// <returns> 'TextBox' елемент отговарящ на '_model'</returns>
        protected TagBuilder MakeTextBox(ModelExpression _model, ViewContext _viewContext, string _format, object _htmlAtrributes)
        {
            TagBuilder textBoxElement = htmlGenerator.GenerateTextBox(viewContext: _viewContext,
                                                                        modelExplorer: _model.ModelExplorer,
                                                                        expression: _model.Name,
                                                                        value: _model.Model,
                                                                        format: _format,
                                                                        htmlAttributes: _htmlAtrributes);

            return textBoxElement;
        }

        protected TagBuilder MakeTextArea(ModelExpression _model, ViewContext _viewContext, string _format, object _htmlAtrributes)
        {
            TagBuilder textBoxElement = htmlGenerator.GenerateTextArea(viewContext: _viewContext,
                                                                        modelExplorer: _model.ModelExplorer,
                                                                        expression: _model.Name,
                                                                        rows: 5, columns: 40,
                                                                        htmlAttributes: _htmlAtrributes);
            //textBoxElement.InnerHtml.AppendHtml((string)_model.Model);

            return textBoxElement;
        }


        /// <summary>
        /// Генерира 'Label' елемент
        /// </summary>
        /// <param name="_model">ModelExpression на елемента, за който се генерира 'Label' елемент</param>
        /// <param name="_viewContext">ViewContext на генерирания елемент as ViewContext<SelectListItem></param>
        /// <param name="_labelText">Текста на генериряния label as String<SelectListItem></param>
        /// <param name="_htmlAtrributes">Html атрибути на генерирания елемент as ob]ect<SelectListItem></param>
        /// <returns>'Label' елемент за елемент отговарящ на '_model'</returns>
        protected TagBuilder MakeLabel(ModelExpression _model, ViewContext _viewContext, string _labelText, object _htmlAtrributes)
        {
            string LabelText = string.Empty;
            if (string.IsNullOrEmpty(_labelText))
                LabelText = _model.Metadata.DisplayName;
            else
                LabelText = _labelText;

            TagBuilder labelElement = htmlGenerator.GenerateLabel(viewContext: _viewContext,
                                                                     modelExplorer: _model.ModelExplorer,
                                                                     expression: _model.Name,
                                                                     labelText: LabelText,
                                                                     htmlAttributes: _htmlAtrributes);

            return labelElement;
        }

        protected string GetDisplayName(ModelExpression _model, string _labelText)
        {
            string LabelText = string.Empty;
            if (string.IsNullOrEmpty(_labelText))
                LabelText = _model.Metadata.DisplayName;
            else
                LabelText = _labelText;

            return LabelText;            
        }



        /// <summary>
        /// Генерира 'CheckBox' елемент
        /// </summary>
        /// <param name="_model">ModelExpression на елемента, за който се генерира 'CheckBox' елемент</param>
        /// <param name="_viewContext">ViewContext на генерирания елемент as ViewContext<SelectListItem></param>
        /// <param name="_htmlAtrributes">Html атрибути на генерирания елемент as ob]ect<SelectListItem></param>
        /// <returns>'CheckBox' елемент отговарящ на '_model'</returns>
        protected TagBuilder MakeCheckBox(ModelExpression _model, ViewContext _viewContext, object _htmlAtrributes)
        {
            TagBuilder checkBoxElement = htmlGenerator.GenerateCheckBox(viewContext: _viewContext,
                                                                           modelExplorer: _model.ModelExplorer,
                                                                           expression: _model.Name,
                                                                           isChecked: (bool?)_model.Model,
                                                                           htmlAttributes: _htmlAtrributes);
            return checkBoxElement;
        }

        /// <summary>
        /// Прави елемента 'disabled'
        /// </summary>
        /// <param name="_element">ModelExpression на елемента, за който се генерира 'TextArea' елемент</param>
        /// <param name="_disabled">Дали елемента да е disabled as bool<SelectListItem></param>   
        /// <returns> Прави елемента 'disabled'</returns>
        protected void DisableElement(ref TagBuilder _element, bool _disabled)
        {
            if (_disabled)
                _element.Attributes.Add("disabled", "disabled");
        }

        /// <summary>
        /// Генерира 'Span' елемент за валидационното съобщение към съответния елемент
        /// </summary>
        /// <param name="_model">ModelExpression на елемента, за който се генерира валидационния 'Span' елемент</param>
        /// <param name="_viewContext">ViewContext на генерирания елемент as ViewContext<SelectListItem></param>
        /// <param name="_htmlAtrributes">Html атрибути на генерирания елемент as ob]ect<SelectListItem></param>
        /// <returns>'Span' елемент за валидационното съобщение към елемент отговарящ на '_model'</returns>
        protected TagBuilder ValidationSpan(ModelExpression _model, ViewContext _viewContext, object _htmlAtrributes)
        {
            TagBuilder SpanElement = htmlGenerator.GenerateValidationMessage(viewContext: _viewContext,
                                                                             modelExplorer: _model.ModelExplorer,
                                                                             expression: _model.Name,
                                                                             message: null,
                                                                             tag: null,
                                                                             htmlAttributes: _htmlAtrributes);
            return SpanElement;
        }

        /// <summary>
        /// Генерира DropDown ('Select') елемент за пропърти '_model' и данни '_data'
        /// </summary>
        /// <param name="_model">Модел на пропъртито за което се bind-ват данните as ModelExpression</param>
        /// <param name="_viewContext">ViewContext на генерирания елемент as ViewContext<SelectListItem></param>
        /// <param name="_data">Данните за DropDown-а as IEnumerable<SelectListItem></param>
        /// <param name="_currentValues">Селектираната стойност(и) от модела елемент as Collection<string>ect<SelectListItem></param>
        /// <param name="_htmlAtrributes">Html атрибути на генерирания елемент as ob]ect<SelectListItem></param>
        /// <returns>'Select' елемент</returns>
        protected TagBuilder MakeDropDown(ModelExpression _model, ViewContext _viewContext, IEnumerable<SelectListItem> _data, Collection<string> _currentValues, object _htmlAtrributes)
        {
            foreach (var item in _data)
            {
                if (item.Value == null)
                {
                    item.Value = "";
                    item.Selected = true;
                    break;
                }
            }

            TagBuilder SelectElement = htmlGenerator.GenerateSelect(viewContext: _viewContext,
                                                                      modelExplorer: _model.ModelExplorer,
                                                                      optionLabel: null,
                                                                      expression: _model.Name,
                                                                      selectList: _data,
                                                                      currentValues: _currentValues,
                                                                      allowMultiple: false,
                                                                      htmlAttributes: _htmlAtrributes);
            return SelectElement;
        }
    }
}
