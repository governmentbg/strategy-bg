using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.Application
{
    /// <summary>
    /// Таблица с броячи
    /// </summary>
    [Table("a_counters")]
    public class Counter
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("prefix")]
        [MaxLength(50)]
        public string Prefix { get; set; }

        [Column("suffix")]
        [MaxLength(50)]
        public string Suffix { get; set; }

        [Column("decimal_places")]
        [Required]
        public int DecimalPlaces { get; set; }


        [Column("value")]
        [Required]
        public long Value { get; set; }

        [Column("last_updated")]
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
