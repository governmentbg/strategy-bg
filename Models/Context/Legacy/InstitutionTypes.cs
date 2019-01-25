using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Legacy
{
  [Table("InstitutionTypes", Schema = "dbo")]
  public class InstitutionTypes
  {
    [Key] [Display(Name = "Id")] public int Id { get; set; }
    [Display(Name = "InstitutionTypeName")] public string InstitutionTypeName { get; set; }
    [Display(Name = "LanguageId")] public int LanguageId { get; set; }
    [Display(Name = "CreatedByUserId")] public int CreatedByUserId { get; set; }
    [Display(Name = "ModifiedByUserId")] public int ModifiedByUserId { get; set; }
  }
}