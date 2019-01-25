using Models.ViewModels.Questionary;
using System.Collections.Generic;
using System.Linq;

namespace Models.Contracts
{
	public interface IQuestionaryService
	{
		IQueryable<QuestionaryListViewModel> GetQuestionaries();
		bool SaveQuestionary(QuestionaryViewModel model, int userId);
		QuestionaryViewModel GetQuestionary(int id);
		QuestionaryViewModel GetQuestionary(int sourceTypeID, int sourceId);

		IQueryable<QuestionsListViewModel> GetQuestions(int questionaryHeaderId);
		QuestionViewModel GetQuestion(int id);
		bool SaveQuestion(QuestionViewModel model);

		IQueryable<PossibleAnswersListViewModel> GetAnswers(int questionaryHeaderId);
		PossibleAnswersViewModel GetAnswer(int id);
		bool SaveAnswer(PossibleAnswersViewModel model);

		bool SaveFilledQuestionary(FillQuestionaryViewModel model);
		FillQuestionaryViewModel SetAnswers(int questionaryHeaderId);
		QuestionaryResultsListViewModel GetResults(int questionaryHeaderId);
		List<QuestionChartResultViewModel> QuestinaryResultsLoadData(int questionaryHeaderId, int questionaryQuestionId);
		FilledQuestionaryViewModel GetFilledQuestionary(int questionaryHeaderId, int? userId, string userEmail);
	}
}
