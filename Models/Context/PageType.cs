using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context
{
    [Table("page_types", Schema = "itf")]
    public class PageType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        [MaxLength(500)]
        [Display(Name = "Наименование")]
        [Required(ErrorMessage ="Въведете '{0}'")]
        public string Title { get; set; }

        [Column("date_created")]
        [Display(Name = "Създадено на")]
        [Required]
        public DateTime DateCreated { get; set; }

    }
}
