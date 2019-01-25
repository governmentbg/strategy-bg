using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.Application
{
    [Table("a_person")]
    public class Person
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("person_type")]
        [Display(Name = "Вид лице")]
        [Required]
        public int PersonType { get; set; }

        [Column("first_name")]
        [MaxLength(500)]
        [Display(Name = "Собствено име")]
        public string FirstName { get; set; }

        [Column("middle_name")]
        [MaxLength(100)]
        [Display(Name = "Бащино име")]
        public string MiddleName { get; set; }

        [Column("last_name")]
        [MaxLength(100)]
        [Display(Name = "Фамилия")]
        public string FamilyName { get; set; }

        [Column("full_name")]
        [MaxLength(500)]
        [Display(Name = "Име/Наименование")]
        public string FullName { get; set; }

        [Column("identifier_type_id")]
        [Display(Name = "Вид идентификатор")]
        [Required]
        public int IdentifierTypeId { get; set; }

        [Column("identifier")]
        [MaxLength(50)]
        [Display(Name = "Идентификатор")]
        public string Identifier { get; set; }

        [ForeignKey(nameof(IdentifierTypeId))]
        public virtual IdentifierType IdentifierType { get; set; }

        public Person()
        {
            PersonType = GlobalConstants.PersonTypes.Entity;
        }
    }
}
