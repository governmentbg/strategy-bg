using Models.Context.Account;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Questionary
{

	[Table("questionary_answered_users", Schema = "questionary")]
	public class QuestionaryAnsweredUsers
	{
		public QuestionaryAnsweredUsers()
		{
		}

		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "QuestionaryHeaderId")]
		public int QuestionaryHeaderId { get; set; }

		[Display(Name = "AnsweredUserId")]
		public int? AnsweredUserId { get; set; }

		[Display(Name = "Имена на отговорилия")]
		public string AnsweredUserName { get; set; }

		[Display(Name = "Email на отговорилия")]
		public string AnsweredUserEmail { get; set; }

		[Display(Name = "Начало на анкетата")]
		public DateTime AnsweredStartDate { get; set; }

		[Display(Name = "Край на анкетата")]
		public DateTime AnsweredEndDate { get; set; }

		[ForeignKey(nameof(QuestionaryHeaderId))]
		public virtual QuestionaryHeaders QuestionaryHeader { get; set; }

		[ForeignKey(nameof(AnsweredUserId))]
		public virtual Users User { get; set; }
	}
}