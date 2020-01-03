using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Consultations;
using Models.Context.Questionary;
using Models.Contracts;
using Models.ViewModels.Questionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCommon.Models;

namespace Models.Services
{
	public class QuestionaryService : BaseService, IQuestionaryService
	{
		private readonly ILogger logger;
		private readonly IAccountService accountService;

		public QuestionaryService(MainContext context, ILogger<QuestionaryService> _logger, IAccountService _accountService)
		{
			this.db = context;
			logger = _logger;
			accountService = _accountService;
		}

		#region Questionary
		public IQueryable<QuestionaryListViewModel> GetQuestionaries(int? status)
		{
			DateTime lastDate = new DateTime(2100, 1, 1);

			var result = this.All<QuestionaryHeaders>()
							 .OrderByDescending(x => x.StartDate)
							 .Select(c => new QuestionaryListViewModel()
							 {
								 Id = c.Id,
								 ActiveId = ((c.StartDate.Date <= DateTime.Now.Date) && ((c.EndDate ?? lastDate) > DateTime.Now.Date)) ? c.Id : 0,
								 SourceType = c.SourceTypeId,
								 Title = c.QuestionaryTitle,
								 Description = c.QuestionaryDescription,
								 OpenningDate = c.StartDate,
								 ClosingDate = c.EndDate,
								 ParticipantsNumber = this.All<QuestionaryAnsweredUsers>().Where(x => x.QuestionaryHeaderId == c.Id).Count()
							 });

			switch (status)
			{
				case -1:
					// всички - не правим нищо
					break;
				case 0:
					// приключили
					result = this.All<QuestionaryHeaders>()
							 .Where(x => x.EndDate < DateTime.Now.Date)
							 .OrderByDescending(x => x.StartDate)
							 .Select(c => new QuestionaryListViewModel()
							 {
								 Id = c.Id,
								 ActiveId = 0,
								 SourceType = c.SourceTypeId,
								 Title = c.QuestionaryTitle,
								 Description = c.QuestionaryDescription,
								 OpenningDate = c.StartDate,
								 ClosingDate = c.EndDate,
								 ParticipantsNumber = this.All<QuestionaryAnsweredUsers>().Where(x => x.QuestionaryHeaderId == c.Id).Count()
							 });
					break;
				case 1:
					// активни
					result = this.All<QuestionaryHeaders>()
							 .Where(x => x.StartDate.Date <= DateTime.Now.Date && ((x.EndDate ?? lastDate) > DateTime.Now.Date))
							 .OrderByDescending(x => x.StartDate)
							 .Select(c => new QuestionaryListViewModel()
							 {
								 Id = c.Id,
								 ActiveId = c.Id,
								 SourceType = c.SourceTypeId,
								 Title = c.QuestionaryTitle,
								 Description = c.QuestionaryDescription,
								 OpenningDate = c.StartDate,
								 ClosingDate = c.EndDate,
								 ParticipantsNumber = this.All<QuestionaryAnsweredUsers>().Where(x => x.QuestionaryHeaderId == c.Id).Count()
							 });
					break;
				default:
					// do nothing - еквивалентно на всички
					break;
			}

			return result;
		}

		public QuestionaryViewModel GetQuestionary(int id)
		{
			var entity = this.All<QuestionaryHeaders>().Find(id);
			var model = new QuestionaryViewModel();
			model.FromEntity(entity);

			return model;
		}

		public QuestionaryViewModel GetQuestionary(int sourceTypeID, int sourceId)
		{
			var entity = this.All<QuestionaryHeaders>().FirstOrDefault(x => x.SourceId == sourceId && x.SourceTypeId == sourceTypeID);

			if (entity == null)
			{
				entity = new QuestionaryHeaders();
				entity.SourceId = sourceId;
				entity.SourceTypeId = sourceTypeID;

                if (sourceTypeID == GlobalConstants.SourceTypes.PublicConsultation)
                {
                    var consultation = this.All<PublicConsultation>().Find(sourceId);

                    if (consultation != null)
                    {
                        entity.StartDate = consultation.OpenningDate;
                        entity.EndDate = consultation.ClosingDate;
                    }
                }
            }

			var model = new QuestionaryViewModel();
			model.FromEntity(entity);

			return model;
		}

