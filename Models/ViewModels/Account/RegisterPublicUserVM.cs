using System;
using System.ComponentModel.DataAnnotations;
using WebCommon.Attributes;

namespace Models.ViewModels.Account
{
    public class RegisterPublicUserVM : RegisterInternalUserVM
    {

        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Паролата не може да е по-къса от 4 и по-дълга от 50 символа")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Паролите не съвпадат")]
        [Display(Name = "Моля, повторете паролата")]
        public string PasswordAgain { get; set; }

        [Display(Name = "Съгласен съм личните ми данни да бъдат съхранени и използвани за целите на системата")]
        [EnforceTrue(ErrorMessage = "Трябва да се съгласите личните Ви данни да бъдат съхранени и използвани от системата за управление на потребителите")]
        public bool IAgree { get; set; }

        public string ExternalProvider { get; set; }

    }
}
