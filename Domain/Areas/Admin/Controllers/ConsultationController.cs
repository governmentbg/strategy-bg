using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.Consultations;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using WebCommon.Models;

namespace Domain.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	[Authorize(Roles = GlobalConstants.Roles.Admin)]
	public class ConsultationController : BaseController
	{
		private readonly IConsultationService consultationService;

        private readonly INomenclatureService nomService;

		public ConsultationController(
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
            var docType = consultationService.GetDocumentTypesDDL();
            docType.RemoveAt(0);
            ViewBag.docType = docType.AddAllItem("Всички");
            var validStates = new List<TextValueVM>();
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Active.ToString(), "Активни"));
            validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Completed.ToString(), "Приключили"));
            ViewBag.validStates = validStates.ToSelectList().AddAllItem("Всички");

            return View();
		}

    public IActionResult Report()
    {
      ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList();
      ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National).ToSelectList().AddAllItem();
      ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District).ToSelectList().AddAllItem();
      var docType = consultationService.GetDocumentTypesDDL();
      docType.RemoveAt(0);
      ViewBag.docType = docType.AddAllItem("Всички");
      var validStates = new List<TextValueVM>();
      validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Active.ToString(), "Активни"));
      validStates.Add(new TextValueVM(GlobalConstants.ValidStates.Completed.ToString(), "Приключили"));
      ViewBag.validStates = validStates.ToSelectList().AddAllItem("Всички");

      return View("Report");
    }

    [HttpPost]
		public IActionResult LoadData(IDataTablesRequest request, int categoryMasterId, int? categoryId, int? municipalityId, int? validState, int? docType)
		{
            var data = consultationService.Portal_List(GlobalConstants.LangBG, validState.EmptyToNull(), docType.EmptyToNull());
            var filteredData = nomService.FilterByCategories(data, categoryMasterId, categoryId, municipalityId).AsQueryable();
            var response = request.GetResponse(data, filteredData);

			return new DataTablesJsonResult(response, true);
		}

		[HttpPost]
		public IActionResult DocumentIndex(IDataTablesRequest request, int consultationId)
		{
			IQueryable<DocumentListViewModel> data = consultationService.GetDocumentList(consultationId);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpPost]
		public IActionResult VersionIndex(IDataTablesRequest request, int documentId)
		{
			IQueryable<VersionListViewModel> data = consultationService.GetVersionList(documentId);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult Add()
		{
			var model = new ConsultationViewModel();
            model.InstututionTypeId = consultationService.GetInstitutionTypeId(UserId);
			SetComboViewBags();

			return View("Edit", model);
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			SetComboViewBags();

			var model = consultationService.GetConsultation(id);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ConsultationViewModel model)
		{
			SetComboViewBags();

            if (model.Id == 0 && model.OpenningDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("OpenningDate", "Не може да създадете консултация със задна дата");
            }

            if (model.OpenningDate.Date > model.ClosingDate.Date)
            {
                ModelState.AddModelError("ClosingDate", "Не може датата на приключване да е преди датата на откриване");
            }

            if ((model.ClosingDate - model.OpenningDate).Days < 14 && String.IsNullOrEmpty(model.ShortTermReason))
            {
                ModelState.AddModelError("ShortTermReason", "Полето Причина за кратък срок е задължително");
            }

			if (!ModelState.IsValid)
			{
				return View(model);
			}

            try
            {
                SetSavedMessage = consultationService.SaveConsultation(model, UserId);
            }
            catch (ApplicationException)
            {
                ModelState.AddModelError("OpenningDate", "Не може да създадете консултация със задна дата");

                return View(model);
            }

			if (SetSavedMessage)
			{
				return RedirectToAction(nameof(Edit), new { id = model.Id });
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult AddDocument(int consultationId)
		{
			var model = new DocumentViewModel()
			{
				ConsultationId = consultationId,
				Revision = 1
			};

			SetConsultationTitle(consultationId);
            SetDocumentViewBags();

			return View(nameof(EditDocument), model);
		}

		[HttpGet]
		public IActionResult EditDocument(int id)
		{
			DocumentViewModel model = consultationService.GetDocument(id);
			SetConsultationTitle(model.ConsultationId);
            SetDocumentViewBags();

            return View(model);
		}

		[HttpPost]
		public IActionResult EditDocument(DocumentViewModel model)
		{
			SetConsultationTitle(model.ConsultationId);
            SetDocumentViewBags();

            if (!ModelState.IsValid)
			{
				return View(model);
			}

			SetSavedMessage = consultationService.SaveDocument(model, UserId);

			return View(model);
		}

		public IActionResult AddVersion(int documentId)
		{
			DocumentViewModel model = consultationService
					.CreateVersion(documentId);

			SetConsultationTitle(model.ConsultationId);
            SetDocumentViewBags();

            return View(nameof(EditDocument), model);
		}

		private void SetComboViewBags()
		{
            ViewBag.InstututionTypeId_ddl = nomService.GetInstitutionTypesDDL();
            ViewBag.LinksCategoryId_ddl = nomService.GetLinksCategoriesDDL();
            ViewBag.CategoryId_ddl = nomService.GetCategories();
        }

        private void SetDocumentViewBags()
        {
            ViewBag.DocumentTypes = consultationService.GetDocumentTypesDDL();
        }

		private void SetConsultationTitle(int consultationId)
		{
			ViewBag.ConsultationTitle = consultationService.GetConsultationTitle(consultationId);
		}
	}
}