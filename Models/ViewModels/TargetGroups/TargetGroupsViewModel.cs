using Models.Context;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.TargetGroupsModel
{
	public class TargetGroupsViewModel
	{
		public TargetGroupsViewModel()
		{
			IsDeleted = false;
			IsApproved = true;
			LanguageId = 1;
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

		[Display(Name = "Изтрит")]
		public bool IsDeleted { get; set; }

		public bool IsApproved { get; set; }

		public int LanguageId { get; set; }

		public int CreatedByUserId { get; set; }

		public int ModifiedByUserId { get; set; }

		public DateTime DateModified { get; set; }

		public TargetGroups ToEntity(TargetGroups entity = null)
		{
			if (entity == null)
			{
				entity = new TargetGroups();
			}

			entity.Id = this.Id;
			entity.Name = this.Name;
			entity.IsActive = this.IsActive;
			entity.DateCreated = this.DateCreated;

			entity.IsDeleted = this.IsDeleted;
			entity.IsApproved = this.IsApproved;
			entity.LanguageId = this.LanguageId;
			entity.CreatedByUserId = this.CreatedByUserId;
			entity.ModifiedByUserId = this.ModifiedByUserId;
			entity.DateModified = this.DateModified;

			return entity;
		}

		public void FromEntity(TargetGroups entity)
		{
			Id = entity.Id;
			Name = entity.Name;
			IsActive = entity.IsActive;
			DateCreated = entity.DateCreated;

			IsDeleted = entity.IsDeleted;
			IsApproved = entity.IsApproved;
			LanguageId = entity.LanguageId;
			CreatedByUserId = entity.CreatedByUserId;
			ModifiedByUserId = entity.ModifiedByUserId;
			DateModified = entity.DateModified;
		}
	}


}
