using Models.ViewModels.Portal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels.Consultations
{
    public class CommentsExportListVM
    {

        [JsonProperty("commentId")]
        public int commentId { get; set; }

        [JsonProperty("commentURL")]
        public string sourceItemURL { get; set; }

        [JsonProperty("commentTitle")]
        public string commentTitle { get; set; }


        [JsonIgnore]
        public int SourceItemId { get; set; }

        [Display(Name = "Коментар към")]
        [JsonProperty("sourceItemTitle")]
        public string sourceItemTitle { get; set; }

    
        //[JsonProperty("commentText")]
        //public string commentText { get; set; }

        [JsonProperty("createDate")]
        public string createDate { get; set; }

        [JsonProperty("tookIntoConsideration")]
        [Display(Name = "Коментара е взет предвид")]
        public string TookIntoConsideration { get; set; }

        [JsonProperty("tookIntoConsiderationReason")]
        [Display(Name = "Причина")]
        public string TookIntoConsiderationReason { get; set; }

        [Display(Name = "Забележка на модератора")]
        [JsonIgnore]
        public string Remark { get; set; }

        [Display(Name = "Статус на коментара")]
        [JsonIgnore]
        public string commentState{ get; set; }
      }
}
