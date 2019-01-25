using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.LinksModels;
using System.Collections.Generic;
using System.Linq;

namespace Models.Contracts
{
	public interface ILinksService
	{
		IQueryable<LinksCateroriesListViewModel> GetLinksCategories(int active);
		bool SaveLinksCategories(LinksCategoriesViewModel model);
		LinksCategoriesViewModel GetLinksCategory(int id);

		IQueryable<LinksListViewModel> GetLinksList(int active, int linksCategoryId);
		LinksViewModel GetLinks(int id);
		bool SaveLinks(LinksViewModel model);

		IEnumerable<SelectListItem> GetLinksCategoriesDDL();
		void OrderLinksCategories(int id, bool moveUp = true);
		void OrderLinks(int id, bool moveUp = true);
	}
}
