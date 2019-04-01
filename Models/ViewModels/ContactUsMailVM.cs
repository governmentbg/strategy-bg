using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
  public class ContactUsMailVM
  {

    [Required(ErrorMessage = "Полето е задължително")]
    [Display(Name = "Име:")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Полето е задължително")]
    [Display(Name = "Е-Майл:")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Полето е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    public string Message { get; set; }

    [Display(Name = "Относно:")]
    public string About { get; set; }

    public List<SelectListItem> AboutTopics { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Неработеща функционалност", Text = "Неработеща функционалност" },
        new SelectListItem { Value = "Грешка в текст", Text = "Грешка в текст"  },
        new SelectListItem { Value = "Предложение", Text = "Предложение"  },
        new SelectListItem { Value = "Други", Text = "Други"  },
    };
  }
}
