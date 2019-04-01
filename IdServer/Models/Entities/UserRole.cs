using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.Models.Entities
{
    [Table("users_roles_itf")]
    public class UserRole
    {
        [Required]
        [MaxLength(50)]
        [Column("user_id")]
        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("role_id")]
        public string RoleId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
