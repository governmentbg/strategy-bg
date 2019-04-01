using Models.ViewModels;
using System.Linq;

namespace Models.Contracts
{
  public interface IDocumentKindService
  {
    IQueryable<DocumentKindListVM> GetDocumentKindList(int active = -1, int lang = GlobalConstants.LangBG);
    DocumentKindVM GetItem(int id);
    bool SaveItem(DocumentKindVM model);
  }
}
