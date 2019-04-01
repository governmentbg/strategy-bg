using FileCDN.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Account;
using Models.Context.Consultations;
using Models.Contracts;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebCommon.Extensions;

namespace Models.Services
{
    public class ConsultationService : BaseService, IConsultationService
    {
        private readonly ILogger logger;

    private readonly IUrlHelper urlHelper;

    public ConsultationService(
            MainContext context,
            ILogger<ConsultationService> _logger,
            IUrlHelper _urlHelper)
    {
      this.db = context;
      logger = _logger;
      urlHelper = _urlHelper;
    }

    public IQueryable<ConsultationListViewModel> GetConsultations()
        {
            return this.All<PublicConsultation>()
                .Select(c => new ConsultationListViewModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    OpenningDate = c.OpenningDate,
                    ClosingDate = c.ClosingDate,
                    IsApproved = c.IsApproved
                });
        }

        public ConsultationViewModel GetConsultation(int id)
        {
            var entity = this.All<PublicConsultation>()
                            .Include(x => x.Category)
                            .Include(x => x.InstitutionType)
                            .Include(x => x.LinksCategory)
                            .ThenInclude(l => l.Links)
                            .Where(x => x.Id == id).FirstOrDefault();
            var model = new ConsultationViewModel();
            model.FromEntity(entity);

            model.ParentCategoryName = this.All<Category>()
                .Find(model.ParentCategoryId)
                ?.CategoryName;

            model.SectionName = this.All<Category>()
                .Find(model.SectionId)
                ?.CategoryName;

            return model;
        }

        public int GetInstitutionTypeId(int userId)
        {
            return All<Users>(u => u.Id == userId)
                .FirstOrDefault()?.InstitutionTypeId ?? -1;
        }

        public IEnumerable<SelectListItem> GetTargetGroupsDDL()
        {
            return this.All<TargetGroups>()
                .Where(g => g.IsActive)
                .Where(g => g.IsApproved)
                .Where(g => !g.IsDeleted)
                .OrderBy(g => g.Name)
                .Select(g => new SelectListItem()
                {
                    Text = g.Name,
                    Value = g.Id.ToString()
                })
                .ToList()
                .Prepend(new SelectListItem()
                {
                    Text = "Изберете",
                    Value = "-1"
                })
                .ToList();

        }

        public bool SaveConsultation(ConsultationViewModel model, int userId)
        {
            var result = false;
            PublicConsultation entity = null;

            try
            {
                if (model.Id > 0)
                {
                    entity = All<PublicConsultation>()
                      .Find(model.Id);

                    if (entity != null)
                    {
                        if (model.OpenningDate < entity.DateCreated)
                        {
                            throw new ApplicationException("Openning date can not be before Date Created");
                        }

                        entity = model.ToEntity(entity);
                        entity.ModifiedByUserId = userId;
                        entity.DateModified = DateTime.Now;
                    }
                }
                else
                {
                    entity = model.ToEntity();
                    entity.LanguageId = GlobalConstants.Language.Bulgarian;
                    entity.CreatedByUserId = userId;
                    entity.DateCreated = DateTime.Now;
                    entity.ModifiedByUserId = userId;
                    entity.DateModified = DateTime.Now;

                    All<PublicConsultation>().Add(entity);
                }

                db.SaveChanges();
                model.Id = entity.Id;

                result = true;
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ApplicationException))
                {
                    throw (ApplicationException)ex;
                }

