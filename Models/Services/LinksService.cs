using Microsoft.Extensions.Logging;
using Models.Context;
using Models.ViewModels.LinksModels;
using Models.Contracts;
using System;
using System.Linq;
using Models.Context.LinksModels;
using WebCommon.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.Services
{
	public class LinksService : BaseService, ILinksService
	{
		private readonly ILogger logger;
		private readonly IUserContext userContext;

		public LinksService(MainContext context, ILogger<QuestionaryService> _logger, IUserContext _userContext)
		{
			this.db = context;
			logger = _logger;
			userContext = _userContext;
		}

		#region Links Caterories
		public IQueryable<LinksCateroriesListViewModel> GetLinksCategories(int active)
		{
			return this.All<LinksCategories>()
				.Where(x => x.LanguageId == GlobalConstants.LangBG && !x.IsDeleted && x.IsActive == (active == -1 ? x.IsActive : (active == 1 ? true : false)))
				.OrderBy(x => x.ViewOrder)
				.Select(c => new LinksCateroriesListViewModel()
				{
					Id = c.Id,
					Name = c.Name,
					IsActive = c.IsActive,
					DateCreated = c.DateCreated
				});
		}

		public LinksCategoriesViewModel GetLinksCategory(int id)
		{
			var entity = this.All<LinksCategories>().Find(id);
			var model = new LinksCategoriesViewModel();
			model.FromEntity(entity);

			return model;
		}

		public bool SaveLinksCategories(LinksCategoriesViewModel model)
		{
			var result = false;
			LinksCategories entity = null;

			try
			{
				if (model.Id > 0)
				{
					entity = All<LinksCategories>().Find(model.Id);

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

					All<LinksCategories>().Add(entity);
				}

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "SaveLinksCategories failed.");
			}

			return result;
		}
		#endregion

		#region Links
		public IQueryable<LinksListViewModel> GetLinksList(int active, int linksCategoryId)
		{
			return this.All<Links>()
				.Where(x => x.LanguageId == GlobalConstants.LangBG && !x.IsDeleted && x.IsActive == (active == -1 ? x.IsActive : (active == 1 ? true : false)) && x.LinksCategoryID == linksCategoryId)
				.OrderBy(x => x.Priority)
				.Select(c => new LinksListViewModel()
				{
					Id = c.Id,
					Title = c.Title,
					Url = c.Url,
					Text = c.Text,
					CategoryText = c.LinksCategory.Name,
					IsActive = c.IsActive,
					DateCreated = c.DateCreated
				});
		}

		public LinksViewModel GetLinks(int id)
		{
			var entity = this.All<Links>().Find(id);
			var model = new LinksViewModel();
			model.FromEntity(entity);

			return model;
		}

		public bool SaveLinks(LinksViewModel model)
		{
			var result = false;
			Links entity = null;

			try
			{
				if (model.Id > 0)
				{
					entity = All<Links>().Find(model.Id);

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

					All<Links>().Add(entity);
				}

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Save Links failed.");
			}

			return result;
		}

		public IEnumerable<SelectListItem> GetLinksCategoriesDDL()
		{
			return this.All<LinksCategories>()
					.Where(g => g.IsActive)
					.Where(g => g.IsApproved)
					.Where(g => !g.IsDeleted)
					.Where(g => g.LanguageId == GlobalConstants.LangBG)
					.OrderBy(g => g.Name)
					.Select(g => new SelectListItem()
					{
						Text = g.Name,
						Value = g.Id.ToString()
					})
					.ToList();
			//.Prepend(new SelectListItem()
			//{
			//	Text = "Изберете",
			//	Value = "-1"
			//})
			//.ToList();

		}
		#endregion

		#region Links - Order
		public void OrderLinksCategories(int id, bool moveUp = true)
		{
			try
			{
				LinksCategories linksCategoryCurrent = this.All<LinksCategories>().Find(id);
				LinksCategories linksCategorySwap = new LinksCategories();

				int maxOrderNum = this.All<LinksCategories>().Max(x => x.ViewOrder);
				int minOrderNum = this.All<LinksCategories>().Min(x => x.ViewOrder);
				int j = 0;
				int swap = 0;

				List<LinksCategories> linksCategoriesList = this.All<LinksCategories>().OrderBy(x => x.ViewOrder).ToList();

				if ((moveUp && linksCategoryCurrent.ViewOrder == minOrderNum) || (moveUp == false && linksCategoryCurrent.ViewOrder == maxOrderNum))
				{
					return;
				}

				for (int i = 0; i < linksCategoriesList.Count; i++)
				{
					if (linksCategoriesList[i].ViewOrder == linksCategoryCurrent.ViewOrder)
					{
						j = i;
						break;
					}
				}

				if (moveUp)
				{
					swap = linksCategoriesList[j - 1].ViewOrder;
					linksCategorySwap = this.All<LinksCategories>().Find(linksCategoriesList[j - 1].Id);

					linksCategorySwap.ViewOrder = linksCategoryCurrent.ViewOrder;
					linksCategoryCurrent.ViewOrder = swap;
				}
				else
				{
					// move down
					swap = linksCategoriesList[j + 1].ViewOrder;
					linksCategorySwap = this.All<LinksCategories>().Find(linksCategoriesList[j + 1].Id);

					linksCategorySwap.ViewOrder = linksCategoryCurrent.ViewOrder;
					linksCategoryCurrent.ViewOrder = swap;
				}

				db.SaveChanges();
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "OrderLinksCategories failed.");
			}
		}

		public void OrderLinks(int id, bool moveUp = true)
		{
			try
			{
				Links linksCurrent = this.All<Links>().Find(id);
				Links linksSwap = new Links();

				int maxOrderNum = this.All<Links>().Max(x => x.Priority);
				int minOrderNum = this.All<Links>().Min(x => x.Priority);
				int j = 0;
				int swap = 0;

				List<Links> linksList = this.All<Links>().Where(x => x.LinksCategoryID == linksCurrent.LinksCategoryID).OrderBy(x => x.Priority).ToList();

				if ((moveUp && linksCurrent.Priority == minOrderNum) || (moveUp == false && linksCurrent.Priority == maxOrderNum))
				{
					return;
				}

				for (int i = 0; i < linksList.Count; i++)
				{
					if (linksList[i].Priority == linksCurrent.Priority)
					{
						j = i;
						break;
					}
				}

				if (moveUp)
				{
					swap = linksList[j - 1].Priority;
					linksSwap = this.All<Links>().Find(linksList[j - 1].Id);

					linksSwap.Priority = linksCurrent.Priority;
					linksCurrent.Priority = swap;
				}
				else
				{
					// move down
					swap = linksList[j + 1].Priority;
					linksSwap = this.All<Links>().Find(linksList[j + 1].Id);

					linksSwap.Priority = linksCurrent.Priority;
					linksCurrent.Priority = swap;
				}

				db.SaveChanges();
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "OrderLinks failed.");
			}
		}
		#endregion
	}
}
