using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdServer.ViewModels
{
    public class UserEditVM
    {
        public string Id { get; set; }

        [Display(Name = "Активен потребител")]
        public bool IsActive { get; set; }

        [Display(Name = "Собствено име")]
        [Required(ErrorMessage = "Въведете '{0}.'")]
        public string GivenName { get; set; }

        [Display(Name = "Бащино име")]
        public string MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Въведете '{0}.'")]
        public string FamilyName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Имейл")]
        [Required(ErrorMessage = "Въведете '{0}.'")]
        public string Email { get; set; }

        [Display(Name = "Потвърден имейл")]
        public bool IsMailConfirmed { get; set; }

        public string GetFullName
        {
            get
            {
                string result = this.GivenName;
                if (!string.IsNullOrEmpty(this.MiddleName))
                {
                    result += " " + this.MiddleName;
                }
                result += " " + this.FamilyName;

                return result;
            }
        }
    }
}
