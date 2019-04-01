using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels;
using System.Linq;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Admin))]
  [Authorize(Roles = GlobalConstants.Roles.Admin)]
  public class InstitutionTypeController : BaseAdminController
  {
    public readonly IInstitutionTypeService institutionTypeService;

    public InstitutionTypeController(IInstitutionTypeService _institutionTypeService)
    {
      institutionTypeService = _institutionTypeService;
    }

    public IActionResult Index(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, int active = -1, int lang = GlobalConstants.LangBG)
    {
      IQueryable<InstitutionTypeListVM> data = institutionTypeService.GetInstitutionTypeList(active, lang);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult Add(int lang)
    {
      var model = new InstitutionTypeVM()
      {
        LanguageId = lang,
        IsActive = true
      };

      return View("Edit", model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      InstitutionTypeVM model = institutionTypeService.GetItem(id);

      return View(model);
    }

    [HttpPost]
    public IActionResult Edit(InstitutionTypeVM model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      SetSavedMessage = institutionTypeService.SaveItem(model);

      return View(model);
    }
  }
}