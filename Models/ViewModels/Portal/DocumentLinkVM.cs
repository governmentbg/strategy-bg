using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class DocumentLinkVM
    {
        public int DocumentId { get; set; }
        public string DocumentTitle { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public int SourceType { get; set; }
    }
}
