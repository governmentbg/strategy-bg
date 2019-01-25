using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Notifications
{
    public class NotificationByFiltersVM
    {
        [Display(Name = "Тип")]
        public int CategoryMasterId { get; set; }

        [Display(Name = "Категория")]
        public int? CategoryId { get; set; }

        [Display(Name = "Област")]
        public int DistrictId { get; set; }

        [Display(Name = "Община")]
        public int? MunicipalityId { get; set; }

        [Display(Name = "Целева група")]
        public int? TargetGroupId { get; set; }

        [Display(Name = "Потребителска група")]
        public int? UserGroupId { get; set; }

        [Display(Name = "Относно")]
        [Required(ErrorMessage = "Полето '{0}' е задължително.")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        [Required(ErrorMessage = "Полето '{0}' е задължително.")]
        public string Body { get; set; }

        [Display(Name = "Изпращане по електронна поща")]
        public bool EmailNotification { get; set; }

        [Display(Name = "Известяване в системата")]
        public bool SystemNotification { get; set; }


    }
}
