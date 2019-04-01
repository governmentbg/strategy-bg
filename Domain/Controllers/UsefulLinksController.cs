using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.LinksModels;
using System.Linq;

namespace Domain.Controllers
{
  public class UsefulLinksController : BasePortalController
  {
    private readonly ILinksService serviceLinks;

    public UsefulLinksController(ILinksService _serviceLinks)
    {
      serviceLinks = _serviceLinks;
    }

    public IActionResult Index(int category = -1)
    {
      ViewData["Title"] = "Полезни връзки";

      UsefulLinksCateroriesListViewModel model = new UsefulLinksCateroriesListViewModel();
      model.UsefulLinksCateroriesList = serviceLinks.GetLinksCategories(1).Select(c => new LinksCateroriesListViewModel
      {
        Id = c.Id,
        Name = c.Name
      }).ToList();

      return View(model);
    }

    [HttpPost]
    public JsonResult LoadDataGrid([FromBody]GridRequestModel data, int category = -1)
    {
      if (category == -1)
      {
        int.TryParse(data.param["category"].ToString(), out category);
      }

      var model = serviceLinks.GetLinksList(1, category);

      return Json(new GridResponseModel<LinksListViewModel>(data, model));
    }
  }
}