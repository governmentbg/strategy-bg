using System;
using System.Collections.Generic;

namespace Models.ViewModels.Questionary
{
	public class QuestionaryResultsAnswerViewModel
	{
		public int Id { get; set; }
		public int QuestionId { get; set; }
		public int AnswersCheckedCount { get; set; }
		public decimal AnswersCheckedPercent { get; set; }
	}
}
