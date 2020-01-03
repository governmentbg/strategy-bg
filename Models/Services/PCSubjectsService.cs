using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.PCSubjectsModels;
using Models.Contracts;
using Models.ViewModels.PCSubjectsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Services;

namespace Models.Services
{
  public class PCSubjectsService : BaseService, IPCSubjectsService
  {
    private readonly ILogger logger;
    private readonly IUserContext userContext;
    private readonly IUrlHelper urlHelper;

    public PCSubjectsService(MainContext context, ILogger<PCSubjectsService> _logger, IUserContext _userContext, IUrlHelper _urlHelper)
    {
      this.db = context;
      logger = _logger;
      userContext = _userContext;
      urlHelper = _urlHelper;
    }
    #region Public Consultation Subjects Service
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="eik"></param>
    /// <param name="pcSubjectsTypeID">-1 - Всички, 1 - ЮЛ, 0 - ФЛ</param>
    /// <returns></returns>
    public IQueryable<PCSubjectsListViewModel> GetPCSubjectsList(string name, string eik, int pcSubjectsTypeID)
    {
      var result = this.All<PCSubjects>()
        .Where(x => x.IsUL == (pcSubjectsTypeID == -1 ? x.IsUL : (pcSubjectsTypeID == 1 ? true : false))
          && (string.IsNullOrEmpty(eik) ? true : (pcSubjectsTypeID == 0 ? true : x.EIK.StartsWith(eik)))
          && (x.Name == (name == "" ? x.Name : name) || (x.Name.StartsWith(name)))
        )
        .OrderBy(x => x.Name)
        .Select(c => new PCSubjectsListViewModel()
        {
          Id = c.Id,
          Name = c.Name,
          IsUL = c.IsUL ? 1 : 0,
          EIK = c.EIK,
          DatePayment = c.DatePayment,
          PaymentValue = c.PaymentValue,
          ActivityDescription = c.ActivityDescription,
          ContractingAuthority = c.ContractingAuthority,
          PaymentVaPaymentIncludeVAT = c.PaymentIncludeVAT
        }).ToList();

      foreach (var item in result)
      {
        var files = All<FilesCDNUsed>()
          .Include(x=>x.FileCdn)
          .Where(x => x.source_id == item.Id && x.source_type == GlobalConstants.SourceTypes.PublicConsultationSubjects)
          .ToList();

        if (files != null && files.Count > 0)
        {
          item.FilesForDownload = "<ul>";

          foreach (var file in files)
          {
            item.FilesForDownload += "<li><a href='/FileCdn/DownloadFile?id=" + file.cdn_file_id + "'>" + file.FileCdn.FileTitle + "</a></li>";
          }

          item.FilesForDownload += "</ul>";
        }
      }

      return result.AsQueryable();
    }

    public IQueryable<PCSubjectsExportListViewModel> GetPCSubjectsGetExport()
    {
      var Url = urlHelper.Action("DownloadFile", "FileCdn", new { area = "" }).ToString() +"/";
     
      var result = (from pc_sub in this.All<PCSubjects>()
                     join cdn in All<FilesCDNUsed>().Where(x => x.source_type == GlobalConstants.SourceTypes.PublicConsultationSubjects) on pc_sub.Id equals cdn.source_id into Files
                     select new
                     {
                       Name = pc_sub.Name,
                       Id = pc_sub.Id,
                       Type = pc_sub.IsUL ? "Юридическо лице" : "Физическо лице",
                       EIK = pc_sub.EIK,
                       DatePayment = pc_sub.DatePayment.ToString(GlobalConstants.DateFormat),
                       PaymentValue = pc_sub.PaymentValue,
                       ActivityDescription = pc_sub.ActivityDescription,
                       ContractingAuthority = pc_sub.ContractingAuthority,
                       PaymentVaPaymentIncludeVAT = pc_sub.PaymentIncludeVAT ? "С ДДС" : "Без ДДС",
                       Files = Files
                      
                     }).ToList()
                     .Select(c => new PCSubjectsExportListViewModel
                     {
                       Id = c.Id,
                       Name = c.Name,
                       Type = c.Type,
                       EIK = c.EIK,
                       DatePayment = c.DatePayment,
                       PaymentValue = c.PaymentValue,
                       ActivityDescription = c.ActivityDescription,
                       ContractingAuthority = c.ContractingAuthority,
                       PaymentVaPaymentIncludeVAT = c.PaymentVaPaymentIncludeVAT,
                       FilesForDownload = c.Files.Count()== 0 ? "" :(
                       Url+(c.Files.Select(p => p.cdn_file_id)
                       .Aggregate((p, n) => p + " | "+ Url + n)).ToString())

                     });
      return result.AsQueryable();
    }

