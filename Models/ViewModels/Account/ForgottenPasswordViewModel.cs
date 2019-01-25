using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Account
{
    public class ForgottenPasswordViewModel
    {
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}
