using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context
{
    [Table("libraries", Schema = "itf")]
    public class Library
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("parent_id")]
        public int ParentId { get; set; }

        [Column("source_type")]
        public int SourceType { get; set; }

        [Column("title")]
        [MaxLength(500)]
        [Display(Name = "Заглавие")]
        [Required(ErrorMessage ="Въведете '{0}'")]
        public string Title { get; set; }

        [Column("is_active")]
        [Display(Name = "Активна библиотека")]
        [Required]
        public bool IsActive { get; set; }

        [Column("order_by")]
        public int OrderBy { get; set; }

        [Column("date_created")]
        [Display(Name = "Създадено на")]
        [Required]
        public DateTime DateCreated { get; set; }

        [Column("user_wrt")]
        public int UserWRT { get; set; }

        [Column("date_published")]
        [Display(Name = "Публикувано на")]
        public DateTime DatePublished { get; set; }
    }
}
