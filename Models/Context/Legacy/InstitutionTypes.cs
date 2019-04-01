using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Legacy
{
  [Table("InstitutionTypes", Schema = "dbo")]
  public class InstitutionTypes
  {
    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "InstitutionTypeName")]
    public string InstitutionTypeName { get; set; }

    [Required]
    [Display(Name = "LanguageId")]
    public int LanguageId { get; set; }

    [Required]
    [Display(Name = "CreatedByUserId")]
    public int CreatedByUserId { get; set; }

    [Required]
    [Display(Name = "ModifiedByUserId")]
    public int ModifiedByUserId { get; set; }

    [Required]
    [Display(Name = "IsActive")]
    public bool IsActive { get; set; }
  }
}