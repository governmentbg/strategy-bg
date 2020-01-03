using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Ogp
{
    [Table("NationalPlanElements", Schema = "ogp")]
    public class NationalPlanElements
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "ParentID")]
        public int? ParentID { get; set; }
        [Display(Name = "Тип на елемента")]
        public int ElementTypeId { get; set; }
        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Полето '{0}' е задължително.")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Полето '{0}' е задължително.")]
        public string Description { get; set; }
        [Display(Name = "Статус")]
        public int? NationalPlanStateId { get; set; }
        [Display(Name = "Записа е активен")]
        public bool IsActive { get; set; }
        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }
        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }
        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }

        [ForeignKey(nameof(ElementTypeId))]
        public ElementTypes ElementType { get; set; }

        [ForeignKey(nameof(NationalPlanStateId))]
        public NationalPlanStates NationalPlanState { get; set; }

        public ICollection<NationalPlanEstimations> Estimations { get; set; }
        public NationalPlanElements()
        {
            Estimations = new HashSet<NationalPlanEstimations>();
        }
    }
}