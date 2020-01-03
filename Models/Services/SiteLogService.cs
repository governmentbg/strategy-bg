using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Linq;
using WebCommon.Services;
using static Models.GlobalConstants;

namespace Models.Services
{
  public class SiteLogService : BaseService, ISiteLogService
  {




    private readonly ILogger logger;
    private readonly IUserContext userContext;

    public SiteLogService(
        MainContext context
        , ILogger<SiteLogService> _logger
        , IUserContext _userContext)
    {
      this.db = context;
      logger = _logger;
      userContext = _userContext;
    }

    public IQueryable<SiteLogListVM> GetSiteLogList(int logType = -1)
    {
      var result = Enumerable.Empty<SiteLogListVM>().AsQueryable();

      switch (logType)
      {
        case 0:
          // Чакащи одобрение
          result = (from log in db.SiteLog
                    join user in db.Users on log.UserId equals user.Id
                    where !log.Approved && log.Action != 3
                    select new SiteLogListVM
                    {
                      Id = log.Id,
                      ActionId = log.Action,
                      ActionName = (log.Action == 1) ? "Създаване на нов" : ((log.Action == 2) ? "Редакция" : ((log.Action == 3) ? "Изтриване" : "N/A")),
                      CreateDate = log.DateCreated,
                      Details = log.Detail,
                      EditLink = log.DeletedForever ? "" : GetLinkOrModuleName(log.RecordId, log.DbTableName, false),
                      ModuleName = GetLinkOrModuleName(0, log.DbTableName, true),
                      UserName = user.UserName
                    })
          .OrderByDescending(x => x.CreateDate)
          .AsQueryable();
          break;
        case 1:
          // Списък промени
          result = (from log in db.SiteLog
                    join user in db.Users on log.UserId equals user.Id
                    where log.Detail != "NewsletterSubscription"
                    select new SiteLogListVM
                    {
                      Id = log.Id,
                      ActionId = log.Action,
                      ActionName = (log.Action == 1) ? "Създаване на нов" : ((log.Action == 2) ? "Редакция" : ((log.Action == 3) ? "Изтриване" : "N/A")),
                      CreateDate = log.DateCreated,
                      Details = log.Detail,
                      EditLink = log.DeletedForever ? "" : GetLinkOrModuleName(log.RecordId, log.DbTableName, false),
                      ModuleName = GetLinkOrModuleName(0, log.DbTableName, true),
                      UserName = user.UserName
                    })
          .OrderByDescending(x => x.CreateDate)
          .AsQueryable();
          break;
        case 2:
          // Изтрити
          result = (from log in db.SiteLog
                    join user in db.Users on log.UserId equals user.Id
                    where log.DeletedForever && log.Action == 3
                    select new SiteLogListVM
                    {
                      Id = log.Id,
                      ActionId = log.Action,
                      ActionName = (log.Action == 1) ? "Създаване на нов" : ((log.Action == 2) ? "Редакция" : ((log.Action == 3) ? "Изтриване" : "N/A")),
                      CreateDate = log.DateCreated,
                      Details = log.Detail,
                      EditLink = log.DeletedForever ? "" : GetLinkOrModuleName(log.RecordId, log.DbTableName, false),
                      ModuleName = GetLinkOrModuleName(0, log.DbTableName, true),
                      UserName = user.UserName
                    })
          .OrderByDescending(x => x.CreateDate)
          .AsQueryable();
          break;
        default:
          result = (from log in db.SiteLog
                    join user in db.Users on log.UserId equals user.Id
                    select new SiteLogListVM
                    {
                      Id = log.Id,
                      ActionId = log.Action,
                      ActionName = (log.Action == 1) ? "Създаване на нов" : ((log.Action == 2) ? "Редакция" : ((log.Action == 3) ? "Изтриване" : "N/A")),
                      CreateDate = log.DateCreated,
                      Details = log.Detail,
                      EditLink = log.DeletedForever ? "" : GetLinkOrModuleName(log.RecordId, log.DbTableName, false),
                      ModuleName = GetLinkOrModuleName(0, log.DbTableName, true),
                      UserName = user.UserName
                    })
          .OrderByDescending(x => x.CreateDate)
          .AsQueryable();
          break;
      }

      return result;
    }

