using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.Consultations
{
    [Table("consultation_document_types", Schema = "itf")]
    public class ConsultationDocumentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(50)]
        public string Label { get; set; }

        public bool IsActive { get; set; }
    }
}
