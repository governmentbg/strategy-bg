using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class PublicConsultationVM
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public string CategoryText { get; set; }
        public string CategoryImagePath { get; set; }
        public string TargetGroup { get; set; }
        public DateTime OpenningDate { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
