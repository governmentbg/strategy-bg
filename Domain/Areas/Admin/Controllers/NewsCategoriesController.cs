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
  public class NewsCategoriesController : BaseAdminController
  {
    public readonly INewsCategoriesService newsCategoriesService;

    public NewsCategoriesController(INewsCategoriesService _newsCategoriesService)
    {
      newsCategoriesService = _newsCategoriesService;
    }

    public IActionResult Index(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, int active = -1, int lang = GlobalConstants.LangBG)
    {
      IQueryable<NewsCategoriesListVM> data = newsCategoriesService.GetNewsCategoriesList(active, lang);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult Add(int lang)
    {
      var model = new NewsCategoriesVM()
      {
        LanguageId = lang,
        IsActive = true,
        IsDeleted = false
      };

      return View("Edit", model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      NewsCategoriesVM model = newsCategoriesService.GetItem(id);

      return View(model);
    }

    [HttpPost]
    public IActionResult Edit(NewsCategoriesVM model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      SetSavedMessage = newsCategoriesService.SaveItem(model);

      return View(model);
    }
  }
}