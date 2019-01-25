using FileCDN.Models.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Consultations;
using Models.Context.Legacy;
using Models.Contracts;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCommon.Services;

namespace Models.Services
{
    public class StrategicDocumentsService : BaseService, IStrategicDocumentsService
    {
        private readonly ILogger logger;
    private readonly IUserContext userContext;
    public StrategicDocumentsService(
            MainContext context,
            ILogger<ConsultationService> _logger,
              IUserContext _userContext)
        {
            this.db = context;
            logger = _logger;
      userContext = _userContext;
        }

        public StrategicDocuments GetStrategicDocument(int id)
        {
            var strDoc= All<StrategicDocuments>()
                        .Include(x => x.Category)
                        .Where(x => x.Id == id)
                        .FirstOrDefault();
      if (strDoc.Category.ParentId==GlobalConstants.Category.Type_National)
      {
        strDoc.CategoryMasterId = GlobalConstants.Category.Type_National;
      }
      
      else
      {
        strDoc.CategoryMasterId = GlobalConstants.Category.Type_District;
      }


      if (strDoc.Category.ParentId==GlobalConstants.Category.Type_District)
      {
        strDoc.DistrictId = strDoc.CategoryId;
      }
      if (strDoc.Category.ParentId == GlobalConstants.Category.Type_Municipal)
      {
        strDoc.DistrictId = strDoc.Category.SectionId;
      
      }
      return strDoc;
        }

        public IQueryable<DocumentLinkVM> Portal_GetFileList(int id)
        {
            return (from uf in All<FilesCDNUsed>(x => x.source_type == GlobalConstants.SourceTypes.PublicConsultationDocuments && x.source_id == id)
                    join f in All<FileCdn>() on uf.cdn_file_id equals f.Id
                    select new DocumentLinkVM
                    {
                        DocumentId = uf.id,
                        DocumentTitle = f.FileTitle,
                        FileName = f.FileName,
                        FileId = f.Id
                    }).AsQueryable();
        }

        public IQueryable<StrategicDocumentVM> Portal_List()
        {
            return All<StrategicDocuments>()
                        .Where(g => g.IsActive)
                        .Where(g => g.IsApproved)
                        .Where(g => !g.IsDeleted)
                        .Where(g => g.LanguageId == GlobalConstants.LangBG)
                        .Include(x => x.Category)
                        .OrderByDescending(x => x.DateCreated)
                        .Select(x => new StrategicDocumentVM()
                        {
                            Id = x.Id,
                            Title = x.Title,
                            CategoryId = x.CategoryId,
                            CategoryText = x.Category.CategoryName,
                            CategoryImagePath = x.Category.ImagePath ?? "icon_default.png",
                            ValidTo = x.ValidTo,
                            CreateDate = x.DateCreated
                        })
                        .AsQueryable();
        }
        public IQueryable<DocumentLinkVM> Document_Comments(int id)
        {
            return (from uf in All<FilesCDNUsed>(x => x.source_type == GlobalConstants.SourceTypes.PublicConsultationDocuments && x.source_id == id)
                    join f in All<FileCdn>() on uf.cdn_file_id equals f.Id
                    select new DocumentLinkVM
                    {
                        DocumentId = uf.id,
                        DocumentTitle = f.FileTitle,
                        FileName = f.FileName,
                        FileId = f.Id
                    }).AsQueryable();
        }
        public StrategicDocumentPDFVM GetPDFModel(int mainCategoryId)
        {
            StrategicDocumentPDFVM PDFModel = new StrategicDocumentPDFVM();
            if (mainCategoryId == 1)
            {
                PDFModel.Title = "Стратегически документи на национално ниво";
            }
            else
            {
                PDFModel.Title = "Стратегически документи на областно и общинско ниво";
            }
            PDFModel.DocumentsCount = 0;

            var categories = All<Category>(x => x.IsActive && x.IsApproved && x.ParentId == mainCategoryId && x.LanguageId == GlobalConstants.LangBG).ToList();
            foreach (var cat in categories)
            {

                StrategicDocumentCategoryRowVM categoryRow = new StrategicDocumentCategoryRowVM();
                categoryRow.Title = cat.CategoryName;
                categoryRow.LinkRows = All<StrategicDocuments>()
                                .Where(g => g.IsActive)
                                .Where(g => g.IsApproved)
                                .Where(g => !g.IsDeleted)
                                .Where(g => g.LanguageId == GlobalConstants.LangBG)
                                .Include(x => x.Category)
                                .Where(x =>
                                (
                                    (x.CategoryId == cat.Id) || (x.Category.SectionId == cat.Id)) &&
                                    (x.ValidTo > DateTime.Now)
                                )
                                .OrderByDescending(x => x.DateCreated)
                                .Select(x => new StrategicDocumentLinkRowVM()
                                {
                                    Id = x.Id,
                                    OrderNumber = " ",
                                    Title = x.Title,
                                    ValidTo = x.ValidTo
                                }).ToList();

                int i = 1;
                foreach (var Link in categoryRow.LinkRows)
                {
                    Link.OrderNumber = (i++).ToString();
                    PDFModel.DocumentsCount = PDFModel.DocumentsCount + 1;
                }
                PDFModel.CategoryRows.Add(categoryRow);



            }






            return PDFModel;
        }

    public bool StrategicDocuments_SaveData(StrategicDocuments model)
    {
      
      try
      {
        if (model.Id > 0)
        {
          var saved = Find<StrategicDocuments>(model.Id);
          if (model.CategoryMasterId!=GlobalConstants.Category.Type_National)
          {
            saved.CategoryId = model.MunicipalityId ?? 0;
          }
          saved.Title = model.Title;
          saved.Summary = model.Summary;
          saved.ValidTo = model.ValidTo;
          saved.DocumentNumber = model.DocumentNumber;
          saved.DocumentTypeId = model.DocumentTypeId;
          saved.DocumentDate = model.DocumentDate;
          saved.InstitutionTypeId = model.InstitutionTypeId;
          saved.IsActive = model.IsActive;
          saved.IsApproved = model.IsApproved;
          saved.IsDeleted = model.IsDeleted;
     
          saved.ModifiedByUserId = userContext.UserId;
          saved.DateModified = DateTime.Now;

          All<StrategicDocuments>().Update(saved);
          db.SaveChanges();
        }
        else
        {
          model.LanguageId = GlobalConstants.LangBG;
          model.CreatedByUserId = userContext.UserId;
          model.DateCreated = DateTime.Now;

          model.ModifiedByUserId = userContext.UserId;
          model.DateModified = model.DateCreated;

          All<StrategicDocuments>().Add(model);
          db.SaveChanges();
        }
        return true;
      }
      catch (Exception ex)
      {
        logger.Log(LogLevel.Error, ex, ex.Message);
        return false;
      }
    }

  }
}
