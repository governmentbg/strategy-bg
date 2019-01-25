using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class StrategicDocumentVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int CategoryId { get; set; }
        public string CategoryText { get; set; }
        public string CategoryImagePath { get; set; }
        public string TargetGroup { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime ClosingDate { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
