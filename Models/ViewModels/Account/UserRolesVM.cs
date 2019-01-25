using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebCommon.Models;

namespace Models.ViewModels.Account
{
    public class UserRolesVM
    {
        public int UserId { get; set; }
        [Display(Name = "Потребителско име")]
        public string Username { get; set; }
        [Display(Name = "Имена")]
        public string FullName { get; set; }
        public IEnumerable<TextValueVM> Roles { get; set; }
    }
}
