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
using Models.ViewModels.Consultations;
using Models.ViewModels.Portal;
using Rotativa.AspNetCore;
using WebCommmon.Controllers;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Admin))]
  [Authorize]
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
      int logState = 0;
      if (model.CommentId == 0)
      { logState = SiteLogAction.Add; }
      else
      {
        logState = SiteLogAction.Edit;
      }


      if (!ModelState.IsValid)
      {
        return View(model);
      }

      SetSavedMessage = commentService.SaveItem(model, UserId);
      if (SetSavedMessage)
      {
        SaveSiteLog(SiteLogTableNames.StrategicDocuments, logState, model.CommentId, SetSavedMessage, model.Title);
      }

      return View(model);
    }

    [HttpGet]
    public IActionResult Export(int documentId)
    {
      DocumentExportViewModel model = commentService.GetDocumentForExport(documentId);

      return new ViewAsPdf("_DocumentExport", model);
    }

    [HttpGet]
    public IActionResult ExportConsultationComments(int consultationId)
    {
      CommentsExportVM model = commentService.GetCommentsForExport(consultationId);

      return new ViewAsPdf("_CommentsExport", model);
    }

    private void SetSelectLists()
    {
      ViewBag.StateId_ddl = commentService.GetStateDDL();
    }
  }
}