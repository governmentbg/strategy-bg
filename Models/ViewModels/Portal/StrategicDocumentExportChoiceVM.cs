using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models.ViewModels.Portal
{
  public class StrategicDocumentExportChoiceVM
  {
    [Display(Name = "Група")]
    public int CategoryMasterId { get; set; }
    [Display(Name = "От дата")]
    public DateTime FromDate { get; set; }
    [Display(Name = "До дата")]
    public DateTime ToDate { get; set; }

  }
}
