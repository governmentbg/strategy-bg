using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebCommon.Models
{
	public class CalculatorActivityVM
	{
		[Display(Name = "Име на дейност")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[StringLength(255, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
		[UIHint("TextAreaWithoutEditor")]
		public string ActivityName { get; set; }

		[Display(Name = "Брой часове, необходими за извършването на дейността")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Range(1, int.MaxValue, ErrorMessage = "{0} трябва да е между {1} и {2}")]
		public int ActivityHours { get; set; }

		[Display(Name = "Средна месечна работна заплата на човека, който трябва да извърши дейността")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Range(1, double.MaxValue, ErrorMessage = "{0} трябва да е между {1} и {2}")]
		public double AverageSalary { get; set; }

		[Display(Name = "Брой на фирмите, които трябва да извършат дейността")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Range(1, int.MaxValue, ErrorMessage = "{0} трябва да е между {1} и {2}")]
		public int CompanyNumbers { get; set; }

		[Display(Name = "Брой пъти на година, които бизнесът трябва да извърши дейността")]
		[Required(ErrorMessage = "Полето {0} е задължително")]
		[Range(1, int.MaxValue, ErrorMessage = "{0} трябва да е между {1} и {2}")]
		public int ActivityNumbers { get; set; }

		[Display(Name = "Общ административен товар за дейността")]
		public double TotalActivityAdministrativeBurden { get; set; }
	}
}
