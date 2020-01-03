using FileCDN.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Account;
using Models.Context.Consultations;
using Models.Context.Legacy;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebCommon.Services;

namespace Models.Services
{
    public class StrategicDocumentsService : BaseService, IStrategicDocumentsService
    {
        private readonly ILogger logger;
        private readonly IUserContext userContext;
        private readonly IUrlHelper urlHelper;
        public StrategicDocumentsService(
                MainContext context,
                ILogger<ConsultationService> _logger,
                  IUserContext _userContext,
                  IUrlHelper _urlHelper)
        {
            this.db = context;
            logger = _logger;
            userContext = _userContext;
            urlHelper = _urlHelper;
        }

        public StrategicDocuments GetStrategicDocument(int id)
        {
            var strDoc = All<StrategicDocuments>()
                        .Include(x => x.Category)
                        .Where(x => x.Id == id)
                        .FirstOrDefault();

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

        public IQueryable<StrategicDocumentVM> Portal_List(int langId = GlobalConstants.LangBG, int? validMode = null, bool activeOnly = true)
        {
            Expression<Func<StrategicDocuments, bool>> whereValid = x => true;
            switch (validMode)
            {
                case GlobalConstants.ValidStates.Active:
                    whereValid = x => x.ValidTo >= DateTime.Now;
                    break;
                case GlobalConstants.ValidStates.Completed:
                    whereValid = x => x.ValidTo < DateTime.Now;
                    break;
            }
            Expression<Func<StrategicDocuments, bool>> whereActive = x => true;
            if (activeOnly)
            {
                whereActive = x => x.IsActive && !x.IsDeleted && x.IsApproved;
            }
            return All<StrategicDocuments>()
                  .Where(whereActive)
                  .Where(g => g.LanguageId == langId)
                  .Where(whereValid)
                  .Include(x => x.Category)
                  .OrderBy(x => x.Category.ParentId)
                  .ThenByDescending(x => x.DateCreated)
                  .Select(x => new StrategicDocumentVM()
                  {
                      Id = x.Id,
                      Title = x.Title,
                      CategoryId = x.CategoryId,
                      CategoryParentId = x.Category.ParentId,
                      CategorySectionId = x.Category.SectionId,
                      CategoryText = x.Category.CategoryName,
                      CategoryImagePath = (x.Category.ImagePath == null || x.Category.ImagePath == "") ? "icon_default.png" : x.Category.ImagePath,
                      DocumentDate = x.DocumentDate,
                      DocumentNumber = x.DocumentNumber,
                      ValidTo = x.ValidTo,
                      CreateDate = x.DateCreated,
                      IsActive = x.IsActive && !x.IsDeleted && x.IsApproved
                  })
                  .AsQueryable();
        }

        public IQueryable<StrategicDocumensListVM> StrategicDocumentsGetExport()
        {
            var _Url = urlHelper.Action("View", "StrategicDocument", new { area = "" });
            return (from std_doc in All<StrategicDocuments>()
                                        .Where(g => g.IsActive)
                                        .Where(g => !g.IsDeleted)
                                        .Include(x => x.Category)
                                        .OrderBy(x => x.Category.ParentId)
                                        .ThenByDescending(x => x.DateCreated)
                    join usr in All<Users>() on std_doc.CreatedByUserId equals usr.Id
                    join cats in All<Category>() on std_doc.Category.ParentId equals cats.Id
                    join doc_types in All<StrategicDocumentTypes>() on std_doc.DocumentTypeId equals doc_types.Id
                    join inst_types in All<InstitutionTypes>() on std_doc.InstitutionTypeId equals inst_types.Id
                    select new StrategicDocumensListVM
                    {
                        Id = std_doc.Id,
                        Title = std_doc.Title,
                        // URL = new Uri($"{Url}/{std_doc.Id}").ToString(),
                        URL = _Url.ToString() + "/" + std_doc.Id.ToString(),
                        Category = std_doc.Category.CategoryName,
                        CategoryParent = cats.CategoryName,
                        CreateDate = std_doc.DateCreated.ToString(GlobalConstants.DateFormat),
                        DocumentType = doc_types.DocumentTypeName,
                        Institution = inst_types.InstitutionTypeName,
                        ValidTo = (std_doc.ValidTo.Year - DateTime.Now.Year) < 75 ? std_doc.ValidTo.ToString(GlobalConstants.DateFormat) : "Не е указан срок",
                        UserCreated = usr.FullName
                    }).AsQueryable();
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
        public StrategicDocumentPDFVM GetPDFModel(int mainCategoryId, DateTime? fromDate, DateTime? toDate, int langId = GlobalConstants.LangBG)
        {
            StrategicDocumentPDFVM PDFModel = new StrategicDocumentPDFVM();
            string strFromDate = "";
            string strToDate = "";
            DateTime tmpDate = DateTime.Now;
            if (fromDate == null)
            { fromDate = new DateTime(1900, 1, 1); }
            else
            {
                bool success = DateTime.TryParse(fromDate.ToString(), out tmpDate);
                strFromDate = " от дата " + tmpDate.ToString(GlobalConstants.DateFormat) + "г.";
            };


            if (toDate == null)
            { toDate = new DateTime(2100, 1, 1); }
            else
            {
                bool success = DateTime.TryParse(toDate.ToString(), out tmpDate);
                strToDate = " до дата " + tmpDate.ToString(GlobalConstants.DateFormat) + "г.";

            };
            var firstDate = new DateTime(1900, 1, 1);
            var lastDate = new DateTime(2200, 1, 1);

            if (mainCategoryId == 1)
            {
                PDFModel.Title = "Справка на действащите стратегически документи" + strFromDate + strToDate + " на национално ниво";
            }
            else
            {
                PDFModel.Title = "Справка на действащите стратегически документи" + strFromDate + strToDate + "на общинско ниво";
            }
            PDFModel.DocumentsCount = 0;

            var categories = All<Category>(x => x.IsActive && x.IsApproved && x.ParentId == mainCategoryId && x.LanguageId == GlobalConstants.LangBG).ToList();
            var strategicUsedFiles = (from uf in db.FilesCDNUsed.Where(u => u.source_type == GlobalConstants.SourceTypes.StrategicDocuments)
                                      join f in db.FileCdn on uf.cdn_file_id equals f.Id
                                      where f.IsActive && (f.IsReportVisible == true)
                                        //&& (f.DateExparing ?? lastDate).Year >= fromDate.Value.Year
                                        && (f.DateExparing ?? lastDate) >= toDate
                                      orderby uf.order_by
                                      select new Files
                                      {
                                          Id = uf.source_id,
                                          Name = f.FileTitle,
                                          DateExparing = (f.DateExparing ?? lastDate)
                                      }).ToList();

            foreach (var cat in categories)
            {

                StrategicDocumentCategoryRowVM categoryRow = new StrategicDocumentCategoryRowVM();
                categoryRow.Title = cat.CategoryName;
                categoryRow.LinkRows = All<StrategicDocuments>()
                                .Where(g => g.IsActive)
                                .Where(g => !g.IsDeleted)
                                .Where(g => g.LanguageId == langId)
                                //.Where(g => g.DocumentDate <= toDate)
                                //.Where(g => g.ValidTo >= fromDate)
                                .Where(g => (g.DocumentDate ?? firstDate) <= fromDate)
                                .Where(g => g.ValidTo >= toDate)
                                .Include(x => x.Category)
                                .Where(x =>
                                (
                                    (x.CategoryId == cat.Id) || (x.Category.SectionId == cat.Id)) &&
                                    (x.ValidTo > DateTime.Now)
                                )
                                .OrderByDescending(x => x.DocumentDate)
                                .Select(x => new StrategicDocumentLinkRowVM()
                                {
                                    Id = x.Id,
                                    OrderNumber = " ",
                                    Title = x.Title,
                                    ValidTo = x.ValidTo,
                            //Files = (from uf in db.FilesCDNUsed.Where(u => u.source_type == GlobalConstants.SourceTypes.StrategicDocuments && u.source_id == x.Id)
                            //         join f in db.FileCdn on uf.cdn_file_id equals f.Id
                            //         where f.IsActive && (f.IsReportVisible == true)
                            //         && (f.DateExparing ?? lastDate).Year >= fromDate.Value.Year
                            //         orderby uf.order_by
                            //         select new StrategicDocumentLinkRowVM
                            //         {
                            //             Title = f.FileTitle,
                            //             ValidTo = (f.DateExparing ?? lastDate)
                            //         })
                            Files = (from f in strategicUsedFiles.Where(u => u.Id == x.Id)

                                             select new StrategicDocumentLinkRowVM
                                             {
                                                 Id = f.Id,
                                                 Title = f.Name,
                                                 ValidTo = (f.DateExparing ?? lastDate)
                                             })
                                }).ToList();

                int i = 0;
                foreach (var Link in categoryRow.LinkRows)
                {
                    i++;
                    Link.OrderNumber = i.ToString();
                    PDFModel.DocumentsCount = PDFModel.DocumentsCount + 1;
                    if (Link.Files.Count() > 0)
                    {
                        foreach (var docFile in Link.Files)
                        {
                            i++;
                            docFile.OrderNumber = i.ToString();
                            // docFile.OrderNumber = "opsa";
                        }
                    }
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

                    saved.Title = model.Title;
                    saved.Summary = model.Summary;
                    saved.ValidTo = model.ValidTo;
                    saved.DocumentNumber = model.DocumentNumber;
                    saved.DocumentTypeId = model.DocumentTypeId;
                    saved.DocumentDate = model.DocumentDate;
                    saved.InstitutionTypeId = model.InstitutionTypeId;
                    saved.IsActive = model.IsActive;
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

        public List<BreadcrumbVM> GetBreadcrump(Category category, IUrlHelper urlHelper)
        {
            List<BreadcrumbVM> result = new List<BreadcrumbVM>()
            {
                new BreadcrumbVM(){ Title = "Начало", Url = urlHelper.Action("Index", "Home") },
                new BreadcrumbVM(){ Title = "Стратегически документи", Url = urlHelper.Action("Index") }
            };

            if (category.ParentId == GlobalConstants.Categories.Type_National)
            {
                result.Add(new BreadcrumbVM()
                {
                    Title = this.All<Category>()
                        .Find(category.ParentId)
                        ?.CategoryName,
                    Url = urlHelper.Action("Index", new { categoryMasterId = category.ParentId })
                });

                result.Add(new BreadcrumbVM()
                {
                    Title = category.CategoryName,
                    Url = urlHelper.Action("Index", new { categoryMasterId = category.ParentId, categoryId = category.Id })
                });
            }
            else
            {
                result.Add(new BreadcrumbVM()
                {
                    Title = "Областни и общински",
                    Url = urlHelper.Action("Index", new { categoryMasterId = GlobalConstants.Categories.Type_District })
                });

                result.Add(new BreadcrumbVM()
                {
                    Title = this.All<Category>()
                        .Find(category.SectionId)
                        ?.CategoryName,
                    Url = urlHelper.Action("Index",
                    new { categoryMasterId = GlobalConstants.Categories.Type_District, categoryId = -1, districtId = category.SectionId })
                });

                result.Add(new BreadcrumbVM()
                {
                    Title = category.CategoryName,
                    Url = urlHelper.Action("Index",
                    new { categoryMasterId = GlobalConstants.Categories.Type_District, categoryId = -1, districtId = category.SectionId, municipalityId = category.Id })
                });
            }

            return result;
        }
    }
}
