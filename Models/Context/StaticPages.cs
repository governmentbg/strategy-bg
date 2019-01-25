using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.Context
{
    [Table("StaticPages", Schema = "itf")]
    public class StaticPages
    {
        [Key]
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Title { get; set; }

        public string Sub_title { get; set; }

        public string ItemContent { get; set; }

        public int OrderToShow { get; set; }

        public int ItemLevel { get; set; }

        public int CreatedByUserId { get; set; }

        public int ModifiedByUserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

    }

}