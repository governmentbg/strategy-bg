using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.PCSubjectsModels;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using WebCommmon.Controllers;
using WebCommon.Services;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
  /// <summary>
  /// Public Consultation Subjects
  /// </summary>
  [Area(nameof(Admin))]
  public class PCSubjectsController : BaseAdminController
  {
    private readonly IPCSubjectsService PCSubjectsService;
    private readonly IUserContext userContext;
    private readonly INomenclatureService nomService;

    public PCSubjectsController(IPCSubjectsService _PCSubjectsService, IUserContext _userContext, INomenclatureService _nomService)
    {
      PCSubjectsService = _PCSubjectsService;
      userContext = _userContext;
      nomService = _nomService;
    }

    #region Public Consultation Subjects
    public IActionResult ListPCSubjects(string name, string eik, int pcSubjectsTypeID)
    {
      SetComboViewBags();

      return View();
    }

    [HttpPost]
    public IActionResult LoadDataPCSubjects(IDataTablesRequest request, string name, string eik, int pcSubjectsTypeID)
    {
      if (name == null)
      {
        name = "";
      }

      if (eik == null)
      {
        eik = "";
      }

      IQueryable<PCSubjectsListViewModel> data = PCSubjectsService.GetPCSubjectsList(name, eik, pcSubjectsTypeID);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult AddPCSubject()
    {
      var model = new PCSubjectsViewModel();
      model.IsUL = 1;
      SetComboViewBags(false);

      return View("EditPCSubjects", model);
    }

    [HttpGet]
    public IActionResult EditPCSubjects(int id)
    {
      var model = PCSubjectsService.GetPCSubjects(id);
      SetComboViewBags(false);

      return View("EditPCSubjects", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditPCSubjects(PCSubjectsViewModel model)
    {
      int logState = 0;
      SetSavedMessage = false;
      SetComboViewBags(false);

      if (!ModelState.IsValid)
      {
        return View("EditPCSubjects", model);
      }
      if (model.Id == 0)
      { logState = SiteLogAction.Add; }
      else
      {
        logState = SiteLogAction.Edit;
 
      }
      SetSavedMessage = PCSubjectsService.SavePCSubjects(model);

      if (SetSavedMessage)
      {
   
          SaveSiteLog(SiteLogTableNames.PCSubjects, logState, model.Id,true, model.ActivityDescription);
   

        return RedirectToAction(nameof(EditPCSubjects), new { id = model.Id });
      }

      return View("EditPCSubjects", model);
    }

    private void SetComboViewBags(bool addAll = true)
    {
      ViewBag.PCSubjectsTypeID_ddl = PCSubjectsService.GetPCSubjectTypesDDL(addAll);

      ViewBag.catMasters = PCSubjectsService.GetCategoriesDDL(0, null);
      ViewBag.catNational = PCSubjectsService.GetCategoriesDDL(GlobalConstants.Categories.Type_National, null);
      ViewBag.catDistrict = PCSubjectsService.GetCategoriesDDL(GlobalConstants.Categories.Type_District, null);
    }
    #endregion

    #region Ajax Autocomplete
    [HttpGet]
    public JsonResult LoadDataPCSubjectsAutocompleteEIK(string Prefix)
    {
      IQueryable<PCSubjectsListViewModel> data = PCSubjectsService.GetPCSubjectsAutocompleteEIK(Prefix);

      var list = (from N in data
                  select new { N.Name, N.EIK, N.ActivityDescription });

      return Json(list);
    }

    [HttpGet]
    public JsonResult LoadDataPCSubjectsAutocompleteName(string Prefix)
    {
      IQueryable<PCSubjectsListViewModel> data = PCSubjectsService.GetPCSubjectsAutocompleteName(Prefix);

      var list = (from N in data
                  select new { N.Name, N.EIK, N.ActivityDescription });

      return Json(list);
    }
    #endregion

    [HttpGet]
    public JsonResult LoadDataMunicipality(int masterCat, int? selectedId)
    {
      var result = PCSubjectsService.GetCategoriesDDL(masterCat, selectedId);

      return Json(result);
    }

    [HttpGet]
    [Description("PDF експорт на лицата по ЗНА")]
    public ActionResult PCSubjectsPDF(int questionaryHeaderId, int? userId, string userEmail)
    {
      IQueryable<PCSubjectsListViewModel> model = PCSubjectsService.GetPCSubjectsList("", "", -1);

      return new ViewAsPdf("_PCSubjectsPDF", model);
    }
  }
}