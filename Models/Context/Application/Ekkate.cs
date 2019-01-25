using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Contracts;

namespace Models.Context.Application
{
    [Table("a_ekkate")]
    public class Ekkate : IHaveLangNames
    {
        [Key]
        [Column("code")]
        [MaxLength(10)]
        [Required]
        public string Code { get; set; }

        [Column("parent_code")]
        [MaxLength(10)]
        [Required]
        public string ParentCode { get; set; }

        [Column("type_id")]
        [Required]
        public int TypeId { get; set; }

        [Column("name_bg")]
        [MaxLength(200)]
        [Required]
        public string NameBG { get; set; }

        [Column("name_en")]
        [MaxLength(200)]
        [Required]
        public string NameEN { get; set; }

        [Column("name_type_bg")]
        [MaxLength(20)]
        [Required]
        public string NameTypeBG { get; set; }

        [Column("name_type_en")]
        [MaxLength(20)]
        [Required]
        public string NameTypeEN { get; set; }

        [Column("is_main")]
        [Required]
        public bool IsMain { get; set; }

        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; }
    }
}
