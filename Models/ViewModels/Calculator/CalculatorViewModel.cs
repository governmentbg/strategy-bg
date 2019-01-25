using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebCommon.Models;

namespace Models.ViewModels.Calculator
{
	public class CalculatorViewModel
	{
		public CalculatorViewModel()
		{
			List<CalculatorActivityVM> CalculatorActivities = new List<CalculatorActivityVM>();
			TotalAdministrativeBurden = 0;
			ActivityNumbers = 1;
		}

		[Display(Name = "Име на административна тежест")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
		[UIHint("TextAreaWithoutEditor")]
		public string AdministrativeBurdenName { get; set; }

		[Display(Name = "Брой дейности")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Range(1, 10, ErrorMessage = "{0} трябва да е между {1} и {2}")]
		public int ActivityNumbers { get; set; }

		[Display(Name = "Общ административен товар за една година")]
		public double TotalAdministrativeBurden { get; set; }

		public List<CalculatorActivityVM> CalculatorActivities { get; set; }
	}
}
