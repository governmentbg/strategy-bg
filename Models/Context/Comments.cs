using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context
{
    [Table("Comments", Schema = "itf")]
    public class Comments
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "SourceType")]
        public int SourceType { get; set; }
        [Display(Name = "SourceId")]
        public int SourceId { get; set; }
        [Display(Name = "SourceAddRef")]
        public string SourceAddRef { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Text")]
        public string Text { get; set; }
        [Display(Name = "CommentStateId")]
        public int CommentStateId { get; set; }
        [Display(Name = "IsChangeAccepted")]
        public bool IsChangeAccepted { get; set; }
        [Display(Name = "ModeratorRemark")]
        public string ModeratorRemark { get; set; }
        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }
        [Display(Name = "ActualUserId")]
        public int ActualUserId { get; set; }
        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }
        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }
        [Display(Name = "SendNotification")]
        public bool SendNotification { get; set; }
        public bool? TookIntoConsideration { get; set; }
        public string TookIntoConsiderationReason { get; set; }

        [ForeignKey(nameof(CommentStateId))]
        public CommentState State { get; set; }
    }
}