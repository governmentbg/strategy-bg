using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebCommon.Models;

namespace Models.ViewModels.Questionary
{
	public class FillQuestionaryViewModel
	{
		public FillQuestionaryViewModel()
		{
			QuestionaryPossibleAnswers = new List<PossibleAnswersViewModel>();
			AnsweredStartDate = DateTime.Now;
		}

		public int Id { get; set; }
		public int QuestionaryHeaderId { get; set; }
        public int SourceType { get; set; }
        public int SourceId { get; set; }
        public string QuestionaryTitle { get; set; }
		public int? AnsweredUserId { get; set; }

		[Display(Name = "Имена на отговорилия")]
		public string AnsweredUserName { get; set; }

		[Display(Name = "Email на отговорилия")]
		public string AnsweredUserEmail { get; set; }
		public DateTime AnsweredStartDate { get; set; }
		public List<PossibleAnswersViewModel> QuestionaryPossibleAnswers { get; set; }
		public IEnumerable<QuestionaryQuestionVM> QuestionaryQuestions { get; set; }
	}
}
