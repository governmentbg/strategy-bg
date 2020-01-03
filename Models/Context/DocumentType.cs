using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context
{
    [Table("document_types", Schema = "itf")]
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(50)]
        public string Label { get; set; }

        public bool IsActive { get; set; }

        public int? ActType { get; set; }
    }
}