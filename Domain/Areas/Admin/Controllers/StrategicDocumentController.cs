using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Legacy;
using Models.Contracts;
using Models.ViewModels.Portal;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Extensions;
using WebCommon.Models;
using WebCommon.Services;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class StrategicDocumentController : BaseAdminController
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
            ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Categories.Type_National).ToSelectList().AddAllItem();
            ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Categories.Type_District).ToSelectList().AddAllItem();
            var validStates = new List<TextValueVM>();
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Active.ToString(), "Действащи"));
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Completed.ToString(), "С изтекъл срок"));
            ViewBag.validStates = validStates.ToSelectList().AddAllItem("Всички");
            return View();
        }

        public IActionResult Report()
        {
            ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList();
            ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Categories.Type_National).ToSelectList().AddAllItem();
            ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Categories.Type_District).ToSelectList().AddAllItem();
            var validStates = new List<TextValueVM>();
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Active.ToString(), "Действащи"));
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Completed.ToString(), "С изтекъл срок"));
            ViewBag.validStates = validStates.ToSelectList().AddAllItem("Всички");
            return View("Report");
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

            var modelpdf = service.GetPDFModel(model.CategoryMasterId, model.FromDate, model.ToDate, GlobalConstants.LangBG);

            return new ViewAsPdf("_PdfExport", modelpdf)
            {
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int categoryMasterId, int? categoryId, int? municipalityId, int? validState, string activeOnly)
        {
            var data = service.Portal_List(GlobalConstants.LangBG, validState.EmptyToNull(), activeOnly == "true");
            var filteredData = nomService.FilterByCategories(data, categoryMasterId, categoryId, municipalityId).AsQueryable();

            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }
        public IActionResult Add()
        {
            var model = new StrategicDocuments()
            {
                IsActive = true,
                IsApproved = true,
                DateCreated = DateTime.Now,
                ValidTo = DateTime.Now,
                DateModified = DateTime.Now
            };
            SendByFilter_ViewBag();
            return View(nameof(Edit), model);
        }
        public IActionResult Edit(int id)
        {
            var model = service.GetStrategicDocument(id);

            model.Title = model.Title.DecodeIfNeeded();
            model.Summary = model.Summary.DecodeIfNeeded();
            //ViewBag.documents = service.Portal_GetFileList(id);
            SendByFilter_ViewBag();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StrategicDocuments model)
    {
      int logState = SiteLogAction.Edit;
      if (model.IsDeleted == true)
      { logState = SiteLogAction.Delete; }
      SendByFilter_ViewBag();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SetSavedMessage = service.StrategicDocuments_SaveData(model);
            if (SetSavedMessage)
            {
                SaveSiteLog(SiteLogTableNames.StrategicDocuments, logState, model.Id, model.IsApproved, model.Title);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(StrategicDocuments model)
        {
     
      
   
      


      SendByFilter_ViewBag();
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = service.StrategicDocuments_SaveData(model);

            if (SetSavedMessage)
            {
                SaveSiteLog(SiteLogTableNames.StrategicDocuments, SiteLogAction.Add, model.Id, model.IsApproved, model.Title);
            }
            return RedirectToAction(nameof(Edit), new { id = model.Id });

            return View(nameof(Edit), model);
        }
        private void SendByFilter_ViewBag()
        {
            ViewBag.institutions = nomService.GetInstitutionTypesDDL();

            ViewBag.documentTypes = nomService.GetDocumentTypesDDL();
            ViewBag.CategoryId_ddl = nomService.GetCategories();



        }
        //public ActionResult PdfExport(int cat)
        //{
        //    var model = service.GetPDFModel(cat, null, null);

        //    return new ViewAsPdf("_PdfExport", model);
        //}
    }
}