		public bool SaveQuestionary(QuestionaryViewModel model, int userId)
		{
			var result = false;
			QuestionaryHeaders entity = null;

			try
			{
				if (model.Id > 0)
				{
					entity = All<QuestionaryHeaders>()
							.Find(model.Id);

					if (entity != null)
					{
						entity = model.ToEntity(entity);
					}
				}
				else
				{
					entity = model.ToEntity();
					entity.SourceId = model.SourceId;
					entity.SourceTypeId = model.SourceTypeId;
					entity.CreateUserId = userId;
					entity.CreateDate = DateTime.Now;

					All<QuestionaryHeaders>().Add(entity);
				}

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Save Questionary failed.");
			}

			return result;
		}
		#endregion

		#region Quetions
		public IQueryable<QuestionsListViewModel> GetQuestions(int questionaryHeaderId)
		{
			return this.All<QuestionaryQuestions>()
							.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
							.Select(c => new QuestionsListViewModel()
							{
								Id = c.Id,
								OrderNum = c.OrderNum,
								Description = c.QuestionDescription
							});
		}

		public QuestionViewModel GetQuestion(int id)
		{
			var entity = this.All<QuestionaryQuestions>().Find(id);
			var model = new QuestionViewModel();
			model.FromEntity(entity);

			return model;
		}

		public bool SaveQuestion(QuestionViewModel model)
		{
			var result = false;
			QuestionaryQuestions entity = null;

			try
			{
				if (model.Id > 0)
				{
					entity = All<QuestionaryQuestions>()
							.Find(model.Id);

					if (entity != null)
					{
						entity = model.ToEntity(entity);
					}
				}
				else
				{
					entity = model.ToEntity();
					All<QuestionaryQuestions>().Add(entity);
				}

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Save Question failed.");
			}

			return result;
		}
		#endregion

		#region Answers
		public IQueryable<PossibleAnswersListViewModel> GetAnswers(int questionaryHeaderId)
		{
			return this.All<QuestionaryPossibleAnswers>()
							.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
							.Select(c => new PossibleAnswersListViewModel()
							{
								Id = c.Id,
								QuestionaryHeaderId = c.QuestionaryHeaderId,
								Answer = c.Answer
							});
		}

		public PossibleAnswersViewModel GetAnswer(int id)
		{
			var entity = this.All<QuestionaryPossibleAnswers>().Find(id);
			var model = new PossibleAnswersViewModel();
			model.FromEntity(entity);

			return model;
		}

		public bool SaveAnswer(PossibleAnswersViewModel model)
		{
			var result = false;
			QuestionaryPossibleAnswers entity = null;

			try
			{
				if (model.Id > 0)
				{
					entity = All<QuestionaryPossibleAnswers>()
							.Find(model.Id);

					if (entity != null)
					{
						entity = model.ToEntity(entity);
					}
				}
				else
				{
					entity = model.ToEntity();
					All<QuestionaryPossibleAnswers>().Add(entity);
				}

				db.SaveChanges();
				model.Id = entity.Id;

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Save Answer failed.");
			}

			return result;
		}
		#endregion

