using Newtonsoft.Json;
using System;

namespace Models.ViewModels
{
    public class BannersListVM
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("languageId")]
        public int LanguageId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("bannerType")]
        public string BannerType { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("mainImageFileId")]
        public string MainImageFileId { get; set; }
    }
}
