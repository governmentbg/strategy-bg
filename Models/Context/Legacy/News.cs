using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Context.Legacy
{

    [Table("News", Schema = "dbo")]
    public class News
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Категория")]
        public int NewsCategoryId { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        public string Text { get; set; }

        [Display(Name = "Дата на събитие")]
        public DateTime Date { get; set; }

        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }

        [Display(Name = "Записът е изтрит")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Записът е активен")]
        public bool IsActive { get; set; }

        [Display(Name = "Записът е одобрен")]
        public bool IsApproved { get; set; }

        [Display(Name = "Записът е архивиран")]
        public bool IsArchive { get; set; }

        [Display(Name = "Водеща новина")]
        public bool IsMainTopic { get; set; }

        [Display(Name = "Показване на начална страница")]
        public bool IsOnMainPage { get; set; }

        [Display(Name = "Приоритет")]
        public int Priority { get; set; }

        [Display(Name = "Език")]
        public int LanguageId { get; set; }

        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }

        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }

        [Display(Name = "Външна връзка")]
        public bool? IsRss { get; set; }

        [Display(Name = "URL на външна връзка")]
        public string RssPostLink { get; set; }

        [ForeignKey(nameof(NewsCategoryId))]
        public virtual NewsCategories NewsCategory { get; set; }
    }
}