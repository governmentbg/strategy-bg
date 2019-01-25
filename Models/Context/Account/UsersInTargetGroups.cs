using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Account
{

    [Table("users_in_targetgroups", Schema = "account")]
    public class UsersInTargetGroups
    {
        
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "TargetGroupId")]
        public int TargetGroupId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; }

        [ForeignKey(nameof(TargetGroupId))]
        public virtual TargetGroups TargetGroup { get; set; }
    }
}

