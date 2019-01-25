using Models.Context.Questionary;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Questionary
{
	public class QuestionChartResultViewModel
	{
		public string ColumnName = "";
		public decimal Value = 0;

		public QuestionChartResultViewModel(string columnName, decimal value)
		{
			ColumnName = columnName;
			Value = value;
		}
	}


}
