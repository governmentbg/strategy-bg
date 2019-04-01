using Newtonsoft.Json;
using System;

namespace Models.ViewModels.LinksModels
{
	public class LinksListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("category")]
		public string CategoryText { get; set; }

		[JsonProperty("dateCreated")]
		public DateTime DateCreated { get; set; }

		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
  }
}
