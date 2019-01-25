using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Legacy
{
  [Table("StrategicDocuments", Schema = "dbo")]
  public class StrategicDocuments
  {
    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "Заглавие")]
    public string Title { get; set; }

    [Display(Name = "Кратко описание")]
    public string Summary { get; set; }

    [Display(Name = "Категория")]
    public int CategoryId { get; set; }

    [Display(Name = "MainFileId")]
    public int MainFileId { get; set; }

    [Display(Name = "Дата на валидност")]
    public DateTime ValidTo { get; set; }

    [Display(Name = "LanguageId")]
    public int LanguageId { get; set; }

    [Display(Name = "Активен")]
    public bool IsActive { get; set; }

    [Display(Name = "Потвърден")]
    public bool IsApproved { get; set; }

    [Display(Name = "Изтрит")]
    public bool IsDeleted { get; set; }

    [Display(Name = "CreatedByUserId")]
    public int CreatedByUserId { get; set; }

    [Display(Name = "ModifiedByUserId")]
    public int ModifiedByUserId { get; set; }

    [Display(Name = "DateCreated")]
    public DateTime DateCreated { get; set; }

    [Display(Name = "DateModified")]
    public DateTime DateModified { get; set; }

    [Display(Name = "Акт")]
    public int? DocumentTypeId { get; set; }

    [Display(Name = "Номер на документ")]
    public string DocumentNumber { get; set; }

    [Display(Name = "Дата на документ")]
    public DateTime? DocumentDate { get; set; }

    [Display(Name = "Институция")]
    public int? InstitutionTypeId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    [NotMapped]
    [Display(Name = "Тип")]
    public int CategoryMasterId { get; set; }
    
    [NotMapped]
    [Display(Name = "Област")]
    public int DistrictId { get; set; }
    [NotMapped]
    [Display(Name = "Категория")]
    public int? MunicipalityId { get; set; }
  }
}


