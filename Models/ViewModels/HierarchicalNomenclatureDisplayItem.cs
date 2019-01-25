using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class HierarchicalNomenclatureDisplayItem : NomenclatureDisplayItem
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("rootId")]
        public int RootId { get; set; }
    }
}