    public bool Log(string tableName, int recordId, bool approved, int action, string details)
    {
      try
      {
        var model = new SiteLog()
        {
          DbTableName = tableName,
          RecordId = recordId,
          Action = action,
          Detail = details,
          UserId = userContext.UserId,
          Approved = approved,
          DeletedForever = false,
          DateCreated = DateTime.Now
        };
        db.SiteLog.Add(model);
        db.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    private string GetLinkOrModuleName(int recordId, string dbTableName, bool getModuleName = false)
    {
      string result = "";

      switch (dbTableName)
      {
        case SiteLogTableNames.Files:
          if (getModuleName)
          {
            result = "Управление файлове -> Файлове";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.Categories:
          if (getModuleName)
          {
            result = "Категории връзки";
          }
          else
          {
            result = "Links/EditLinksCategories/" + recordId;
          }
          break;
        case SiteLogTableNames.NewsCategories:
          if (getModuleName)
          {
            result = "Категории новини";
          }
          else
          {
            result = "NewsCategories/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.FileFolders:
          if (getModuleName)
          {
            result = "Управление файлове";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.DocumentTypes:
          if (getModuleName)
          {
            result = "Видове документи";
          }
          else
          {
            result = "DocumentKind/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.AboutUs:
          if (getModuleName)
          {
            result = "За нас";
          }
          else
          {
            result = "AboutUs/EditAboutUs/" + recordId;
          }
          break;
        case SiteLogTableNames.ReportAbuse:
          if (getModuleName)
          {
            result = "ReportAbuse";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.Publications:
          if (getModuleName)
          {
            result = "Публикации";
          }
          else
          {
            result = "Publication/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.ArticleCategories:
          if (getModuleName)
          {
            result = "Категории новини";
          }
          else
          {
            result = "NewsCategories/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.PublicationCategories:
          if (getModuleName)
          {
            result = "Категории публикации";
          }
          else
          {
            result = "PublicationCategories/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.News:
          if (getModuleName)
          {
            result = "Новини";
          }
          else
          {
            result = "News/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.InstitutionTypes:
          if (getModuleName)
          {
            result = "Институции";
          }
          else
          {
            result = "InstitutionType/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.UsersAnswers:
          if (getModuleName)
          {
            result = "Потребители -> Отговор";
          }
          else
          {
            result = "#";
          }
          break;
        case SiteLogTableNames.ForumGroups:
          if (getModuleName)
          {
            result = "Форум -> Групи";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.ForumTopics:
          if (getModuleName)
          {
            result = "Форум -> Тема";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.SiteSettings:
          if (getModuleName)
          {
            result = "Настройки";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.Links:
          if (getModuleName)
          {
            result = "Връзки";
          }
          else
          {
            result = "Links/EditLinks/" + recordId;
          }
          break;
        case SiteLogTableNames.LinksCategories:
          if (getModuleName)
          {
            result = "Категории връзки";
          }
          else
          {
            result = "Links/ListLinksCategories" + recordId;
          }
          break;
        case SiteLogTableNames.PublicConsultations:
          if (getModuleName)
          {
            result = "Обществени консултации";
          }
          else
          {
            result = "Consultation/Edit/" + recordId;
          }
          break;

        case SiteLogTableNames.PublicConsultationComments:
          if (getModuleName)
          {
            result = "Обществени консултации -> Коментари";
          }
          else
          {
            result = "Comments/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.NewsletterSubscription:
          if (getModuleName)
          {
            result = "Новини -> Абониране";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.Banners:
          if (getModuleName)
          {
            result = "Банери";
          }
          else
          {
            result = "Banners/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.Articles:
          if (getModuleName)
          {
            result = "Новини и събития";
          }
          else
          {
            result = "Article/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.PCSubjects:
          if (getModuleName)
          {
            result = "Лица и възнаграждения";
          }
          else
          {
            result = "PCSubjects/EditPCSubjects/" + recordId;
          }
          break;
        case SiteLogTableNames.TargetGroups:
          if (getModuleName)
          {
            result = "Целеви групи";
          }
          else
          {
            result = "TargetGroups/EditTargetGroups/" + recordId;
          }
          break;
        case SiteLogTableNames.Forums:
          if (getModuleName)
          {
            result = "Форум";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.StrategicDocumentReports:
          if (getModuleName)
          {
            result = "Стратегически документи -> Справки";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.ForumMessages:
          if (getModuleName)
          {
            result = "Форум -> съобщения";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.Used_Files:
          if (getModuleName)
          {
            result = "Прикачени файлове";
          }
          else
          {
            result = "";
          }
          break;
        case SiteLogTableNames.StrategicDocuments:
          if (getModuleName)
          {
            result = "Стратегически документи";
          }
          else
          {
            result = "StrategicDocument/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.Questionary:
          if (getModuleName)
          {
            result = "Анкета";
          }
          else
          {
            result = "Questionary/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.MSProgram:
          if (getModuleName)
          {
            result = "Законодателна програма";
          }
          else
          {
            result = "MSProgram/Edit/" + recordId;
          }
          break;
        case SiteLogTableNames.OGP:
          if (getModuleName)
          {
            result = "Партньорство за ОУ";
          }
          else
          {
            result = "Ogp/PlanElements_Edit/" + recordId;
          }
          break;
        default:
          if (getModuleName)
          {
            result = dbTableName;
          }
          else
          {
            result = "";
          }
          break;
      }

      return result;
    }
  }
}
