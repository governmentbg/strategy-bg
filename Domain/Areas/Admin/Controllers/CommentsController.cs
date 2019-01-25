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
using Models.ViewModels.Portal;
using Rotativa.AspNetCore;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class CommentsController : BaseAdminController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        public IActionResult Index(int sourceTypeId = 0, int sourceId = 0)
        {
            MakeSourceItemVM(sourceTypeId, sourceId);

            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int sourceTypeId = 0, int sourceId = 0)
        {
            IQueryable<CommentsListVM> data = commentService.GetCommentsList(sourceTypeId, sourceId);

            var response = request.GetResponse(data);

            return new DataTablesJsonResult(response, true);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CommentVM model = commentService.GetComment(id);
            SetSelectLists();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CommentVM model)
        {
            MakeSourceItemVM(model.SourceTypeId, model.SourceId);
            SetSelectLists();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SetSavedMessage = commentService.SaveItem(model, UserId);

            return View(model);
        }

        [HttpGet]
        public IActionResult Export(int documentId)
        {
            DocumentExportViewModel model = commentService.GetDocumentForExport(documentId);

            return new ViewAsPdf("_DocumentExport", model);
        }

        private void SetSelectLists()
        {
            ViewBag.StateId_ddl = commentService.GetStateDDL();
        }
    }
}