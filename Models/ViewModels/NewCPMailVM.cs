using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
  public class NewCPMailVM
  {

    [Required(ErrorMessage = "Полето е задължително")]
    [Display(Name = "Име:")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Полето е задължително")]
    [Display(Name = "Е-Майл:")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Полето е задължително")]
    [StringLength(4096, MinimumLength = 1, ErrorMessage = "Текста трябва да е между {1} и {2} символа")]
    [UIHint("TextArea")]
    [Display(Name = "Съобщение:")]
    public string Message { get; set; }

    [Display(Name = "Относно:")]
    public string About { get; set; }

    [JsonProperty("categoryType")]
    public string CategoryType { get; set; }

    [JsonProperty("categoryName")]
    public string CategoryName { get; set; }

    [JsonProperty("DistrictName")]
    public string DistrictName { get; set; }

    [JsonProperty("MunicipalityName")]
    public string MunicipalityName { get; set; }

    [JsonProperty("CategoryMasterId")]
    public int CategoryMasterId { get; set; }

    [JsonProperty("districtId")]
    public int DistrictId { get; set; }

    [JsonProperty("CategoryId")]
    public int CategoryId { get; set; }

    [JsonProperty("municipalityId")]
    public int MunicipalityId { get; set; }
  }
}
