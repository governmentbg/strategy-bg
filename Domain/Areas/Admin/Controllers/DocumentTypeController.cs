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
using Models.ViewModels;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class DocumentTypeController : BaseAdminController
    {
        public readonly IDocumentTypeService documentTypeService;

        public DocumentTypeController(IDocumentTypeService _documentTypeService)
        {
            documentTypeService = _documentTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request)
        {
            IQueryable<DocumentTypeListVM> data = documentTypeService.GetDocumentTypeList();

            var response = request.GetResponse(data);

            return new DataTablesJsonResult(response, true);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new DocumentTypeVM();

            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DocumentTypeVM model = documentTypeService.GetItem(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DocumentTypeVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SetSavedMessage = documentTypeService.SaveItem(model);

            return View(model);
        }
    }
}