		#region FillQuestionary
		public FillQuestionaryViewModel SetAnswers(int questionaryHeaderId)
		{
			FillQuestionaryViewModel model = new FillQuestionaryViewModel();
			var questionaryHeader = this.All<QuestionaryHeaders>().FirstOrDefault(x => x.Id == questionaryHeaderId);
			model.QuestionaryHeaderId = questionaryHeaderId;
			model.QuestionaryTitle = questionaryHeader.QuestionaryTitle;
			model.QuestionaryDescription = questionaryHeader.QuestionaryDescription;
			model.SourceType = questionaryHeader.SourceTypeId ?? 0;
			model.SourceId = questionaryHeader.SourceId ?? 0;

			model.QuestionaryPossibleAnswers = this.All<QuestionaryPossibleAnswers>()
								.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
								.Select(c => new PossibleAnswersViewModel()
								{
									Id = c.Id,
									QuestionaryHeaderId = c.QuestionaryHeaderId,
									Answer = c.Answer
								})
								.ToList();

			model.QuestionaryQuestions = this.All<QuestionaryQuestions>()
											.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
											.Select(c => new QuestionaryQuestionVM()
											{
												AnswerId = 0,
												QuestionId = c.Id,
												Text = c.QuestionDescription
											})
											.ToList();

			foreach (var question in model.QuestionaryQuestions)
			{
				question.QuestionaryAnswers = model.QuestionaryPossibleAnswers
						.Select(c => new QuestionaryAnswerVM()
						{
							Selected = false,
							Text = c.Answer,
							Value = c.Id.ToString(),
							QuestionId = c.Id
						});
			}

			/*
			foreach (var question in model.QuestionaryQuestions)
			{
				int i = 1;
				foreach (var answer in question.QuestionaryAnswers)
				{
					if (i == 1)
					{
						answer.Selected = true;
					}
					else
					{
						answer.Selected = false;
					}

					i++;
				}
			}
			*/

			return model;
		}

		public bool SaveFilledQuestionary(FillQuestionaryViewModel model)
		{
			var result = false;

			QuestionaryAnsweredUsers answeredUser = this.All<QuestionaryAnsweredUsers>()
					.FirstOrDefault(x => x.QuestionaryHeaderId == model.QuestionaryHeaderId &&
					((x.AnsweredUserId != null && x.AnsweredUserId == model.AnsweredUserId) || x.AnsweredUserEmail == model.AnsweredUserEmail));

			try
			{
				if (answeredUser != null && answeredUser.Id > 0)
				{
					answeredUser.AnsweredUserEmail = model.AnsweredUserEmail;
					answeredUser.AnsweredUserName = model.AnsweredUserName;
					answeredUser.AnsweredStartDate = model.AnsweredStartDate;
					answeredUser.AnsweredEndDate = DateTime.Now;
				}
				else
				{
					// add new answered User
					QuestionaryAnsweredUsers user = new QuestionaryAnsweredUsers();
					user.QuestionaryHeaderId = model.QuestionaryHeaderId;
					user.AnsweredStartDate = model.AnsweredStartDate;
					user.AnsweredEndDate = DateTime.Now;
					user.AnsweredUserId = model.AnsweredUserId;
					user.AnsweredUserEmail = model.AnsweredUserEmail;
					user.AnsweredUserName = model.AnsweredUserName;
					user.AnsweredStartDate = model.AnsweredStartDate;
					user.AnsweredEndDate = DateTime.Now;

					All<QuestionaryAnsweredUsers>().Add(user);

					db.SaveChanges();

					answeredUser = new QuestionaryAnsweredUsers();
					answeredUser.Id = user.Id;
				}

				foreach (var question in model.QuestionaryQuestions)
				{
					List<QuestionaryAnswers> entityForDeletion = this.All<QuestionaryAnswers>().Where(x => x.QuestionaryQuestionId == question.QuestionId
						&& x.QuestionaryAnsweredUserId == answeredUser.Id).ToList();

					this.DeleteRange<QuestionaryAnswers>(x => x.QuestionaryQuestionId == question.QuestionId && x.QuestionaryAnsweredUserId == answeredUser.Id);

					if (question.AnswerId != null)
					{
						QuestionaryAnswers entity = new QuestionaryAnswers();
						entity.QuestionaryQuestionId = question.QuestionId;
						entity.QuestionaryAnsweredUserId = answeredUser.Id;
						entity.QuestionaryPossibleAnswerId = question.AnswerId ?? 0;

						All<QuestionaryAnswers>().Add(entity);
					}
				}

				db.SaveChanges();

				result = true;
			}
			catch (Exception ex)
			{
				logger.LogError(ex, "Save Filled Question failed.");
			}

			return result;
		}

