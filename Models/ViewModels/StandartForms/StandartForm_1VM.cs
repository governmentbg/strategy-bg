using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.StandartForms
{
  public class StandartForm_1VM
  {

    [Display(Name = "Институция:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string Institution { get; set; }

    [Display(Name = "Нормативен акт:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string Enactment { get; set; }

    [Display(Name = "За включване в законодателната/оперативната програма на Министерския съвет за периода:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string Period { get; set; }

    [Display(Name = "Дата:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string DateFirst { get; set; }

    [Display(Name = "Контакт за въпроси:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string Contact { get; set; }

    [Display(Name = "Телефон:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string Phone { get; set; }

    [Display(Name = "1.1. Кратко опишете проблема и причините за неговото възникване. Посочете аргументите, които обосновават нормативната промяна.")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p1_1 { get; set; }

    [Display(Name = "1.2. Опишете какви са проблемите в прилагането на съществуващото законодателство или възникналите обстоятелства, които налагат приемането на ново законодателство. Посочете възможно ли е проблемът да се реши в рамките на съществуващото законодателство чрез промяна в организацията на работа и/или чрез въвеждане на нови технологични възможности (например съвместни инспекции между няколко органа и др.)")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p1_2 { get; set; }

    [Display(Name = "1.3. Посочете дали са извършени последващи оценки на нормативния акт, или анализи за изпълнението на политиката и какви са резултатите от тях?")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p1_3 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p2 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p3 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p4 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p5 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p6 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p7 { get; set; }

    [Display(Name = "8.1. Административната тежест за физическите и юридическите лица:")]
    public int p8_1{ get; set; }

    [Display(Name = "8.2. Създават ли се нови регулаторни режими? Засягат ли се съществуващи режими и услуги?")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p8_2 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(2048, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p9 { get; set; }

    [Display(Name = " ")]
    public int p10 { get; set; }

    [Display(Name = " ")]
    public int p11 { get; set; }

    [Display(Name = " ")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p12 { get; set; }
    
    [Display(Name = " ")]
    public int p13_1{ get; set; }

    [Display(Name = "Моля посочете изискванията на правото на Европейския съюз, включително информацията по т. 8.1 и 8.2, дали е извършена оценка на въздействието на ниво Европейски съюз, и я приложете (или посочете връзка към източник).")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string p13_2 { get; set; }

    [Display(Name = "Име и длъжност:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(256, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string NameRole { get; set; }

    [Display(Name = "Дата:")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(64, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    public string DateEnd { get; set; }
  }
}

