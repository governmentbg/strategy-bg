using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class CommentsListVM
    {
        public int Id { get; set; }

        public string ItemTitle { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }
        
        public string State { get; set; }

        public bool? TookIntoConsideration { get; set; }
    }
}
