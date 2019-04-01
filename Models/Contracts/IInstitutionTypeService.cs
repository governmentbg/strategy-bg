using Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Models;

namespace Models.Contracts
{
  public interface IInstitutionTypeService
  {
    IQueryable<InstitutionTypeListVM> GetInstitutionTypeList(int active = -1, int lang = GlobalConstants.LangBG);
    InstitutionTypeVM GetItem(int id);
    bool SaveItem(InstitutionTypeVM model);
  }
}
