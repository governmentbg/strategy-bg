using System.Collections.Generic;

namespace WebCommon.Models
{
	public class QuestionaryQuestionVM
	{
		public int QuestionId { get; set; }
		public int? AnswerId { get; set; }
		public string Text { get; set; }
		public IEnumerable<QuestionaryAnswerVM> QuestionaryAnswers { get; set; }
	}
}
