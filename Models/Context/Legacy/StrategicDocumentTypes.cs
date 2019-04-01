using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Legacy
{
  [Table("DocumentTypes", Schema = "dbo")]
  public class StrategicDocumentTypes
  {
    [Key]
    [Display(Name = "Id")]

    public int Id { get; set; }
    [Display(Name = "DocumentTypeName")]

    public string DocumentTypeName { get; set; }

    [Display(Name = "LanguageId")]
    public int LanguageId { get; set; }

    [Display(Name = "CreatedByUserId")]
    public int CreatedByUserId { get; set; }

    [Display(Name = "ModifiedByUserId")]
    public int ModifiedByUserId { get; set; }

    [Display(Name = "IsActive")]
    public bool IsActive { get; set; }
  }
}