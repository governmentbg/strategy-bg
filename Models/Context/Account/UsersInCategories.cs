using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Account
{

    [Table("users_in_categories", Schema = "account")]
    public class UsersInCategories
    {
        
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual Users User { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}

