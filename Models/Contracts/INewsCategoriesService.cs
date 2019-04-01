using Models.ViewModels;
using System.Linq;

namespace Models.Contracts
{
  public interface INewsCategoriesService
  {
    IQueryable<NewsCategoriesListVM> GetNewsCategoriesList(int active = -1, int lang = GlobalConstants.LangBG);
    NewsCategoriesVM GetItem(int id);
    bool SaveItem(NewsCategoriesVM model);
  }
}
