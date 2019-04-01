using Newtonsoft.Json;

namespace Models.ViewModels
{
  public class UsersInfoConsultationsVM
  {
    [JsonProperty("consultationId")]
    public int ConsultationId { get; set; }

    [JsonProperty("publicConsultation")]
    public string PublicConsultation { get; set; }

    [JsonProperty("isCreatedByUser")]
    public bool IsCreatedByUser { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }
  }
}
