using Models.Context.LinksModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.LinksModels
{
	public class LinksViewModel
	{
		public LinksViewModel()
		{
			Priority = 0;
			IsDeleted = false;
			IsApproved = true;
			LanguageId = 1;
			Priority = 0;
		}
		public int Id { get; set; }

		[Display(Name = "Заглавие")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(255, MinimumLength = 1, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа")]
		public string Title { get; set; }

		[Display(Name = "Текст")]
		[StringLength(255, MinimumLength = 1, ErrorMessage = "Дължината на текста трябва да е между {2} и {1} символа")]
		[UIHint("TextArea")]
		public string Text { get; set; }

		[Display(Name = "Интернет адрес")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		public string Url { get; set; }

		[Display(Name = "Изтрит")]
		public bool IsDeleted { get; set; }

		[Display(Name = "Активност")]
		public bool IsActive { get; set; }

		public bool IsApproved { get; set; }

		public int LanguageId { get; set; }

		public int Priority { get; set; }

		public DateTime DateCreated { get; set; }

		public int CreatedByUserId { get; set; }

		public int ModifiedByUserId { get; set; }

		public DateTime DateModified { get; set; }
		
		[Display(Name = "Категория връзки")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		public int LinksCategoryID { get; set; }

		public Links ToEntity(Links entity = null)
		{
			if (entity == null)
			{
				entity = new Links();
			}

			entity.Id = this.Id;
			entity.Title = this.Title;
			entity.Text = this.Text;
			entity.Url = this.Url;
			entity.IsDeleted = this.IsDeleted;
			entity.IsActive = this.IsActive;
			entity.IsApproved = this.IsApproved;
			entity.LanguageId = this.LanguageId;
			entity.Priority = this.Priority;
			entity.DateCreated = this.DateCreated;
			entity.CreatedByUserId = this.CreatedByUserId;
			entity.ModifiedByUserId = this.ModifiedByUserId;
			entity.DateModified = this.DateModified;
			entity.LinksCategoryID = this.LinksCategoryID;

			return entity;
		}

		public void FromEntity(Links entity)
		{
			Id = entity.Id;
			Title = entity.Title;
			Text = entity.Text;
			Url = entity.Url;
			IsDeleted = entity.IsDeleted;
			IsActive = entity.IsActive;
			IsApproved = entity.IsApproved;
			LanguageId = entity.LanguageId;
			Priority = entity.Priority;
			DateCreated = entity.DateCreated;
			CreatedByUserId = entity.CreatedByUserId;
			ModifiedByUserId = entity.ModifiedByUserId;
			DateModified = entity.DateModified;
			LinksCategoryID = entity.LinksCategoryID;
		}
	}


}
