using Models.Context.PCSubjectsModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.PCSubjectsModels
{
	public class PCSubjectsViewModel
	{
		public PCSubjectsViewModel()
		{
			IsUL = 1;
		}
		public int Id { get; set; }

		[Display(Name = "Вид на лицето")]
		public int IsUL { get; set; }

		[Display(Name = "ЕИК")]
		[StringLength(15, MinimumLength = 9, ErrorMessage = "{0} трябва да е между {2} и {1} символа")]
		public string EIK { get; set; }

		[Display(Name = "Име")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(500, MinimumLength = 1, ErrorMessage = "{0} трябва да е между {2} и {1} символа")]
		public string Name { get; set; }

		[Display(Name = "Възнаграждение за извършените дейности")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		//[DisplayFormat(true, false, "#0.00", true, "Въведете стойност", null)]
		[Range(0, double.MaxValue, ErrorMessage = "{0} трябва да е между {2} и {1}")]
		public decimal PaymentValue { get; set; }

		[Display(Name = "Извършени дейности")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[UIHint("TextAreaWithoutEditor")]
		public string ActivityDescription { get; set; }

		[Display(Name = "Дата на плащане")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		public DateTime DatePayment { get; set; }

		public DateTime DateCreated { get; set; }

		public int CreatedByUserId { get; set; }

		public int ModifiedByUserId { get; set; }

		public DateTime DateModified { get; set; }

		public PCSubjects ToEntity(PCSubjects entity = null)
		{
			if (entity == null)
			{
				entity = new PCSubjects();
			}

			entity.Id = this.Id;
			entity.IsUL = this.IsUL == 1 ? true : false;
			entity.EIK = this.EIK;
			entity.Name = this.Name;
			entity.PaymentValue = this.PaymentValue;
			entity.ActivityDescription = this.ActivityDescription;
			entity.DatePayment = this.DatePayment;
			entity.DateCreated = this.DateCreated;
			entity.CreatedByUserId = this.CreatedByUserId;
			entity.ModifiedByUserId = this.ModifiedByUserId;
			entity.DateModified = this.DateModified;

			return entity;
		}

		public void FromEntity(PCSubjects entity)
		{
			Id = entity.Id;
			IsUL = entity.IsUL ? 1 : 0;
			EIK = entity.EIK;
			Name = entity.Name;
			PaymentValue = entity.PaymentValue;
			ActivityDescription = entity.ActivityDescription;
			DatePayment = entity.DatePayment;
			DateCreated = entity.DateCreated;
			CreatedByUserId = entity.CreatedByUserId;
			ModifiedByUserId = entity.ModifiedByUserId;
			DateModified = entity.DateModified;
		}
	}


}
