using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
//using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Questionary;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Extensions;
using WebCommon.Models;

namespace Domain.Controllers
{
  public class PublicConsultationController : BasePortalController
    {
        private readonly IConsultationService consultationService;
        private readonly INomenclatureService nomService;
        private readonly ICommentService commentService;
        private readonly IUrlHelper urlHelper;
        public PublicConsultationController(
            IConsultationService _consultationService,
            INomenclatureService _nomService,
            ICommentService _commentService,
            IUrlHelper _urlHelper)
        {
            consultationService = _consultationService;
            nomService = _nomService;
            commentService = _commentService;
            urlHelper = _urlHelper;
        }
        public IActionResult Index(int categoryMasterId = 1, int categoryId = -1, int districtId = -1, int municipalityId = -1, int validState = -1)
        {
            ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList().SetSelected(categoryMasterId);
            ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National).ToSelectList().AddAllItem().SetSelected(categoryId);
            ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District).ToSelectList().AddAllItem().SetSelected(districtId);

            var validStates = new List<TextValueVM>();
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Active.ToString(), "Активни"));
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Completed.ToString(), "Приключили"));
            ViewBag.MunicipalityId = municipalityId;
            ViewBag.validStates = validStates.ToSelectList().AddAllItem("Всички").SetSelected(validState);
            ViewBag.RssLink = urlHelper.Action("GetDocumentFeed", "Rss", new
            {
                type = RssFeedType.PublicConsultations,
                categoryMasterId = GlobalConstants.Category.Type_National
            });

            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int categoryMasterId, int? categoryId, int? municipalityId, int? validState, string searchTerm)
        {
            string sanitizedSearch = searchTerm.EmptyToNull();
            var data = consultationService.Portal_List(this.Lang, validState.EmptyToNull()).Where(x => x.Title.Contains(sanitizedSearch ?? x.Title));
            var filteredData = nomService.FilterByCategories(data, categoryMasterId, categoryId, municipalityId).AsQueryable();

            var orderColums = request.Columns.Where(x => x.Sort != null);
            var page = filteredData.OrderBy(orderColums).Skip(request.Start).Take((request.Length > 0) ? request.Length : filteredData.Count());
            List<PublicConsultationVM> dataPage = new List<PublicConsultationVM>();
                       
            foreach (PublicConsultationVM item in page)
            {
                item.CommentsCount = consultationService.GetConsultationCommentsCount(item.Id);
                dataPage.Add(item);
            }

            return new DataTablesJsonResult(DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage), true);
        }

        public IActionResult View(int id)
        {
            var model = consultationService.GetConsultation(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Summary = model.Summary.DecodeIfNeeded();
            model.CanComment = this.User.Identity.IsAuthenticated;
            var documents = consultationService.Portal_GetDocumentsList(id);
            ViewBag.documents = documents;
            ViewBag.mainDocuments = documents
                .Where(d => d.IsLastRevision)
                .GroupBy(d => d.DocumentType);

            ViewBag.hasQuestionary = consultationService.All<QuestionaryHeaders>().Where(x => x.SourceTypeId == GlobalConstants.SourceTypes.PublicConsultation && x.SourceId == id).Any();
            ViewBag.UserIdentityList = commentService.GetUserDDL(UserId);
            ViewBag.Breadcrumb = GetBreadcrump(model);

            return View(model);
        }

        public IActionResult ViewDocument(int id)
        {
            var model = consultationService.GetConsultationDocument(id);
            model.DocumentTitle = model.DocumentTitle.DecodeIfNeeded();
            model.Content = model.Content.DecodeIfNeeded();
            ViewBag.TimeLine = consultationService.GetDocumentVersions(id);
            ViewBag.SectionList = consultationService.GetSections(model.Content);
            ViewBag.UserIdentityList = commentService.GetUserDDL(UserId);

            return View(model);
        }

        private List<BreadcrumbVM> GetBreadcrump(ConsultationViewModel model)
        {
            List<BreadcrumbVM> result = new List<BreadcrumbVM>()
            {
                new BreadcrumbVM(){ Title = "Начало", Url = urlHelper.Action("Index", "Home") },
                new BreadcrumbVM(){ Title = "Обществени консултации", Url = urlHelper.Action("Index") }
            };

            if (model.ParentCategoryId == GlobalConstants.Category.Type_National)
            {
                result.Add(new BreadcrumbVM()
                {
                    Title = model.ParentCategoryName,
                    Url = urlHelper.Action("Index", new { categoryMasterId = model.ParentCategoryId })
                });

                result.Add(new BreadcrumbVM()
                {
                    Title = model.CategoryName,
                    Url = urlHelper.Action("Index", new { categoryMasterId = model.ParentCategoryId, categoryId = model.CategoryId })
                });
            }
            else
            {
                result.Add(new BreadcrumbVM()
                {
                    Title = "Областни и общински",
                    Url = urlHelper.Action("Index", new { categoryMasterId = GlobalConstants.Category.Type_District })
                });

                result.Add(new BreadcrumbVM()
                {
                    Title = model.SectionName,
                    Url = urlHelper.Action("Index", 
                    new { categoryMasterId = GlobalConstants.Category.Type_District, categoryId = -1, districtId = model.SectionId })
                });

                result.Add(new BreadcrumbVM()
                {
                    Title = model.CategoryName,
                    Url = urlHelper.Action("Index",
                    new { categoryMasterId = GlobalConstants.Category.Type_District, categoryId = -1, districtId = model.SectionId, municipalityId = model.CategoryId })
                });
            }

            return result;
        }
    }
}