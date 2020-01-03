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
  public class PublicationCategoriesController : BaseAdminController
  {
    public readonly IPublicationCategoriesService publicationCategoriesService;

    public PublicationCategoriesController(IPublicationCategoriesService _publicationCategoriesService)
    {
      publicationCategoriesService = _publicationCategoriesService;
    }

    public IActionResult Index(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, int active = -1, int lang = GlobalConstants.LangBG)
    {
      IQueryable<PublicationCategoriesListVM> data = publicationCategoriesService.GetPublicationCategoriesList(active, lang);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult Add(int lang)
    {
      var model = new PublicationCategoriesVM()
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
      PublicationCategoriesVM model = publicationCategoriesService.GetItem(id);

      return View(model);
    }

    [HttpPost]
    public IActionResult Edit(PublicationCategoriesVM model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      SetSavedMessage = publicationCategoriesService.SaveItem(model);

      return View(model);
    }
  }
}