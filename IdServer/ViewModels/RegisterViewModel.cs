using IdServer.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace IdServer.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [EmailAddress(ErrorMessage = "Невалиден email")]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Паролата не може да е по-къса от 4 и по-дълга от 20 символа")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Паролите не съвпадат")]
        [Display(Name = "Парола още веднъж")]
        public string PasswordAgain { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(20, ErrorMessage = "Името не може да е по-дълго от 20 символа")]
        [Display(Name = "Име")]
        public string GivenName { get; set; }

        [Display(Name = "Презиме")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(20, ErrorMessage = "Името не може да е по-дълго от 20 символа")]
        [Display(Name = "Фамилия")]
        public string FamilyName { get; set; }


        [Display(Name = "Съгласен съм личните ми данни да бъдат съхранени и използвани за целите на системата")]
        [EnforceTrue(ErrorMessage = "Трябва да се съгласите личните Ви данни да бъдат съхранени и използвани от системата за управление на потребителите")]
        public bool IAgree { get; set; }

        public bool IsPublic { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MiddleName))
                {
                    return String.Format("{0} {1} {2}", GivenName, MiddleName, FamilyName);
                }
                else
                {
                    return String.Format("{0} {1}", GivenName, FamilyName);
                }
            }
        }
    }
}
