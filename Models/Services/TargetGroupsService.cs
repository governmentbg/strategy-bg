using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Contracts;
using Models.ViewModels.TargetGroupsModel;
using System;
using System.Linq;
using WebCommon.Services;

namespace Models.Services
{
	public class TargetGroupsService : BaseService, ITargetGroupsService
	{
		private readonly ILogger logger;
		private readonly IUserContext userContext;

		public TargetGroupsService(MainContext context, ILogger<QuestionaryService> _logger, IUserContext _userContext)
		{
			this.db = context;
			logger = _logger;
			userContext = _userContext;
		}

		#region TargetGroups
		public IQueryable<TargetGroupsListViewModel> GetTargetGroupsList(int active)
		{
			return this.All<TargetGroups>()
				.Where(x => x.LanguageId == GlobalConstants.LangBG && !x.IsDeleted && x.IsActive == (active == -1 ? x.IsActive : (active == 1 ? true : false)))
				.OrderBy(x => x.Name)
				.Select(c => new TargetGroupsListViewModel()
				{
					Id = c.Id,
					Name = c.Name,
					IsActive = c.IsActive,
					DateCreated = c.DateCreated
				});
		}

		public TargetGroupsViewModel GetTargetGroups(int id)
		{
			var entity = this.All<TargetGroups>().Find(id);
			var model = new TargetGroupsViewModel();
			model.FromEntity(entity);

			return model;
		}

		public bool SaveTargetGroups(TargetGroupsViewModel model)
		{
			var result = false;
			TargetGroups entity = null;

			try
			{
				if (model.Id > 0)
				{
					entity = All<TargetGroups>().Find(model.Id);

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
					entity.IsDeleted = false;
					entity.DateCreated = DateTime.Now;
					entity.ModifiedByUserId = userContext.UserId;
					entity.CreatedByUserId = userContext.UserId;
					entity.DateModified = DateTime.Now;

					All<TargetGroups>().Add(entity);
				}

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "SaveTargetGroups failed.");
			}

			return result;
		}
		#endregion
	}
}
