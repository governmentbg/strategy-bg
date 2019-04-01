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
  public class BannersController : BaseAdminController
  {
    public readonly IBannersService BannersService;

    public BannersController(IBannersService _BannersService)
    {
      BannersService = _BannersService;
    }

    public IActionResult Index(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, int active = -1, int lang = GlobalConstants.LangBG)
    {
      IQueryable<BannersListVM> data = BannersService.GetBannersList(active, lang);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult Add(int lang)
    {
      var model = new BannersVM()
      {
        LanguageId = lang,
        IsActive = true,
        IsDeleted = false,
        IsApproved = true
      };

      return View("Edit", model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      BannersVM model = BannersService.GetItem(id);

      return View(model);
    }

    [HttpPost]
    public IActionResult Edit(BannersVM model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      SetSavedMessage = BannersService.SaveItem(model);

      return View(model);
    }
  }
}