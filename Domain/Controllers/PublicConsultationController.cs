using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
//using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using WebCommon.Extensions;
using System.Linq;
using Models.Context.Questionary;
using Models;

namespace Domain.Controllers
{
    public class PublicConsultationController : Controller
    {
        private readonly IConsultationService consultationService;
        private readonly INomenclatureService nomService;
        public PublicConsultationController(
            IConsultationService _consultationService,
            INomenclatureService _nomService)
        {
            consultationService = _consultationService;
            nomService = _nomService;
        }
        public IActionResult Index()
        {
            ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList();
            ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National).ToSelectList().AddAllItem();
            ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District).ToSelectList().AddAllItem();

            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int categoryMasterId, int? categoryId, int? municipalityId)
        {
            int? selectedCategory = null;
            switch (categoryMasterId)
            {
                case GlobalConstants.Category.Type_National:
                    selectedCategory = categoryId;
                    break;
                default:
                    selectedCategory = municipalityId;
                    break;
            }

            var data = consultationService.Portal_List();
            var filteredData = data.Where(x => x.CategoryId == (selectedCategory.EmptyToNull() ?? x.CategoryId));

            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult View(int id)
        {
            var model = consultationService.GetConsultation(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Summary = model.Summary.DecodeIfNeeded();
            var documents = consultationService.Portal_GetDocumentsList(id);
            ViewBag.documents = documents;
            ViewBag.mainDocuments = documents
                .Where(d => d.IsLastRevision)
                .GroupBy(d => d.DocumentType);

            ViewBag.hasQuestionary = consultationService.All<QuestionaryHeaders>().Where(x => x.SourceTypeId == GlobalConstants.SourceTypes.PublicConsultation && x.SourceId == id).Any();

            return View(model);
        }

        public IActionResult ViewDocument(int id)
        {
            var model = consultationService.GetConsultationDocument(id);
            model.DocumentTitle = model.DocumentTitle.DecodeIfNeeded();
            model.Content = model.Content.DecodeIfNeeded();
            ViewBag.TimeLine = consultationService.GetDocumentVersions(id);
            ViewBag.SectionList = consultationService.GetSections(model.Content);

            return View(model);
        }
    }
}