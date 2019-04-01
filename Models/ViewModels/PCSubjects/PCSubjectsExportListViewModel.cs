using Newtonsoft.Json;
using System;

namespace Models.ViewModels.PCSubjectsModels
{
	public class PCSubjectsExportListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("eik")]
		public string EIK { get; set; }

		[JsonProperty("contractingAuthority")]
    public string ContractingAuthority { get; set; }

    [JsonProperty("paymentValue")]
		public decimal PaymentValue { get; set; }

    [JsonProperty("paymentIncludeVAT")]
    public string PaymentVaPaymentIncludeVAT { get; set; }

    [JsonProperty("activityDescription")]
		public string ActivityDescription { get; set; }

		[JsonProperty("datePayment")]
		public string DatePayment { get; set; }

    [JsonProperty("filesForDownload")]
    public string FilesForDownload { get; set; }
  }
}
