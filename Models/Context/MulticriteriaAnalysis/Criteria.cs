using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.MulticriteriaAnalysis
{
    [Table("mca_Criteria", Schema = "dbo")]
    public class Criteria
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Name { get; set; }

        [Column("description")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Column("impact")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        [Display(Name = "Тежест на критерия")]
        public int Impact { get; set; }

        [Column("is_active")]
        [Required]
        [Display(Name = "Активен запис")]
        public bool IsActive { get; set; }

        [Column("user_wrt")]
        [Required]
        public int UserWrt { get; set; }

        [Column("date_wrt")]
        [Required]
        public DateTime DateWrt { get; set; }

        public virtual ICollection<CriteriaValue> CriteriaValues { get; set; }
    }
}
