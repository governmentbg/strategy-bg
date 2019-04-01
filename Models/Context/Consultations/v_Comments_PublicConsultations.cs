using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.Consultations
{
    [Table("v_comments_public_consultations",Schema ="itf")]
    public class v_Comments_PublicConsultations
    {
        [Column("public_consultation_id")]
        [Key]
        public int PublicConsultationId { get; set; }

        [Column("comments_count")]
        public int CommentsCount { get; set; }
    }
}
