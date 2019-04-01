using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.StandartForms
{
  public class StandartForm_3VM
  {

    [Display(Name = "1.1 Въведение:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextAreaWithoutEditor")]
    public string Introduction { get; set; }

    [Display(Name = "1.2 Цели на консултацията:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextAreaWithoutEditor")]
    public string Goals { get; set; }

    [Display(Name = "1.3 Консултационен процес:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextAreaWithoutEditor")]
    public string Process { get; set; }

    [Display(Name = "1.4 Релевантни документи и нормативни актове:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string LinkedDocuments { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Description { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Questions { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Documents { get; set; }
  }
}

