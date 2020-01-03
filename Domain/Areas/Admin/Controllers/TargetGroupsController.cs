using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.TargetGroupsModel;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	public class TargetGroupsController : BaseAdminController
    {
		private readonly ITargetGroupsService targetGroupsService;
		private readonly IUserContext userContext;

		public TargetGroupsController(ITargetGroupsService _targetGroupsService, IUserContext _userContext)
		{
			targetGroupsService = _targetGroupsService;
			userContext = _userContext;
		}

		#region TargetGroups
		public IActionResult ListTargetGroups()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LoadDataTargetGroups(IDataTablesRequest request, int active = -1)
		{
			IQueryable<TargetGroupsListViewModel> data = targetGroupsService.GetTargetGroupsList(active);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddTargetGroups()
		{
			var model = new TargetGroupsViewModel();
			model.IsActive = true;

			return View("EditTargetGroups", model);
		}

		[HttpGet]
		public IActionResult EditTargetGroups(int id)
		{
			var model = targetGroupsService.GetTargetGroups(id);

			return View("EditTargetGroups", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditTargetGroups(TargetGroupsViewModel model)
		{
			SetSavedMessage = false;

			if (!ModelState.IsValid)
			{
				return View("EditTargetGroups", model);
			}

			SetSavedMessage = targetGroupsService.SaveTargetGroups(model);

			if (SetSavedMessage)
			{
				return RedirectToAction(nameof(EditTargetGroups), new { id = model.Id });
			}

			return View("EditTargetGroups", model);
		}
		#endregion
	}
}