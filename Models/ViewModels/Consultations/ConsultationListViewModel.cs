using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Consultations
{
    public class ConsultationListViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("openningDate")]
        public DateTime OpenningDate { get; set; }

        [JsonProperty("closingDate")]
        public DateTime ClosingDate { get; set; }

        [JsonProperty("isApproved")]
        public bool IsApproved { get; set; }
    }
}
