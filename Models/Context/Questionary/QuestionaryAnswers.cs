using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Questionary
{

	[Table("questionary_answers", Schema = "questionary")]
	public class QuestionaryAnswers
	{
		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "QuestionaryQuestionId")]
		public int QuestionaryQuestionId { get; set; }

		[Display(Name = "QuestionaryAnsweredUserId")]
		public int QuestionaryAnsweredUserId { get; set; }

		[Display(Name = "QuestionaryPossibleAnswerId")]
		public int QuestionaryPossibleAnswerId { get; set; }

		[ForeignKey(nameof(QuestionaryQuestionId))]
		public virtual QuestionaryQuestions QuestionaryQuestion { get; set; }

		[ForeignKey(nameof(QuestionaryAnsweredUserId))]
		public virtual QuestionaryAnsweredUsers QuestionaryAnsweredUser { get; set; }

		[ForeignKey(nameof(QuestionaryPossibleAnswerId))]
		public virtual QuestionaryPossibleAnswers QuestionaryPossibleAnswer { get; set; }
	}
}