                logger.LogError(ex, "Save consultation failed");
            }

            return result;
        }

        public IQueryable<PublicConsultationVM> Portal_List(int langId = GlobalConstants.LangBG, int? validMode = null, int? docType = null)
        {
            Expression<Func<PublicConsultation, bool>> whereValid = x => true;
            switch (validMode)
            {
                case GlobalConstants.ValidStates.Active:
                    whereValid = x => x.ClosingDate >= DateTime.Now;
                    break;
                case GlobalConstants.ValidStates.Completed:
                    whereValid = x => x.ClosingDate < DateTime.Now;
                    break;
            }

            Expression<Func<PublicConsultation, bool>> docTypeFilter = x => true;

            if (docType != null)
            {
                docTypeFilter = x => x.Documents != null && x.Documents.Count > 0 && x.Documents.Select(d => d.DocumentTypeId).Contains(docType);
            }

            return (from pc in All<PublicConsultation>()
                        .Where(g => g.IsActive)
                        .Where(g => g.IsApproved)
                        .Where(g => !g.IsDeleted)
                        .Where(g => g.LanguageId == langId)
                        .Where(whereValid)
                        .Where(docTypeFilter)
                        .Include(x => x.Category)
                        //.Include(x => x.TargetGroup)
                        .OrderByDescending(x => x.OpenningDate)
                        .Select(x => new PublicConsultationVM()
                        {
                            Id = x.Id,
                            Title = x.Title,
                            CategoryText = x.Category.CategoryName,
                            CategoryId = x.Category.Id,
                            CategoryParentId = x.Category.ParentId,
                            CategorySectionId = x.Category.SectionId,
                            CategoryImagePath = (x.Category.ImagePath == null || x.Category.ImagePath == "") ? "icon_default.png" : x.Category.ImagePath,
                            OpenningDate = x.OpenningDate,
                            ClosingDate = x.ClosingDate
                        })
                    join c in All<v_Comments_PublicConsultations>() on pc.Id equals c.PublicConsultationId
                    select new PublicConsultationVM()
                    {
                        Id = pc.Id,
                        Title = pc.Title,
                        CategoryText = pc.CategoryText,
                        CategoryId = pc.CategoryId,
                        CategoryParentId = pc.CategoryParentId,
                        CategorySectionId = pc.CategorySectionId,
                        CategoryImagePath = pc.CategoryImagePath,
                        OpenningDate = pc.OpenningDate,
                        ClosingDate = pc.ClosingDate,
                        CommentsCount = c.CommentsCount
                    }
                     )
                    .AsQueryable();
        }

        public IEnumerable<TimelineDocumentViewModel> Portal_GetDocumentsList(int id)
        {
            var documents = All<PublicConsultationDocument>(x => x.PublicConsultationId == id)
                .Include(d => d.DocumentType)
                .OrderByDescending(d => d.DateCreated)
                .Select(d => new TimelineDocumentViewModel()
                {
                    DateCreated = d.DateCreated,
                    DocumentId = d.Id,
                    DocumentTitle = d.Title,
                    IsCurrent = false,
                    RevisionNumber = d.RevisionNo,
                    DocumentTypeId = d.DocumentTypeId ?? 0,
                    DocumentType = d.DocumentType.Label,
                    IsLastRevision = d.IsLastRevision
                }).ToList();

            int[] documentIds = documents
                .Select(d => d.DocumentId)
                .ToArray();

            var comments = All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultationDocuments &&
                        documentIds.Contains(x.SourceId) &&
                        x.CommentStateId == GlobalConstants.CommentStatus.Approved)
                        .ToList();

            foreach (var item in documents)
            {
                item.AttachedFiles = Portal_GetDocmentFiles(item.DocumentId)
                    .ToList();
                item.CommentsCount = comments.Where(c => c.SourceId == item.DocumentId).Count();
            }

            return documents;
        }

        public IQueryable<CommentVM> Portal_GetComments(int id)
        {
            var version = All<PublicConsultationDocument>(x => x.PublicConsultationId == id && x.IsLastRevision);

            return Internal_GetComments(version);
        }

        public ConsultationDocumentVM GetConsultationDocument(int documentId)
        {
            ConsultationDocumentVM result = new ConsultationDocumentVM();
            var document = db.PublicConsultationDocuments
                .Where(d => d.Id == documentId)
                .Include(d => d.Consultation)
                .FirstOrDefault();

            if (document != null)
            {
                result = new ConsultationDocumentVM()
                {
                    AttachedFiles = Portal_GetDocmentFiles(document.Id).ToList(),
                    Content = document.DocumentContent,
                    DateCreated = document.DateCreated,
                    DocumentId = document.Id,
                    DocumentTitle = document.Title,
                    RevisionNumber = document.RevisionNo,
                    ConsultationId = document.PublicConsultationId,
                    OpeningDate = document.Consultation.OpenningDate,
                    ClosingDate = document.Consultation.ClosingDate,
                    IsLastRevision = document.IsLastRevision,
                    CanComment = document.CanComment
                };
            }

            return result;
        }

        public IEnumerable<CommentVM> Portal_GetDocumentComments(int documentId)
        {
            var document = All<PublicConsultationDocument>(x => x.Id == documentId);

            return Internal_GetComments(document);
        }



        private IQueryable<ConsultationDocumentVM> Internal_FileList(IQueryable<PublicConsultationDocument> version)
        {
            return (from pcd in version
                    join uf in All<FilesCDNUsed>(x => x.source_type == GlobalConstants.SourceTypes.PublicConsultationDocuments) on pcd.Id equals uf.source_id
                    join f in All<FileCdn>() on uf.cdn_file_id equals f.Id
                    select new ConsultationDocumentVM
                    {
                        DocumentId = pcd.Id,
                        DocumentTitle = pcd.Title,
                        DateCreated = pcd.DateCreated,
                        IsCurrent = false,
                        RevisionNumber = pcd.RevisionNo,
                        CommentsCount = pcd.Comments.Count
                    }).AsQueryable();
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
                        Title = pc.Title,
                        Text = pc.Text,
                        UserName = us.UserName,
                        FullName = us.FullName,
                        Publish = pc.DateModified
                    }).AsQueryable().OrderByDescending(x => x.Publish);
        }

        public IQueryable<DocumentListViewModel> GetDocumentList(int consultationId)
        {
            return All<PublicConsultationDocument>()
                .Include(x => x.DocumentType)
                .Where(d => d.PublicConsultationId == consultationId)
                .Where(d => d.IsLastRevision)
                .Select(d => new DocumentListViewModel()
                {
                    Id = d.Id,
                    Title = d.Title,
                    TypeName = (d.DocumentType != null) ? d.DocumentType.Label : ""
                });
        }

        public IEnumerable<DocumentLinkVM> Portal_GetDocmentFiles(int documentId)
        {
            return All<FilesCDNUsed>(f => f.source_type == GlobalConstants.SourceTypes.PublicConsultationDocuments && f.source_id == documentId)
                        .Join(All<FileCdn>(), uf => uf.cdn_file_id, cf => cf.Id, (uf, cf) => new DocumentLinkVM()
                        {
                            DocumentId = uf.id,
                            FileId = cf.Id,
                            FileName = cf.FileName,
                            FileTitle = cf.FileTitle
                        }).ToList();
        }

        public IEnumerable<TimelineDocumentViewModel> GetDocumentVersions(int id)
        {
            int mainId = db.PublicConsultationDocuments.Find(id)?.MainId ?? 0;

            var documentVersions = All<PublicConsultationDocument>(d => d.MainId == mainId)
                .Select(d => new TimelineDocumentViewModel()
                {
                    DateCreated = d.DateCreated,
                    DocumentId = d.Id,
                    DocumentTitle = d.Title,
                    IsCurrent = d.Id == id,
                    RevisionNumber = d.RevisionNo
                })
                .OrderByDescending(d => d.DateCreated)
                .ToList();

            int[] documentIds = documentVersions
                .Select(d => d.DocumentId)
                .ToArray();

            var comments = All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultationDocuments &&
                        documentIds.Contains(x.SourceId) &&
                        x.CommentStateId == GlobalConstants.CommentStatus.Approved)
                        .ToList();

            foreach (var version in documentVersions)
            {
                version.CommentsCount = comments
                    .Where(c => c.SourceId == version.DocumentId)
                    .Count();
            }

            return documentVersions;
        }

        public DocumentViewModel GetDocument(int documentId)
        {
            return All<PublicConsultationDocument>(d => d.Id == documentId)
                .Select(d => new DocumentViewModel()
                {
                    Id = d.Id,
                    MainId = d.MainId,
                    ConsultationId = d.PublicConsultationId,
                    Content = d.DocumentContent,
                    IsFinal = d.IsFinal,
                    Revision = d.RevisionNo,
                    Title = d.Title,
                    CanComment = d.CanComment,
                    DocumentTypeId = d.DocumentTypeId ?? 0
                })
                .FirstOrDefault();
        }

        public bool SaveDocument(DocumentViewModel model, int userId)
        {
            bool result = false;

            try
            {
                if (model.Id != 0)
                {
                    EditDocument(model, userId);
                    result = true;
                }
                else if (model.MainId == 0)
                {
                    AddNewDocument(model, userId);
                    result = true;
                }
                else
                {
                    AddVersion(model, userId);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return result;
        }

        private void AddVersion(DocumentViewModel model, int userId)
        {
            var lastRevision = All<PublicConsultationDocument>(d => d.MainId == model.MainId && d.IsLastRevision)
                .FirstOrDefault();

            lastRevision.IsLastRevision = false;

            PublicConsultationDocument document = new PublicConsultationDocument()
            {
                ActualUserId = userId,
                CreatedByUserId = userId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                DocumentContent = model.Content,
                IsFinal = model.IsFinal,
                IsLastRevision = true,
                MainId = model.MainId,
                ModifiedByUserId = userId,
                PublicConsultationId = model.ConsultationId,
                RevisionNo = lastRevision.RevisionNo + 1,
                Title = model.Title,
                CanComment = model.CanComment,
                DocumentTypeId = model.DocumentTypeId
            };

            db.PublicConsultationDocuments.Add(document);
            db.SaveChanges();

            model.Id = document.Id;
            model.Revision = document.RevisionNo;
        }

        private void EditDocument(DocumentViewModel model, int userId)
        {
            var entity = All<PublicConsultationDocument>().Find(model.Id);

            if (entity != null)
            {
                entity.DateModified = DateTime.Now;
                entity.DocumentContent = model.Content;
                entity.IsFinal = model.IsFinal;
                entity.ModifiedByUserId = userId;
                entity.Title = model.Title;
                entity.DocumentTypeId = model.DocumentTypeId;
                entity.CanComment = model.CanComment;

                db.SaveChanges();
            }
        }

        private void AddNewDocument(DocumentViewModel model, int userId)
        {
            PublicConsultationDocument document = new PublicConsultationDocument()
            {
                ActualUserId = userId,
                CreatedByUserId = userId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                DocumentContent = model.Content,
                IsFinal = model.IsFinal,
                IsLastRevision = true,
                ModifiedByUserId = userId,
                PublicConsultationId = model.ConsultationId,
                RevisionNo = 1,
                Title = model.Title,
                CanComment = model.CanComment,
                DocumentTypeId = model.DocumentTypeId
            };

            db.PublicConsultationDocuments.Add(document);
            db.SaveChanges();

            document.MainId = document.Id;
            model.Id = document.Id;
            model.MainId = document.Id;
            model.Revision = document.RevisionNo;

            db.SaveChanges();
        }

        public string GetConsultationTitle(int consultationId)
        {
            return All<PublicConsultation>()
                .Find(consultationId)
                ?.Title;
        }

        public IQueryable<VersionListViewModel> GetVersionList(int documentId)
        {
            int mainId = All<PublicConsultationDocument>().Find(documentId)?.MainId ?? 0;

            return All<PublicConsultationDocument>(d => d.MainId == mainId)
                .Select(d => new VersionListViewModel()
                {
                    Id = d.Id,
                    Revision = d.RevisionNo,
                    CreateDate = d.DateCreated
                })
                .OrderByDescending(v => v.CreateDate);
        }

        public DocumentViewModel CreateVersion(int documentId)
        {
            return All<PublicConsultationDocument>(d => d.Id == documentId)
                .Select(d => new DocumentViewModel()
                {
                    ConsultationId = d.PublicConsultationId,
                    Content = d.DocumentContent,
                    MainId = d.MainId,
                    Title = d.Title,
                    DocumentTypeId = d.DocumentTypeId ?? 0
                })
                .FirstOrDefault();
        }

        public List<SelectListItem> GetSections(string content)
        {
            var allText = "Няма зададени отметки";
            if (string.IsNullOrEmpty(content))
            {
                return GlobalConstants.EmptyComboList.AddAllItem(allText, null).ToList();
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(content);
            var spanList = doc.DocumentNode.Descendants("span");
            var ddl = spanList.Where(x => x.HasClass("page-tag"))
                        .Select(x => x.Attr("id"))
                        .Select(x => new SelectListItem
                        {
                            Text = x,
                            Value = x
                        }).ToList();


            if (ddl.Count() > 0)
            {
                allText = "Изберете отметка";
            }


            return ddl.AddAllItem(allText, null).ToList();
        }

        public List<SelectListItem> GetDocumentTypesDDL()
        {
            return All<DocumentType>(d => d.IsActive)
                .Select(d => new SelectListItem()
                {
                    Text = d.Label,
                    Value = d.Id.ToString()
                })
                .AddAllItem()
                .ToList();
        }

        public int GetConsultationCommentsCount(int consultationId)
        {
            int[] documentIds = All<PublicConsultationDocument>(d => d.PublicConsultationId == consultationId)
                .Select(d => d.Id)
                .ToArray();

            return All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultation && x.SourceId == consultationId &&
                     x.CommentStateId == GlobalConstants.CommentStatus.Approved)
                     .Union(All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultationDocuments && documentIds.Contains(x.SourceId) &&
                     x.CommentStateId == GlobalConstants.CommentStatus.Approved))
                     .Count();

        }
    public IQueryable<ConsultationsExportListVM> GetConsultationsListForExport()
    {
      var _Url = urlHelper.Action("View", "PublicConsultation", new { area = "" });

      var result = (from pub_cons in All<PublicConsultation>()
                               .Where(g => g.IsActive)
                               .Where(g => g.IsApproved)
                               .Where(g => !g.IsDeleted)
                               .Include(x => x.Category)
                               .OrderByDescending(x => x.OpenningDate)
                    join docs in All<PublicConsultationDocument>() on pub_cons.Id equals docs.PublicConsultationId
                    select new ConsultationsExportListVM()
                    {
                      Id = pub_cons.Id,
                      Title = pub_cons.Title,
                      CategoryId = pub_cons.Category.Id,
                      CategoryName = pub_cons.Category.CategoryName,
                      CategoryParentId = pub_cons.Category.ParentId,
                      CategoryParentName = pub_cons.Category.CategoryName,
                      CategorySectionId = pub_cons.Category.SectionId,
                      CategorySectionName = pub_cons.Category.CategoryName,
                      DocumentTypeId = (docs.DocumentTypeId == null ? 0 : docs.DocumentTypeId.Value),
                      DocumentType = docs.DocumentType.Label,
                      OpenningDate = pub_cons.OpenningDate,
                      ClosingDate = pub_cons.ClosingDate,
                      InstututionType = (pub_cons.InstitutionType.InstitutionTypeName == null ? "" : pub_cons.InstitutionType.InstitutionTypeName),
                      InstututionTypeId = (pub_cons.InstitutionType.Id == null ? 0 : pub_cons.InstitutionType.Id),
                      CommentsCount = pub_cons.Comments.Count,
                      ShortTermReason = pub_cons.ShortTermReason,
                      // URL = new Uri($"{Url}/{pub_cons.Id}").ToString()
                      URL = _Url.ToString() + "/" + pub_cons.Id.ToString()
                    })
                  .AsQueryable();
      return result;
    }
  }

}