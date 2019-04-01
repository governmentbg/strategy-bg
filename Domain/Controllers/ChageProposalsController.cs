using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Context;
using Models.Context.Questionary;
using Models.Contracts;
using Models.ViewModels;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Controllers
{
	public class ChangeProposalsController : BasePortalController
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

		[HttpGet]
		public IActionResult ViewChangeProposals(int id)
		{
			var model = changeProposalsService.GetChangeProposals(id);

			model.CategoryMasterText = changeProposalsService.GetCategoryFullText(model);

			ViewBag.HasQuestionary = changeProposalsService.All<QuestionaryHeaders>().Where(x => x.SourceTypeId == GlobalConstants.SourceTypes.ChangeProposals && x.SourceId == id).Any();

			return View(model);
		}

		[HttpPost]
		public IActionResult LoadDataChangeProposals(IDataTablesRequest request, int categoryId = -1, bool isMunicipality = false)
		{
			IQueryable<ChangeProposalsListViewModel> data = changeProposalsService.GetChangeProposalsList(1, categoryId, isMunicipality, true, false);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		private void SetViewBags(bool setTextAll = false)
		{
			ViewBag.catMasters = nomService.ComboCategories(0)
				.Select(g => new SelectListItem()
				{
					Text = g.Text,
					Value = g.Value
				})
				.ToList();

			ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National)
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

			ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District)
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
		#endregion
	}
}