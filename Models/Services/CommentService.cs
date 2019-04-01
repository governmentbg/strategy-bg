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
using Models.ViewModels.Consultations;
using Microsoft.AspNetCore.Mvc;

namespace Models.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly ILogger logger;
    private readonly IUrlHelper urlHelper;

    private readonly IConsultationService consultationService;

        public CommentService(
            MainContext context,
            ILogger<CommentService> _logger,
            IConsultationService _consultationService,
            IUrlHelper _urlHelper)
        {
            db = context;
            logger = _logger;
            consultationService = _consultationService;
      urlHelper = _urlHelper;
        }

        public bool AddComment(PostCommentVM comment, int UserId)
        {
            bool result = false;

            Comments entity = new Comments()
            {
                ActualUserId = UserId,
                CommentStateId = GlobalConstants.CommentStatus.Approved,
                CreatedByUserId = comment.UserIdentityId != 0 ? comment.UserIdentityId : UserId,
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
            if (sourceTypeId == GlobalConstants.SourceTypes.PublicConsultation)
            {
                return Portal_GetConsultationComments(sourceId);
            }

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

    public IQueryable<CommentsExportListVM> GetCommentsListForExport()
    {
      IQueryable<Comments> comments = null;
      var _Url = urlHelper.Action("View", "PublicConsultation", new { area = "" });
      comments = All<Comments>()
            .Include(c => c.State); 
      return comments
          .Join(db.vSourceItems, c => new { c.SourceType, c.SourceId }, i => new { i.SourceType, i.SourceId }, (c, i) => new CommentsExportListVM()
          {
            commentId = c.Id,
            //sourceItemURL = new Uri($"{Url}/{i.SourceId}").ToString(),
            sourceItemURL = _Url.ToString() + "/" + i.SourceId.ToString(),
            commentTitle = c.Title,
            SourceItemId = i.SourceId,
            sourceItemTitle = i.Title,
            commentState = c.State.Name,
            //commentText = c.Text,
            createDate = c.DateCreated.ToString(),
            Remark = c.ModeratorRemark,
            TookIntoConsideration = (c.TookIntoConsideration==null)? "Неразгледан" : (c.TookIntoConsideration==true) ? "Взет предвид" : "Не взет предвид",
            TookIntoConsiderationReason = c.TookIntoConsiderationReason
          }).OrderByDescending(c => c.createDate);
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

        public CommentsExportVM GetCommentsForExport(int consultationId)
        {
            CommentsExportVM model = new CommentsExportVM();
            var consultation = All<PublicConsultation>(c => c.Id == consultationId)
                .FirstOrDefault();

            if (consultation != null)
            {
                model.Comments = Portal_GetConsultationComments(consultationId);
                model.ConsultationTitle = consultation.Title;
                model.Summary = consultation.Summary;
            }

            return model;
        }

        public List<SelectListItem> GetUserDDL(int userId)
        {
            var groupUserIds = All<UsersInGroups>()
                .Where(x => x.UserId == userId)
                .Select(x => x.GroupUserId)
                .ToArray();
            
            return All<Users>(u => u.Id == userId)
                .Union(All<Users>(u => groupUserIds.Contains(u.Id)))
                .Select(u => new SelectListItem()
                {
                    Text = u.FullName,
                    Value = u.Id.ToString()
                }).ToList();
        }

        private IEnumerable<CommentVM> Portal_GetConsultationComments(int consultationId)
        {
            var comments = (from pc in All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultation && x.SourceId == consultationId &&
                     x.CommentStateId == GlobalConstants.CommentStatus.Approved)
                            join us in All<Users>() on pc.CreatedByUserId equals us.Id
                            select new CommentVM
                            {
                                CommentId = pc.Id,
                                FullName = us.FullName,
                                Publish = pc.DateModified,
                                Text = pc.Text,
                                Title = pc.Title,
                                UserName = us.UserName,
                                PageTag = String.Empty, //pc.SourceAddRef,
                                TookIntoConsideration = pc.TookIntoConsideration ?? false,
                                TookIntoConsiderationReason = pc.TookIntoConsiderationReason,
                                StateId = pc.CommentStateId
                            });

            var documents = All<PublicConsultationDocument>(x => x.PublicConsultationId == consultationId);

            var documentsComments = Internal_GetComments(documents);

            return comments.Union(documentsComments)
                .OrderByDescending(c => c.Publish);
        }

        private IQueryable<CommentVM> Internal_GetComments(IQueryable<PublicConsultationDocument> document)
        {
            return (from pcd in document
                    join pc in All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultationDocuments &&
                        x.CommentStateId == GlobalConstants.CommentStatus.Approved) on pcd.Id equals pc.SourceId
                    join us in All<Users>() on pc.CreatedByUserId equals us.Id
                    select new CommentVM
                    {
                        CommentId = pc.Id,
                        FullName = us.FullName,
                        Publish = pc.DateModified,
                        Text = pc.Text,
                        Title = pc.Title,
                        UserName = us.UserName,
                        PageTag = String.Empty, //pc.SourceAddRef,
                        TookIntoConsideration = pc.TookIntoConsideration ?? false,
                        TookIntoConsiderationReason = pc.TookIntoConsiderationReason,
                        StateId = pc.CommentStateId
                    }).AsQueryable().OrderByDescending(x => x.Publish);
        }
    }
}
