using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Ogp;
using Models.Contracts;
using Models.ViewModels.Ogp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebCommon.Models;
using WebCommon.Services;

namespace Models.Services
{
    public class OgpService : BaseService, IOgpService
    {
        private readonly ILogger logger;
        private readonly IUserContext userContext;
        public OgpService(
            MainContext context,
            ILogger<OgpService> _logger,
            IUserContext _userContext
         )
        {
            this.db = context;
            logger = _logger;
            userContext = _userContext;
        }
        public IQueryable<PlanItemVM> Element_Select(int? parentId, int? id = null)
        {
            Expression<Func<NationalPlanElements, bool>> where = x => true;
            if (id > 0)
            {
                where = x => x.Id == id;
            }
            else
            {
                where = x => x.ParentID == parentId;
            }
            return All<NationalPlanElements>()
                        .Include(x => x.ElementType)
                        .Include(x => x.NationalPlanState)
                        .Where(where)
                        .OrderBy(x => x.NationalPlanStateId)
                        .Select(x => new PlanItemVM
                        {
                            Id = x.Id,
                            ParentId = x.ParentID,
                            ElementTypeId = x.ElementTypeId,
                            ElementTypeName = x.ElementType.Title,
                            Title = x.Title,
                            Description = x.Description,
                            IsActive = x.IsActive,
                            StateId = x.NationalPlanStateId,
                            StateName = (x.NationalPlanState != null) ? x.NationalPlanState.Title : string.Empty
                        }).AsQueryable();
        }
        public bool Element_SaveData(NationalPlanElements model)
        {
            if (model.ElementTypeId != GlobalConstants.OgpElementTypes.NationalPlan)
            {
                model.NationalPlanStateId = null;
            }
            try
            {
                if (model.Id > 0)
                {
                    var saved = Find<NationalPlanElements>(model.Id);
                    saved.ParentID = model.ParentID;
                    saved.ElementTypeId = model.ElementTypeId;
                    saved.Title = model.Title;
                    saved.Description = model.Description;
                    saved.IsActive = model.IsActive;
                    saved.NationalPlanStateId = model.NationalPlanStateId;
                    saved.ModifiedByUserId = userContext.UserId;
                    saved.DateModified = DateTime.Now;

                    All<NationalPlanElements>().Update(saved);
                    db.SaveChanges();
                }
                else
                {
                    model.CreatedByUserId = userContext.UserId;
                    model.DateCreated = DateTime.Now;

                    model.ModifiedByUserId = userContext.UserId;
                    model.DateModified = model.DateCreated;

                    All<NationalPlanElements>().Add(model);
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

        public IQueryable<TextValueVM> ElementType_Combo()
        {
            return All<ElementTypes>()
                        .OrderBy(x => x.Priority)
                        .Where(x => x.ElementCategory == GlobalConstants.NationalElementTypeCategories.Plan)
                        .ToList()
                        .Select(x => new TextValueVM
                        {
                            Value = x.Id.ToString(),
                            Text = x.Title
                        }).AsQueryable();
        }

        public IQueryable<TextValueVM> NationalPlanStates_Combo()
        {
            return All<NationalPlanStates>()
                        .OrderBy(x => x.Id)
                        .ToList()
                        .Select(x => new TextValueVM
                        {
                            Value = x.Id.ToString(),
                            Text = x.Title
                        }).AsQueryable();
        }

        public PlanVM Portal_GetElement(int id)
        {
            var model = new PlanVM()
            {
                Plan = Element_Select(null, id).FirstOrDefault(),
                SubElements = Element_Select(id, null)
            };
            if (model.Plan.ParentId > 0)
            {
                model.Parent = Element_Select(null, model.Plan.ParentId).FirstOrDefault();
            }
            return model;
        }

        public IQueryable<EstimationVM> Estimation_Select(int elementId, int? parentId, int? id = null)
        {
            Expression<Func<NationalPlanEstimations, bool>> where = x => x.ElementID == elementId;
            if (parentId > 0)
            {
                where = x => x.ParentID == parentId;
            }
            if (id > 0)
            {
                where = x => x.Id == id;
            }
            return All<NationalPlanEstimations>()
                         .Include(x => x.EstimationType)
                         .Include(x => x.PlanElement)
                         .ThenInclude(x => x.ElementType)
                         .Where(where)
                         .Select(x => new EstimationVM
                         {
                             Id = x.Id,
                             ElementId = x.ElementID,
                             ElementName = x.PlanElement.ElementType.Title + ": " + x.PlanElement.Title,
                             EstimationTypeId = x.EstimationTypeId,
                             EstimationTypeName = x.EstimationType.Title,
                             Title = x.Title,
                             Description = x.Description,
                             IsActive = x.IsActive
                         }).AsQueryable();
        }

        public bool Estimation_SaveData(NationalPlanEstimations model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var saved = Find<NationalPlanEstimations>(model.Id);
                    saved.EstimationTypeId = model.EstimationTypeId;
                    saved.Title = model.Title;
                    saved.Description = model.Description;
                    saved.IsActive = model.IsActive;
                    saved.ModifiedByUserId = userContext.UserId;
                    saved.DateModified = DateTime.Now;

                    All<NationalPlanEstimations>().Update(saved);
                    db.SaveChanges();
                }
                else
                {
                    model.CreatedByUserId = userContext.UserId;
                    model.DateCreated = DateTime.Now;

                    model.ModifiedByUserId = userContext.UserId;
                    model.DateModified = model.DateCreated;

                    All<NationalPlanEstimations>().Add(model);
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

        public IQueryable<TextValueVM> EstimationType_Combo()
        {
            return All<EstimationTypes>()
                        .OrderBy(x => x.Id)
                        .ToList()
                        .Select(x => new TextValueVM
                        {
                            Value = x.Id.ToString(),
                            Text = x.Title
                        }).AsQueryable();
        }

        public IQueryable<TextValueVM> NationalPlanSubElements_Combo(int planId)
        {
            var result = new List<TextValueVM>();

            NationalPlanSubElements_Combo(result, planId, false);

            return result.AsQueryable();
        }
        private void NationalPlanSubElements_Combo(List<TextValueVM> items, int elementId, bool addCurrent = true)
        {
            if (addCurrent)
            {
                items.Add(
                    Element_Select(null, elementId)
                                .ToList()
                                .Select(x => x.GetComboElement())
                                .FirstOrDefault()
                );
            }
            var subElements = Element_Select(elementId, null)
                                .ToList();
            foreach (var item in subElements)
            {
                NationalPlanSubElements_Combo(items, item.Id);
            }
        }

    }
}
