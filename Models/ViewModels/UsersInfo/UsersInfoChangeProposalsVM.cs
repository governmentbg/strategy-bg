using Newtonsoft.Json;

namespace Models.ViewModels
{
  public class UsersInfoChangeProposalsVM
  {
    [JsonProperty("changeProposals")]
    public int ChangeProposalsId { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
  }
}
