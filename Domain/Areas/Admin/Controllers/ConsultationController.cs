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
using WebCommon.Services;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Admin))]

  public class ConsultationController : BaseAdminController
  {
    private readonly IConsultationService consultationService;

    private readonly INomenclatureService nomService;
    private readonly IUserContext userContext;

    public ConsultationController(
        IConsultationService _consultationService,
        INomenclatureService _nomService,
        IUserContext _userContext)
    {
      consultationService = _consultationService;
      nomService = _nomService;
      userContext = _userContext;
    }

    public IActionResult Index()
    {
      ViewBag.catMasters = nomService.ComboCategories(0, -1, true).ToSelectList();
      ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Categories.Type_National, -1, true).ToSelectList().AddAllItem();
      ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Categories.Type_District, -1, true).ToSelectList().AddAllItem();
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
      ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Categories.Type_National).ToSelectList().AddAllItem();
      ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Categories.Type_District).ToSelectList().AddAllItem();
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
    public IActionResult LoadData(IDataTablesRequest request, int categoryMasterId, int? categoryId, int? municipalityId, int? validState, int? docType, string activeOnly)
    {
      bool isAdmin = userContext.IsInRole(Roles.Admin);
      var data = consultationService.Portal_List(GlobalConstants.LangBG, validState.EmptyToNull(), docType.EmptyToNull(), activeOnly == "true");
      var filteredData = nomService.FilterByUserGroupRights(nomService.FilterByCategories(data, categoryMasterId, categoryId, municipalityId).AsQueryable()
                  , this.UserId, isAdmin
                  );
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
      SetComboViewBags(model.ParentCategoryId, model.ActId ?? 0);

      return View("Edit", model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      var model = consultationService.GetConsultation(id);
      SetComboViewBags(model.ParentCategoryId, model.ActId ?? 0);

      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ConsultationViewModel model)
    {
      int logState = 0;
      SetComboViewBags(model.ParentCategoryId, model.ActId ?? 0);

      if (model.Id == 0 && model.OpenningDate.Date < DateTime.Now.Date)
      {
        ModelState.AddModelError("OpenningDate", "Не може да създадете консултация със задна дата");
      }

      if (model.OpenningDate.Date > model.ClosingDate.Date)
      {
        ModelState.AddModelError("ClosingDate", "Не може датата на приключване да е преди датата на откриване");
      }

      if ((model.ClosingDate - model.OpenningDate).Days < 14)
      {
        ModelState.AddModelError("ClosingDate", "Срока на консултацията не може да е по-малък от 14 дни");
      }

      if ((model.ClosingDate - model.OpenningDate).Days >= 14 && (model.ClosingDate - model.OpenningDate).Days <= 30 && String.IsNullOrEmpty(model.ShortTermReason))
      {
        ModelState.AddModelError("ShortTermReason", "Полето Причина за кратък срок е задължително");
      }

      if (!ModelState.IsValid)
      {
        return View(model);
      }

      try
      {
        if( model.Id==0)
        { logState = SiteLogAction.Add; }
        else
        { logState = SiteLogAction.Edit;
          if (model.IsDeleted == true)
          { logState = SiteLogAction.Delete; } }

        SetSavedMessage = consultationService.SaveConsultation(model, UserId);
      }
      catch (ApplicationException)
      {
        ModelState.AddModelError("OpenningDate", "Не може да създадете консултация със задна дата");

        return View(model);
      }

      if (SetSavedMessage)
      {
        SaveSiteLog(SiteLogTableNames.PublicConsultations, logState, model.Id, model.IsApproved, model.Title);
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

    [HttpGet]
    public IActionResult GetCategories(int typeId)
    {
      var result = nomService.
          GetCategoriesByParentId(typeId, this.UserId, this.User.IsInRole(GlobalConstants.Roles.Admin));

      return new JsonResult(result);
    }

    [HttpGet]
    public IActionResult GetActTypes()
    {
      var result = nomService
          .GetActDocumentTypes();

      return new JsonResult(result);
    }

    [HttpGet]
    public IActionResult GetEmptyList()
    {
      var result = nomService
          .GetEmptyList();

      return new JsonResult(result);
    }

    [HttpGet]
    public IActionResult GetProjects(int actId)
    {
      var result = consultationService
          .GetProjects(actId, UserId);

      return new JsonResult(result);
    }

    private void SetComboViewBags(int typeId, int actId)
    {
      //ViewBag.InstututionTypeId_ddl = nomService.GetInstitutionTypesDDL();
      var linkCategories = nomService.GetLinksCategoriesDDL_ByUser();
      ViewBag.LinksCategoryId_ddl = linkCategories;
      if (linkCategories.Count() == 1)
      {
        ViewBag.SingleLinkCategory = linkCategories.FirstOrDefault();
      }
      ViewBag.CategoryId_ddl = nomService.GetCategoriesByParentId(typeId, this.UserId, this.User.IsInRole(GlobalConstants.Roles.Admin));//nomService.GetCategories();
      ViewBag.ParentCategoryId_ddl = nomService.GetBaseCategories();

      if (typeId == GlobalConstants.Categories.Type_National)
      {
        ViewBag.ActId_ddl = nomService.GetActDocumentTypes();
      }
      else
      {
        ViewBag.ActId_ddl = nomService.GetEmptyList();
      }

      if (actId > 0)
      {
        ViewBag.MSProgramProjectId_ddl = consultationService
            .GetProjects(actId, UserId);
      }
      else
      {
        ViewBag.MSProgramProjectId_ddl = nomService.GetEmptyList();
      }
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