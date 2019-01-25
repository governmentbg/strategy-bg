using Newtonsoft.Json;
using System;

namespace Models.ViewModels.LinksModels
{
	public class LinksCateroriesListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("dateCreated")]
		public DateTime DateCreated { get; set; }

		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
	}
}
