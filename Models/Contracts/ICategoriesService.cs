using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.CategoriesModels;
using System.Collections.Generic;
using System.Linq;

namespace Models.Contracts
{
	public interface ICategoriesService
	{
		IQueryable<CateroriesListViewModel> GetCategories(int active, int parentId, int sectionId);
		bool SaveCategory(CategoryViewModel model);
		CategoryViewModel GetCategory(int id);
		IEnumerable<SelectListItem> GetParentCategoriesDDL();
		IEnumerable<SelectListItem> GetSectionCategoriesDDL(int parentId);
	}
}
