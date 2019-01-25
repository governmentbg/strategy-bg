using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Models.Contracts;

namespace Models.Context.Application
{
    /// <summary>
    /// Вид на идентификатор на лице
    /// </summary>
    [Table("a_identifier_types")]
    public class IdentifierType : IHaveLangNames
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(200)]
        [Required]
        public string NameBG { get; set; }

        [Column("name_en")]
        [MaxLength(200)]
        [Required]
        public string NameEN { get; set; }


        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; }
    }
}
