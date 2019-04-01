using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Legacy;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Models;
using WebCommon.Services;

namespace Models.Services
{
  public class InstitutionTypeService : BaseService, IInstitutionTypeService
  {
    private readonly ILogger logger;
    private readonly IUserContext userContext;

    public InstitutionTypeService(
        MainContext context
        , ILogger<InstitutionTypeService> _logger
        , IUserContext _userContext)
    {
      this.db = context;
      logger = _logger;
      userContext = _userContext;
    }

    public IQueryable<InstitutionTypeListVM> GetInstitutionTypeList(int active = -1, int lang = GlobalConstants.LangBG)
    {
      return All<InstitutionTypes>()
          .Where(x => x.LanguageId == lang && (x.IsActive == (active == -1) ? x.IsActive : active == 1))
          .Select(d => new InstitutionTypeListVM()
          {
            Id = d.Id,
            Label = d.InstitutionTypeName,
            IsActive = d.IsActive,
            LanguageId = d.LanguageId
          });
    }

    public InstitutionTypeVM GetItem(int id)
    {
      return All<InstitutionTypes>()
          .Where(d => d.Id == id)
          .Select(d => new InstitutionTypeVM()
          {
            Id = d.Id,
            Label = d.InstitutionTypeName,
            IsActive = d.IsActive,
            LanguageId = d.LanguageId
          })
          .FirstOrDefault();
    }

    public bool SaveItem(InstitutionTypeVM model)
    {
      var result = false;
      InstitutionTypes entity = null;

      try
      {
        if (model.Id > 0)
        {
          entity = All<InstitutionTypes>().Find(model.Id);

          if (entity != null)
          {
            entity.IsActive = model.IsActive;
            entity.InstitutionTypeName = model.Label;
            entity.ModifiedByUserId = userContext.UserId;
          }
        }
        else
        {
          entity = new InstitutionTypes()
          {
            IsActive = model.IsActive,
            InstitutionTypeName = model.Label,
            CreatedByUserId = userContext.UserId,
            ModifiedByUserId = userContext.UserId,
            LanguageId = model.LanguageId
          };

          db.InstitutionTypes.Add(entity);
        }

        if (entity != null)
        {
          db.SaveChanges();
          result = true;
        }
      }
      catch (Exception ex)
      {
        logger.LogError(ex, "InstitutionTypes->SaveItem");
      }

      return result;
    }
  }
}
