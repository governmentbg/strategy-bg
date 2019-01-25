using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class NomenclatureDisplayItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
