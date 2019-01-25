using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Ogp
{
    [Table("ElementTypes", Schema = "ogp")]
    public class ElementTypes
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "ElementCategory")]
        public int ElementCategory { get; set; }
        [Display(Name = "Priority")]
        public int Priority { get; set; }
    }
}