using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class SearchItemVM
    {
        public string ItemType { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public string ItemUrl { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? LastEdited { get; set; }
        public string dateText
        {
            get
            {
                return LastEdited?.ToString("dd.MM.yyyy, HH:mm");
            }
        }
    }
}
