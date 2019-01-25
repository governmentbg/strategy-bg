using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context
{

    [Table("GenericContent", Schema = "itf")]
    public class GenericContent
    {
        [Key]
        [Display(Name = "Ключова стойност")]
        public string Alias { get; set; }

        [NotMapped]
        public string SavedAlias { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        public string Text { get; set; }

        [Display(Name = "Забележка")]
        public string Remark { get; set; }

        [Display(Name = "Активен запис")]
        public bool IsActive { get; set; }

        [Display(Name = "CreatedByUserId")]
        public int CreatedByUserId { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "ModifiedByUserId")]
        public int? ModifiedByUserId { get; set; }

        [Display(Name = "DateModified")]
        public DateTime? DateModified { get; set; }

    }
}
