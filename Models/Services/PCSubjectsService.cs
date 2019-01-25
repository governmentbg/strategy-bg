using Microsoft.AspNetCore.Mvc.Rendering;
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

		public PCSubjectsService(MainContext context, ILogger<QuestionaryService> _logger, IUserContext _userContext)
		{
			this.db = context;
			logger = _logger;
			userContext = _userContext;
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
			return this.All<PCSubjects>()
				.Where(x => x.IsUL == (pcSubjectsTypeID == -1 ? x.IsUL : (pcSubjectsTypeID == 1 ? true : false))
					&& (string.IsNullOrEmpty(eik) ? true : (pcSubjectsTypeID == 0 ? true : x.EIK == eik))
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
					ActivityDescription = c.ActivityDescription
				});
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
	}
}
