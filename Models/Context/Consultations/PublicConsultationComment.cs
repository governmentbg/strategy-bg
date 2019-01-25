using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Consultations
{
    [Table("PublicConsultationComments", Schema = "dbo")]
    public class PublicConsultationComment
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "ConsultationId")]
        public int ConsultationId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Text")]
        public string Text { get; set; }
        [Display(Name = "IsApproved")]
        public bool IsApproved { get; set; }
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }
        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }
        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }
        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }
        [Display(Name = "SendNotification")]
        public bool SendNotification { get; set; }
        public int DocumentId { get; set; }

        [ForeignKey(nameof(ConsultationId))]
        public PublicConsultation Consultation { get; set; }

        [ForeignKey(nameof(DocumentId))]
        public PublicConsultationDocument Document { get; set; }
    }
}
