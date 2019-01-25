using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Ogp
{
    [Table("NationalPlanEstimations", Schema = "ogp")]
    public class NationalPlanEstimations
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "ParentID")]
        public int? ParentID { get; set; }
        [Display(Name = "Елемент от национален план")]
        public int ElementID { get; set; }
        [Display(Name = "Тип оценка")]
        public int EstimationTypeId { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Полето '{0}' е задължително.")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Полето '{0}' е задължително.")]
        public string Description { get; set; }
        [Display(Name = "Активна оценка")]
        public bool IsActive { get; set; }
        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }
        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }
        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }

        [ForeignKey(nameof(ElementID))]
        public NationalPlanElements PlanElement { get; set; }
        [ForeignKey(nameof(EstimationTypeId))]
        public EstimationTypes EstimationType { get; set; }
    }
}