		public QuestionaryResultsListViewModel GetResults(int questionaryHeaderId)
		{
			QuestionaryResultsListViewModel results = new QuestionaryResultsListViewModel();

			int checkedCount = 0;
			decimal checkedPercent = 0m;
			int totalCheckedCountForQuestion = 0;

			var questionaryHeader = this.GetQuestionary(questionaryHeaderId);
            results.SourceType = questionaryHeader.SourceTypeId ?? 0;
            results.SourceId = questionaryHeader.SourceId ?? 0;
            results.QuestionaryHeaderId = questionaryHeaderId;
			results.QuestionaryTitle = questionaryHeader.QuestionaryTitle;
			results.QuestionaryDescription = questionaryHeader.QuestionaryDescription;
			results.StartDate = questionaryHeader.StartDate;
			results.EndDate = questionaryHeader.EndDate;
			results.AnsweredUsersCount = this.All<QuestionaryAnsweredUsers>().Where(x => x.QuestionaryHeaderId == questionaryHeaderId).Count();

			results.PossibleAnswers = this.All<QuestionaryPossibleAnswers>()
											.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
											.Select(c => new PossibleAnswersListViewModel()
											{
												Id = c.Id,
												QuestionaryHeaderId = c.QuestionaryHeaderId,
												Answer = c.Answer
											})
											.ToList();

			results.Questions = this.All<QuestionaryQuestions>()
											.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
											.Select(c => new QuestionaryResultsQuestionViewModel()
											{
												Id = c.Id,
												QuestionDescription = c.QuestionDescription,
												QuestionNum = c.OrderNum ?? 0
											})
											.ToList();

			foreach (var question in results.Questions)
			{
				question.answers = new List<QuestionaryResultsAnswerViewModel>();

				totalCheckedCountForQuestion = 0;
				foreach (var possibleAnswer in results.PossibleAnswers)
				{
					totalCheckedCountForQuestion += this.All<QuestionaryAnswers>().Where(x => x.QuestionaryQuestionId == question.Id
						&& x.QuestionaryPossibleAnswerId == possibleAnswer.Id).Count();
				}

				foreach (var possibleAnswer in results.PossibleAnswers)
				{
					QuestionaryResultsAnswerViewModel answer = new QuestionaryResultsAnswerViewModel();

					answer.Id = possibleAnswer.Id;
					answer.QuestionId = question.Id;

					checkedCount = this.All<QuestionaryAnswers>().Where(x => x.QuestionaryQuestionId == question.Id
						&& x.QuestionaryPossibleAnswerId == possibleAnswer.Id).Count();
					answer.AnswersCheckedCount = checkedCount;

					checkedPercent = checkedCount == 0 ? 0 : Math.Round(100 * (decimal)checkedCount / (decimal)totalCheckedCountForQuestion, 2);
					answer.AnswersCheckedPercent = checkedPercent;

					question.answers.Add(answer);
				}
			}

			return results;
		}

		public List<QuestionChartResultViewModel> QuestinaryResultsLoadData(int questionaryHeaderId, int questionaryQuestionId)
		{
			QuestionaryResultsListViewModel model = this.GetResults(questionaryHeaderId);

			List<QuestionChartResultViewModel> dataList = new List<QuestionChartResultViewModel>();

			foreach (var question in model.Questions.Where(x => x.Id == questionaryQuestionId))
			{
				foreach (var possibleAnswer in model.PossibleAnswers)
				{
					var pa = question.answers.FirstOrDefault(x => x.QuestionId == question.Id && x.Id == possibleAnswer.Id);
					dataList.Add(new QuestionChartResultViewModel(possibleAnswer.Answer, pa == null ? 0 : pa.AnswersCheckedPercent));
				}
			}

			return dataList;
		}

