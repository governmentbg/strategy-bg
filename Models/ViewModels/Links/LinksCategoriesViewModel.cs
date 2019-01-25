using Models.Context.LinksModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.LinksModels
{
	public class LinksCategoriesViewModel
	{
		public LinksCategoriesViewModel()
		{
			Priority = 0;
			IsDeleted = false;
			IsApproved = true;
			LanguageId = 1;
			ColumnsCount = 1;
		}
		public int Id { get; set; }

		[Display(Name = "Име")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(100, MinimumLength = 1, ErrorMessage = "Заглавието трябва да е между {2} и {1} символа")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Display(Name = "Дата на създаване")]
		public DateTime DateCreated { get; set; }

		[Display(Name = "Активност")]
		public bool IsActive { get; set; }

		public int Priority { get; set; }

		[Display(Name = "Изтрит")]
		public bool IsDeleted { get; set; }

		public bool IsApproved { get; set; }

		public int LanguageId { get; set; }

		public int CreatedByUserId { get; set; }

		public int ModifiedByUserId { get; set; }

		public DateTime DateModified { get; set; }

		public int ViewOrder { get; set; }

		[Display(Name = "Брой колони")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Range(1, 5, ErrorMessage = "Броя трябва да е между {1} и {2}")]
		public int ColumnsCount { get; set; }

		public LinksCategories ToEntity(LinksCategories entity = null)
		{
			if (entity == null)
			{
				entity = new LinksCategories();
			}

			entity.Id = this.Id;
			entity.Name = this.Name;
			entity.IsActive = this.IsActive;
			entity.DateCreated = this.DateCreated;

			entity.Priority = this.Priority;
			entity.IsDeleted = this.IsDeleted;
			entity.IsApproved = this.IsApproved;
			entity.LanguageId = this.LanguageId;
			entity.CreatedByUserId = this.CreatedByUserId;
			entity.ModifiedByUserId = this.ModifiedByUserId;
			entity.DateModified = this.DateModified;
			entity.ViewOrder = this.ViewOrder;
			entity.ColumnsCount = this.ColumnsCount;

			return entity;
		}

		public void FromEntity(LinksCategories entity)
		{
			Id = entity.Id;
			Name = entity.Name;
			IsActive = entity.IsActive;
			DateCreated = entity.DateCreated;

			Priority = entity.Priority;
			IsDeleted = entity.IsDeleted;
			IsApproved = entity.IsApproved;
			LanguageId = entity.LanguageId;
			CreatedByUserId = entity.CreatedByUserId;
			ModifiedByUserId = entity.ModifiedByUserId;
			DateModified = entity.DateModified;
			ViewOrder = entity.ViewOrder;
			ColumnsCount = entity.ColumnsCount;
		}
	}


}
