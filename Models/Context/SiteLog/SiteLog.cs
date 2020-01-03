using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context
{

  [Table("SiteLog", Schema = "dbo")]
  public class SiteLog
  {
    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "RecordId")]
    public int RecordId { get; set; }

    [Display(Name = "Detail")]
    public string Detail { get; set; }

    [Display(Name = "DbTableName")]
    public string DbTableName { get; set; }

    [Display(Name = "Action")]
    public int Action { get; set; }

    [Display(Name = "UserId")]
    public int UserId { get; set; }

    [Display(Name = "Approved")]
    public bool Approved { get; set; }

    [Display(Name = "DeletedForever")]
    public bool DeletedForever { get; set; }

    [Display(Name = "DateCreated")]
    public DateTime DateCreated { get; set; }
  }
}