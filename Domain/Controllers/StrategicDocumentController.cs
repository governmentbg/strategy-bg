using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Rotativa.AspNetCore;
using System.Linq;
using WebCommon.Extensions;

namespace Domain.Controllers
{
    public class StrategicDocumentController : Controller
    {
        private readonly IStrategicDocumentsService service;
        private readonly INomenclatureService nomService;
        public StrategicDocumentController(IStrategicDocumentsService _consultationService, INomenclatureService _nomService)
        {
            service = _consultationService;
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
            var data = service.Portal_List();
            var filteredData = data.Where(x => x.CategoryId == (selectedCategory.EmptyToNull() ?? x.CategoryId));

            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }
        public IActionResult View(int id)
        {
            var model = service.GetStrategicDocument(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Summary = model.Summary.DecodeIfNeeded();
            return View(model);
        }

        public ActionResult PdfExport(int cat)
        {
            var model = service.GetPDFModel(cat);

            return new ViewAsPdf("_PdfExport", model);
        }
    }
}