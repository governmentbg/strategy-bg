using Models.Context.Questionary;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Questionary
{
	public class PossibleAnswersViewModel
	{
		public int Id { get; set; }
		public int QuestionaryHeaderId { get; set; }

		[Display(Name = "Отговор")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(250, MinimumLength = 1, ErrorMessage = "Дължината на текста трябва да е между {2} и {1} символа")]
		public string Answer { get; set; }

		public QuestionaryPossibleAnswers ToEntity(QuestionaryPossibleAnswers entity = null)
		{
			if (entity == null)
			{
				entity = new QuestionaryPossibleAnswers();
			}

			entity.Id = this.Id;
			entity.QuestionaryHeaderId = this.QuestionaryHeaderId;
			entity.Answer = this.Answer;

			return entity;
		}

		public void FromEntity(QuestionaryPossibleAnswers entity)
		{
			Id = entity.Id;
			QuestionaryHeaderId = entity.QuestionaryHeaderId;
			Answer = entity.Answer;
		}
	}


}
