using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    /// <summary>
    /// Consultation Document element
    /// </summary>
    public class ConsultationDocumentVM :TimelineDocumentViewModel
    {
        public string Content { get; set; }

        public int ConsultationId { get; set; }

        public DateTime OpeningDate { get; set; }

        public DateTime ClosingDate { get; set; }

        public bool IsLastRevision { get; set; }

        public bool CanComment { get; set; }
    }
}
