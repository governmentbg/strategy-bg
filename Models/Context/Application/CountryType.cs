using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Contracts;

namespace Models.Context.Application
{
    /// <summary>
    /// Видове заявления
    /// </summary>
    [Table("a_country_types")]
    public class CountryType 
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }




        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; }
    }
}
