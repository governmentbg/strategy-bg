using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
  public class UsersInfoVM
  {
    [JsonProperty("userId")]
    public int UserId { get; set; }

    [JsonProperty("fullName")]
    public string FullName { get; set; }

    [JsonProperty("categories")]
    public string UserCategories { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("userType")]
    public string UserType { get; set; }
  }
}
