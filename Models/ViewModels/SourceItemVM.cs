using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class SourceItemVM
    {
        public int SourceType { get; set; }
        public int SourceId { get; set; }
        public string SourceTypeName { get; set; }
        public string SourceItemName { get; set; }
        public string BackUrl { get; set; }
    }
}
