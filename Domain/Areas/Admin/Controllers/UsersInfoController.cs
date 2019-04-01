using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
  [Area(nameof(Admin))]
  [Authorize(Roles = GlobalConstants.Roles.Admin)]
  public class UsersInfoController : BaseController
  {
    private readonly IUsersInfoService usersInfoService;
    private readonly IUserContext userContext;

    public UsersInfoController(
      IUsersInfoService _usersInfoService
      , IUserContext _userContext
    )
    {
      usersInfoService = _usersInfoService;
      userContext = _userContext;
    }

    [HttpGet]
    public IActionResult GetUsersInfoData(int? userId, string userName, int? userType)
    {
      UsersInfoVM model = new UsersInfoVM();
      model = usersInfoService.UsersInfo_Select(userId, userName, userType);

      if (model != null)
      {
        model = usersInfoService.GetUserInCategories(model);
      }
      else
      {
        model = new UsersInfoVM
        {
          UserId = 0
        };
      }

      return View("UsersInfo", model);
    }

    [HttpPost]
    public IActionResult LoadConsultationsData(IDataTablesRequest request, int userId)
    {
      var data = usersInfoService.GetConsultations(userId);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    [HttpPost]
    public IActionResult LoadChangeProposalsData(IDataTablesRequest request, int userId)
    {
      var data = usersInfoService.GetChangeProposals(userId);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }
  }
}
