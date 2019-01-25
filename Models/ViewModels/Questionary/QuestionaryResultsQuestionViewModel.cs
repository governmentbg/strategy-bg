using System;
using System.Collections.Generic;

namespace Models.ViewModels.Questionary
{
	public class QuestionaryResultsQuestionViewModel
	{
		public QuestionaryResultsQuestionViewModel()
		{
			List<QuestionaryResultsAnswerViewModel> answers = new List<QuestionaryResultsAnswerViewModel>();
		}

		public int Id { get; set; }
		public string QuestionDescription { get; set; }
		public int QuestionNum { get; set; }
		public List<QuestionaryResultsAnswerViewModel> answers { get; set; }
	}
}
