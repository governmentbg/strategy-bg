using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.Consultations;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	[Authorize(Roles = GlobalConstants.Roles.Admin)]
	public class ConsultationController : BaseController
	{
		private readonly IConsultationService consultationService;

		public ConsultationController(IConsultationService _consultationService)
		{
			consultationService = _consultationService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LoadData(IDataTablesRequest request)
		{
			IQueryable<ConsultationListViewModel> data = consultationService.GetConsultations();

			var response = request.GetResponse(data);

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

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			SetSavedMessage = consultationService.SaveConsultation(model, UserId);

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
			ViewBag.TargetGroupId_ddl = consultationService.GetTargetGroupsDDL();
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