using Newtonsoft.Json;
using System;

namespace Models.ViewModels.CategoriesModels
{
	public class CateroriesListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }

		[JsonProperty("dateCreated")]
		public DateTime DateCreated { get; set; }

		[JsonProperty("isActive")]
		public bool IsActive { get; set; }
	}
}
