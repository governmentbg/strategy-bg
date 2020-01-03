using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
//using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels.Questionary;
using reCAPTCHA.AspNetCore;
using Rotativa.AspNetCore;
using System.ComponentModel;
using System.Linq;
using WebCommon.Extensions;
using WebCommon.Services;

namespace Domain.Controllers
{
    public class QuestionaryController : BasePortalController
    {
        private readonly IQuestionaryService questionaryService;
        private readonly IUserContext userContext;
        private readonly IConsultationService consultationService;
        private readonly IRecaptchaService recaptcha;

        public QuestionaryController(
                IQuestionaryService _questionaryService,
                IUserContext _userContext,
                IConsultationService _consultationService,
                IRecaptchaService _recaptcha)
        {
            questionaryService = _questionaryService;
            userContext = _userContext;
            consultationService = _consultationService;
            recaptcha = _recaptcha;
        }

        #region Questionary
        public IActionResult Index()
        {
            var items = questionaryService.GetStatusID_DDL();
            items.Find(x => x.Value == "1").Selected = true;

            ViewBag.StatusID_ddl = items;
            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int status)
        {
            IQueryable<QuestionaryListViewModel> data = questionaryService.GetQuestionaries(status).OrderByDescending(x => x.ActiveId).ThenBy(x => x.OpenningDate);

            var response = request.GetResponse(data);

            return new DataTablesJsonResult(response, true);
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

            switch (model.SourceType)
            {
                case Models.GlobalConstants.SourceTypes.PublicConsultation:
                    model.SourceTitle = consultationService.GetConsultation(model.SourceId).Title.DecodeIfNeeded();
                    break;
                default:
                    break;
            }

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
                SetSavedMessageExt("<b>Благодарим Ви!<b><br/>Вашето мнение е важно за нас.", true);
                return RedirectToAction(nameof(QuestionaryResults), new { questionaryHeaderId = model.QuestionaryHeaderId });
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

            switch (model.SourceType)
            {
                case Models.GlobalConstants.SourceTypes.PublicConsultation:
                    model.SourceTitle = consultationService.GetConsultation(model.SourceId).Title.DecodeIfNeeded();
                    MakeSourceItemVMPortal(model.SourceType, model.SourceId);
                    break;
                default:
                    break;
            }
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