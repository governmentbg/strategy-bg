using Models.Context.Account;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Account
{
    public class GroupUserVM
    {
        public int Id { get; set; }

        [Display(Name = "Област")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        [Range(0, 9999999, ErrorMessage = "Въведете '{0}'")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryParent { get; set; }

        [Display(Name = "Институция")]
        public int? InstitutionTypeId { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Organization { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон за контакт")]
        public string Phone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Активна група")]
        public bool IsActive { get; set; }

    }
}
