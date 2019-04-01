using System.ComponentModel.DataAnnotations;

namespace IdServer.ViewModels
{
    public class ForgottenPasswordViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}
