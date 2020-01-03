using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Models.Context.Consultations;
using static Models.GlobalConstants;



using System;
using Models.ViewModels;
using Models.ViewModels.Portal;
using Models.Context.Legacy;
using Elastic.Models.Data;
using System.Text;
using Elastic.Models.Contracts;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Areas.Admin))]
  [Authorize]
  public class MSProgramController : BaseController
  {
    private readonly IConsultationService service;
    public MSProgramController(IConsultationService _service)
    {
      service = _service;
    }
    public IActionResult Index(int type, int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      ViewBag.type = type;
      return View();
    }
    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, string term, int type, int lang)
    {



      var data = service.Program_Select(lang, type, term.EmptyToNull());


      var filtered = data;
      var response = request.GetResponse(data, filtered);

      return new DataTablesJsonResult(response, true);
    }


    public IActionResult Add(int type, int lang)
    {
      var model = new MSProgram()
      {
        ProgramTypeId = type,
        LanguageId = lang,
        IsActive = true,
        DateFrom=DateTime.Now,
        DateTo=DateTime.Now.AddMonths(1)
      };
      SetViewBag(model);
      return View(nameof(Edit), model);
    }
    [HttpPost]
    public IActionResult Add(MSProgram model)
    {
      SetViewBag(model);
      if (!ModelState.IsValid)
      {
        return View(nameof(Edit), model);
      }

      SetSavedMessage = service.Program_SaveData(model);
      if (SetSavedMessage)
      {
        return RedirectToAction(nameof(Edit), new { id = model.Id });
      }
      return View(nameof(Edit), model);
    }

    public IActionResult Edit(int id)
    {
      var model = service.Find<MSProgram>(id);
      SetViewBag(model);
      return View(model);
    }

    [HttpPost]
    public IActionResult Edit(MSProgram model)
    {
      SetViewBag(model);
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      this.SetSavedMessage = service.Program_SaveData(model);
   
      return View(model);
    }

    private void SetViewBag(MSProgram model)
    {
      //ViewBag.categories = service.PublicationCategories_SelectCombo().ToSelectList(model.PublicationCategoryId);
    }
  }
}