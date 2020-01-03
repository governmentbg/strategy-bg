using Models.Context.PCSubjectsModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.PCSubjectsModels
{
  public class PCSubjectsViewModel
  {
    public PCSubjectsViewModel()
    {
      IsUL = 1;
    }
    public int Id { get; set; }

    [Display(Name = "Вид на лицето")]
    public int IsUL { get; set; }
    [Display(Name = "Вид на лицето")]
    public string sIsUL { get; set; }

    [Display(Name = "ЕИК")]
    [StringLength(15, MinimumLength = 9, ErrorMessage = "{0} трябва да е между {2} и {1} символа")]
    public string EIK { get; set; }

    [Display(Name = "Име")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [StringLength(500, MinimumLength = 1, ErrorMessage = "{0} трябва да е между {2} и {1} символа")]
    public string Name { get; set; }

    [Display(Name = "Група")]
    [Range(1, Int32.MaxValue, ErrorMessage = "Полето {0} е задължително")]
    public int CategoryMasterId { get; set; }

    [Display(Name = "Категория")]
    [Range(1, Int32.MaxValue, ErrorMessage = "Полето {0} е задължително")]
    public int CategoryId { get; set; }

    [Display(Name = "Област")]
    public int? DistrictId { get; set; }

    [Display(Name = "Община")]
    public int? MunicipalityId { get; set; }
    public int FakeMunicipalityId { get; set; }

    [Display(Name = "Възнаграждение за извършените услуги в лева")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [Range(0, double.MaxValue, ErrorMessage = "{0} трябва да е между {2} и {1}")]
    public decimal PaymentValue { get; set; }

    [Display(Name = "Във възнаграждението е включено ДДС в лева")]
    public bool PaymentIncludeVAT { get; set; }

    [Display(Name = "Описание на извършените услуги")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    [UIHint("TextAreaWithoutEditor")]
    public string ActivityDescription { get; set; }

    [Display(Name = "Дата на договор")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    public DateTime DatePayment { get; set; }

    [Display(Name = "Възложител")]
    [Required(ErrorMessage = "Полето {0} е задължително")]
    public string ContractingAuthority { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedByUserId { get; set; }

    public int ModifiedByUserId { get; set; }

    public DateTime DateModified { get; set; }

    public PCSubjects ToEntity(PCSubjects entity = null)
    {
      if (entity == null)
      {
        entity = new PCSubjects();
      }

      entity.Id = this.Id;
      entity.IsUL = this.IsUL == 1 ? true : false;

      entity.EIK = this.EIK;
      entity.Name = this.Name;
      entity.PaymentValue = this.PaymentValue;
      entity.ActivityDescription = this.ActivityDescription;
      entity.DatePayment = this.DatePayment;
      entity.DateCreated = this.DateCreated;
      entity.CreatedByUserId = this.CreatedByUserId;
      entity.ModifiedByUserId = this.ModifiedByUserId;
      entity.DateModified = this.DateModified;
      entity.PaymentIncludeVAT = this.PaymentIncludeVAT;
      entity.ContractingAuthority = this.ContractingAuthority;
      entity.CategoryId = this.CategoryId;

      return entity;
    }

    public void FromEntity(PCSubjects entity)
    {
      Id = entity.Id;
      IsUL = entity.IsUL ? 1 : 0;
      sIsUL= entity.IsUL ? "Юридическо": "Физическо";
      EIK = entity.EIK;
      Name = entity.Name;
      PaymentValue = entity.PaymentValue;
      ActivityDescription = entity.ActivityDescription;
      DatePayment = entity.DatePayment;
      DateCreated = entity.DateCreated;
      CreatedByUserId = entity.CreatedByUserId;
      ModifiedByUserId = entity.ModifiedByUserId;
      DateModified = entity.DateModified;
      PaymentIncludeVAT = entity.PaymentIncludeVAT;
      ContractingAuthority = entity.ContractingAuthority;
      CategoryId = entity.CategoryId;
    }
  }


}
