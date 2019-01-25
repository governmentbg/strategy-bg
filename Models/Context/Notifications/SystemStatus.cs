
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Notifications
{
  [Table("SystemStatus", Schema = "notification")]
  public class SystemStatus
  {
    [Key] [Display(Name = "Id")] public int Id { get; set; }
    [Display(Name = "Title")] public string Title { get; set; }
  }
}