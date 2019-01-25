using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Account
{
    public class UserEditVM
    {
        public int Id { get; set; }

        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Display(Name = "Активен потребител")]
        public bool IsActive { get; set; }

        [Display(Name = "Собствено име")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Организация")]
        public string Organization { get; set; }

        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [MaxLength(100)]
        [Display(Name = "Имейл")]
        [Required(ErrorMessage = "Въведете '{0}.'")]
        public string Email { get; set; }

        [Display(Name = "Потвърден потребител")]
        public bool IsApproved { get; set; }

        [Display(Name = "Потвърден имейл")]
        public bool IsMailConfirmed { get; set; }

        [Display(Name = "Тип потребител")]
        public string UserType { get; set; }

        public string GetFullName
        {
            get
            {
                string result = this.FirstName;
                if (!string.IsNullOrEmpty(this.LastName))
                {
                    result += " " + this.LastName;
                }

                return result;
            }
        }
    }
}
