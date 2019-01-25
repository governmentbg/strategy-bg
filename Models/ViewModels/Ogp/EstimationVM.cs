using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Ogp
{
    public class EstimationVM
    {
        public int Id { get; set; }
        public int EstimationTypeId { get; set; }
        public string EstimationTypeName { get; set; }
        public int ElementId { get; set; }
        public string ElementName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