		public FilledQuestionaryViewModel GetFilledQuestionary(int questionaryHeaderId, int? userId, string userEmail)
		{
			FilledQuestionaryViewModel results = new FilledQuestionaryViewModel();
			QuestionaryAnsweredUsers user = null;
			int aUserId = 0;

			if (userId == null)
			{
				// search user by email
				user = this.All<QuestionaryAnsweredUsers>().Where(x => x.QuestionaryHeaderId == questionaryHeaderId && x.AnsweredUserEmail == userEmail).FirstOrDefault();
				aUserId = user == null ? 0 : user.Id;
			}
			else
			{
				// search user by userID
				user = this.All<QuestionaryAnsweredUsers>().Where(x => x.QuestionaryHeaderId == questionaryHeaderId && x.AnsweredUserId == userId).FirstOrDefault();
				aUserId = user == null ? 0 : user.Id;

				var accUser = accountService.Users_GetById(aUserId);

				if (accUser != null)
				{
					user.AnsweredUserEmail = accUser.Email;
					user.AnsweredUserName = accUser.GetFullName;
				}
			}

			if (user != null)
			{
				results.AnsweredUserEmail = user.AnsweredUserEmail;
				results.AnsweredUserName = user.AnsweredUserName;
				results.AnsweredStartDate = user.AnsweredStartDate;
				results.AnsweredEndDate = user.AnsweredEndDate;
			}
			else
			{
				aUserId = 0;
			}

			var questionaryHeader = this.GetQuestionary(questionaryHeaderId);
			results.QuestionaryTitle = questionaryHeader.QuestionaryTitle;

			results.QuestionsWithAnswers = this.All<QuestionaryAnswers>()
				.Where(x => x.QuestionaryQuestion.QuestionaryHeader.Id == questionaryHeaderId && x.QuestionaryAnsweredUserId == aUserId)
				.Select(c => new QuestionsWithAnswers()
				{
					Question = c.QuestionaryQuestion.QuestionDescription,
					Answer = c.QuestionaryPossibleAnswer.Answer
				})
				.ToList();
			/*

			results.PossibleAnswers = this.All<QuestionaryPossibleAnswers>()
											.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
											.Select(c => new PossibleAnswersListViewModel()
											{
												Id = c.Id,
												QuestionaryHeaderId = c.QuestionaryHeaderId,
												Answer = c.Answer
											})
											.ToList();

			results.Questions = this.All<QuestionaryQuestions>()
											.Where(x => x.QuestionaryHeaderId == questionaryHeaderId)
											.Select(c => new QuestionaryResultsQuestionViewModel()
											{
												Id = c.Id,
												QuestionDescription = c.QuestionDescription,
												QuestionNum = c.OrderNum ?? 0
											})
											.ToList();

			foreach (var question in results.Questions)
			{
				question.answers = new List<QuestionaryResultsAnswerViewModel>();

				foreach (var possibleAnswer in results.PossibleAnswers)
				{
					QuestionaryResultsAnswerViewModel answer = new QuestionaryResultsAnswerViewModel();

					answer.Id = possibleAnswer.Id;
					answer.QuestionId = question.Id;

					checkedCount = this.All<QuestionaryAnswers>().Where(x => x.QuestionaryQuestionId == question.Id
						&& x.QuestionaryPossibleAnswerId == possibleAnswer.Id).Count();
					answer.AnswersCheckedCount = checkedCount;

					checkedPercent = checkedCount == 0 ? 0 : Math.Round(100 * (decimal)checkedCount / (decimal)checkedCount, 2);
					answer.AnswersCheckedPercent = checkedPercent;

					question.answers.Add(answer);
				}
			}
			*/
			return results;
		}
		#endregion

		#region for Public
		public List<SelectListItem> GetStatusID_DDL()
		{
			List<SelectListItem> result = new List<SelectListItem>
			{
				new SelectListItem()
				{
					Text = "Всички",
					Value = "-1"
				},

				new SelectListItem()
				{
					Text = "Активни",
					Value = "1"
				},

				new SelectListItem()
				{
					Text = "Приключили",
					Value = "0"
				}
			};

			return result;
		}
		#endregion
	}
}
