using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels.CategoriesModels;
using Models.Contracts;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	[Authorize(Roles = GlobalConstants.Roles.Admin)]
	public class CategoriesController : BaseController
	{
		private readonly ICategoriesService categoriesService;
		private readonly IUserContext userContext;

		public CategoriesController(ICategoriesService _categoriesService, IUserContext _userContext)
		{
			categoriesService = _categoriesService;
			userContext = _userContext;
		}

		#region Categories
		public IActionResult ListCategories(int lang = GlobalConstants.LangBG)
		{
      ViewBag.lang = lang;
      SetComboViewBags();
			return View();
		}

		[HttpPost]
		public IActionResult LoadDataCategories(IDataTablesRequest request, int active = -1, int parentId = 0, int sectionId = 0, int lang = GlobalConstants.LangBG)
		{
			IQueryable<CateroriesListViewModel> data = categoriesService.GetCategories(active, parentId, sectionId, lang);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddCategory(int lang)
		{
			var model = new CategoryViewModel()
      {
        LanguageId = lang,
        IsActive = true,
        IsDeleted = false,
        IsApproved = true
      };

			SetComboViewBags();

			return View("EditCategory", model);
		}

		[HttpGet]
		public IActionResult EditCategory(int id)
		{
			var model = categoriesService.GetCategory(id);
			SetComboViewBags(model.ParentId);

			return View("EditCategory", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditCategory(CategoryViewModel model)
		{
			SetSavedMessage = false;
			SetComboViewBags(model.ParentId);

			if (!ModelState.IsValid)
			{
				return View("EditCategory", model);
			}

			SetSavedMessage = categoriesService.SaveCategory(model);

			if (SetSavedMessage)
			{
				return RedirectToAction(nameof(EditCategory), new { id = model.Id });
			}

			return View("EditCategory", model);
		}
		#endregion

		private void SetComboViewBags(int parentId = -1)
		{
			ViewBag.ParentCategoryID_ddl = categoriesService.GetParentCategoriesDDL();
			ViewBag.SectionCategoryID_ddl = categoriesService.GetSectionCategoriesDDL(parentId);
		}

		[HttpGet]
		public IActionResult GetSections(int parentId)
		{
			return new JsonResult(categoriesService.GetSectionCategoriesDDL(parentId));
		}
	}
}