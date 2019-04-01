using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels.PCSubjectsModels;
using System.Collections.Generic;
using System.Linq;

namespace Models.Contracts
{
	public interface IPCSubjectsService
	{
		IQueryable<PCSubjectsListViewModel> GetPCSubjectsList(string name, string eik, int pcSubjectsTypeID);
		PCSubjectsViewModel GetPCSubjects(int id);
		bool SavePCSubjects(PCSubjectsViewModel model);

		IEnumerable<SelectListItem> GetPCSubjectTypesDDL(bool addAll = true);
		IQueryable<PCSubjectsListViewModel> GetPCSubjectsAutocompleteEIK(string eik);
		IQueryable<PCSubjectsListViewModel> GetPCSubjectsAutocompleteName(string name);

    IEnumerable<SelectListItem> GetCategoriesDDL(int categoryId, int? selectedId);

    IQueryable<PCSubjectsExportListViewModel> GetPCSubjectsGetExport();
  }
}
