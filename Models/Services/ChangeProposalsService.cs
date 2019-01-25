using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Services;

namespace Models.Services
{
	public class ChangeProposalsService : BaseService, IChangeProposalsService
	{

		private readonly ILogger logger;
		private readonly IUserContext userContext;

		public ChangeProposalsService(MainContext context, ILogger<ChangeProposalsService> _logger, IUserContext _userContext)
		{
			this.db = context;
			logger = _logger;
			userContext = _userContext;
		}

		#region Change Proposal
		public IQueryable<ChangeProposalsListViewModel> GetChangeProposalsList(int active, int categoryId, bool isMunicipality, bool? approved, bool? rejected)
		{
			if (isMunicipality)
			{
				return this.All<ChangeProposals>()
				.Where(x => !x.IsRejected && x.IsActive == (active == -1 ? x.IsActive : (active == 1 ? true : false))
					&& ((categoryId == -1) ? (x.Category.ParentId == 2 || x.Category.ParentId == 3)
						: ((categoryId < -1 && x.Category.SectionId != -categoryId) ? (x.CategoryId == -categoryId) : (x.Category.SectionId == -categoryId || x.Category.Id == categoryId)))
					&& (approved == null ? x.IsApproved == x.IsApproved : x.IsApproved == approved)
					&& (rejected == null ? x.IsRejected == x.IsRejected : x.IsRejected == rejected)
					)
				.OrderBy(x => x.Title)
				.Select(c => new ChangeProposalsListViewModel()
				{
					Id = c.Id,
					Title = c.Title,
					Text = c.Text,
					CategoryName = c.Category.CategoryName,
					IsActive = c.IsActive,
					IsApproved = c.IsApproved,
					IsRejected = c.IsRejected,
					DateCreated = c.DateCreated
				});
			}
			else
			{
				return this.All<ChangeProposals>()
				.Where(x => !x.IsRejected && x.IsActive == (active == -1 ? x.IsActive : (active == 1 ? true : false))
					&& x.CategoryId == (categoryId == -1 && x.Category.ParentId != 2 && x.Category.ParentId != 3 ? x.CategoryId : categoryId)
					&& (approved == null ? x.IsApproved == x.IsApproved : x.IsApproved == approved)
					&& (rejected == null ? x.IsRejected == x.IsRejected : x.IsRejected == rejected)
					)
				.OrderBy(x => x.Title)
				.Select(c => new ChangeProposalsListViewModel()
				{
					Id = c.Id,
					Title = c.Title,
					Text = c.Text,
					CategoryName = c.Category.CategoryName,
					IsActive = c.IsActive,
					IsApproved = c.IsApproved,
					IsRejected = c.IsRejected,
					DateCreated = c.DateCreated
				});
			}
		}

		public ChangeProposalsViewModel GetChangeProposals(int id)
		{
			var entity = this.All<ChangeProposals>()
				.Include(x => x.Category)
				.FirstOrDefault(x => x.Id == id);
			var model = new ChangeProposalsViewModel();

			model.FromEntity(entity);

			// областни и общински
			if (entity.Category.ParentId == 2)
			{
				model.CategoryMasterId = 2;

				if (entity.Category.SectionId == 0)
				{
					model.DistrictId = entity.Category.Id;
					model.MunicipalityId = entity.Category.Id;
				}
				else
				{
					model.DistrictId = entity.Category.SectionId;
					model.MunicipalityId = entity.Category.Id;
				}
			}

			return model;
		}

		public string GetCategoryFullText(ChangeProposalsViewModel model)
		{
			string result = "";

			var entity = this.All<Category>().FirstOrDefault(x => x.Id == model.CategoryId);

			// национални
			if (entity.ParentId == 1)
			{
				var parent = this.All<Category>().FirstOrDefault(x => x.Id == entity.ParentId);
				result = parent.CategoryName + " | " + entity.CategoryName;
			}
			else
			{
				// областни и общински
				if (entity.SectionId == 0)
				{
					// ниво областни
					var parent = this.All<Category>().FirstOrDefault(x => x.Id == entity.ParentId);
					result = "Областни и общински | обл." + entity.CategoryName + " | област " + parent.CategoryName;
				}
				else
				{
					// ниво обшина
					var parent = this.All<Category>().FirstOrDefault(x => x.Id == entity.SectionId);
					result = "Областни и общински | обл." + parent.CategoryName + " | " + entity.CategoryName;
				}
			}

			return result;
		}

		public bool SaveChangeProposals(ChangeProposalsViewModel model)
		{
			var result = false;
			ChangeProposals entity = null;

			try
			{
				int categoryId = model.CategoryId;

				// областни и общински
				if (model.CategoryMasterId == 2)
				{
					categoryId = model.MunicipalityId ?? -1;
				}

				if (model.Id > 0)
				{
					entity = All<ChangeProposals>().Find(model.Id);

					if (entity != null)
					{
						entity = model.ToEntity(entity);
						entity.DateModified = DateTime.Now;
						entity.ModifiedByUserId = userContext.UserId;
						entity.ActualUserId = userContext.UserId;
					}
				}
				else
				{
					entity = model.ToEntity();
					entity.Id = model.Id;
					entity.IsActive = model.IsActive;
					entity.ActualUserId = userContext.UserId;

					entity.DateCreated = DateTime.Now;
					entity.ModifiedByUserId = userContext.UserId;

					entity.CreatedByUserId = userContext.UserId;
					entity.DateModified = DateTime.Now;

					All<ChangeProposals>().Add(entity);
				}

				entity.CategoryId = categoryId;

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Save Change Proposals failed.");
			}

			return result;
		}
		#endregion
	}
}
