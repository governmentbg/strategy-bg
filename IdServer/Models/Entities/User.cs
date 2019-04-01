using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdServer.Models.Entities
{
    [Table("users_itf")]
    public class User
    {
        [Key]
        [MaxLength(50)]
        [Column("id")]
        public string Id { get; set; }

        [MaxLength(100)]
        [Required]
        [Column("user_name")]
        public string Username { get; set; }

        [MaxLength(100)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; }

        [MaxLength(100)]
        [Required]
        [Column("given_name")]
        public string GivenName { get; set; }

        [MaxLength(100)]
        [Column("middle_name")]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        [Required]
        [Column("family_name")]
        public string FamilyName { get; set; }

        [MaxLength(200)]
        [Column("full_name")]
        public string FullName { get; set; }

        [MaxLength(100)]
        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Column("is_mail_confirmed")]
        public bool IsMailConfirmed { get; set; }

        [Column("must_change_password")]
        public bool MustChangePassword { get; set; }

        [Required]
        [Column("is_public")]
        public bool IsPublic { get; set; }

        [Column("old_id")]
        public int? OldId { get; set; }

        [Column("organization")]
        public string Organization { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("create_date")]
        public DateTime? CreateDate { get; set; }

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();

        public ICollection<UserLogin> Logins { get; set; } = new List<UserLogin>();

        public ICollection<UserRole> UsersRoles { get; set; } = new List<UserRole>();
    }
}
