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

        public IEnumerable<TextValueVM> PublicationCategories_SelectCombo()
        {
            return All<PublicationCategories>()
                   .Where(x => x.IsActive && !x.IsDeleted && x.IsApproved && x.LanguageId == GlobalConstants.LangBG)
                   .OrderBy(x => x.Name)
                    .Select(x => new TextValueVM
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    });
        }

        public IQueryable<ArticleListAdminVM> Publication_AdminSelect(DateTime? dateFrom, DateTime? dateTo, int? category, string term)
        {
            return
               (from p in
               db.Publications
               .Include(x => x.PublicationCategory)
               .Where(x => (x.Date >= (dateFrom ?? x.Date)) && (x.Date <= (dateTo ?? x.Date)))
               .Where(x => x.PublicationCategoryId == (category ?? x.PublicationCategoryId) && x.Title.Contains(term ?? x.Title))
               //.Where(x => x.IsActive && !x.IsDeleted && !x.IsArchive && x.IsApproved)
               .OrderByDescending(x => x.Date)

                join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PublicationsImages)
                on p.Id equals f.source_id into n_f
                from x in n_f.DefaultIfEmpty()
                select new ArticleListAdminVM
                {
                    Id = p.Id,
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
                   LastModified = x.DateModified
               }).FirstOrDefault();

            var images = commService.FileCdn_GetList(GlobalConstants.SourceTypes.PublicationsImages, model.Id).ToList();
            if (images.Any())
            {
                model.MainImageFileId = images.FirstOrDefault().FileId;
            }
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
                    saved.IsOnMainPage = model.IsOnMainPage;
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
                    model.LanguageId = GlobalConstants.LangBG;
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

        public IQueryable<ArticleListVM> Publication_Select(int? category, string term)
        {

            return
               (from n in
               db.Publications
               .Include(x => x.PublicationCategory)
               .Where(x => x.PublicationCategoryId == (category ?? x.PublicationCategoryId) && x.Title.Contains(term ?? x.Title))
               .OrderByDescending(x => x.Date)

                join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.PublicationsImages)
                on n.Id equals f.source_id into n_f
                where n.IsActive && !n.IsDeleted && n.IsApproved
                from x in n_f.DefaultIfEmpty()
                select new ArticleListVM
                {
                    Id = n.Id,
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
