using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context
{

	[Table("ChangeProposals", Schema = "itf")]
	public class ChangeProposals
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "CategoryId")]
		public int CategoryId { get; set; }

		[Display(Name = "Title")]
		public string Title { get; set; }

		[Display(Name = "Text")]
		public string Text { get; set; }

		[Display(Name = "IsActive")]
		public bool IsActive { get; set; }

		[Display(Name = "IsRejected")]
		public bool IsRejected { get; set; }

		[Display(Name = "IsApproved")]
		public bool IsApproved { get; set; }

		[Display(Name = "AdminRemark")]
		public string AdminRemark { get; set; }

		[Display(Name = "CreatedByUserId")]
		public int CreatedByUserId { get; set; }

		[Display(Name = "ActualUserId")]
		public int ActualUserId { get; set; }

		[Display(Name = "ModifiedByUserId")]
		public int ModifiedByUserId { get; set; }

		[Display(Name = "DateCreated")]
		public DateTime DateCreated { get; set; }

		[Display(Name = "DateModified")]
		public DateTime DateModified { get; set; }

		[ForeignKey(nameof(CategoryId))]
		public virtual Category Category { get; set; }
	}
}