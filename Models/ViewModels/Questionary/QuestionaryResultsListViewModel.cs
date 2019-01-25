using System;
using System.Collections.Generic;

namespace Models.ViewModels.Questionary
{
	public class QuestionaryResultsListViewModel
	{
		public QuestionaryResultsListViewModel()
		{
			List<PossibleAnswersListViewModel> PossibleAnswers = new List<PossibleAnswersListViewModel>();
			List<QuestionaryResultsQuestionViewModel> Questions = new List<QuestionaryResultsQuestionViewModel>();
		}
		public int QuestionaryHeaderId { get; set; }
		public string QuestionaryTitle { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int AnsweredUsersCount { get; set; }

		public List<PossibleAnswersListViewModel> PossibleAnswers { get; set; }
		public List<QuestionaryResultsQuestionViewModel> Questions { get; set; }
	}
}
