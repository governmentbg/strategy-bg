using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.MulticriteriaAnalysis
{
    public class mcaCriteriaVM
  {
    public int CriteriaId { get; set; }
    [Display(Name = "Име на критерий")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextAreaWithoutEditor")]
    public string CriteriaName { get; set; }

    [Display(Name = "Описание на критерий")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextAreaWithoutEditor")]
    public string CriteriaDescription { get; set; }
    public int CriteriaImpact { get; set; }
    public int CriteriaSelectedValue { get; set; }
    public int CriteriaSelectedID { get; set; }
    public string CriteriaSelectedText { get; set; }
    public IEnumerable<SelectListItem> CriteriaValues { get; set; }
    public int CriteriaTotalValue { get; set; }
  }

}
