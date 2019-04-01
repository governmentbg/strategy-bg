using Models.ViewModels;
using System.Collections.Generic;
using WebCommon.Models;
using Models.Context.Legacy;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.Categories;

namespace Models.Contracts
{
    public interface INomenclatureService
    {
        HierarchicalNomenclatureDisplayModel SearchCategory(string query);

        HierarchicalNomenclatureDisplayItem GetCategory(int id);

        IEnumerable<TextValueVM> ComboCategories(int categoryId, int municipalityId = -1);
        IEnumerable<SelectListItem> GetDocumentTypesDDL();
        IEnumerable<SelectListItem> GetInstitutionTypesDDL();

        IEnumerable<T> FilterByCategories<T>(IEnumerable<T> data, int catMasterId, int? catId, int? munId) where T : ICategorySearchableItem;

        IEnumerable<SelectListItem> GetLinksCategoriesDDL();

        List<SelectListItem> GetCategories();
    }
}
