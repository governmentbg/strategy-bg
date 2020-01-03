using Newtonsoft.Json;
using System;

namespace Models.ViewModels
{
  public class SiteLogListVM
  {
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("actionId")]
    public int ActionId { get; set; }

    [JsonProperty("moduleName")]
    public string ModuleName { get; set; }

    [JsonProperty("actionName")]
    public string ActionName { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }

    [JsonProperty("createDate")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("userName")]
    public string UserName { get; set; }

    [JsonProperty("editLink")]
    public string EditLink { get; set; }
  }
}
