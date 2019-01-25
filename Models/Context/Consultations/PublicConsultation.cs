using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Consultations
{
    [Table("PublicConsultations", Schema = "dbo")]
    public class PublicConsultation
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TargetGroupId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime OpenningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public int MainFileId { get; set; }
        public int? ResultsFileId { get; set; }
        public int LanguageId { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedByUserId { get; set; }
        public int ModifiedByUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public string ShortTermReason { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [ForeignKey(nameof(TargetGroupId))]
        public TargetGroups TargetGroup { get; set; }

        public ICollection<PublicConsultationComment> Comments { get; set; }

        public ICollection<PublicConsultationDocument> Documents { get; set; }
    }
}
