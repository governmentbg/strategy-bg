using Models.Context;
using Models.Contracts;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Context.Account;
using Microsoft.Extensions.Logging;
using Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCommon.Extensions;
using Models.Context.Consultations;

namespace Models.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly ILogger logger;

        private readonly IConsultationService consultationService;

        public CommentService(
            MainContext context,
            ILogger<CommentService> _logger,
            IConsultationService _consultationService)
        {
            db = context;
            logger = _logger;
            consultationService = _consultationService;
        }

        public bool AddComment(PostCommentVM comment, int UserId)
        {
            bool result = false;

            Comments entity = new Comments()
            {
                ActualUserId = UserId,
                CommentStateId = GlobalConstants.CommentStatus.Approved,
                CreatedByUserId = UserId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IsChangeAccepted = true,
                ModifiedByUserId = UserId,
                SourceId = comment.SourceId,
                SourceType = comment.SourceTypeId,
                Text = comment.Comment,
                Title = comment.Title,
                SourceAddRef = comment.PageTag
            };

            try
            {
                db.Comments.Add(entity);
                db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding comment");
            }

            return result;
        }

        public IEnumerable<CommentVM> GetComments(int sourceTypeId, int sourceId)
        {
            return db.Comments.Where(c => c.SourceType == sourceTypeId && c.SourceId == sourceId)
                .Join(db.Users, c => c.CreatedByUserId, u => u.Id, (c, u) => new CommentVM()
                {
                    CommentId = c.Id,
                    FullName = u.FullName,
                    Publish = c.DateModified,
                    Text = c.Text,
                    Title = c.Title,
                    UserName = u.UserName,
                    PageTag = c.SourceAddRef,
                    TookIntoConsideration = c.TookIntoConsideration ?? false,
                    TookIntoConsiderationReason = c.TookIntoConsiderationReason,
                    StateId = c.CommentStateId

                })
                .OrderByDescending(c => c.Publish);

        }

        public CommentVM GetComment(int commentId)
        {
            var model = db.Comments.Where(c => c.Id == commentId)
                .Join(db.Users, c => c.CreatedByUserId, u => u.Id, (c, u) => new CommentVM()
                {
                    CommentId = c.Id,
                    FullName = u.FullName,
                    Publish = c.DateModified,
                    Text = c.Text,
                    Title = c.Title,
                    UserName = u.UserName,
                    PageTag = c.SourceAddRef,
                    TookIntoConsideration = c.TookIntoConsideration ?? false,
                    TookIntoConsiderationReason = c.TookIntoConsiderationReason,
                    StateId = c.CommentStateId,
                    Remark = c.ModeratorRemark,
                    SourceId = c.SourceId,
                    SourceTypeId = c.SourceType

                })
                .FirstOrDefault();

            model.SourceItemTitle = All<vSourceItems>(x => x.SourceId == model.SourceId && x.SourceType == model.SourceTypeId).FirstOrDefault()?.Title;

            return model;

        }

        public IQueryable<CommentsListVM> GetCommentsList(int sourceTypeId, int sourceId)
        {
            IQueryable<Comments> comments = null;

            if (sourceTypeId != 0 && sourceId != 0)
            {
                comments = All<Comments>(c => c.SourceType == sourceTypeId && c.SourceId == sourceId)
                    .Include(c => c.State);
            }
            else
            {
                comments = All<Comments>()
                    .Include(c => c.State); ;
            }

            return comments
                .Join(db.vSourceItems, c => new { c.SourceType, c.SourceId }, i => new { i.SourceType, i.SourceId }, (c, i) => new CommentsListVM()
                {
                    Id = c.Id,
                    State = c.State.Name,
                    Title = c.Title,
                    CreateDate = c.DateCreated,
                    TookIntoConsideration = c.TookIntoConsideration,
                    ItemTitle = i.Title
                }).OrderByDescending(c => c.CreateDate);
        }

        public bool SaveItem(CommentVM model, int userId)
        {
            bool result = false;

            try
            {
                var entity = All<Comments>().Find(model.CommentId);

                if (entity != null)
                {
                    entity.CommentStateId = model.StateId;
                    entity.ModeratorRemark = model.Remark;
                    entity.ModifiedByUserId = userId;
                    entity.TookIntoConsideration = model.TookIntoConsideration;
                    entity.TookIntoConsiderationReason = model.TookIntoConsiderationReason;
                }

                db.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }


            return result;
        }

        public List<SelectListItem> GetStateDDL()
        {
            return All<CommentState>()
                .Select(d => new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                })
                .AddAllItem()
                .ToList();
        }

        public DocumentExportViewModel GetDocumentForExport(int documentId)
        {
            DocumentExportViewModel result = new DocumentExportViewModel();
            var doc = All<PublicConsultationDocument>()
                .Where(d => d.Id == documentId)
                .Include(d => d.Consultation)
                .FirstOrDefault();

            if (doc != null)
            {
                result.ConsultationTitle = doc.Consultation.Title;

                var documentVersions = All<PublicConsultationDocument>(d => d.MainId == doc.MainId)
                    .OrderBy(d => d.RevisionNo);

                foreach (var item in documentVersions)
                {
                    DocumentExportItemViewModel version = new DocumentExportItemViewModel();

                    version.DocumentTitle = item.Title;
                    version.RevisionNumber = item.RevisionNo;
                    version.AttachedFiles = consultationService.Portal_GetDocmentFiles(item.Id);
                    version.Comments = GetComments(GlobalConstants.SourceTypes.PublicConsultationDocuments, item.Id)
                        .OrderBy(c => c.Publish);

                    result.Versions.Add(version);
                }
            }

            return result;
        }
    }
}
