using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Legacy
{

    [Table("Articles", Schema = "dbo")]
    public class Articles
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Категория")]
        public int ArticleCategoryId { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        public string Text { get; set; }

        [Display(Name = "Дата на събитие")]
        public DateTime Date { get; set; }

        [Display(Name = "Изображение")]
        public string Image { get; set; }

        [Display(Name = "Номер на страница")]
        public string PageTitle { get; set; }

        [Display(Name = "Водеща новина")]
        public bool IsMainTopic { get; set; }

        [Display(Name = "Показване на начална страница")]
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

        [Display(Name = "Създадена от")]
        public int CreatedByUserId { get; set; }

        [Display(Name = "Ридактирана от")]
        public int ModifiedByUserId { get; set; }

        [Display(Name = "Дата на създаване")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Дата на промяна")]
        public DateTime DateModified { get; set; }

        [Display(Name = "FileId")]
        public int? FileId { get; set; }

        [Display(Name = "VideoFileId")]
        public int? VideoFileId { get; set; }


        [ForeignKey("ArticleCategoryId")]
        public ArticleCategories ArticleCategory { get; set; }
    }
}