using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Account
{
    public class DeactivateUserViewModel : ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, ErrorMessage = "Полето '{0}' не може да е по-дълго от 50 символа")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}
