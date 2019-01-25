using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels
{
    public class PageVM
    {
        public int Id { get; set; }

        public int ParentContentId { get; set; }

        public string Lang { get; set; }

        public int ContentId { get; set; }

        public int OrderBy { get; set; }

        [MaxLength(500)]
        [Display(Name = "заглавие")]
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public string Content { get; set; }

        [Display(Name = "Url")]
        public string Url { get; set; }

        [Display(Name = "Контролер")]
        public string Controller { get; set; }

        [Display(Name = "Метод")]
        public string Action { get; set; }
        public string ClassName { get; set; }

        public bool ShowInMenu { get; set; }

        [Display(Name = "Статус")]
        public int StateID { get; set; }

        [Display(Name = "Създадено на")]
        public DateTime DateCreated { get; set; }

        public int UserWRT { get; set; }

        [Display(Name = "Публикувано на")]
        public DateTime DatePublished { get; set; }
    }
}
