using System.Linq;
using WebCommon.Models;
using WebCommon.Services;
using Models.Context.Application;

namespace Models.Contracts
{
    public interface INomService : IBaseService
    {
        IQueryable<TextValueVM> Country_Select(string lang);
        IQueryable<Country> Country_Select();
        Country Country_GetByID(int id);
        bool Country_SaveData(Country model);
        IQueryable<TextValueVM> RiskCategory_Combo(int? parent = -1);
        IQueryable<TextValueVM> CountryType_Combo(int? parent = -1);
        IQueryable<TextValueVM> ActivityType_Select(string lang);
        IQueryable<TextValueVM> DocumentType_Select(string lang);
        IQueryable<TextValueVM> LocalEntityType_Select(string lang);
        IQueryable<TextValueVM> Ekkate_Select(string lang, string parentCode);
    }
}
