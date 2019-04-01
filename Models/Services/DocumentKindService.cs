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
  public class DocumentKindService : BaseService, IDocumentKindService
  {
    private readonly ILogger logger;
    private readonly IUserContext userContext;

    public DocumentKindService(
        MainContext context
        , ILogger<DocumentKindService> _logger
        , IUserContext _userContext)
    {
      this.db = context;
      logger = _logger;
      userContext = _userContext;
    }

    public IQueryable<DocumentKindListVM> GetDocumentKindList(int active = -1, int lang = GlobalConstants.LangBG)
    {
      return All<StrategicDocumentTypes>()
          .Where(x => x.LanguageId == lang && (x.IsActive == ((active == -1) ? x.IsActive : (active == 1 ? true : false))))
          .Select(d => new DocumentKindListVM()
          {
            Id = d.Id,
            Label = d.DocumentTypeName,
            IsActive = d.IsActive
          });
    }

    public DocumentKindVM GetItem(int id)
    {
      return All<StrategicDocumentTypes>()
          .Where(d => d.Id == id)
          .Select(d => new DocumentKindVM()
          {
            Id = d.Id,
            Label = d.DocumentTypeName,
            IsActive = d.IsActive,
            LanguageId = d.LanguageId
          })
          .FirstOrDefault();
    }

    public bool SaveItem(DocumentKindVM model)
    {
      var result = false;
      StrategicDocumentTypes entity = null;

      try
      {
        if (model.Id > 0)
        {
          entity = All<StrategicDocumentTypes>().Find(model.Id);

          if (entity != null)
          {
            entity.IsActive = model.IsActive;
            entity.DocumentTypeName = model.Label;
          }
        }
        else
        {
          entity = new StrategicDocumentTypes()
          {
            IsActive = model.IsActive,
            DocumentTypeName = model.Label,
            LanguageId = model.LanguageId,
          };

          db.StrategicDocumentTypes.Add(entity);
        }

        if (entity != null)
        {
          db.SaveChanges();
          result = true;
        }
      }
      catch (Exception ex)
      {
        logger.LogError(ex, "DocumentKinds->SaveItem");
      }

      return result;
    }
  }
}
