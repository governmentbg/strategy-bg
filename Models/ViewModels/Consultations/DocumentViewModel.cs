using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Consultations
{
    public class DocumentViewModel
    {
        public int Id { get; set; }

        public int MainId { get; set; }

        public int ConsultationId { get; set; }

        public int Revision { get; set; }

        [Display(Name = "Документът е окончателен")]
        public bool IsFinal { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        [UIHint("TextArea")]
        public string Content { get; set; }

        [Display(Name = "Тип на документа")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Полето {0} е задължително")]
        public int DocumentTypeId { get; set; }

        [Display(Name = "Разреши коментари")]
        public bool CanComment { get; set; }
    }
}
