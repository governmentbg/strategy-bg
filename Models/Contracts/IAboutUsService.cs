using Models.ViewModels.AboutUs;
using System.Linq;
using WebCommon.Services;

namespace Models.Contracts
{
	public interface IAboutUsService : IBaseService
	{
		IQueryable<AboutUsListViewModel> GetAboutUsList(int active);
		AboutUsViewModel GetAboutUs(int id);
		bool SaveAboutUs(AboutUsViewModel model);
	}
}
