using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Legacy;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Linq;
using WebCommon.Services;

namespace Models.Services
{
  public class NewsCategoriesService : BaseService, INewsCategoriesService
  {
    private readonly ILogger logger;
    private readonly IUserContext userContext;

    public NewsCategoriesService(
        MainContext context
        , ILogger<NewsCategoriesService> _logger
        , IUserContext _userContext)
    {
      this.db = context;
      logger = _logger;
      userContext = _userContext;
    }

    public IQueryable<NewsCategoriesListVM> GetNewsCategoriesList(int active = -1, int lang = GlobalConstants.LangBG)
    {
      return All<NewsCategories>()
          .Where(x => x.LanguageId == lang && (x.IsActive == ((active == -1) ? x.IsActive : (active == 1 ? true : false))) && x.IsApproved && !x.IsDeleted)
          .OrderBy(x => x.Priority)
          .Select(d => new NewsCategoriesListVM()
          {
            Id = d.Id,
            Label = d.Name,
            IsActive = d.IsActive,
            DateCreated = d.DateCreated
          });
    }

    public NewsCategoriesVM GetItem(int id)
    {
      return All<NewsCategories>()
          .Where(d => d.Id == id)
          .Select(d => new NewsCategoriesVM()
          {
            Id = d.Id,
            Label = d.Name,
            IsActive = d.IsActive,
            IsDeleted = d.IsDeleted,
            LanguageId = d.LanguageId
          })
          .FirstOrDefault();
    }

    public bool SaveItem(NewsCategoriesVM model)
    {
      var result = false;
      NewsCategories entity = null;

      try
      {
        if (model.Id > 0)
        {
          entity = All<NewsCategories>().Find(model.Id);

          if (entity != null)
          {
            entity.IsActive = model.IsActive;
            entity.Name = model.Label;
            entity.ModifiedByUserId = userContext.UserId;
            entity.DateModified = DateTime.Now;
            entity.IsDeleted = model.IsDeleted;
          }
        }
        else
        {
          entity = new NewsCategories()
          {
            IsActive = model.IsActive,
            Name = model.Label,
            CreatedByUserId = userContext.UserId,
            ModifiedByUserId = userContext.UserId,
            DateModified = DateTime.Now,
            DateCreated = DateTime.Now,
            IsApproved = true,
            Priority = 0,
            LanguageId = model.LanguageId,
            IsDeleted = model.IsDeleted
          };

          db.NewsCategories.Add(entity);
        }

        if (entity != null)
        {
          db.SaveChanges();
          result = true;
        }
      }
      catch (Exception ex)
      {
        logger.LogError(ex, "NewsCategoriess->SaveItem");
      }

      return result;
    }
  }
}
