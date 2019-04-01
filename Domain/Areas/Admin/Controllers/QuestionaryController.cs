using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.Questionary;
using Rotativa.AspNetCore;
using System;
using System.ComponentModel;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
	[Area(nameof(Admin))]
	[Authorize(Roles = GlobalConstants.Roles.Admin)]
	public class QuestionaryController : BaseController
	{
		private readonly IQuestionaryService questionaryService;
		private readonly IUserContext userContext;

		public QuestionaryController(IQuestionaryService _QuestionaryService, IUserContext _userContext)
		{
			questionaryService = _QuestionaryService;
			userContext = _userContext;
		}

		#region Questionary
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult LoadData(IDataTablesRequest request)
		{
			IQueryable<QuestionaryListViewModel> data = questionaryService.GetQuestionaries(null);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult Add(int? sourceTypeID, int? sourceId, int? userId)
		{
			if (sourceTypeID == null || sourceId == null)
			{
				var model = new QuestionaryViewModel();
				model.SourceId = null;
				model.SourceTypeId = null;

				return View("Edit", model);
			}
			else
			{
				var model = questionaryService.GetQuestionary(sourceTypeID ?? 0, sourceId ?? 0);
				return View("Edit", model);
			}
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var model = questionaryService.GetQuestionary(id);

			return View("Edit", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(QuestionaryViewModel model)
		{
			SetSavedMessage = false;

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			SetSavedMessage = questionaryService.SaveQuestionary(model, UserId);

			if (SetSavedMessage)
			{
				return RedirectToAction(nameof(Edit), new { id = model.Id });
			}

			return View(model);
		}
		#endregion

		#region Questions
		public IActionResult IndexQuestions(int questionaryHeaderId)
		{
			QuestionsListViewModel questionsListViewModel = new QuestionsListViewModel
			{
				QuestionaryHeaderId = questionaryHeaderId
			};
			var questionary = questionaryService.GetQuestionary(questionaryHeaderId);
			ViewBag.QuestionaryTitle = questionary.QuestionaryTitle;
			ViewBag.QuestionaryHeaderId = questionaryHeaderId;

			return View("IndexQuestions", questionsListViewModel);
		}

		[HttpPost]
		public IActionResult LoadDataQuestions(IDataTablesRequest request, int questionaryHeaderId)
		{
			IQueryable<QuestionsListViewModel> data = questionaryService.GetQuestions(questionaryHeaderId);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddQuestion(int questionaryHeaderId)
		{
			var model = new QuestionViewModel();
			model.QuestionaryHeaderId = questionaryHeaderId;
			ViewBag.QuestionaryHeaderId = questionaryHeaderId;

			return View("EditQuestion", model);
		}

		[HttpGet]
		public IActionResult EditQuestion(int id)
		{
			var model = questionaryService.GetQuestion(id);
			ViewBag.QuestionaryHeaderId = model.QuestionaryHeaderId;

			return View("EditQuestion", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditQuestion(QuestionViewModel model)
		{
			SetSavedMessage = false;

			if (!ModelState.IsValid)
			{
				return View("EditQuestion", model);
			}

			SetSavedMessage = questionaryService.SaveQuestion(model);
			ViewBag.QuestionaryHeaderId = model.QuestionaryHeaderId;

			return View("EditQuestion", model);
		}
		#endregion

		#region Answers
		public IActionResult IndexAnswers(int questionaryHeaderId)
		{
			PossibleAnswersListViewModel AnswersListViewModel = new PossibleAnswersListViewModel
			{
				QuestionaryHeaderId = questionaryHeaderId
			};
			var questionary = questionaryService.GetQuestionary(questionaryHeaderId);
			ViewBag.QuestionaryTitle = questionary.QuestionaryTitle;
			ViewBag.QuestionaryHeaderId = questionaryHeaderId;

			return View("IndexAnswers", AnswersListViewModel);
		}

		[HttpPost]
		public IActionResult LoadDataAnswers(IDataTablesRequest request, int questionaryHeaderId)
		{
			IQueryable<PossibleAnswersListViewModel> data = questionaryService.GetAnswers(questionaryHeaderId);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		[HttpGet]
		public IActionResult AddAnswer(int questionaryHeaderId)
		{
			var model = new PossibleAnswersViewModel();
			model.QuestionaryHeaderId = questionaryHeaderId;
			ViewBag.QuestionaryHeaderId = questionaryHeaderId;

			return View("EditAnswer", model);
		}

		[HttpGet]
		public IActionResult EditAnswer(int id)
		{
			var model = questionaryService.GetAnswer(id);
			ViewBag.QuestionaryHeaderId = model.QuestionaryHeaderId;

			return View("EditAnswer", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult EditAnswer(PossibleAnswersViewModel model)
		{
			SetSavedMessage = false;

			if (!ModelState.IsValid)
			{
				return View("EditAnswer", model);
			}

			SetSavedMessage = questionaryService.SaveAnswer(model);
			ViewBag.QuestionaryHeaderId = model.QuestionaryHeaderId;

			return View("EditAnswer", model);
		}
		#endregion

		#region Fill Questionary
		[HttpGet]
		public IActionResult FillQuestionary(int questionaryHeaderId, int? userId)
		{
			var model = questionaryService.SetAnswers(questionaryHeaderId);

			if (userId == 0)
			{
				userId = UserId;
			}

			// fill user name and email if user is loged
			if (userContext != null)
			{
				model.AnsweredUserName = userContext.FullName;
				model.AnsweredUserEmail = userContext.Email;
			}

			model.AnsweredUserId = userId;

			return View("FillQuestionary", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult FillQuestionary(FillQuestionaryViewModel model)
		{
			SetSavedMessage = false;

			if (!ModelState.IsValid)
			{
				return View("FillQuestionary", model);
			}

			SetSavedMessage = questionaryService.SaveFilledQuestionary(model);

			if (SetSavedMessage)
			{
				return View("FillQuestionarySuccess", model);
			}
			else
			{
				return View("FillQuestionary", model);
			}
		}

		[HttpGet]
		public IActionResult QuestionaryResults(int questionaryHeaderId)
		{
			QuestionaryResultsListViewModel model = questionaryService.GetResults(questionaryHeaderId);

			return View("QuestionaryResults", model);
		}

		public IActionResult QuestinaryResultsLoadData(int questionaryHeaderId, int questionaryQuestionId)
		{
			return new JsonResult(questionaryService.QuestinaryResultsLoadData(questionaryHeaderId, questionaryQuestionId));
		}
		#endregion

		#region PDF export
		[HttpGet]
		[Description("PDF експорт на резултати от анкета")]
		public ActionResult QuestionaryResultsPDF(int questionaryHeaderId)
		{
			QuestionaryResultsListViewModel model = questionaryService.GetResults(questionaryHeaderId);

			return new ViewAsPdf("_QuestionaryResultsPDF", model);
			//return new ViewAsPdf("_QuestionaryResultsPDF", model)
			//{
			//	FileName = string.Format("{0}_{1}.pdf", "QuestionaryResultsPDF", DateTime.Now.ToString("dd.MM.yyyy HH_mm_ss")),
			//	PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
			//	IsGrayScale = true,
			//	IsJavaScriptDisabled = true,
			//	PageSize = Rotativa.AspNetCore.Options.Size.A4,
			//	CustomSwitches = " --print-media-type"
			//};
		}

		[HttpGet]
		[Description("PDF експорт на попълнена анкета")]
		public ActionResult FillQuestionaryPDF(int questionaryHeaderId, int? userId, string userEmail)
		{
			FilledQuestionaryViewModel model = questionaryService.GetFilledQuestionary(questionaryHeaderId, userId, userEmail);

			return new ViewAsPdf("_FillQuestionaryPDF", model);
		}
		#endregion
	}
}