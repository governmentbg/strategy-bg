using Newtonsoft.Json;
using System;

namespace Models.ViewModels
{
	public class ChangeProposalsListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("adminRemark")]
		public string AdminRemark { get; set; }

		[JsonProperty("dateCreated")]
		public DateTime DateCreated { get; set; }

		[JsonProperty("isActive")]
		public bool IsActive { get; set; }

		[JsonProperty("isApproved")]
		public bool IsApproved { get; set; }

		[JsonProperty("isRejected")]
		public bool IsRejected { get; set; }

		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }

		[JsonProperty("categoryMasterId")]
		public int CategoryMasterId { get; set; }

		[JsonProperty("districtId")]
		public int DistrictId { get; set; }

		[JsonProperty("municipalityId")]
		public int MunicipalityId { get; set; }
	}
}
