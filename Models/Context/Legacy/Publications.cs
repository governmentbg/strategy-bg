using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Legacy
{

    [Table("Publications", Schema = "dbo")]
    public class Publications
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Категория")]
        public int PublicationCategoryId { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        public string Text { get; set; }

        [Display(Name = "Дата на събитието")]
        public DateTime Date { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "PageTitle")]
        public string PageTitle { get; set; }

        [Display(Name = "Водеща публикация")]
        public bool IsMainTopic { get; set; }

        [Display(Name = "Водеща публикация")]
        public bool IsOnMainPage { get; set; }

        [Display(Name = "Записът е изтрит")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Записът е активен")]
        public bool IsActive { get; set; }

        [Display(Name = "Записът е одобрен")]
        public bool IsApproved { get; set; }

        [Display(Name = "Priority")]
        public int Priority { get; set; }

        [Display(Name = "LanguageId")]
        public int LanguageId { get; set; }

        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }

        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }

        [Display(Name = "FileId")]
        public int? FileId { get; set; }

        [Display(Name = "VideoFileId")]
        public int? VideoFileId { get; set; }

        [ForeignKey(nameof(PublicationCategoryId))]
        public virtual PublicationCategories PublicationCategory { get; set; }
    }
}