using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Questionary
{
	public class FilledQuestionaryViewModel
	{
		public FilledQuestionaryViewModel()
		{
			List<QuestionsWithAnswers> QuestionsWithAnswers = new List<QuestionsWithAnswers>();
		}

		[Display(Name = "Наименование на анкетата")]
		public string QuestionaryTitle { get; set; }

		[Display(Name = "Имена на отговорилия")]
		public string AnsweredUserName { get; set; }

		[Display(Name = "Email на отговорилия")]
		public string AnsweredUserEmail { get; set; }

		[Display(Name = "Начало на попълване")]
		public DateTime? AnsweredStartDate { get; set; }

		[Display(Name = "Край на попълване")]
		public DateTime? AnsweredEndDate { get; set; }

		public List<QuestionsWithAnswers> QuestionsWithAnswers { get; set; }
	}
}
