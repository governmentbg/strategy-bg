using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context.Ogp
{
    [Table("EstimationTypes", Schema = "ogp")]
    public class EstimationTypes
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }

    }
}