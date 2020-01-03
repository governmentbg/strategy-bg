using Models.Context.Legacy;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Consultations
{

    [Table("MSProgramProjects", Schema = "dbo")]
    public class MSProgramProject
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "MSProgramId")]
        public int MSProgramId { get; set; }

        [Display(Name = "LanguageId")]
        public int LanguageId { get; set; }

        [Display(Name = "Наименование")]
        public string Title { get; set; }

        [Display(Name = "Вносител")]
        public int? InstitutionTypeId { get; set; }

        [Display(Name = "Основни положения и очаквани резултати")]
        public string Description { get; set; }
        
        [Display(Name = "Включен в Плана за действие с мерките, произтичащи от членството на РБ в ЕС")]
        public string IncludedInEUplan { get; set; }

        [Display(Name = "Необходими промени в други закони")]
        public string OtherLawsImpact { get; set; }

        [Display(Name = "Изготвена на цялостна оценка на въздействието")]
        public bool? HasAssessment { get; set; }

        [Display(Name = "Месец на съгласуване")]
        public DateTime DateCoordinated { get; set; }

        [Display(Name = "Месец на внасяне в МС")]
        public DateTime? DateMS { get; set; }

        [Display(Name = "Активен запис")]
        public bool IsActive { get; set; }

        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }

        [Display(Name = "ModifiedByUserId")]
        public int? ModifiedByUserId { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "DateModified")]
        public DateTime? DateModified { get; set; }

        [ForeignKey(nameof(MSProgramId))]
        public MSProgram MSProgram { get; set; }

        [ForeignKey(nameof(InstitutionTypeId))]
        public virtual InstitutionTypes InstitutionType { get; set; }

        //[ForeignKey(nameof(DocumentTypeId))]
        //public DocumentType DocumentType { get; set; }
    }
}
