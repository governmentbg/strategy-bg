using Models.Context;
using Models.ViewModels;
using Models.ViewModels.Portal;
using System.Linq;
using WebCommon.Services;

namespace Models.Contracts
{
    public interface ICommonService : IBaseService
    {
        IQueryable<DocumentLinkVM> FileCdn_GetList(int sourceType, int sourceId);
        bool FileCdn_AppendUsedFile(string fileId, int sourceType, int sourceId);
        bool FileCdn_RemoveUsedFile(string fileId, int sourceType, int sourceId);

        IQueryable<GenericContentVM> GenericContent_Select();
        bool GenericContent_SaveData(GenericContent model);
    }
}
