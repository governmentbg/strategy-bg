using Models.ViewModels;
using System.Linq;

namespace Models.Contracts
{
  public interface IBannersService
  {
    IQueryable<BannersListVM> GetBannersList(int active = -1, int lang = GlobalConstants.LangBG);
    BannersVM GetItem(int id);
    bool SaveItem(BannersVM model);
  }
}
