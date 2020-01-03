using Models.ViewModels;
using System.Collections.Generic;
using WebCommon.Models;
using Models.Context.Legacy;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.Categories;
using System.Linq;

namespace Models.Contracts
{
    public interface INomenclatureService
    {
        HierarchicalNomenclatureDisplayModel SearchCategory(string query);

        HierarchicalNomenclatureDisplayItem GetCategory(int id);

        IEnumerable<TextValueVM> ComboCategories(int categoryId, int municipalityId = -1, bool isFromAdminPanel = false);
        IEnumerable<SelectListItem> GetDocumentTypesDDL();
        IEnumerable<SelectListItem> GetInstitutionTypesDDL();

        IEnumerable<T> FilterByCategories<T>(IEnumerable<T> data, int catMasterId, int? catId, int? munId) where T : ICategorySearchableItem;
        IQueryable<T> FilterByUserGroupRights<T>(IQueryable<T> data, int userId, bool isAdmin) where T : ICategorySearchableItem;

        IEnumerable<SelectListItem> GetLinksCategoriesDDL();
        IEnumerable<SelectListItem> GetLinksCategoriesDDL_ByUser();

        List<SelectListItem> GetCategories();

        List<SelectListItem> GetBaseCategories();

        List<SelectListItem> GetCategoriesByParentId(int parentId, int userId, bool isAdmin);

        List<SelectListItem> GetProgramsByType(int programType, int institutionId);

        List<SelectListItem> GetEmptyList();

        List<SelectListItem> GetActDocumentTypes();
    }
}
