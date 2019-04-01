using Models.Context.Legacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Account
{

    [Table("users", Schema = "account")]
    public class Users
    {
        public Users()
        {
            UsersInRoles = new HashSet<UsersInRoles>();
            UsersInGroups = new HashSet<UsersInGroups>();
            UsersInCategories = new HashSet<UsersInCategories>();
            UsersInTargetGroups = new HashSet<UsersInTargetGroups>();
        }

        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "UserTypeId")]
        public int UserTypeId { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "Organization")]
        public string Organization { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public int? CategoryId { get; set; }

        [Display(Name = "IsApproved")]
        public bool IsApproved { get; set; }

        [Display(Name = "IsMailConfirmed")]
        public bool IsMailConfirmed { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }


        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }

        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }

        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }

        [Display(Name = "Институция")]
        public int? InstitutionTypeId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public virtual UsersTypes UsersType { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(InstitutionTypeId))]
        public virtual InstitutionTypes InstitutionType { get; set; }
        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }
        public virtual ICollection<UsersInGroups> UsersInGroups { get; set; }
        public virtual ICollection<UsersInCategories> UsersInCategories { get; set; }
        public virtual ICollection<UsersInTargetGroups> UsersInTargetGroups { get; set; }

    }
}