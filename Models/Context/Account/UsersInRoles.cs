using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Account
{

    [Table("users_in_roles", Schema = "account")]
    public class UsersInRoles
    {
        
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "RoleId")]
        public int RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Roles Role { get; set; }
    }
}

