using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Consultations;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Extensions;
using WebCommon.Services;

namespace Models.Services
{
  public class UsersInfoService : BaseService, IUsersInfoService
  {
    private readonly ILogger logger;
    private readonly IUserContext userContext;
    private readonly IAccountService accountService;

    public UsersInfoService(
      MainContext context
      , ILogger<UsersInfoService> _logger
      , IUserContext _userContext
      , IAccountService _accountService
      )
    {
      this.db = context;
      logger = _logger;
      userContext = _userContext;
      accountService = _accountService;
    }

    public UsersInfoVM UsersInfo_Select(int? userId, string userName, int? userType)
    {
      int[] userTypes = new int[] { GlobalConstants.UserTypes.Internal, GlobalConstants.UserTypes.Public };

      return db.Users
              .Include(x => x.UsersType)
              .Where(x => (x.FullName.Contains(userName ?? x.FullName)) || (x.UserName.Contains(userName ?? x.UserName)))
              .Where(x => x.UserTypeId == (userType ?? x.UserTypeId) && userTypes.Contains(x.UserTypeId))
              .Where(x => x.Id == (userId ?? x.Id))
              .Select(x => new UsersInfoVM
              {
                UserId = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                UserType = x.UsersType.Name
              })
              .FirstOrDefault();
    }

    public UsersInfoVM GetUserInCategories(UsersInfoVM model)
    {
      var categoriesModel = accountService.UserInCategoriesVM_Select(model.UserId);
      string userCategoriesText = "";

      foreach (var parentCategory in categoriesModel.ParentCategories)
      {
        userCategoriesText += parentCategory.CategoryName + ": ";
        var userInCategories = accountService.UserInCategories_Select(model.UserId, null);

        foreach (var category in userInCategories)
        {
          if (category.CategoryMasterId == parentCategory.Id)
          {
            if (string.IsNullOrEmpty(model.UserCategories))
            {
              model.UserCategories = category.CategoryName;
            }
            else
            {
              model.UserCategories += "; " + category.CategoryName;
            }
          }
        }

        userCategoriesText += model.UserCategories + ". ";
        model.UserCategories = "";
      }

      model.UserCategories = userCategoriesText;

      return model;
    }

    public IQueryable<UsersInfoConsultationsVM> GetConsultations(int userId)
    {
      List<UsersInfoConsultationsVM> result = new List<UsersInfoConsultationsVM>();

      // коментари в ОК
      var consultationComments = this.All<PublicConsultationComment>()
            .Include(x => x.Consultation)
            .Where(x => x.CreatedByUserId == userId || x.Consultation.CreatedByUserId == userId)
            .ToList();

      foreach (var comment in consultationComments)
      {
        if (!result.Any(x => x.ConsultationId == comment.Id))
        {
          result.Add(new UsersInfoConsultationsVM
          {
            ConsultationId = comment.Consultation.Id,
            IsCreatedByUser = comment.Consultation.CreatedByUserId == userId,
            PublicConsultation = comment.Consultation.Title.DecodeIfNeeded()
          });
        }
      }

      // коментари в документи
      var documentComments = GetConsultationDocumentComments(userId);

      foreach (var comment in documentComments)
      {
        if (!result.Any(x => x.ConsultationId == comment.SourceId))
        {
          PublicConsultation consultation = this.All<PublicConsultation>()
                    .Where(x => x.Id == comment.SourceId)
                    .FirstOrDefault();

          if (consultation != null)
          {
            result.Add(new UsersInfoConsultationsVM
            {
              ConsultationId = consultation.Id,
              IsCreatedByUser = consultation.CreatedByUserId == userId,
              PublicConsultation = consultation.Title.DecodeIfNeeded()
            });
          }
        }
      }


      // обработка на резултата
      foreach (var consultation in result)
      {
        var comments = this.All<PublicConsultationComment>()
            .Where(x => x.ConsultationId == consultation.ConsultationId && x.CreatedByUserId == userId)
            .ToList();

        string notes = "";

        foreach (var comment in comments)
        {
          notes += "<b>" + comment.Title + "</b><br/>" + comment.Text + "</br>";
        }

        foreach (var comment in documentComments)
        {
          notes += "<b>" + comment.Title + "</b><br/>" + comment.Text + "</br>";
        }

        consultation.Notes = notes.DecodeIfNeeded();
      }

      return result.AsQueryable();
    }

    public List<Comments> GetConsultationDocumentComments(int userId)
    {
      int[] documentIds = All<PublicConsultationDocument>(d => d.CreatedByUserId == userId || d.ModifiedByUserId == userId || d.ActualUserId == userId)
          .Select(d => d.Id)
          .ToArray();

      return All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultation && x.CommentStateId == GlobalConstants.CommentStatus.Approved
               )
               .Union(All<Comments>(x => x.SourceType == GlobalConstants.SourceTypes.PublicConsultationDocuments && documentIds.Contains(x.SourceId)
               && x.CommentStateId == GlobalConstants.CommentStatus.Approved
               ))
               .ToList();
    }

    public IQueryable<UsersInfoChangeProposalsVM> GetChangeProposals(int userId)
    {
      int maxTextLength = 250;

      return this.All<ChangeProposals>()
            .Where(x => x.CreatedByUserId == userId || x.ActualUserId == userId || x.ModifiedByUserId == userId)
            .Select(c => new UsersInfoChangeProposalsVM
            {
              ChangeProposalsId = c.Id,
              Title = c.Title.DecodeIfNeeded(),
              Text = (c.Text.Length > maxTextLength) ? (c.Text.Substring(0, maxTextLength) + "...") : c.Text.Substring(0, maxTextLength)
            })
            .AsQueryable();
    }
  }
}
