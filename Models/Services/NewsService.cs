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
    public class NewsService : BaseService, INewsService
    {
        private readonly ILogger logger;
        private readonly ICommonService commService;
        private readonly IUserContext userContext;

        public NewsService(
            MainContext context,
            ICommonService _commService,
            ILogger<NewsService> _logger,
            IUserContext _userContext)
        {
            this.db = context;
            commService = _commService;
            logger = _logger;
            userContext = _userContext;
        }

        public NewsCategories NewsCategories_GetById(int id)
        {
            return Find<NewsCategories>(id);
        }

        public IEnumerable<TextValueVM> NewsCategories_SelectCombo()
        {
            return All<NewsCategories>()
                    .Where(x => x.IsActive && !x.IsDeleted && x.IsApproved && x.LanguageId == GlobalConstants.LangBG)
                    .OrderBy(x => x.Name)
                     .Select(x => new TextValueVM
                     {
                         Value = x.Id.ToString(),
                         Text = x.Name
                     });
        }

        public IQueryable<ArticleListAdminVM> News_AdminSelect(DateTime? dateFrom, DateTime? dateTo, int? category, string term)
        {
            return
                (from n in
                db.News
                .Include(x => x.NewsCategory)
                .Where(x => (x.Date >= (dateFrom ?? x.Date)) && (x.Date <= (dateTo ?? x.Date)))
                .Where(x => x.NewsCategoryId == (category ?? x.NewsCategoryId) && x.Title.Contains(term ?? x.Title))
                //.Where(x => x.IsActive && !x.IsDeleted && !x.IsArchive && x.IsApproved)
                .OrderByDescending(x => x.Date)

                 join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.NewsImage)
                 on n.Id equals f.source_id into n_f
                 from x in n_f.DefaultIfEmpty()
                 select new ArticleListAdminVM
                 {
                     Id = n.Id,
                     Title = n.Title,
                     CategoryId = n.NewsCategoryId,
                     CategoryName = n.NewsCategory.Name,
                     EventDate = n.Date,
                     LastModified = n.DateModified,
                     IsRss = n.IsRss,
                     RssPostLink = n.RssPostLink,
                     MainImageFileId = (x != null) ? x.cdn_file_id : null,
                     IsActive = n.IsActive,
                     IsDeleted = n.IsDeleted,
                     IsApproved = n.IsApproved
                 }).AsQueryable();


        }

        public ArticleVM News_GetById(int id)
        {
            var model = db.News
                .Include(x => x.NewsCategory)
                .Where(x => x.Id == id)
                .OrderByDescending(x => x.Date)
                .Select(x => new ArticleVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Text,
                    CategoryId = x.NewsCategoryId,
                    CategoryName = x.NewsCategory.Name,
                    EventDate = x.Date,
                    LastModified = x.DateModified
                }).FirstOrDefault();


            var images = commService.FileCdn_GetList(GlobalConstants.SourceTypes.NewsImage, model.Id).ToList();
            if (images.Any())
            {
                model.MainImageFileId = images.FirstOrDefault().FileId;
            }
            return model;
        }

        public bool News_SaveData(News model)
        {
            model.IsRss = model.IsRss ?? false;
            try
            {
                if (model.Id > 0)
                {
                    var saved = Find<News>(model.Id);
                    saved.NewsCategoryId = model.NewsCategoryId;
                    saved.Title = model.Title;
                    saved.Text = model.Text;
                    saved.IsRss = model.IsRss;
                    saved.RssPostLink = model.RssPostLink;
                    saved.IsOnMainPage = model.IsOnMainPage;
                    saved.IsMainTopic = model.IsMainTopic;
                    saved.IsActive = model.IsActive;
                    saved.IsApproved = model.IsApproved;
                    saved.IsDeleted = model.IsDeleted;
                    saved.IsArchive = model.IsArchive;
                    saved.ModifiedByUserId = userContext.UserId;
                    saved.DateModified = DateTime.Now;

                    All<News>().Update(saved);
                    db.SaveChanges();
                }
                else
                {
                    model.LanguageId = GlobalConstants.LangBG;
                    model.CreatedByUserId = userContext.UserId;
                    model.DateCreated = DateTime.Now;

                    model.ModifiedByUserId = userContext.UserId;
                    model.DateModified = model.DateCreated;

                    All<News>().Add(model);
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

        public IQueryable<ArticleListVM> News_Select(int? category, string term)
        {
            return
                (from n in
                db.News
                .Include(x => x.NewsCategory)
                .Where(x => x.NewsCategoryId == (category ?? x.NewsCategoryId) && x.Title.Contains(term ?? x.Title))
                .OrderByDescending(x => x.Date)

                 join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.NewsImage)
                 on n.Id equals f.source_id into n_f
                 where n.IsActive && !n.IsDeleted && !n.IsArchive && n.IsApproved
                 from x in n_f.DefaultIfEmpty()
                 select new ArticleListVM
                 {
                     Id = n.Id,
                     Title = n.Title,
                     CategoryId = n.NewsCategoryId,
                     CategoryName = n.NewsCategory.Name,
                     EventDate = n.Date,
                     LastModified = n.DateModified,
                     IsRss = n.IsRss,
                     RssPostLink = n.RssPostLink,
                     MainImageFileId = (x != null) ? x.cdn_file_id : null
                 }).AsQueryable();
        }
      
    }
}
