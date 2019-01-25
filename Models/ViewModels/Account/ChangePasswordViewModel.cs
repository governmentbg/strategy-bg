using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Account
{
    public class ChangePasswordViewModel
    {
        [UIHint("password")]
        [Display(Name = "Парола")]
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Паролата не може да е по-къса от 4 и по-дълга от 20 символа")]
        public string Password { get; set; }

        [UIHint("password")]
        [Display(Name = "Парола още веднъж")]
        [Compare(nameof(Password), ErrorMessage = "Паролите не съвпадат")]
        public string PasswordAgain { get; set; }

        [UIHint("hidden")]
        public string Code { get; set; }

        [UIHint("hidden")]
        public string ReturnUrl { get; set; }
    }
}
