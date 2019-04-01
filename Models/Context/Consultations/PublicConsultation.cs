using Models.Context.Legacy;
using Models.Context.LinksModels;
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

        public int? LinksCategoryId { get; set; }

        public int? InstututionTypeId { get; set; }

        public bool ShouldAlertSubscribers { get; set; }

        public string ResponsiblePerson { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        [ForeignKey(nameof(InstututionTypeId))]
        public InstitutionTypes InstitutionType { get; set; }

        [ForeignKey(nameof(LinksCategoryId))]
        public LinksCategories LinksCategory { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public ICollection<PublicConsultationComment> Comments { get; set; }

        public ICollection<PublicConsultationDocument> Documents { get; set; }

        public ICollection<PublicConsultationResponsiblePerson> ResponsiblePeople { get; set; }

        public PublicConsultation()
        {
            IsApproved = true;
            Comments = new List<PublicConsultationComment>();
            Documents = new List<PublicConsultationDocument>();
            ResponsiblePeople = new List<PublicConsultationResponsiblePerson>();
        }
    }
}
