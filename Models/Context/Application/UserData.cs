using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context.Application
{
    [Table("a_users_data")]
    public class UserData
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("ud_user_id")]
        [Required]
        public string UserId { get; set; }

        [Column("ud_organization_person_id")]
        [Required]
        [Display(Name = "Командироващо лице / Предприятие, осигуряващо временна работа")]
        public int OrganizationPersonId { get; set; }

        [Column("ud_represented_by")]
        [MaxLength(200)]
        [Display(Name = "Представлявано от")]
        public string RepresentedBy { get; set; }

        //--------------------------------------------------------
        // Характер на дейността
        //--------------------------------------------------------
        [Column("ud_activity_type_id")]
        [Required]
        [Display(Name = "Характер на дейността")]
        public int ActivityTypeId { get; set; }

        [Column("ud_headquaters_address_id")]
        [Required]
        [Display(Name = "Седалище и адрес на управление")]
        public int HeadquatersAddressId { get; set; }

        [Column("ud_poste_address_id")]
        [Required]
        [Display(Name = "Адрес за кореспонденция")]
        public int PosteAddressId { get; set; }

        //---------------------------
        //---------------Foreign keys
        //---------------------------

        [ForeignKey(nameof(OrganizationPersonId))]
        public virtual Person OrganizationPerson { get; set; }

        [ForeignKey(nameof(ActivityTypeId))]
        public virtual ActivityType ActivityType { get; set; }

        [ForeignKey(nameof(HeadquatersAddressId))]
        public virtual Address HeadquatersAddress { get; set; }

        [ForeignKey(nameof(PosteAddressId))]
        public virtual Address PosteAddress { get; set; }


        public UserData()
        {
            OrganizationPerson = new Person();
            HeadquatersAddress = new Address();
            PosteAddress = new Address();
        }
    }
}
