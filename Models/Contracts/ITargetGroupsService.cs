using Models.ViewModels.TargetGroupsModel;
using System.Linq;

namespace Models.Contracts
{
	public interface ITargetGroupsService
	{
		IQueryable<TargetGroupsListViewModel> GetTargetGroupsList(int active);
		bool SaveTargetGroups(TargetGroupsViewModel model);
		TargetGroupsViewModel GetTargetGroups(int id);
	}
}
