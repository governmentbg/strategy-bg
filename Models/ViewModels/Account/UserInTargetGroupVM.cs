using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Account
{
    public class UserInTargetGroupVM
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }

        [Display(Name = "Целева група")]
        public int TargetGroupId { get; set; }
        public string TargetGroupName { get; set; }
    }
}
