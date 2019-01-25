using Models.Context.Legacy;
using Models.ViewModels.Portal;
using System.Linq;
using System;
using WebCommon.Services;
using WebCommon.Models;
using System.Collections.Generic;

namespace Models.Contracts
{
    public interface IPublicationService : IBaseService
    {
        IEnumerable<TextValueVM> PublicationCategories_SelectCombo();
        IQueryable<ArticleListAdminVM> Publication_AdminSelect(DateTime? dateFrom, DateTime? dateTo, int? category, string term);

        PublicationCategories PublicationCategories_GetById(int id);

        IQueryable<ArticleListVM> Publication_Select(int? category, string term);
        ArticleVM Publication_GetById(int id);
        bool Publication_SaveData(Publications model);
    }
}
