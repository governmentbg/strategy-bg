using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.IdentityServer
{
    [Table("users")]
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

    }
}
