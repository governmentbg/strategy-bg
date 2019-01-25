
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Notifications
{
  [Table("Attachments", Schema = "notification")]
  public class Attachments
  {
    [Key] [Display(Name = "Id")] public int Id { get; set; }
    [Display(Name = "MessageID")] public int MessageID { get; set; }
    [Display(Name = "Content_type")] public string Content_type { get; set; }
    [Display(Name = "File_description")] public string File_description { get; set; }
    [Display(Name = "File_name")] public string File_name { get; set; }
    [Display(Name = "File_size")] public int File_size { get; set; }
    [Display(Name = "File_title")] public string File_title { get; set; }
    [Display(Name = "Fontent")] public byte[] Fontent { get; set; }

    public virtual NotificationMessages NotificationMessage { get; set; }
  }
}