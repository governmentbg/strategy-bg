using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Context.Questionary
{

	[Table("questionary_questions", Schema = "questionary")]
	public class QuestionaryQuestions
	{
		public QuestionaryQuestions()
		{
		}

		[Key]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "QuestionaryHeaderId")]
		public int QuestionaryHeaderId { get; set; }

		[ForeignKey(nameof(QuestionaryHeaderId))]
		public virtual QuestionaryHeaders QuestionaryHeader { get; set; }

		[Display(Name = "Описание на въпрос")]
		public string QuestionDescription { get; set; }

		[Display(Name = "Номер за подредба")]
		public int? OrderNum { get; set; }
	}
}