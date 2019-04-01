using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.LinksModels;
using System.Collections.Generic;
using System.Linq;

namespace Models.Contracts
{
	public interface ILinksService
	{
		IQueryable<LinksCateroriesListViewModel> GetLinksCategories(int active, int lang = GlobalConstants.LangBG);
		bool SaveLinksCategories(LinksCategoriesViewModel model);
		LinksCategoriesViewModel GetLinksCategory(int id);

		IQueryable<LinksListViewModel> GetLinksList(int active, int linksCategoryId, int lang = GlobalConstants.LangBG);
		LinksViewModel GetLinks(int id);
		bool SaveLinks(LinksViewModel model);

		IEnumerable<SelectListItem> GetLinksCategoriesDDL(int lang = GlobalConstants.LangBG);
		void OrderLinksCategories(int id, bool moveUp = true, int lang = GlobalConstants.LangBG);
		void OrderLinks(int id, bool moveUp = true, int lang = GlobalConstants.LangBG);
	}
}
