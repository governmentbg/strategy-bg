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
		public IActionResult ListLinksCategories()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LoadDataLinksCategories(IDataTablesRequest request, int active = -1)
		{
			IQueryable<LinksCateroriesListViewModel> data = linksService.GetLinksCategories(active);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddLinksCategory()
		{
			var model = new LinksCategoriesViewModel();
			model.IsActive = true;

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
		public IActionResult ListLinks(int linksCategoryId, int active = 1)
		{
			SetComboViewBags();

			return View();
		}

		[HttpPost]
		public IActionResult LoadDataLinks(IDataTablesRequest request, int linksCategoryId, int active = 1)
		{
			IQueryable<LinksListViewModel> data = linksService.GetLinksList(active, linksCategoryId);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddLinks()
		{
			var model = new LinksViewModel();
			model.IsActive = true;
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

		private void SetComboViewBags()
		{
			ViewBag.LinksCategoryID_ddl = linksService.GetLinksCategoriesDDL();
		}
		#endregion

		#region Links - Order
		public IActionResult OrderLinksCategories()
		{
			return View("OrderLinksCategories");
		}

		public IActionResult OrderLinksCategoriesUp(int id)
		{
			linksService.OrderLinksCategories(id, true);
			return View("OrderLinksCategories");
		}

		public IActionResult OrderLinksCategoriesDown(int id)
		{
			linksService.OrderLinksCategories(id, false);
			return View("OrderLinksCategories");
		}

		public IActionResult OrderLinks()
		{
			SetComboViewBags();
			return View("OrderLinks");
		}

		public IActionResult OrderLinksUp(int id)
		{
			SetComboViewBags();
			linksService.OrderLinks(id, true);
			return View("OrderLinks");
		}

		public IActionResult OrderLinksDown(int id)
		{
			SetComboViewBags();
			linksService.OrderLinks(id, false);
			return View("OrderLinks");
		}
		#endregion
	}
}