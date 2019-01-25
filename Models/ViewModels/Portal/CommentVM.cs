using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class CommentVM
    {
        [JsonProperty("commentId")]
        public int CommentId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("publish")]
        public DateTime Publish { get; set; }

        [JsonProperty("pageTag")]
        public string PageTag { get; set; }

        [JsonProperty("tookIntoConsideration")]
        [Display(Name = "Коментара е взет предвид")]
        public bool TookIntoConsideration { get; set; }

        [JsonProperty("tookIntoConsiderationReason")]
        [Display(Name = "Причина")]
        public string TookIntoConsiderationReason { get; set; }

        [Display(Name = "Забележка на модератора")]
        [JsonIgnore]
        public string Remark { get; set; }

        [Display(Name = "Статус на коментара")]
        [JsonIgnore]
        public int StateId { get; set; }

        [JsonIgnore]
        public int SourceTypeId { get; set; }

        [JsonIgnore]
        public int SourceId { get; set; }

        [Display(Name = "Коментар към")]
        [JsonIgnore]
        public string SourceItemTitle { get; set; }
    }
}
