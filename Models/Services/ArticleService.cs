using Microsoft.Extensions.Logging;
using Models.Context;
using System.Linq;
using Models.ViewModels.Portal;
using Microsoft.EntityFrameworkCore;
using Models.Context.Legacy;
using Models.Contracts;
using System;
using WebCommon.Services;
using WebCommon.Models;
using System.Collections.Generic;

namespace Models.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        private readonly ILogger logger;
        private readonly ICommonService commService;
        private readonly IUserContext userContext;

        public ArticleService(
            MainContext context,
            ICommonService _commService,
            ILogger<ArticleService> _logger,
            IUserContext _userContext)
        {
            this.db = context;
            commService = _commService;
            logger = _logger;
            userContext = _userContext;
        }

        public ArticleCategories ArticleCategories_GetById(int id)
        {
            return Find<ArticleCategories>(id);
        }

        public IEnumerable<TextValueVM> ArticleCategories_SelectCombo()
        {
            return All<ArticleCategories>()
                    .Where(x => x.IsActive && !x.IsDeleted && x.IsApproved && x.LanguageId == GlobalConstants.LangBG)
                    .OrderBy(x => x.Priority)
                     .Select(x => new TextValueVM
                     {
                         Value = x.Id.ToString(),
                         Text = x.Name
                     });
        }

        public IQueryable<ArticleListAdminVM> Article_AdminSelect(DateTime? dateFrom, DateTime? dateTo, int? category, string term)
        {
            return
                (from n in
                db.Articles
                .Include(x => x.ArticleCategory)
                .Where(x => (x.Date >= (dateFrom ?? x.Date)) && (x.Date <= (dateTo ?? x.Date)))
                .Where(x => x.ArticleCategoryId == (category ?? x.ArticleCategoryId) && x.Title.Contains(term ?? x.Title))
                //.Where(x => x.IsActive && !x.IsDeleted && !x.IsArchive && x.IsApproved)
                .OrderByDescending(x => x.Date)

                 join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PartnershipImage)
                 on n.Id equals f.source_id into n_f
                 from x in n_f.DefaultIfEmpty()
                 select new ArticleListAdminVM
                 {
                     Id = n.Id,
                     Title = n.Title,
                     CategoryId = n.ArticleCategoryId,
                     CategoryName = n.ArticleCategory.Name,
                     EventDate = n.Date,
                     LastModified = n.DateModified,
                     MainImageFileId = (x != null) ? x.cdn_file_id : null,
                     IsActive = n.IsActive,
                     IsDeleted = n.IsDeleted,
                     IsApproved = n.IsApproved
                 }).AsQueryable();


        }

        public ArticleVM Article_GetById(int id)
        {
            var model = db.Articles
                .Include(x => x.ArticleCategory)
                .Where(x => x.Id == id)
                .OrderByDescending(x => x.Date)
                .Select(x => new ArticleVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Text,
                    CategoryId = x.ArticleCategoryId,
                    CategoryName = x.ArticleCategory.Name,
                    EventDate = x.Date,
                    LastModified = x.DateModified
                }).FirstOrDefault();


            var images = commService.FileCdn_GetList(GlobalConstants.SourceTypes.PartnershipImage, model.Id).ToList();
            if (images.Any())
            {
                model.MainImageFileId = images.FirstOrDefault().FileId;
            }
            return model;
        }

        public bool Article_SaveData(Articles model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var saved = Find<Articles>(model.Id);
                    saved.ArticleCategoryId = model.ArticleCategoryId;
                    saved.Title = model.Title;
                    saved.Text = model.Text;
                    saved.IsOnMainPage = model.IsOnMainPage;
                    saved.IsMainTopic = model.IsMainTopic;
                    saved.IsActive = model.IsActive;
                    saved.IsApproved = model.IsApproved;
                    saved.IsDeleted = model.IsDeleted;
                    saved.ModifiedByUserId = userContext.UserId;
                    saved.DateModified = DateTime.Now;

                    All<Articles>().Update(saved);
                    db.SaveChanges();
                }
                else
                {
                    model.LanguageId = GlobalConstants.LangBG;
                    model.CreatedByUserId = userContext.UserId;
                    model.DateCreated = DateTime.Now;

                    model.ModifiedByUserId = userContext.UserId;
                    model.DateModified = model.DateCreated;

                    All<Articles>().Add(model);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message);
                return false;
            }
        }

        public IQueryable<ArticleListVM> Article_Select(int? category, string term)
        {
            return
                (from n in
                db.Articles
                .Include(x => x.ArticleCategory)
                .Where(x => x.ArticleCategoryId == (category ?? x.ArticleCategoryId) && x.Title.Contains(term ?? x.Title))
                .OrderByDescending(x => x.Date)

                 join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PartnershipImage)
                 on n.Id equals f.source_id into n_f
                 where n.IsActive && !n.IsDeleted && n.IsApproved
                 from x in n_f.DefaultIfEmpty()
                 select new ArticleListVM
                 {
                     Id = n.Id,
                     Title = n.Title,
                     CategoryId = n.ArticleCategoryId,
                     CategoryName = n.ArticleCategory.Name,
                     EventDate = n.Date,
                     LastModified = n.DateModified,
                     MainImageFileId = (x != null) ? x.cdn_file_id : null
                 }).AsQueryable();

        }

    }
}
