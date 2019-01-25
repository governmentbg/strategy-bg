using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels.Portal
{
    public class TimelineDocumentViewModel
    {
        /// <summary>
        /// Document Identifier
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Document title for Timeline
        /// </summary>
        public string DocumentTitle { get; set; }

        /// <summary>
        /// Version number
        /// </summary>
        public int RevisionNumber { get; set; }

        /// <summary>
        /// Creation date of the revision
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Currently selected revision
        /// </summary>
        public bool IsCurrent { get; set; }

        public bool IsLastRevision { get; set; }

        /// <summary>
        /// Number of comments
        /// </summary>
        public int CommentsCount { get; set; }

        public List<DocumentLinkVM> AttachedFiles { get; set; }

        public int DocumentTypeId { get; set; }

        public string DocumentType { get; set; }

        public TimelineDocumentViewModel()
        {
            AttachedFiles = new List<DocumentLinkVM>();
        }
    }
}
