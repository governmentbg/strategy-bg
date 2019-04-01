using Microsoft.AspNetCore.Mvc;
using WebCommon.Services;
using Models.ViewModels.StandartForms;
using System.ComponentModel;
using Rotativa.AspNetCore;

namespace Domain.Controllers
{
  public class StandartFormsController : BasePortalController
    {

    private readonly IUserContext userContext;
    public StandartFormsController(IUserContext _userContext)
    {
      userContext = _userContext;
    }

    public IActionResult Index()
    {
      return View("Index");
    }

    public IActionResult Index_StandartForm_1()
    {
      return View("Index_StandartForm_1");
    }
    public IActionResult Index_StandartForm_2()
    {
      return View("Index_StandartForm_2");
    }
    public IActionResult Index_StandartForm_3()
    {
      StandartForm_3VM model = new StandartForm_3VM();

      return View("Index_StandartForm_3", model);
    }



    [HttpPost]
    public IActionResult ExportSF1ToPDF(StandartForm_1VM model)
    {
      return new ViewAsPdf("_sf1PDF", model);
    }

    [HttpPost]
    public IActionResult ExportSF2ToPDF(StandartForm_2VM model)
    {
      return new ViewAsPdf("_sf2PDF", model);
    }

    [HttpPost]
    public IActionResult ExportSF3ToPDF(StandartForm_3VM model)
    {
      return new ViewAsPdf("_sf3PDF", model);
    }
  }
}