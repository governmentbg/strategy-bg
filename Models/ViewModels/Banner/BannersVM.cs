using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
  public class BannersVM
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Полето е задължително")]
    [Display(Name = "Име")]
    public string Label { get; set; }

    [Required(ErrorMessage = "Полето е задължително")]
    [Display(Name = "Линк")]
    public string Link { get; set; }

    [Display(Name = "Вид")]
    public string BannerType { get; set; }

    [Display(Name = "Активен")]
    public bool IsActive { get; set; }

    [Display(Name = "Изтрит")]
    public bool IsDeleted { get; set; }

    [Display(Name = "Одобрен")]
    public bool IsApproved { get; set; }

    [Display(Name = "Език")]
    public int LanguageId { get; set; }
  }
}
