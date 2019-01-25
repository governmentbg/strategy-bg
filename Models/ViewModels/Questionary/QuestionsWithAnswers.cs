using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Questionary
{
	public class QuestionsWithAnswers
	{
		[Display(Name = "Въпрос")]
		public string Question { get; set; }

		[Display(Name = "Отговор")]
		public string Answer { get; set; }
	}
}
