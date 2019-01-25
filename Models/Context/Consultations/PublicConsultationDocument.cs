using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Consultations
{
    [Table("PublicConsultationDocuments", Schema = "dbo")]
    public class PublicConsultationDocument
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "PublicConsultationId")]
        public int PublicConsultationId { get; set; }
        [Display(Name = "MainId")]
        public int MainId { get; set; }
        [Display(Name = "RevisionNo")]
        public int RevisionNo { get; set; }
        [Display(Name = "IsLastRevision")]
        public bool IsLastRevision { get; set; }
        [Display(Name = "IsFinal")]
        public bool IsFinal { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "DocumentContent")]
        public string DocumentContent { get; set; }
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

        public int? DocumentTypeId { get; set; }

        public bool CanComment { get; set; }

        [ForeignKey(nameof(PublicConsultationId))]
        public PublicConsultation Consultation { get; set; }

        [ForeignKey(nameof(DocumentTypeId))]
        public DocumentType DocumentType { get; set; }

        public ICollection<PublicConsultationComment> Comments { get; set; }

        public PublicConsultationDocument()
        {
            Comments = new List<PublicConsultationComment>();
        }
    }
}