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
  public class SiteLogController : BaseAdminController
  {
    public readonly ISiteLogService SiteLogService;

    public SiteLogController(ISiteLogService _SiteLogService)
    {
      SiteLogService = _SiteLogService;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult LoadData(IDataTablesRequest request, int logType = -1)
    {
      IQueryable<SiteLogListVM> data = SiteLogService.GetSiteLogList(logType);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }
  }
}