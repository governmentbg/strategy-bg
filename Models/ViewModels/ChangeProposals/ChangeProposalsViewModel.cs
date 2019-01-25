using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
	public class ChangeProposalsViewModel
	{
		public ChangeProposalsViewModel()
		{
			IsActive = true;
			IsRejected = false;
			IsApproved = false;
		}
		public int Id { get; set; }

		[Display(Name = "Категория")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		[Display(Name = "Група")]
		public int? CategoryMasterId { get; set; }
		public string CategoryMasterText { get; set; }

		[Display(Name = "Област")]
		public int? DistrictId { get; set; }

		[Display(Name = "Община")]
		public int? MunicipalityId { get; set; }

		[Display(Name = "Заглавие")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		public string Title { get; set; }

		[Display(Name = "Текст")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[UIHint("TextArea")]
		public string Text { get; set; }

		[Display(Name = "Активност")]
		public bool IsActive { get; set; }

		[Display(Name = "Отказанa")]
		public bool IsRejected { get; set; }

		[Display(Name = "Одобренa")]
		public bool IsApproved { get; set; }

		[Display(Name = "Причина за отказ")]
		[UIHint("TextArea")]
		public string AdminRemark { get; set; }

		public int CreatedByUserId { get; set; }
		public int ActualUserId { get; set; }
		public int ModifiedByUserId { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }

		public Context.ChangeProposals ToEntity(Context.ChangeProposals entity = null)
		{
			if (entity == null)
			{
				entity = new Context.ChangeProposals();
			}

			entity.Id = this.Id;
			entity.Title = this.Title;
			entity.Text = this.Text;

			entity.IsActive = this.IsActive;
			entity.IsApproved = this.IsApproved;
			entity.IsRejected = this.IsRejected;

			entity.ActualUserId = ActualUserId;
			entity.DateCreated = this.DateCreated;
			entity.CreatedByUserId = this.CreatedByUserId;
			entity.ModifiedByUserId = this.ModifiedByUserId;
			entity.DateModified = this.DateModified;
			entity.CategoryId = CategoryId;

			return entity;
		}

		public void FromEntity(Context.ChangeProposals entity)
		{
			Id = entity.Id;
			Title = entity.Title;
			Text = entity.Text;
			IsActive = entity.IsActive;
			IsApproved = entity.IsApproved;
			IsRejected = entity.IsRejected;
			ActualUserId = entity.ActualUserId;
			DateCreated = entity.DateCreated;
			CreatedByUserId = entity.CreatedByUserId;
			ModifiedByUserId = entity.ModifiedByUserId;
			DateModified = entity.DateModified;
			CategoryId = entity.CategoryId;
		}
	}


}
