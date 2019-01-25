using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebCommon.Models;

namespace Models.ViewModels.MulticriteriaAnalysis

{
    public class MulticriteriaAnalysisVM
    {

    public MulticriteriaAnalysisVM()
    {
      List<CalculatorActivityVM> Criteria = new List<CalculatorActivityVM>();
      TotalAssessmentValue = 0;
      AnalysisDate = DateTime.Now;
    }

    [Display(Name = "Дата на извършване на анализа:")]
    public DateTime AnalysisDate { get; set; }

    [Display(Name = "Бележки относно направения анализ:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextAreaWithoutEditor")]
    public string Remark { get; set; }
    [Display(Name = "Обща оценка:")]
    public decimal TotalAssessmentValue { get; set; }
     public List<mcaCriteriaVM> Criteria { get; set; }
  }
}
