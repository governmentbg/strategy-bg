using System.Collections.Generic;
using System.Linq;
using Models.Context;
using Models.ViewModels;

namespace Models.Contracts
{
    public interface IPageService
    {
        T Find<T>(object id) where T : class;

        IQueryable<PageVM> Select(int pageType, string lang, int? parentContentId, bool loadContent = false);
        IQueryable<TranslationVM> SelectTranslations(int pageType);

        IQueryable<PageVM> SelectPeerPages(int pageId);
        IQueryable<PageVM> SelectParentPages(string lang, int content_id);
        IEnumerable<TranslationVM> GetTranslations(int content_id);

        Page GetByID(int id);
        Page GetForTranslate(int id);
        Page GetByContentID(string lang, int content_id);
        int GetContentIdByUrl(int pageType, string url);
        int GetPageType(int? pageId, int? contentId);

        bool AddPage(Page model);
        bool UpdatePage(Page model);
        bool ChangeParent(int id, int newParent);
        bool ChangeOrder(int id, bool moveDown);

        PageType GetPageType(int id);

        IQueryable<SearchItemVM> SearchItems(string lang, string term);

        bool DeletePage(int pageId, bool deleteAllTranslation);

        IQueryable<PageLink> SelectPageLink(int pageId);
        bool SavePageLink(PageLink model);
        bool SavePageLinkFromSelectedPage(int pageId, int contentId, string lang);
        bool DeletePageLink(int id);

    }
}
