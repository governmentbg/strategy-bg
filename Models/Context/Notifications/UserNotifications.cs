using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Notifications
{
  [Table("UserNotifications", Schema = "notification")]
  public class UserNotifications
  {
    [Key] [Display(Name = "Id")] public int Id { get; set; }
    [Display(Name = "UserId")] public int? UserId { get; set; }
    [Display(Name = "Email")] public string Email { get; set; }
    [Display(Name = "MessageID")] public int MessageID { get; set; }
    [Display(Name = "EmailStatus")] public int EmailStatus { get; set; }
    [Display(Name = "DateEmailStatus")] public DateTime DateEmailStatus { get; set; }
    [Display(Name = "SystemStatus")] public int SystemStatus { get; set; }
    [Display(Name = "DateSystemStatus")] public DateTime DateSystemStatus { get; set; }

    [ForeignKey(nameof(MessageID))]
    public virtual NotificationMessages NotificationMessage { get; set; }
    [ForeignKey(nameof(SystemStatus))]
    public virtual SystemStatus SystemStatusTable { get; set; }

  }
}