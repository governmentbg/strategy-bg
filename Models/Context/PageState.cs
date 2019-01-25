using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context
{
    [Table("page_states", Schema = "itf")]
    public class PageState
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        [MaxLength(500)]
        [Display(Name = "Наименование")]
        [Required(ErrorMessage ="Въведете '{0}'")]
        public string Title { get; set; }       
    }
}
