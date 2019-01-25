using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Ogp
{
    [Table("NationalPlanEstimationResults", Schema = "ogp")]
    public class NationalPlanEstimationResults
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "EstimationID")]
        public int EstimationID { get; set; }
        [Display(Name = "ElementID")]
        public int ElementID { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
        [Display(Name = "CreatedByUserId")]
        public int? CreatedByUserId { get; set; }
        [Display(Name = "ModifiedByUserId")]
        public int? ModifiedByUserId { get; set; }
        [Display(Name = "DateCreated")]
        public DateTime? DateCreated { get; set; }
        [Display(Name = "DateModified")]
        public DateTime? DateModified { get; set; }

        [ForeignKey(nameof(EstimationID))]
        public NationalPlanEstimations NationalPlanEstimation { get; set; }

        [ForeignKey(nameof(ElementID))]
        public NationalPlanElements NationalPlanElement { get; set; }
    }
}