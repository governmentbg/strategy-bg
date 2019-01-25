using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Contracts;
using Models.ViewModels.CategoriesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Services;

namespace Models.Services
{
    public class CategoriesService : BaseService, ICategoriesService
    {
        private readonly ILogger logger;
        private readonly IUserContext userContext;

        public CategoriesService(MainContext context, ILogger<QuestionaryService> _logger, IUserContext _userContext)
        {
            this.db = context;
            logger = _logger;
            userContext = _userContext;
        }

        #region Caterories
        public IQueryable<CateroriesListViewModel> GetCategories(int active, int parentId, int sectionId)
        {
            return this.All<Category>()
                .Where(x => x.LanguageId == GlobalConstants.LangBG
										&& !x.IsDeleted
                    && x.IsActive == (active == -1 ? x.IsActive : (active == 1 ? true : false))
                    && x.ParentId == parentId
                    && x.SectionId == (sectionId == -1 ? x.SectionId : sectionId)
                    )
                .OrderBy(x => x.CategoryName)
                .Select(c => new CateroriesListViewModel()
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    IsActive = c.IsActive,
                    DateCreated = c.DateCreated
                });
        }

        public CategoryViewModel GetCategory(int id)
        {
            var entity = this.All<Category>().Find(id);
            var model = new CategoryViewModel();
            model.FromEntity(entity);

            return model;
        }

        public bool SaveCategory(CategoryViewModel model)
        {
            var result = false;
            Category entity = null;

            try
            {
                if (model.Id > 0)
                {
                    entity = All<Category>().Find(model.Id);

                    if (entity != null)
                    {
                        entity = model.ToEntity(entity);
                        entity.DateModified = DateTime.Now;
                        entity.ModifiedByUserId = userContext.UserId;
                    }
                }
                else
                {
                    entity = model.ToEntity();
                    entity.DateCreated = DateTime.Now;
                    entity.CreatedByUserId = userContext.UserId;
                    entity.DateModified = DateTime.Now;
                    entity.ModifiedByUserId = userContext.UserId;

                    All<Category>().Add(entity);
                }

                if (entity.ImagePath == null)
                {
                    entity.ImagePath = "";
                }

                db.SaveChanges();
                model.Id = entity.Id;

                result = true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "SaveCategory failed.");
            }

            return result;
        }
        #endregion

        public IEnumerable<SelectListItem> GetParentCategoriesDDL()
        {
            List<int> possibleParentIDs = this.All<Category>()
                .Select(x => x.Id)
                .ToList();

            return (from c in db.Categories
                    where c.IsActive && c.IsApproved && !c.IsDeleted && c.LanguageId == GlobalConstants.LangBG
												&& !possibleParentIDs.Contains(c.ParentId)
                    orderby c.CategoryName
                    select new SelectListItem()
                    {
                        Text = c.CategoryName,
                        Value = c.Id.ToString()
                    })
                            .ToList();
        }

        public IEnumerable<SelectListItem> GetSectionCategoriesDDL(int parentId)
        {
            List<int> parents = this.All<Category>()
                .Where(x => x.SectionId > 0 && x.IsActive && x.IsApproved && !x.IsDeleted && x.LanguageId == GlobalConstants.LangBG)
                .Select(x => x.SectionId)
                .ToList();

            List<int> possibleParentIDs = new List<int>();

            foreach (var item in parents)
            {
                if (!possibleParentIDs.Contains(item))
                {
                    possibleParentIDs.Add(item);
                }
            }

            int parentsCount = (from c in db.Categories
                                where c.IsActive && c.IsApproved && !c.IsDeleted && c.LanguageId == GlobalConstants.LangBG && c.SectionId > 0
                                    && possibleParentIDs.Contains(c.SectionId) && c.ParentId == parentId
                                select c)
                            .Count();

            int sectionId = (from c in db.Categories
                             where c.IsActive && c.IsApproved && !c.IsDeleted && c.LanguageId == GlobalConstants.LangBG && c.SectionId == 0
                                 && possibleParentIDs.Contains(c.Id)
                             orderby c.CategoryName
                             select c)
                                             .FirstOrDefault()
                                             .Id;

            if (possibleParentIDs.Count > 0 && parentsCount > 0)
            {
                var ret = (from c in db.Categories
                           where c.IsActive && c.IsApproved && !c.IsDeleted && c.LanguageId == GlobalConstants.LangBG
															 && possibleParentIDs.Contains(c.Id)
                           orderby c.CategoryName
                           select new SelectListItem()
                           {
                               Text = c.CategoryName,
                               Value = c.Id.ToString()
                           })
                                .ToList();

                return ret;
            }
            else
            {
                return new List<SelectListItem>();
            }
        }
    }
}
