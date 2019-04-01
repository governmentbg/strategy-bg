using Newtonsoft.Json;
using System;

namespace Models.ViewModels
{
  public class NewsCategoriesListVM
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("languageId")]
    public int LanguageId { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }
  }
}
