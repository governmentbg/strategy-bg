using Models.Context.Consultations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Целева група")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Полето {0} е задължително")]
        public int TargetGroupId { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [StringLength(256, MinimumLength = 10, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа")]
        public string Title { get; set; }

        [Display(Name = "Кратко описание")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [UIHint("TextArea")]
        public string Summary { get; set; }

        [Display(Name = "Начало")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public DateTime OpenningDate { get; set; }

        [Display(Name = "Край")]
        [Required(ErrorMessage = "Полето {0} е задължително")]
        public DateTime ClosingDate { get; set; }

        [Display(Name = "Причина за кратък срок")]
        public string ShortTermReason { get; set; }

        [Display(Name = "Активна")]
        public bool IsActive { get; set; }

        [Display(Name = "Одобрена")]
        public bool IsApproved { get; set; }

        [Display(Name = "Изтрита")]
        public bool IsDeleted { get; set; }

        public PublicConsultation ToEntity(PublicConsultation entity = null)
        {
            if (entity == null)
            {
                entity = new PublicConsultation();
            }

            entity.CategoryId = this.CategoryId;
            entity.TargetGroupId = this.TargetGroupId;
            entity.Title = this.Title;
            entity.Summary = this.Summary;
            entity.OpenningDate = this.OpenningDate;
            entity.ClosingDate = this.ClosingDate;
            entity.ShortTermReason = this.ShortTermReason;
            entity.IsActive = this.IsActive;
            entity.IsApproved = this.IsApproved;
            entity.IsDeleted = this.IsDeleted;

            return entity;
        }

        public void FromEntity(PublicConsultation entity)
        {
            Id = entity.Id;
            CategoryId = entity.CategoryId;
            CategoryName = entity.Category.CategoryName;
            TargetGroupId = entity.TargetGroupId;
            Title = entity.Title;
            Summary = entity.Summary;
            OpenningDate = entity.OpenningDate;
            ClosingDate = entity.ClosingDate;
            ShortTermReason = entity.ShortTermReason;
            IsActive = entity.IsActive;
            IsApproved = entity.IsApproved;
            IsDeleted = entity.IsDeleted;
        }
    }


}
