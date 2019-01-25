using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Context
{
    [Table("pages", Schema = "itf")]
    public class Page
    {

        public Page()
        {
            PageLinks = new HashSet<PageLink>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("page_type_id")]
        public int PageTypeId { get; set; }

        [Column("parent_content_id")]
        public int ParentContentId { get; set; }

        [Column("lang")]
        [MaxLength(2)]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Lang { get; set; }

        [Column("content_id")]
        public int ContentId { get; set; }

        [Column("title")]
        [MaxLength(500)]
        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Въведете '{0}'")]
        public string Title { get; set; }

        [Column("sub_title")]
        [Display(Name = "Под-заглавие")]
        public string SubTitle { get; set; }

        [Column("content")]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }

        [Column("url")]
        [Display(Name = "Url")]
        [MaxLength(500)]
        public string Url { get; set; }

        [Column("controller_name")]
        [Display(Name = "Контролер")]
        [MaxLength(100)]
        public string Controller { get; set; }

        [Column("action_name")]
        [Display(Name = "Метод")]
        [MaxLength(100)]
        public string Action { get; set; }

        [Column("class_name")]
        [Display(Name = "CSS клас")]
        [MaxLength(100)]
        public string ClassName { get; set; }

        [Column("state_id")]
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Изберете '{0}'")]
        public int StateID { get; set; }

        [Column("order_by")]
        public int OrderBy { get; set; }

        [Column("show_in_menu")]
        [Required]
        [Display(Name = "Покажи в основното меню")]
        public bool ShowInMenu { get; set; }

        [Column("date_created")]
        [Display(Name = "Създадено на")]
        [Required]
        public DateTime DateCreated { get; set; }

        [Column("user_wrt")]
        public int UserWRT { get; set; }

        [Column("date_event")]
        [Display(Name = "Дата на събитието")]
        public Nullable<DateTime> DateEvent { get; set; }

        [Column("date_published")]
        [Display(Name = "Публикувано на")]
        public Nullable<DateTime> DatePublished { get; set; }

        [ForeignKey(nameof(PageTypeId))]
        public PageType PageType { get; set; }

        [ForeignKey(nameof(StateID))]
        public PageState PageState { get; set; }

        public ICollection<PageLink> PageLinks { get; set; }

        [NotMapped]
        [Display(Name = "Специализирана страница")]
        public bool SpecialPage
        {
            get
            {
                return !string.IsNullOrEmpty(this.Action);
            }            
        }
    }
}
