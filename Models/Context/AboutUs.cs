using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context
{
	[Table("AboutUs", Schema = "dbo")]
	public class AboutUs
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "FirstName")]
		public string FirstName { get; set; }

		[Display(Name = "LastName")]
		public string LastName { get; set; }

		[Display(Name = "Phone")]
		public string Phone { get; set; }

		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "ThumbFileId")]
		public int? ThumbFileId { get; set; }

		[Display(Name = "VideoFileId")]
		public int? VideoFileId { get; set; }

		[Display(Name = "IsDeleted")]
		public bool IsDeleted { get; set; }

		[Display(Name = "IsActive")]
		public bool IsActive { get; set; }

		[Display(Name = "IsApproved")]
		public bool IsApproved { get; set; }

		[Display(Name = "LanguageId")]
		public int LanguageId { get; set; }

		[Display(Name = "CreatedByUserId")]
		public int CreatedByUserId { get; set; }

		[Display(Name = "ModifiedByUserId")]
		public int ModifiedByUserId { get; set; }

		[Display(Name = "DateCreated")]
		public DateTime DateCreated { get; set; }

		[Display(Name = "DateModified")]
		public DateTime DateModified { get; set; }

		[Display(Name = "IsAdmin")]
		public bool IsAdmin { get; set; }

		[Display(Name = "Rank")]
		public int Rank { get; set; }
	}
}