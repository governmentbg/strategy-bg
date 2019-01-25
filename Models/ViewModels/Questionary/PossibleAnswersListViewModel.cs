using Newtonsoft.Json;

namespace Models.ViewModels.Questionary
{
	public class PossibleAnswersListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("questionaryHeaderId")]
		public int QuestionaryHeaderId { get; set; }

		[JsonProperty("answer")]
		public string Answer { get; set; }
	}
}
