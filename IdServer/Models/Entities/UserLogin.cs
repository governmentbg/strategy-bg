using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdServer.Models.Entities
{
    [Table("user_logins")]
    public class UserLogin
    {
        [Key]
        [MaxLength(50)]
        [Column("id")]
        public string Id { get; set; }

        [MaxLength(50)]
        [Required]
        [Column("user_id")]
        public string UserId { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("login_provider")]
        public string LoginProvider { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("provider_key")]
        public string ProviderKey { get; set; }
    }
}
