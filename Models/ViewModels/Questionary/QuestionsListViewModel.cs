using Newtonsoft.Json;
using System;

namespace Models.ViewModels.Questionary
{
	public class QuestionsListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("questionaryHeaderId")]
		public int QuestionaryHeaderId { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("orderNum")]
		public int? OrderNum { get; set; }
	}
}
