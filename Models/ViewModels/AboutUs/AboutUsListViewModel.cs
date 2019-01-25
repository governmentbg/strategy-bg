using Newtonsoft.Json;
using System;

namespace Models.ViewModels.AboutUs
{
	public class AboutUsListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("firstName")]
		public string FirstName { get; set; }

		[JsonProperty("lastName")]
		public string LastName { get; set; }

		[JsonProperty("dateCreated")]
		public DateTime DateCreated { get; set; }

		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
	}
}
