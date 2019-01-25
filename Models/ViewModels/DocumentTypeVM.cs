using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class DocumentTypeVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Тип на документа")]
        public string Label { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; }
    }
}
