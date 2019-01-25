using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class DocumentExportViewModel
    {
        public string ConsultationTitle { get; set; }

        public List<DocumentExportItemViewModel> Versions { get; set; }

        public DocumentExportViewModel()
        {
            Versions = new List<DocumentExportItemViewModel>();
        }
    }
}
