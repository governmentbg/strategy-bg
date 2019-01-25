using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.AboutUs;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	[Authorize(Roles = GlobalConstants.Roles.Admin)]
	public class AboutUsController : BaseController
	{
		private readonly IAboutUsService aboutUsService;
		private readonly IUserContext userContext;

		public AboutUsController(IAboutUsService _aboutUsService, IUserContext _userContext)
		{
			aboutUsService = _aboutUsService;
			userContext = _userContext;
		}

		#region About Us
		public IActionResult ListAboutUs()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LoadDataAboutUs(IDataTablesRequest request, int active = -1)
		{
			IQueryable<AboutUsListViewModel> data = aboutUsService.GetAboutUsList(active);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddAboutUs()
		{
			var model = new AboutUsViewModel();
			model.IsActive = true;

			return View("EditAboutUs", model);
		}

		[HttpGet]
		public IActionResult EditAboutUs(int id)
		{
			var model = aboutUsService.GetAboutUs(id);

			return View("EditAboutUs", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditAboutUs(AboutUsViewModel model)
		{
			SetSavedMessage = false;

			if (!ModelState.IsValid)
			{
				return View("EditAboutUs", model);
			}

			SetSavedMessage = aboutUsService.SaveAboutUs(model);

			if (SetSavedMessage)
			{
				return RedirectToAction(nameof(EditAboutUs), new { id = model.Id });
			}

			return View("EditAboutUs", model);
		}
		#endregion
	}
}