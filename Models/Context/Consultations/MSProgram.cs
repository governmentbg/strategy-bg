using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Consultations
{

    [Table("MSPrograms", Schema = "dbo")]
    public class MSProgram
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ProgramTypeId")]
        public int ProgramTypeId { get; set; }

        [Display(Name = "LanguageId")]
        public int LanguageId { get; set; }

        [Display(Name = "Наименование")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Активен запис")]
        public bool IsActive { get; set; }

        [Display(Name = "В сила от")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "В сила до")]
        public DateTime DateTo { get; set; }

        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }

        [Display(Name = "ModifiedByUserId")]
        public int? ModifiedByUserId { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "DateModified")]
        public DateTime? DateModified { get; set; }

        public ICollection<MSProgramProject> MSProgramProjects { get; set; }

    }
}
