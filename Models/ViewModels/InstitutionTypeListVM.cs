using Newtonsoft.Json;

namespace Models.ViewModels
{
  public class InstitutionTypeListVM
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("languageId")]
    public int LanguageId { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
  }
}
