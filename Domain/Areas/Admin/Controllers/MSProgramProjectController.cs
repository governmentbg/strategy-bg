using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using System;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Models.Context.Consultations;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    [Authorize]
    public class MSProgramProjectController : BaseController
    {
        private readonly IConsultationService service;
        private readonly IInstitutionTypeService institutionService;
        public MSProgramProjectController(IConsultationService _service, IInstitutionTypeService _institutionService)
        {
            service = _service;
            institutionService = _institutionService;
        }
        public IActionResult Index(int programId, int lang = GlobalConstants.LangBG)
        {
            ViewBag.lang = lang;
            ViewBag.program = service.Find<MSProgram>(programId);
            return View();
        }
        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int programId, string term, int lang)
        {
            var data = service.ProgramProject_Select(lang, programId, term.EmptyToNull());

            var filtered = data;
            var response = request.GetResponse(data, filtered);

            return new DataTablesJsonResult(response, true);
        }


        public IActionResult Add(int programId, int lang)
        {
            var model = new MSProgramProject()
            {
                LanguageId = lang,
                MSProgramId = programId,
                DateCoordinated = DateTime.Now,
                IsActive = true
            };
            SetViewBag(model);
            return View(nameof(Edit), model);
        }
        [HttpPost]
        public IActionResult Add(MSProgramProject model)
        {
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = service.ProgramProject_SaveData(model);
            if (SetSavedMessage)
            {
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            return View(nameof(Edit), model);
        }

        public IActionResult Edit(int id)
        {
            var model = service.Find<MSProgramProject>(id);
            SetViewBag(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(MSProgramProject model)
        {
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = service.ProgramProject_SaveData(model);
            return View(model);
        }

        private void SetViewBag(MSProgramProject model)
        {
            ViewBag.program = service.Find<MSProgram>(model.MSProgramId);
            // ViewBag.documentTypes = service.GetDocumentTypesDDL().SetSelected(model.DocumentTypeId);
            ViewBag.insitutionTypes = institutionService.GetInstitutionTypeList(-1, model.LanguageId).ToSelectList(x => x.Id, x => x.Label);
            //ViewBag.categories = service.PublicationCategories_SelectCombo().ToSelectList(model.PublicationCategoryId);
        }
    }
}