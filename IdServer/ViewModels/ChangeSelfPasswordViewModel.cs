using System.ComponentModel.DataAnnotations;

namespace IdServer.ViewModels
{
    public class ChangeSelfPasswordViewModel : ChangePasswordViewModel
    {
        [UIHint("password")]
        [Display(Name = "Съществуваща парола")]
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Паролата не може да е по-къса от 4 и по-дълга от 20 символа")]
        public string OldPassword { get; set; }
    }
}
