using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.Application
{
    [Table("a_address")]
    public class Address
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("country_code")]
        [Required]
        [Display(Name = "Страна")]
        public int CountryId { get; set; }

        [Column("settlement")]
        [MaxLength(200)]
        [Display(Name = "Населено място")]
        public string Settlement { get; set; }

        [Column("area_code")]
        [MaxLength(10)]
        [Display(Name = "Област")]
        public string AreaCode { get; set; }

        [Column("municipality_code")]
        [MaxLength(10)]
        [Display(Name = "Община")]
        public string MunicipalityCode { get; set; }

        [Column("city_code")]
        [MaxLength(10)]
        [Display(Name = "Населено място")]
        public string CityCode { get; set; }

        [Column("street_address")]
        [MaxLength(500)]
        [Display(Name = "Адрес")]
        public string StreetAddress { get; set; }

        [Column("post_code")]
        [MaxLength(10)]
        [Display(Name = "Пощенски код")]
        public string PostCode { get; set; }

        [Column("phone_fax")]
        [MaxLength(100)]
        [Display(Name = "Телефон/факс")]
        public string PhoneFax { get; set; }

        [Column("email")]
        [MaxLength(100)]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Column("full_address")]
        public string   FullAddress { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        [ForeignKey(nameof(AreaCode))]
        public virtual Ekkate Area { get; set; }

        [ForeignKey(nameof(MunicipalityCode))]
        public virtual Ekkate Municipality { get; set; }

        [ForeignKey(nameof(CityCode))]
        public virtual Ekkate City { get; set; }
    }
}
