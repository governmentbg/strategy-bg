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
using System.Linq.Expressions;

namespace Models.Services
{
    public class PublicationService : BaseService, IPublicationService
    {
        private readonly ILogger logger;
        private readonly ICommonService commService;
        private readonly IUserContext userContext;

        public PublicationService(
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

        public PublicationCategories PublicationCategories_GetById(int id)
        {
            return Find<PublicationCategories>(id);
        }

        public IEnumerable<TextValueVM> PublicationCategories_SelectCombo(int lang = GlobalConstants.LangBG)
        {
            return All<PublicationCategories>()
                   .Where(x => x.IsActive && !x.IsDeleted && x.IsApproved && x.LanguageId == lang)
                   .OrderBy(x => x.Name)
                    .Select(x => new TextValueVM
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    });
        }

        public IQueryable<ArticleListAdminVM> Publication_AdminSelect(DateTime? dateFrom, DateTime? dateTo, int? category, string term, bool activeOnly)
        {
            Expression<Func<Publications, bool>> whereActive = x => true;
            if (activeOnly)
            {
                whereActive = x => x.IsActive && !x.IsDeleted;
            }
            return
               (from p in
               db.Publications
               .Include(x => x.PublicationCategory)
               .Where(x => (x.Date >= (dateFrom ?? x.Date)) && (x.Date <= (dateTo ?? x.Date)))
               .Where(x => x.PublicationCategoryId == (category ?? x.PublicationCategoryId) && x.Title.Contains(term ?? x.Title))
               //.Where(x => x.IsActive && !x.IsDeleted && !x.IsArchive && x.IsApproved)
               .Where(whereActive)
               .OrderBy(x => x.IsMainTopic)
               .ThenByDescending(x => x.Date)

                join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PublicationsImages)
                on p.Id equals f.source_id into n_f
                from x in n_f.DefaultIfEmpty()
                select new ArticleListAdminVM
                {
                    Id = p.Id,
                    LanguageId = p.LanguageId,
                    Title = p.Title,
                    CategoryId = p.PublicationCategoryId,
                    CategoryName = p.PublicationCategory.Name,
                    EventDate = p.Date,
                    LastModified = p.DateModified,
                    MainImageFileId = (x != null) ? x.cdn_file_id : null,
                    IsActive = p.IsActive,
                    IsDeleted = p.IsDeleted,
                    IsApproved = p.IsApproved
                }).AsQueryable();

        }

        public ArticleVM Publication_GetById(int id)
        {
            var model = db.Publications
               .Include(x => x.PublicationCategory)
               .Where(x => x.Id == id)
               .OrderByDescending(x => x.Date)
               .Select(x => new ArticleVM
               {
                   Id = x.Id,
                   Title = x.Title,
                   Content = x.Text,
                   CategoryId = x.PublicationCategoryId,
                   CategoryName = x.PublicationCategory.Name,
                   EventDate = x.Date,
                   LastModified = x.DateModified,
                   lang_Id = x.LanguageId,
                   IsActive = x.IsActive && !x.IsDeleted
               }).FirstOrDefault();

            if (model == null)
            {
                return null;
            }

            var images = commService.FileCdn_GetList(GlobalConstants.SourceTypes.PublicationsImages, model.Id).ToList();
            if (images.Any())
            {
                model.MainImageFileId = images.FirstOrDefault().FileId;
            }

            var prev = (from n in
                       db.Publications
                       .Include(x => x.PublicationCategory)
                       //.Where(x => x.PublicationCategoryId == ( x.PublicationCategoryId) && x.Title.Contains( x.Title))
                       .Where(x => x.LanguageId == model.lang_Id)
                       .Where(x => x.Id < model.Id)
                       .OrderByDescending(x => x.Date)

                        join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PublicationsImages)
                        on n.Id equals f.source_id into n_f
                        where n.IsActive && !n.IsDeleted && n.IsApproved
                        from x in n_f.DefaultIfEmpty()
                        select new ArticleListVM
                        {
                            Id = n.Id,
                            LanguageId = n.LanguageId,
                            Title = n.Title,
                            CategoryId = n.PublicationCategoryId,
                            CategoryName = n.PublicationCategory.Name,
                            EventDate = n.Date,
                            LastModified = n.DateModified,
                            MainImageFileId = (x != null) ? x.cdn_file_id : null
                        }).Take(1).ToList();

            var next = (from n in
                 db.Publications
                 .Include(x => x.PublicationCategory)
                 //.Where(x => x.PublicationCategoryId == (x.PublicationCategoryId) && x.Title.Contains(x.Title))
                 .Where(x => x.LanguageId == model.lang_Id)
                 .Where(x => x.Id > model.Id)
                 .OrderBy(x => x.Date)

                        join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PublicationsImages)
                        on n.Id equals f.source_id into n_f
                        where n.IsActive && !n.IsDeleted && n.IsApproved
                        from x in n_f.DefaultIfEmpty()
                        select new ArticleListVM
                        {
                            Id = n.Id,
                            LanguageId = n.LanguageId,
                            Title = n.Title,
                            CategoryId = n.PublicationCategoryId,
                            CategoryName = n.PublicationCategory.Name,
                            EventDate = n.Date,
                            LastModified = n.DateModified,
                            MainImageFileId = (x != null) ? x.cdn_file_id : null
                        }).Take(1).ToList();

            if (prev.Count() != 0) { model.prev_Id = prev.FirstOrDefault().Id; } else { model.prev_Id = model.Id; }
            if (next.Count() != 0) { model.next_Id = next.FirstOrDefault().Id; } else { model.next_Id = model.Id; }

            return model;
        }

        public bool Publication_SaveData(Publications model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var saved = Find<Publications>(model.Id);
                    saved.PublicationCategoryId = model.PublicationCategoryId;
                    saved.Title = model.Title;
                    saved.Text = model.Text;
                    saved.IsMainTopic = model.IsMainTopic;
                    saved.IsActive = model.IsActive;
                    saved.IsApproved = model.IsApproved;
                    saved.IsDeleted = model.IsDeleted;
                    saved.ModifiedByUserId = userContext.UserId;
                    saved.DateModified = DateTime.Now;

                    All<Publications>().Update(saved);
                    db.SaveChanges();
                }
                else
                {
                    model.CreatedByUserId = userContext.UserId;
                    model.DateCreated = DateTime.Now;

                    model.ModifiedByUserId = userContext.UserId;
                    model.DateModified = model.DateCreated;

                    All<Publications>().Add(model);
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

        public IQueryable<ArticleListVM> Publication_Select(int? category, string term, int lang = GlobalConstants.LangBG)
        {

            return
               (from n in
               db.Publications
               .Include(x => x.PublicationCategory)
               .Where(x => x.PublicationCategoryId == (category ?? x.PublicationCategoryId) && x.Title.Contains(term ?? x.Title))
               .Where(x => x.LanguageId == lang)
               .OrderByDescending(x => x.Date)

                join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PublicationsImages)
                on n.Id equals f.source_id into n_f
                where n.IsActive && !n.IsDeleted && n.IsApproved
                from x in n_f.DefaultIfEmpty()
                select new ArticleListVM
                {
                    Id = n.Id,
                    LanguageId = n.LanguageId,
                    Title = n.Title,
                    CategoryId = n.PublicationCategoryId,
                    CategoryName = n.PublicationCategory.Name,
                    EventDate = n.Date,
                    LastModified = n.DateModified,
                    MainImageFileId = (x != null) ? x.cdn_file_id : null
                }).AsQueryable();


        }
    }
}
