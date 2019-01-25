using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context
{
    [Table("page_links", Schema = "itf")]
    public class PageLink
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        public int PageId { get; set; }

        [Column("title")]
        [MaxLength(500)]
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Title { get; set; }

        [Column("href")]
        [MaxLength(500)]
        [Display(Name = "Връзка/страница")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Href { get; set; }

        [Required]
        public int OrderBy { get; set; }

        [ForeignKey(nameof(PageId))]
        public virtual Page Page { get; set; }
    }
}
