using Newtonsoft.Json;
using System;

namespace Models.ViewModels.PCSubjectsModels
{
	public class PCSubjectsListViewModel
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("isUL")]
		public int IsUL { get; set; }

		[JsonProperty("eik")]
		public string EIK { get; set; }

		[JsonProperty("contractingAuthority")]
    public string ContractingAuthority { get; set; }

    [JsonProperty("paymentValue")]
		public decimal PaymentValue { get; set; }

    [JsonProperty("paymentIncludeVAT")]
    public bool PaymentVaPaymentIncludeVAT { get; set; }

    [JsonProperty("activityDescription")]
		public string ActivityDescription { get; set; }

		[JsonProperty("datePayment")]
		public DateTime DatePayment { get; set; }

    [JsonProperty("filesForDownload")]
    public string FilesForDownload { get; set; }
  }
}
