using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Context;
using Models.Context.Questionary;
using Models.Contracts;
using Models.ViewModels;
using reCAPTCHA.AspNetCore;
using System;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;

namespace Domain.Controllers
{
	public class ChangeProposalsController : BasePortalController
    {
		private readonly IChangeProposalsService changeProposalsService;
		private readonly IUserContext userContext;
		private readonly INomenclatureService nomService;
    private readonly IEmailSender emailSender;
    private readonly IRecaptchaService recaptcha;

    public ChangeProposalsController(IChangeProposalsService _changeProposalsService, IUserContext _userContext, INomenclatureService _nomService, IRecaptchaService _recaptcha, IEmailSender _emailSender)
		{
			changeProposalsService = _changeProposalsService;
			userContext = _userContext;
			nomService = _nomService;
      recaptcha = _recaptcha;
      emailSender = _emailSender;
    }

    #region Chage Proposals

    public IActionResult NewChangeProposal()
    {
      if (userContext.Email!=null)
      {
        NewCPMailVM model = new NewCPMailVM();
        SetViewBags(true);
        model.About = MessageConstants.NewCPMail_Subject;
        model.Email = userContext.Email;
        model.Name = userContext.FullName;

        return View(model);
      }
      else
      {
        SetMessageDialog(false, string.Format("Моля, влезте в системата с вашия потребител!"),"Неактивен логин");

        return GotoMessages();
      }

    }

    public IActionResult SendMessage(NewCPMailVM mailData)
    {

      //var recaptchaResult = recaptcha.Validate(Request).Result;
      //string reCaptchaError = "";

      //if (!recaptchaResult.success)
      //{
      //  reCaptchaError = "Възникна грешка при проверка на reCaptcha. Моля, опитайте отново!";
      //  ModelState.AddModelError("Recaptcha", reCaptchaError);
      //}


      //if (!ModelState.IsValid)
      //{
      //  ViewBag.reCaptchaError = reCaptchaError;
      //  return View("NewChangeProposal", mailData);
      //}

      mailData.CategoryType = nomService.GetCategory(mailData.CategoryMasterId).Label;
      mailData.CategoryName = nomService.GetCategory(mailData.CategoryId).Label;
      mailData.DistrictName = nomService.GetCategory(mailData.DistrictId).Label;
      mailData.MunicipalityName = nomService.GetCategory(mailData.MunicipalityId).Label;

      if (mailData.CategoryName==null) { mailData.CategoryName = "Всички категории"; }
      if (mailData.DistrictName == null) { mailData.DistrictName = "Всички области"; }
      if (mailData.MunicipalityName == null) { mailData.MunicipalityName = "Всички общини"; }

      if (mailData.CategoryType == "Национални") {
        string mailBody = String.Format(MessageConstants.NewCP_National_Mail_Body, mailData.Name, mailData.Email, mailData.About, mailData.CategoryType, mailData.CategoryName, mailData.Message);
          emailSender.SendMail(mailData.Email, MessageConstants.NewCPMail_Subject, mailBody);
      }
      if (mailData.CategoryType == "Областни")
      {
        string mailBody = String.Format(MessageConstants.NewCP_Municip_Mail_Body, mailData.Name, mailData.Email, mailData.About, mailData.CategoryType, mailData.DistrictName, mailData.MunicipalityName, mailData.Message);
       emailSender.SendMail(mailData.Email,MessageConstants.NewCPMail_Subject, mailBody);
      }

      SetMessageDialog(false, string.Format("{0}, <br/> Вашeто съобщение относно {1} беше изпратено успешно.", mailData.Name, mailData.About), MessageConstants.NewCPMail_Subject);

      return GotoMessages();
    }
    public IActionResult ListChangeProposals()
		{
			SetViewBags(true);
			return View();
		}

		[HttpGet]
		public IActionResult ViewChangeProposals(int id)
		{
			var model = changeProposalsService.GetChangeProposals(id);

			model.CategoryMasterText = changeProposalsService.GetCategoryFullText(model);

			ViewBag.HasQuestionary = changeProposalsService.All<QuestionaryHeaders>().Where(x => x.SourceTypeId == GlobalConstants.SourceTypes.ChangeProposals && x.SourceId == id).Any();

			return View(model);
		}

		[HttpPost]
		public IActionResult LoadDataChangeProposals(IDataTablesRequest request, int categoryId = -1, bool isMunicipality = false)
		{
			IQueryable<ChangeProposalsListViewModel> data = changeProposalsService.GetChangeProposalsList(1, categoryId, isMunicipality, true, false);

			var response = request.GetResponse(data);

			return new DataTablesJsonResult(response, true);
		}

		private void SetViewBags(bool setTextAll = false)
		{
			ViewBag.catMasters = nomService.ComboCategories(0)
				.Select(g => new SelectListItem()
				{
					Text = g.Text,
					Value = g.Value
				})
				.ToList();

			ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Categories.Type_National)
				.Select(g => new SelectListItem()
				{
					Text = g.Text,
					Value = g.Value
				})
				.Prepend(new SelectListItem()
				{
					Text = setTextAll ? "Всички" : "Изберете",
					Value = "-1"
				})
				.ToList();

			ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Categories.Type_District)
				.Select(g => new SelectListItem()
				{
					Text = g.Text,
					Value = g.Value
				})
				.Prepend(new SelectListItem()
				{
					Text = setTextAll ? "Всички" : "Изберете",
					Value = "-1"
				})
				.ToList();
		}
		#endregion
	}
}