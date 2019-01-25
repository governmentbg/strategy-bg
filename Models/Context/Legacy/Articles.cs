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

        [Display(Name = "ArticleCategoryId")]
        public int ArticleCategoryId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "PageTitle")]
        public string PageTitle { get; set; }

        [Display(Name = "IsMainTopic")]
        public bool IsMainTopic { get; set; }

        [Display(Name = "IsOnMainPage")]
        public bool IsOnMainPage { get; set; }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        [Display(Name = "IsApproved")]
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


        [ForeignKey("ArticleCategoryId")]
        public ArticleCategories ArticleCategory { get; set; }
    }
}