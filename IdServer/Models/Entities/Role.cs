using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.Models.Entities
{
    [Table("roles_itf")]
    public class Role
    {
        [Key]
        [MaxLength(50)]
        [Column("id")]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("name")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Column("display_name")]
        public string DisplayName { get; set; }

        [Column("client_id")]
        public string ClientId { get; set; }

        public ICollection<UserRole> UsersRoles { get; set; } = new List<UserRole>();
    }
}
