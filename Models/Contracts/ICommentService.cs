using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Contracts
{
    public interface ICommentService
    {
        IEnumerable<CommentVM> GetComments(int sourceTypeId, int sourceId);

        bool AddComment(PostCommentVM comment, int UserId);
        IQueryable<CommentsListVM> GetCommentsList(int sourceTypeId, int sourceId);

        CommentVM GetComment(int commentId);
        bool SaveItem(CommentVM model, int userId);

        List<SelectListItem> GetStateDDL();
        DocumentExportViewModel GetDocumentForExport(int documentId);
        CommentsExportVM GetCommentsForExport(int consultationId);

        List<SelectListItem> GetUserDDL(int userId);

        IQueryable<CommentsExportListVM> GetCommentsListForExport();
    }
}
