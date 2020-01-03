using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Account
{
    public class UserInGroupVM
    {
        [Display(Name = "Потребителска група")]
        public int GroupUserId { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }
        
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
    }
}
