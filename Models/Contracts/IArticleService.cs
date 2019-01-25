using Models.Context.Legacy;
using Models.ViewModels.Portal;
using System.Linq;
using System;
using WebCommon.Services;
using WebCommon.Models;
using System.Collections.Generic;

namespace Models.Contracts
{
    public interface IArticleService : IBaseService
    {
        ArticleCategories ArticleCategories_GetById(int id);
        IEnumerable<TextValueVM> ArticleCategories_SelectCombo();
        IQueryable<ArticleListAdminVM> Article_AdminSelect(DateTime? dateFrom, DateTime? dateTo, int? category, string term);
        IQueryable<ArticleListVM> Article_Select(int? category, string term);
        ArticleVM Article_GetById(int id);

        bool Article_SaveData(Articles model);
    }
}
