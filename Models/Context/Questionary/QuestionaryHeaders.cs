using Models.Context.Account;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Questionary
{
	[Table("questionary_headers", Schema = "questionary")]
	public class QuestionaryHeaders
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		public int? SourceId { get; set; }
		public int? SourceTypeId { get; set; }

		[Display(Name = "Наименование на анкетата")]
		public string QuestionaryTitle { get; set; }

		[Display(Name = "Описание на анкетата")]
		public string QuestionaryDescription { get; set; }

		[Display(Name = "Начална дата")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Крайна дата")]
		public DateTime? EndDate { get; set; }

		[Display(Name = "CreateDate")]
		public DateTime CreateDate { get; set; }

		[Display(Name = "CreateUserId")]
		public int CreateUserId { get; set; }

		//[ForeignKey(nameof(SourceType))]
		//public virtual Users SourceType { get; set; }

		[ForeignKey(nameof(CreateUserId))]
		public virtual Users User { get; set; }
	}
}
