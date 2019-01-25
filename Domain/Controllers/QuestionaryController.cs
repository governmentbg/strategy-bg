using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Questionary;
using reCAPTCHA.AspNetCore;
using Rotativa.AspNetCore;
using System.ComponentModel;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Controllers
{
    public class QuestionaryController : BasePortalController
    {
        private readonly IQuestionaryService questionaryService;
        private readonly IUserContext userContext;
        private readonly IRecaptchaService recaptcha;

        public QuestionaryController(
                IQuestionaryService _questionaryService,
                IUserContext _userContext,
                IRecaptchaService _recaptcha)
        {
            questionaryService = _questionaryService;
            userContext = _userContext;
            recaptcha = _recaptcha;
        }

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

        [HttpGet]
        public IActionResult FillQuestionaryBySourceType(int sourceTypeID, int sourceId, int? userId)
        {
            var questionary = questionaryService.GetQuestionary(sourceTypeID, sourceId);

            FillQuestionaryViewModel model = new FillQuestionaryViewModel();
            if (questionary != null && questionary.Id > 0)
            {
                model = questionaryService.SetAnswers(questionary.Id);
            }
            else
            {
                return View("FillQuestionaryError");
            }
            MakeSourceItemVMPortal(model.SourceType, model.SourceId);

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
            //var recaptchaResult = recaptcha.Validate(Request).Result;

            //if (!recaptchaResult.success)
            //{
            //    ModelState.AddModelError("Recaptcha", "Възникна грешка при проверка на reCaptcha. Моля, опитайте отново!");
            //}
            MakeSourceItemVMPortal(model.SourceType, model.SourceId);

            if (!ModelState.IsValid)
            {
                return View("FillQuestionary", model);
            }

            if (questionaryService.SaveFilledQuestionary(model))
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