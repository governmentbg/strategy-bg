using Models.ViewModels;
using System.Collections.Generic;
using WebCommon.Models;
using Models.Context.Legacy;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Models.Contracts
{
    public interface INomenclatureService
    {
        HierarchicalNomenclatureDisplayModel SearchCategory(string query);

        HierarchicalNomenclatureDisplayItem GetCategory(int id);

        IEnumerable<TextValueVM> ComboCategories(int categoryId);
    IEnumerable<SelectListItem> GetDocumentTypesDDL();
    IEnumerable<SelectListItem> GetInstitutionTypesDDL();
  }
}
