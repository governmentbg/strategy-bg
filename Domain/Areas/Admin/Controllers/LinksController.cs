using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels.LinksModels;
using Models.Contracts;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Admin))]
  [Authorize(Roles = GlobalConstants.Roles.Admin)]
  public class LinksController : BaseController
  {
    private readonly ILinksService linksService;
    private readonly IUserContext userContext;

    public LinksController(ILinksService _linksService, IUserContext _userContext)
    {
      linksService = _linksService;
      userContext = _userContext;
    }

    #region Links - Categories
    public IActionResult ListLinksCategories(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      return View();
    }

    [HttpPost]
    public IActionResult LoadDataLinksCategories(IDataTablesRequest request, int active = -1, int lang = GlobalConstants.LangBG)
    {
      IQueryable<LinksCateroriesListViewModel> data = linksService.GetLinksCategories(active, lang);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult AddLinksCategory(int lang)
    {
			var model = new LinksCategoriesViewModel()
      {
        LanguageId = lang,
        IsActive = true,
        IsApproved = true,
        IsDeleted = false
      };

      return View("EditLinksCategories", model);
    }

    [HttpGet]
    public IActionResult EditLinksCategories(int id)
    {
      var model = linksService.GetLinksCategory(id);

      return View("EditLinksCategories", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditLinksCategories(LinksCategoriesViewModel model)
    {
      SetSavedMessage = false;

      if (!ModelState.IsValid)
      {
        return View("EditLinksCategories", model);
      }

      SetSavedMessage = linksService.SaveLinksCategories(model);

      if (SetSavedMessage)
      {
        return RedirectToAction(nameof(EditLinksCategories), new { id = model.Id });
      }

      return View("EditLinksCategories", model);
    }
    #endregion

    #region Links
    public IActionResult ListLinks(int linksCategoryId, int active = 1, int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      SetComboViewBags(lang);

      return View();
    }

    [HttpPost]
    public IActionResult LoadDataLinks(IDataTablesRequest request, int linksCategoryId, int active = 1, int lang = GlobalConstants.LangBG)
    {
      IQueryable<LinksListViewModel> data = linksService.GetLinksList(active, linksCategoryId, lang);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult AddLinks(int lang = GlobalConstants.LangBG)
    {
      var model = new LinksViewModel()
      {
        IsActive = true,
        IsDeleted = false,
        IsApproved = true,
        LanguageId = lang
      };

      SetComboViewBags();

      return View("EditLinks", model);
    }

    [HttpGet]
    public IActionResult EditLinks(int id)
    {
      var model = linksService.GetLinks(id);
      SetComboViewBags();

      return View("EditLinks", model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditLinks(LinksViewModel model)
    {
      SetSavedMessage = false;
      SetComboViewBags();

      if (!ModelState.IsValid)
      {
        return View("EditLinks", model);
      }

      SetSavedMessage = linksService.SaveLinks(model);

      if (SetSavedMessage)
      {
        return RedirectToAction(nameof(EditLinks), new { id = model.Id });
      }

      return View("EditLinks", model);
    }

    private void SetComboViewBags(int lang = GlobalConstants.LangBG)
    {
      ViewBag.LinksCategoryID_ddl = linksService.GetLinksCategoriesDDL(lang);
    }
    #endregion

    #region Links - Order
    public IActionResult OrderLinksCategories(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      return View("OrderLinksCategories");
    }

    public IActionResult OrderLinksCategoriesUp(int id, int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      linksService.OrderLinksCategories(id, true, lang);
      return View("OrderLinksCategories");
    }

    public IActionResult OrderLinksCategoriesDown(int id, int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      linksService.OrderLinksCategories(id, false, lang);
      return View("OrderLinksCategories");
    }

    public IActionResult OrderLinks(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      SetComboViewBags();
      return View("OrderLinks");
    }

    public IActionResult OrderLinksUp(int id, int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      SetComboViewBags();
      linksService.OrderLinks(id, true, lang);
      return View("OrderLinks");
    }

    public IActionResult OrderLinksDown(int id, int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      SetComboViewBags();
      linksService.OrderLinks(id, false, lang);
      return View("OrderLinks");
    }
    #endregion
  }
}