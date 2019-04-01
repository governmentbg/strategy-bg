using Models.Context.Consultations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using WebCommon.Extensions;

namespace Models.ViewModels.Consultations
{
    public class ConsultationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Категория")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Полето {0} е задължително")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int ParentCategoryId { get; set; }

        public string ParentCategoryName { get; set; }

        public int SectionId { get; set; }

        public string SectionName { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [StringLength(256, MinimumLength = 10, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа")]
        public string Title { get; set; }

        [Display(Name = "Кратко описание")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [UIHint("TextArea")]
        public string Summary { get; set; }

        [Display(Name = "Дата на откриване")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public DateTime OpenningDate { get; set; }

        [Display(Name = "Дата на приключване")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public DateTime ClosingDate { get; set; }

        public int ActiveDays
        {
            get
            {
                int days = 0;

                if (OpenningDate.Date <= DateTime.Today && ClosingDate.Date > DateTime.Today)
                {
                    days = (ClosingDate.Date - DateTime.Today).Days;
                }

                return days;
            }
        }

        [Display(Name = "Причина за кратък срок")]
        public string ShortTermReason { get; set; }

        [Display(Name = "Активна")]
        public bool IsActive { get; set; }

        [Display(Name = "Одобрена")]
        public bool IsApproved { get; set; }

        [Display(Name = "Изтрита")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Категория връзки")]
        public int LinksCategoryId { get; set; }

        [Display(Name = "Отговорно звено")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Полето {0} е задължително")]
        public int InstututionTypeId { get; set; }

        public string InstitutionName { get; set; }

        [Display(Name = "Извести абонираните с имейл")]
        public bool ShouldAlertSubscribers { get; set; }

        [Display(Name = "Отговорно лице")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public string ResponsiblePerson { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Telephone { get; set; }

        [Display(Name = "Ел. поща")]
        [EmailAddress(ErrorMessage = "Полето {0} не е валидна Ел. поща")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public string Email { get; set; }

        public bool CanComment { get; set; }

        public List<MenuLinkViewModel> MenuLinks { get; set; }

        public PublicConsultation ToEntity(PublicConsultation entity = null)
        {
            if (entity == null)
            {
                entity = new PublicConsultation();
            }

            entity.CategoryId = this.CategoryId;
            entity.Title = this.Title;
            entity.Summary = this.Summary;
            entity.OpenningDate = this.OpenningDate;
            entity.ClosingDate = this.ClosingDate;
            entity.ShortTermReason = this.ShortTermReason;
            entity.IsActive = this.IsActive;
            entity.IsDeleted = this.IsDeleted;
            entity.LinksCategoryId = this.LinksCategoryId;
            entity.InstututionTypeId = this.InstututionTypeId;
            entity.ShouldAlertSubscribers = this.ShouldAlertSubscribers;
            entity.ResponsiblePerson = this.ResponsiblePerson;
            entity.Address = this.Address;
            entity.Telephone = this.Telephone;
            entity.Email = this.Email;

            return entity;
        }

        public void FromEntity(PublicConsultation entity)
        {
            Id = entity.Id;
            CategoryId = entity.CategoryId;
            CategoryName = entity.Category.CategoryName;
            ParentCategoryId = entity.Category.ParentId;
            SectionId = entity.Category.SectionId;
            Title = entity.Title;
            Summary = entity.Summary;
            OpenningDate = entity.OpenningDate;
            ClosingDate = entity.ClosingDate;
            ShortTermReason = entity.ShortTermReason;
            IsActive = entity.IsActive;
            IsDeleted = entity.IsDeleted;
            LinksCategoryId = entity.LinksCategoryId ?? -1;
            InstututionTypeId = entity.InstututionTypeId ?? -1;
            ShouldAlertSubscribers = entity.ShouldAlertSubscribers;
            ResponsiblePerson = entity.ResponsiblePerson;
            Address = entity.Address;
            Telephone = entity.Telephone;
            Email = entity.Email;
            InstitutionName = entity.InstitutionType?.InstitutionTypeName;
            MenuLinks = entity.LinksCategory != null ? entity.LinksCategory.Links
                .Select(l => new MenuLinkViewModel()
                {
                    Title = l.Title,
                    Url = l.Url
                }).ToList() : new List<MenuLinkViewModel>();
        }
    }


}
