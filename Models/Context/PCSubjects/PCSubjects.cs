using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.PCSubjectsModels
{
	[Table("PublicConsultationSubjects", Schema = "dbo")]
	public class PCSubjects
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "IsUL")]
		public bool IsUL { get; set; }

		[Display(Name = "EIK")]
		public string EIK { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "PaymentValue")]
		public decimal PaymentValue { get; set; }

		[Display(Name = "ActivityDescription")]
		public string ActivityDescription { get; set; }

		[Display(Name = "DatePayment")]
		public DateTime DatePayment { get; set; }

		[Display(Name = "DateCreated")]
		public DateTime DateCreated { get; set; }

		[Display(Name = "CreatedByUserId")]
		public int CreatedByUserId { get; set; }

		[Display(Name = "DateModified")]
		public DateTime DateModified { get; set; }

		[Display(Name = "ModifiedByUserId")]
		public int ModifiedByUserId { get; set; }
	}
}
