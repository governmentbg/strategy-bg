using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context
{
    [Table("Categories", Schema = "dbo")]
    public class Category
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
        [Display(Name = "ParentId")]
        public int ParentId { get; set; }
        [Display(Name = "SectionId")]
        public int SectionId { get; set; }
        [Display(Name = "LanguageId")]
        public int LanguageId { get; set; }
        [Display(Name = "Priority")]
        public int Priority { get; set; }
        [Display(Name = "IsApproved")]
        public bool IsApproved { get; set; }
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { get; set; }
        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }
        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }
        [Display(Name = "ModifiedByUserId")]
        public int ModifiedByUserId { get; set; }
        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "DateModified")]
        public DateTime DateModified { get; set; }
    }
}