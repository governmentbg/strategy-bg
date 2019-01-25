using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Contracts;
using Models.ViewModels.AboutUs;
using System;
using System.Linq;
using WebCommon.Services;

namespace Models.Services
{
	public class AboutUsService : BaseService, IAboutUsService
	{

		private readonly ILogger logger;
		private readonly IUserContext userContext;

		public AboutUsService(MainContext context, ILogger<AboutUsService> _logger, IUserContext _userContext)
		{
			this.db = context;
			logger = _logger;
			userContext = _userContext;
		}

		#region About Us
		public IQueryable<AboutUsListViewModel> GetAboutUsList(int active)
		{
			return this.All<AboutUs>()
			.Where(x => !x.IsDeleted && x.IsApproved && x.IsActive == (active == -1 ? x.IsActive : (active == 1 ? true : false)) && x.LanguageId == GlobalConstants.LangBG)
			.OrderBy(x => x.Rank)
			.Select(c => new AboutUsListViewModel()
			{
				Id = c.Id,
				FirstName = c.FirstName,
				LastName = c.LastName,
				IsActive = c.IsActive,
				DateCreated = c.DateCreated
			});
		}

		public AboutUsViewModel GetAboutUs(int id)
		{
			var entity = this.All<AboutUs>().Find(id);
			var model = new AboutUsViewModel();
			model.FromEntity(entity);

			return model;
		}

		public bool SaveAboutUs(AboutUsViewModel model)
		{
			var result = false;
			AboutUs entity = null;

			try
			{
				if (model.Id > 0)
				{
					entity = All<AboutUs>().Find(model.Id);

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
					entity.Id = model.Id;
					entity.IsActive = model.IsActive;

					entity.DateCreated = DateTime.Now;
					entity.ModifiedByUserId = userContext.UserId;

					entity.CreatedByUserId = userContext.UserId;
					entity.DateModified = DateTime.Now;

					All<AboutUs>().Add(entity);
				}

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Save About Us failed.");
			}

			return result;
		}
		#endregion
	}
}
