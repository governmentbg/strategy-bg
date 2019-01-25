using System;
using System.ComponentModel.DataAnnotations;
using WebCommon.Attributes;

namespace Models.ViewModels.Account
{
    public class RegisterInternalUserVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, ErrorMessage = "Полето '{0}' не може да е по-дълго от 50 символа")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        [EmailAddress(ErrorMessage = "Невалиден email")]
        [Display(Name = "Електронна поща")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, ErrorMessage = "Полето '{0}' не може да е по-дълго от 50 символа")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        [StringLength(50, ErrorMessage = "Полето '{0}' не може да е по-дълго от 50 символа")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [StringLength(200, ErrorMessage = "Полето '{0}' не може да е по-дълго от 200 символа")]
        [Display(Name = "Организация")]
        public string Organization { get; set; }

        [StringLength(1000, ErrorMessage = "Полето '{0}' не може да е по-дълго от 1000 символа")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "Полето '{0}' не може да е по-дълго от 50 символа")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        public int? GroupId { get; set; }
        [Display(Name = "Потребителска група")]
        public string GroupName { get; set; }

        public string FullName
        {
            get
            {

                return String.Format("{0} {1}", FirstName, LastName);

            }
        }
    }
}
