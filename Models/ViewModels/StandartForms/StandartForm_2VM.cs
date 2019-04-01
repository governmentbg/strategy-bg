using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.StandartForms
{
  public class StandartForm_2VM
  {

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string NaimenovanieNaAkta { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Period { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(1024, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string VodestaInstitucia { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(1024, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string NivoNaNeobhodimost { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(1024, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string DrugiOrganizacii { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string InformaciaZaKontact { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string ProblemZaReshavane { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string CeliNaReshenieto { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant0 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant1 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant2 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant3 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string VariantDrugi { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(10, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string PreporachanVariant { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string JelaniEfecti { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string VariantNaDeistvie { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant0NaDeistvie { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant1NaDeistvie { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant2NaDeistvie { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Variant3NaDeistvie { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string VariantiDrugiNaDeistvie { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string ObhvatIOsnovniRazhodi { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Micro { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Malki { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Sredni { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string OsvobodeniPredpriatia { get; set; }
  

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string OpisanieIObhvatNaOsnovniPolzi { get; set; }
  

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string KliuchoviRiskove { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Konsultacii { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(32, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string DataNaDeistvie { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string InstituciaZaKontrol { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(32, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string Date { get; set; }
  }
}

