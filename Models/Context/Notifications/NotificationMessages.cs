using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace Models.Context.Notifications
{
    [Table("NotificationMessages", Schema = "notification")]
    public class NotificationMessages
    {
        [Key] [Display(Name = "Id")] public int Id { get; set; }
        [Display(Name = "Title")] public string Title { get; set; }
        [Display(Name = "Body")] public string Body { get; set; }
        [Display(Name = "SourceID")] public int SourceID { get; set; }
        [Display(Name = "SourceType")] public int? SourceType { get; set; }
        [Display(Name = "EmailNotification")] public bool EmailNotification { get; set; }
        [Display(Name = "SystemNotification")] public bool SystemNotification { get; set; }

        [Display(Name = "IsActive")] public bool IsActive { get; set; }
        [Display(Name = "CreatedByUserId")] public int CreatedByUserId { get; set; }
        [Display(Name = "ModifiedByUserId")] public int ModifiedByUserId { get; set; }
        [Display(Name = "DateCreated")] public DateTime DateCreated { get; set; }
        [Display(Name = "DateModified")] public DateTime DateModified { get; set; }

        public virtual ICollection<UserNotifications> UserNotifications { get; set; }

        public NotificationMessages()
        {
            UserNotifications = new HashSet<UserNotifications>();
        }
    }
}