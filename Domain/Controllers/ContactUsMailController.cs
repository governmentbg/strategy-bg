using Microsoft.AspNetCore.Mvc;
using WebCommon.Services;
using Models.ViewModels;
using System.ComponentModel;
using Rotativa.AspNetCore;
using System;
using Models;
using reCAPTCHA.AspNetCore;

namespace Domain.Controllers
{
  public class ContactUsMailController : BasePortalController
  {

    private readonly IUserContext userContext;
    private readonly IEmailSender emailSender;
    private readonly IRecaptchaService recaptcha;
    public ContactUsMailController(IUserContext _userContext, IEmailSender _emailSender, IRecaptchaService _recaptcha)
    {
      userContext = _userContext;
      emailSender = _emailSender;
      recaptcha = _recaptcha;
    }

    public IActionResult Index()
    {

      ContactUsMailVM model = new ContactUsMailVM();
      ViewBag.AboutTopics = model.AboutTopics;
      return View("Index", model);
    }

    public IActionResult SendMessage(ContactUsMailVM mailData)
    {

      var recaptchaResult = recaptcha.Validate(Request).Result;
      string reCaptchaError = "";

      if (!recaptchaResult.success)
      {
        reCaptchaError = "Възникна грешка при проверка на reCaptcha. Моля, опитайте отново!";
        ModelState.AddModelError("Recaptcha", reCaptchaError);
      }


      if (!ModelState.IsValid)
      {
        ViewBag.AboutTopics = mailData.AboutTopics;
        ViewBag.reCaptchaError = reCaptchaError;
        return View("Index", mailData);
      }

      emailSender.SendMail(
          mailData.Email,
          MessageConstants.ContactUsMail_Subject,
          String.Format(MessageConstants.ContactUsMail_Body, mailData.Name, mailData.Email, mailData.About, mailData.Message));

      SetMessageDialog(false, string.Format("{0}, <br/> Вашeто съобщение относно {1} беше изпратено успешно.", mailData.Name, mailData.About), "Свържете се с нас");

      return GotoMessages();
    }
  }
}