      public IQueryable<PCSubjectsListViewModel> GetPCSubjectsAutocompleteEIK(string eik)
    {
      return this.All<PCSubjects>()
        .Where(x => x.EIK.StartsWith(eik))
        .OrderBy(x => x.Name)
        .Select(c => new PCSubjectsListViewModel()
        {
          Name = c.Name,
          EIK = c.EIK,
          ActivityDescription = c.EIK + " " + c.Name
        });
    }

    public IQueryable<PCSubjectsListViewModel> GetPCSubjectsAutocompleteName(string name)
    {
      return this.All<PCSubjects>()
        .Where(x => x.Name.StartsWith(name))
        .OrderBy(x => x.Name)
        .Select(c => new PCSubjectsListViewModel()
        {
          Name = c.Name,
          EIK = c.EIK ?? "",
          ActivityDescription = (c.EIK ?? "") + " " + c.Name
        });
    }

    public PCSubjectsViewModel GetPCSubjects(int id)
    {
      var entity = this.All<PCSubjects>().Find(id);
      var model = new PCSubjectsViewModel();
      model.FromEntity(entity);

      var category = All<Category>(x => x.Id == model.CategoryId).FirstOrDefault();

      if (category.SectionId == 0)
      {
        // национални
        model.CategoryMasterId = GlobalConstants.Categories.Type_National;
        model.CategoryId = model.CategoryId;
        model.DistrictId = null;
        model.MunicipalityId = null;
        model.FakeMunicipalityId = 0;
      }
      else
      {
        // областни и общински
        model.CategoryMasterId = GlobalConstants.Categories.Type_District;
        model.CategoryId = category.Id;
        model.DistrictId = category.SectionId;
        model.MunicipalityId = category.Id;
        model.FakeMunicipalityId = category.Id;
      }

      return model;
    }

    public bool SavePCSubjects(PCSubjectsViewModel model)
    {
      var result = false;
      PCSubjects entity = null;

      try
      {
        if (model.Id > 0)
        {
          entity = All<PCSubjects>().Find(model.Id);

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
          entity.ModifiedByUserId = userContext.UserId;

          entity.CreatedByUserId = userContext.UserId;
          entity.DateModified = DateTime.Now;

          All<PCSubjects>().Add(entity);
        }

        if (model.CategoryMasterId == GlobalConstants.Categories.Type_District)
        {
          // областни и общински
          entity.CategoryId = (int)model.MunicipalityId;
          model.CategoryId = entity.CategoryId;
        }

        db.SaveChanges();
        model.Id = entity.Id;

        result = true;
      }
      catch (Exception ex)
      {
        logger.LogError(ex, "SavePCSubjects failed.");
      }

      return result;
    }

    public IEnumerable<SelectListItem> GetPCSubjectTypesDDL(bool addAll = true)
    {
      List<SelectListItem> result = new List<SelectListItem>();

      if (addAll)
      {
        result.Add(
          new SelectListItem()
          {
            Text = "Всички",
            Value = "-1"
          });
      }

      result.Add(
        new SelectListItem()
        {
          Text = "Юридическо лице",
          Value = "1"
        });

      result.Add(
        new SelectListItem()
        {
          Text = "Физическо лице",
          Value = "0"
        });

      return result;
    }
    #endregion

    public IEnumerable<SelectListItem> GetCategoriesDDL(int categoryId, int? selectedId)
    {
      List<SelectListItem> result = new List<SelectListItem>();

      var allCat = All<Category>(x => x.LanguageId == GlobalConstants.LangBG && x.IsActive && x.IsApproved && !x.IsDeleted).ToList();

      if (categoryId == 0)
      {
        result.Add(new SelectListItem() { Text = "Национални", Value = GlobalConstants.Categories.Type_National.ToString() });
        result.Add(new SelectListItem() { Text = "Областни и общински", Value = GlobalConstants.Categories.Type_District.ToString() });
        return result;
      }

      if (categoryId == GlobalConstants.Categories.Type_National)
      {
        result.AddRange(
           allCat.Where(x => x.ParentId == GlobalConstants.Categories.Type_National)
                .OrderBy(x => x.CategoryName)
                .Select(x => new SelectListItem
                {
                  Value = x.Id.ToString(),
                  Text = x.CategoryName
                })
          );

        return result;
      }


      if (categoryId == GlobalConstants.Categories.Type_District)
      {
        result.AddRange(
            allCat.Where(x => x.ParentId == GlobalConstants.Categories.Type_District)
            .OrderBy(x => x.CategoryName)
                .Select(x => new SelectListItem
                {
                  Value = x.Id.ToString(),
                  Text = x.CategoryName
                })
            );

        return result;
      }

      var currentDistrict = allCat.Where(x => x.Id == categoryId).FirstOrDefault();

      result.AddRange(
          allCat.Where(x => x.SectionId == currentDistrict.Id)
          .OrderBy(x => x.CategoryName)
              .Select(x => new SelectListItem
              {
                Value = x.Id.ToString(),
                Text = x.CategoryName,
                Selected = x.Id == (selectedId == null ? 0 : selectedId)
              })
          );

      return result;
    }
  }
}
