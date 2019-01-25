using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Legacy;
using Models.Contracts;
using Rotativa.AspNetCore;
using System;
using System.Linq;
using WebCommon.Extensions;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Admin))]
  public class StrategicDocumentController :BaseAdminController
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
      ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National).ToSelectList().AddAllItem();
      ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District).ToSelectList().AddAllItem();
      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, int categoryMasterId, int? categoryId, int? municipalityId)
    {
      int? selectedCategory = null;
      switch (categoryMasterId)
      {
        case GlobalConstants.Category.Type_National:
          selectedCategory = categoryId;
          break;
        default:
          selectedCategory = municipalityId;
          break;
      }
      var data = service.Portal_List();
      var filteredData = data.Where(x => x.CategoryId == (selectedCategory.EmptyToNull() ?? x.CategoryId));

      var response = request.GetResponse(data, filteredData);
      return new DataTablesJsonResult(response, true);
    }
    public IActionResult Add()
    {
      var model = new StrategicDocuments()
      {
        IsActive = true,
        IsApproved = true,
        DateCreated= DateTime.Now,  
       ValidTo= DateTime.Now,
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
      SendByFilter_ViewBag();
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      SetSavedMessage = service.StrategicDocuments_SaveData(model);
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
     

        return RedirectToAction(nameof(Edit), new { id = model.Id });
      
      return View(nameof(Edit), model);
    }
    private void SendByFilter_ViewBag()
    {
      ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList();
      ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National).ToSelectList().AddAllItem();
      ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District).ToSelectList().AddAllItem();
      ViewBag.institution = nomService.GetInstitutionTypesDDL();
                             
      ViewBag.documentType = nomService.GetDocumentTypesDDL();
                              


    }
    public ActionResult PdfExport(int cat)
    {
      var model = service.GetPDFModel(cat);

      return new ViewAsPdf("_PdfExport", model);
    }
  }
}