using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebCommon.Models;

namespace Models.ViewModels
{
    public class SendQuestionVM : GoogleReCaptchaModelBase
    {
        [MaxLength(200)]
        [Required]
        public string Email { get; set; }

        [MaxLength(200)]
        [Required]
        public string Names { get; set; }

        [Required]
        [MaxLength(200)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
