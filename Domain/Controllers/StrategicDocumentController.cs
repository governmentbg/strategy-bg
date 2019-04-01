using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Extensions;
using WebCommon.Models;

namespace Domain.Controllers
{
    public class StrategicDocumentController : BasePortalController
    {
        private readonly IStrategicDocumentsService service;
        private readonly INomenclatureService nomService;
        private readonly IUrlHelper urlHelper;
        public StrategicDocumentController(IStrategicDocumentsService _consultationService,
            INomenclatureService _nomService, IUrlHelper _urlHelper)
        {
            service = _consultationService;
            nomService = _nomService;
            urlHelper = _urlHelper;
        }
        public IActionResult Index(int categoryMasterId = 1, int categoryId = -1, int districtId = -1, int municipalityId = -1, int validState = -1)
        {
            ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList().SetSelected(categoryMasterId);
            ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National).ToSelectList().AddAllItem().SetSelected(categoryId);
            ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District).ToSelectList().AddAllItem().SetSelected(districtId);

            var validStates = new List<TextValueVM>();
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Active.ToString(), "Действащи"));
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Completed.ToString(), "С изтекъл срок"));

            ViewBag.MunicipalityId = municipalityId;
            ViewBag.validStates = validStates.ToSelectList().AddAllItem("Всички").SetSelected(validState);
            ViewBag.RssLink = urlHelper.Action("GetDocumentFeed", "Rss", new
            {
                type = RssFeedType.StrategicDocuments,
                categoryMasterId = GlobalConstants.Category.Type_National
            });

            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int categoryMasterId, int? categoryId, int? municipalityId, int? validState, string searchTerm)
        {
            string sanitizedSearch = searchTerm.EmptyToNull();
            var data = service.Portal_List(this.Lang, validState.EmptyToNull()).Where(x => x.Title.Contains(sanitizedSearch ?? x.Title));
            var filteredData = nomService.FilterByCategories(data, categoryMasterId, categoryId, municipalityId).AsQueryable();

            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }
        public IActionResult View(int id)
        {
            var model = service.GetStrategicDocument(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Summary = model.Summary.DecodeIfNeeded();

            ViewBag.Breadcrumb = service.GetBreadcrump(model.Category, urlHelper);

            return View(model);
        }

        public ActionResult PdfExport(int cat)
        {
            var model = service.GetPDFModel(cat, null, null);

            return new ViewAsPdf("_PdfExport", model)
            {
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }
        public IActionResult ExportChoice()
        {
            var model = new Models.ViewModels.Portal.StrategicDocumentExportChoiceVM();
            model.FromDate = System.DateTime.Now.AddYears(-1);
            model.ToDate = System.DateTime.Now;
            model.CategoryMasterId = 1;
            ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList();

            return View(model);
        }
        [HttpPost]
        public IActionResult ExportChoice(Models.ViewModels.Portal.StrategicDocumentExportChoiceVM model)
        {

            var modelpdf = service.GetPDFModel(model.CategoryMasterId, model.FromDate, model.ToDate, this.Lang);

            return new ViewAsPdf("_PdfExport", modelpdf)
            {
              PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
              PageSize = Rotativa.AspNetCore.Options.Size.A4
            }; 
        }

        public ActionResult ActionToLoadPartial()
        {
            try
            {
                // Do something to load any model data
            }
            catch (Exception ex)
            {

            }

            return PartialView("_ModalWindowEditTemplate");
        }
    }
}