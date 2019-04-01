using Models.ViewModels.Portal;
using System.Collections.Generic;

namespace Models.ViewModels.Consultations
{
    public class CommentsExportVM
    {
        public string ConsultationTitle { get; set; }

        public string Summary { get; set; }

        public IEnumerable<CommentVM> Comments { get; set; }

        public CommentsExportVM()
        {
            Comments = new List<CommentVM>();
        }
    }
}
