using Models.Context.Questionary;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Questionary
{
	public class QuestionaryViewModel
	{
		public int Id { get; set; }
		public int? SourceId { get; set; }
		public int? SourceTypeId { get; set; }

		[Display(Name = "Заглавие")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(250, MinimumLength = 1, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа")]
		public string QuestionaryTitle { get; set; }

		[Display(Name = "Описание")]
		[StringLength(500, ErrorMessage = "Описанието трябва да е по-малко от {1} символа")]
		[UIHint("TextArea")]
		public string QuestionaryDescription { get; set; }
	
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Display(Name = "Начална дата")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Крайна дата")]
		public DateTime? EndDate { get; set; }

		public QuestionaryHeaders ToEntity(QuestionaryHeaders entity = null)
		{
			if (entity == null)
			{
				entity = new QuestionaryHeaders();
			}

			entity.Id = this.Id;
			entity.SourceId = this.SourceId;
			entity.SourceTypeId = this.SourceTypeId;
			entity.QuestionaryTitle = this.QuestionaryTitle;
			entity.QuestionaryDescription = this.QuestionaryDescription;
			entity.StartDate = this.StartDate;
			entity.EndDate = this.EndDate;

			return entity;
		}

		public void FromEntity(QuestionaryHeaders entity)
		{
			Id = entity.Id;
			SourceId = entity.SourceId;
			SourceTypeId = entity.SourceTypeId;
			QuestionaryTitle = entity.QuestionaryTitle;
			QuestionaryDescription = entity.QuestionaryDescription;
			StartDate = entity.StartDate;
			EndDate = entity.EndDate;
		}
	}


}
