using Models.Context.Legacy;
using Models.ViewModels.Portal;
using System.Linq;
using System;
using WebCommon.Services;
using WebCommon.Models;
using System.Collections.Generic;

namespace Models.Contracts
{
    public interface INewsService : IBaseService
    {
        NewsCategories NewsCategories_GetById(int id);
        IEnumerable<TextValueVM> NewsCategories_SelectCombo(int lang = GlobalConstants.LangBG);
        IQueryable<ArticleListAdminVM> News_AdminSelect(DateTime? dateFrom, DateTime? dateTo, int? category, string term, bool activeOnly);
        IQueryable<ArticleListVM> News_Select(int? category, string term, int lang = GlobalConstants.LangBG);
        ArticleVM News_GetById(int id);

        bool News_SaveData(News model);
    }
}
