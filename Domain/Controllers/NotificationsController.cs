using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Rotativa.AspNetCore;
using System.Linq;
using WebCommon.Extensions;


namespace Domain.Controllers
{
  public class NotificationsController : BasePortalController
  {
    private readonly INotificationService service;
    private readonly INomenclatureService nomService;
    public NotificationsController(INotificationService _notificationService, INomenclatureService _nomService)
    {
      service = _notificationService;
      nomService = _nomService;
    }
    public IActionResult Index()
    {

      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request)
    {

      var data = service.CurrentUserSystemNotification_List();
      var filteredData = data;

      var response = request.GetResponse(data, filteredData);
      return new DataTablesJsonResult(response, true);
    }
    public IActionResult View(int id)
    {
      var model = service.CurrentUserSystemNotification(id);
      var b = service.CurrentUserSystemNotification_MarkAsRead(id);
      if (model != null)
      {
        model.Title = model.Title.DecodeIfNeeded();
        model.Body = model.Body.DecodeIfNeeded();
      }

      return View(model);
    }

  }
}