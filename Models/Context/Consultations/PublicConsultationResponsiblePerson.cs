using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.Consultations
{
    public class PublicConsultationResponsiblePerson
    {
        [Key]
        public int Id { get; set; }

        public int ConsultationId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Полето {0} не може да е по-дълго от 200 символа")]
        public string ResponsiblePerson { get; set; }

        [StringLength(200, ErrorMessage = "Полето {0} не може да е по-дълго от 200 символа")]
        public string Address { get; set; }

        [StringLength(30, ErrorMessage = "Полето {0} не може да е по-дълго от 200 символа")]
        public string Telephone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Полето {0} не може да е по-дълго от 200 символа")]
        public string Email { get; set; }

        [ForeignKey(nameof(ConsultationId))]
        public PublicConsultation Consultation { get; set; }
    }
}
