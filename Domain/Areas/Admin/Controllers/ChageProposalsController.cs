using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.Contracts;
using Models.ViewModels;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	[Authorize(Roles = GlobalConstants.Roles.Admin)]
	public class ChangeProposalsController : BaseController
	{
		private readonly IChangeProposalsService changeProposalsService;
		private readonly IUserContext userContext;
		private readonly INomenclatureService nomService;

		public ChangeProposalsController(IChangeProposalsService _changeProposalsService, IUserContext _userContext, INomenclatureService _nomService)
		{
			changeProposalsService = _changeProposalsService;
			userContext = _userContext;
			nomService = _nomService;
		}

		#region Chage Proposals
		public IActionResult ListChangeProposals()
		{
			SetViewBags(true);
			return View();
		}

		[HttpPost]
		public IActionResult LoadDataChangeProposals(IDataTablesRequest request, int active = -1, int categoryId = -1, bool isMunicipality = false)
		{
			IQueryable<ChangeProposalsListViewModel> data = changeProposalsService.GetChangeProposalsList(active, categoryId, isMunicipality, null, null);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddChangeProposals()
		{
			var model = new ChangeProposalsViewModel();
			model.IsActive = true;

			SetViewBags();

			return View("EditChangeProposals", model);
		}

		[HttpGet]
		public IActionResult EditChangeProposals(int id)
		{
			var model = changeProposalsService.GetChangeProposals(id);

			SetViewBags();

			return View("EditChangeProposals", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditChangeProposals(ChangeProposalsViewModel model)
		{
			SetSavedMessage = false;
			SetViewBags();

			if (!ModelState.IsValid 
				|| (model.CategoryMasterId == 1 && model.CategoryId < 1) 
				|| (model.CategoryMasterId == 2 && (model.MunicipalityId == null || model.MunicipalityId == -1)))
			{
				return View("EditChangeProposals", model);
			}

			SetSavedMessage = changeProposalsService.SaveChangeProposals(model);

			if (SetSavedMessage)
			{
				return RedirectToAction(nameof(EditChangeProposals), new { id = model.Id });
			}

			return View("EditChangeProposals", model);
		}
		#endregion

		private void SetViewBags(bool setTextAll = false)
		{
			ViewBag.catMasters = nomService.ComboCategories(0)
				.Select(g => new SelectListItem()
				{
					Text = g.Text,
					Value = g.Value
				})
				.ToList();

			ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Categories.Type_National)
				.Select(g => new SelectListItem()
				{
					Text = g.Text,
					Value = g.Value
				})
				.Prepend(new SelectListItem()
				{
					Text = setTextAll ? "Всички" : "Изберете",
					Value = "-1"
				})
				.ToList();
			
			ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Categories.Type_District)
				.Select(g => new SelectListItem()
				{
					Text = g.Text,
					Value = g.Value
				})
				.Prepend(new SelectListItem()
				{
					Text = setTextAll ? "Всички" : "Изберете",
					Value = "-1"
				})
				.ToList();
		}
	}
}