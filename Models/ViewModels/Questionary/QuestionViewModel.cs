using Models.Context.Questionary;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Questionary
{
	public class QuestionViewModel
	{
		public int Id { get; set; }
		public int QuestionaryHeaderId { get; set; }

		[Display(Name = "Въпрос")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(250, MinimumLength = 1, ErrorMessage = "Дължината на текста трябва да е между {2} и {1} символа")]
		public string QuestionDescription { get; set; }

		[Display(Name = "Номер за подредба при визуализация")]
		public int? OrderNum { get; set; }

		public QuestionaryQuestions ToEntity(QuestionaryQuestions entity = null)
		{
			if (entity == null)
			{
				entity = new QuestionaryQuestions();
			}

			entity.Id = this.Id;
			entity.QuestionaryHeaderId = this.QuestionaryHeaderId;
			entity.OrderNum = this.OrderNum;
			entity.QuestionDescription = this.QuestionDescription;

			return entity;
		}

		public void FromEntity(QuestionaryQuestions entity)
		{
			Id = entity.Id;
			QuestionaryHeaderId = entity.QuestionaryHeaderId;
			OrderNum = entity.OrderNum;
			QuestionDescription = entity.QuestionDescription;
		}
	}


}
