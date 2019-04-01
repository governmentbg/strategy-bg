using Models.ViewModels;
using System.Linq;

namespace Models.Contracts
{
  public interface IPublicationCategoriesService
  {
    IQueryable<PublicationCategoriesListVM> GetPublicationCategoriesList(int active = -1, int lang = GlobalConstants.LangBG);
    PublicationCategoriesVM GetItem(int id);
    bool SaveItem(PublicationCategoriesVM model);
  }
}
