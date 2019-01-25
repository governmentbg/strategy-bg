using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Contracts;

namespace Models.Context.Application
{
    [Table("a_countries")]
    public class Country : IHaveLangNames
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("code")]
        [MaxLength(3)]
        [Display(Name = "Код на държава")]
        [Required]
        public string Code { get; set; }

        [Column("name_bg")]
        [MaxLength(200)]
        [Display(Name = "Име на Български език")]
        [Required]
        public string NameBG { get; set; }

        [Column("name_en")]
        [MaxLength(200)]
        [Display(Name = "Име на Английски език")]
        [Required]
        public string NameEN { get; set; }

        [Column("country_type_id")]
        [Display(Name = "Тип на държава")]
        [Required]
        public int CountryTypeId { get; set; }

        [Column("risk_category_id")]
        [Display(Name = "Рискова категория")]
        [Required]
        public int RiskCategoryId { get; set; }

        [Column("is_active")]
        [Display(Name = "Активна")]
        [Required]
        public bool IsActive { get; set; }
    }
}
