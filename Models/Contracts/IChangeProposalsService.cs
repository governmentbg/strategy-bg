using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Services;

namespace Models.Contracts
{
	public interface IChangeProposalsService : IBaseService
	{
		IQueryable<ChangeProposalsListViewModel> GetChangeProposalsList(int active, int CategoryId, bool isMunicipality, bool? approved, bool? rejected);
		ChangeProposalsViewModel GetChangeProposals(int id);
		bool SaveChangeProposals(ChangeProposalsViewModel model);
		string GetCategoryFullText(ChangeProposalsViewModel model);
	}
}
