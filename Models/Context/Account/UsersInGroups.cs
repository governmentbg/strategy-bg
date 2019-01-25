using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Account
{

    [Table("users_in_groups", Schema = "account")]
    public class UsersInGroups
    {
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "GroupUserId")]
        public int GroupUserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; }

        [ForeignKey(nameof(GroupUserId))]
        public virtual Users Group { get; set; }
    }
}
