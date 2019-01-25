using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.AboutUs
{
	public class AboutUsViewModel
	{
		public AboutUsViewModel()
		{
			IsActive = true;
			IsDeleted = false;
			IsApproved = false;
			IsAdmin = false;
			LanguageId = GlobalConstants.LangBG;
			Rank = 0;
		}
		public int Id { get; set; }

		[Display(Name = "Имена")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(256, MinimumLength = 1, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
		public string FirstName { get; set; }

		[Display(Name = "Институция")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(256, MinimumLength = 1, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
		public string LastName { get; set; }

		[Display(Name = "Телефон")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(256, MinimumLength = 1, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
		public string Phone { get; set; }

		[Display(Name = "Е-Майл")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(256, MinimumLength = 1, ErrorMessage = "Полето {0} трябва да е между {2} и {1} символа")]
		public string Email { get; set; }

		[Display(Name = "Активност")]
		public bool IsActive { get; set; }

		[Display(Name = "Изтрит")]
		public bool IsDeleted { get; set; }

		[Display(Name = "Одобренa")]
		public bool IsApproved { get; set; }

		[Display(Name = "Администратор")]
		public bool IsAdmin { get; set; }

		public int CreatedByUserId { get; set; }
		public int ActualUserId { get; set; }
		public int ModifiedByUserId { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }

		[Display(Name = "LanguageId")]
		public int LanguageId { get; set; }

		[Display(Name = "Rank")]
		public int Rank { get; set; }

		public Context.AboutUs ToEntity(Context.AboutUs entity = null)
		{
			if (entity == null)
			{
				entity = new Context.AboutUs();
			}

			entity.Id = this.Id;
			entity.FirstName = this.FirstName;
			entity.LastName = this.LastName;
			entity.Phone = this.Phone;
			entity.Email = this.Email;

			entity.IsActive = this.IsActive;
			entity.IsApproved = this.IsApproved;
			entity.IsDeleted = this.IsDeleted;
			entity.IsAdmin = this.IsAdmin;

			entity.Rank = this.Rank;

			entity.DateCreated = this.DateCreated;
			entity.CreatedByUserId = this.CreatedByUserId;
			entity.ModifiedByUserId = this.ModifiedByUserId;
			entity.DateModified = this.DateModified;

			return entity;
		}

		public void FromEntity(Context.AboutUs entity)
		{
			Id = entity.Id;
			FirstName = entity.FirstName;
			LastName = entity.LastName;
			Phone = entity.Phone;
			Email = entity.Email;

			IsActive = entity.IsActive;
			IsApproved = entity.IsApproved;
			IsDeleted = entity.IsDeleted;
			IsAdmin = entity.IsAdmin;

			Rank = entity.Rank;

			DateCreated = entity.DateCreated;
			CreatedByUserId = entity.CreatedByUserId;
			ModifiedByUserId = entity.ModifiedByUserId;
			DateModified = entity.DateModified;
		}
	}


}
