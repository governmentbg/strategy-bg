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
  public class DocumentKindController : BaseAdminController
  {
    public readonly IDocumentKindService documentKindService;

    public DocumentKindController(IDocumentKindService _documentKindService)
    {
      documentKindService = _documentKindService;
    }

    public IActionResult Index(int lang = GlobalConstants.LangBG)
    {
      ViewBag.lang = lang;
      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, int active = -1, int lang = GlobalConstants.LangBG)
    {
      IQueryable<DocumentKindListVM> data = documentKindService.GetDocumentKindList(active, lang);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpGet]
    public IActionResult Add(int lang)
    {
      var model = new DocumentKindVM()
      {
        LanguageId = lang,
        IsActive = true
      };

      return View("Edit", model);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
      DocumentKindVM model = documentKindService.GetItem(id);

      return View(model);
    }

    [HttpPost]
    public IActionResult Edit(DocumentKindVM model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      SetSavedMessage = documentKindService.SaveItem(model);

      return View(model);
    }
  }
}