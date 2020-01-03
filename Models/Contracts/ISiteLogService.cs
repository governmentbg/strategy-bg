using Models.ViewModels;
using System.Linq;

namespace Models.Contracts
{
    public interface ISiteLogService
    {
        IQueryable<SiteLogListVM> GetSiteLogList(int logType = -1);
        bool Log(string tableName, int recordId,bool approved, int action, string details);
    }
}
