using Newtonsoft.Json;
using System;

namespace Models.ViewModels.Questionary
{
	public class QuestionaryListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("openningDate")]
		public DateTime OpenningDate { get; set; }

		[JsonProperty("closingDate")]
		public DateTime? ClosingDate { get; set; }
	}
}
