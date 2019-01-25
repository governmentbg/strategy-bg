// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Account
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        //[EmailAddress(ErrorMessage = "Потребителското име трябва да е валиден Email")]
        [Display(Name = "Електронна поща")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Полето '{0}' е задължително")]
        [Display(Name = "Парола")]
        public string Password { get; set; }
        [Display(Name = "Запомни ме")]
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public bool ExternalLoginEnabled { get; set; }
    }
}