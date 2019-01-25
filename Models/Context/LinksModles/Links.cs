using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.LinksModels
{
	[Table("Links", Schema = "dbo")]
	public class Links
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Title")]
		public string Title { get; set; }

		[Display(Name = "Text")]
		public string Text { get; set; }

		[Display(Name = "Url")]
		public string Url { get; set; }

		[Display(Name = "IsDeleted")]
		public bool IsDeleted { get; set; }

		[Display(Name = "IsActive")]
		public bool IsActive { get; set; }

		[Display(Name = "IsApproved")]
		public bool IsApproved { get; set; }

		[Display(Name = "LanguageId")]
		public int LanguageId { get; set; }

		[Display(Name = "Priority")]
		public int Priority { get; set; }

		[Display(Name = "CreatedByUserId")]
		public int CreatedByUserId { get; set; }

		[Display(Name = "ModifiedByUserId")]
		public int ModifiedByUserId { get; set; }

		[Display(Name = "DateCreated")]
		public DateTime DateCreated { get; set; }

		[Display(Name = "DateModified")]
		public DateTime DateModified { get; set; }

		[Display(Name = "LinksCategoryID")]
		public int LinksCategoryID { get; set; }

		[ForeignKey(nameof(LinksCategoryID))]
		public virtual LinksCategories LinksCategory { get; set; }
	}
}
