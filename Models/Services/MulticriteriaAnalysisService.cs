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
using Models.Context.MulticriteriaAnalysis;
using Models.ViewModels.MulticriteriaAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.Services
{
    public class MulticriteriaAnalisysService : BaseService, IMulticriteriaAnalisysService
    {
        private readonly ILogger logger;
        private readonly ICommonService commService;
        private readonly IUserContext userContext;
        public MulticriteriaAnalisysService(
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

        #region MulticriteriaAnalisys Services 
        public Criteria Criteria_GetByID(int id)
        {
            return db.Criteria.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Criteria_SaveData(Criteria model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var saved = db.Criteria.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
                    model.DateWrt = DateTime.Now;
                    db.Criteria.Update(model);
                    db.SaveChanges();
                }
                else
                {
                    model.DateWrt = DateTime.Now;
                    db.Criteria.Add(model);
                    db.SaveChanges();
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<Criteria> Criteria_Select()
        {
            return db.Criteria.AsQueryable();
        }
        #endregion

        #region CriteriaValues Services
        public CriteriaValue CriteriaValue_GetByID(int id)
        {
            return db.CriteriaValue.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool CriteriaValue_SaveData(CriteriaValue model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var saved = db.CriteriaValue.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);
                    db.CriteriaValue.Update(model);
                    db.SaveChanges();
                }
                else
                {

                    db.CriteriaValue.Add(model);
                    db.SaveChanges();
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<CriteriaValue> CriteriaValue_Select(int criteria_id)
        {
            return db.CriteriaValue.Where(x => x.CriteriaId == criteria_id).AsQueryable();
        }
    #endregion



    public MulticriteriaAnalysisVM MulticriteriaAnalysis_Init()
    {
      MulticriteriaAnalysisVM model = new MulticriteriaAnalysisVM();
      model.Criteria = db.Criteria
                          .Include(x => x.CriteriaValues)
                          .ToList()
                          .Select(x => new mcaCriteriaVM
                          {
                            CriteriaId = x.Id,
                            CriteriaName = x.Name,
                            CriteriaDescription = x.Description,
                            CriteriaValues = x.CriteriaValues.Select(v => new SelectListItem
                            {
                              Value = v.Id.ToString(),
                              Text = v.Name
                            })
                          })
                          .ToList();

      return model;
    }


  }


}
