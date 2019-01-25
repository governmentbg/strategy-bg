using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class DocumentExportItemViewModel
    {
        public string DocumentTitle { get; set; }

        public int RevisionNumber { get; set; }

        public IEnumerable<DocumentLinkVM>  AttachedFiles { get; set; }

        public IEnumerable<CommentVM> Comments { get; set; }

        public DocumentExportItemViewModel()
        {
            AttachedFiles = new List<DocumentLinkVM>();

            Comments = new List<CommentVM>();
        }
    }
}
