using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.MulticriteriaAnalysis
{
    [Table("mca_CriteriaValues", Schema = "dbo")]
    public class CriteriaValue
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("criteria_id")]
        [Required]
        public int CriteriaId { get; set; }

        [Column("name")]
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Name { get; set; }       

        [Column("value")]
        [Display(Name = "Стойност")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public int Value { get; set; }



        [ForeignKey(nameof(CriteriaId))]
        public virtual Criteria Criteria { get; set; }
    }
}
