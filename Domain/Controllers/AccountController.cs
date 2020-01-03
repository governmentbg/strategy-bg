using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.Account;
using PopForums.Models;
using PopForums.Services;
using WebCommon.Services;

namespace Domain.Controllers
{
    [Authorize]
    public partial class AccountController : BasePortalController
    {
        private readonly IAccountService accountService;
        private readonly IEmailSender emailSender;
        private readonly IUserContext userContext;
        private readonly INomenclatureService nomService;
        private readonly IConsultationService consulationService;
        private readonly IUserService pf_userService;
        private readonly IProfileService pf_profileService;
        public AccountController(
                IAccountService _accountService,
                IEmailSender _emailSender,
                IUserContext _userContext,
                INomenclatureService _nomService,
                IConsultationService _consulationService,
                IUserService _pf_userService,
                IProfileService _pf_profileService)

        {
            accountService = _accountService;
            emailSender = _emailSender;
            userContext = _userContext;
            nomService = _nomService;
            consulationService = _consulationService;
            pf_userService = _pf_userService;
            pf_profileService = _pf_profileService;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            LoginInputModel model = new LoginInputModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var passwordIsValid = accountService.AreUserCredentialsValid(model.Username, model.Password);

            if (!passwordIsValid)
            {
                ModelState.AddModelError("Username", "Невалиден потребител и/или парола.");
                return View(model);
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                accountService.GeneratePrincipalByUsername(model.Username));

            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterPublicUserVM());
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterPublicUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string errorMessage = accountService.Users_CheckRegistration(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError(nameof(RegisterPublicUserVM.UserName), errorMessage);
                return View(model);
            }

            this.SetSavedMessage = accountService.Users_RegisterPublic(model);
            if (!SetSavedMessage)
            {
                return View(model);
            }

            //// e te tuka se pravi usera za momenta, ama triabva da e po dolu   aangelov
            SignupData signupData = new SignupData();
            signupData.Email = model.Email;
            signupData.IsDaylightSaving = true;
            signupData.TimeZone = 2;
            signupData.IsSubscribed = true;
            signupData.IsTos = true;
            signupData.Name = model.FullName;
            var pf_user = pf_userService.CreateUserByID(model.Id, model.FullName, model.Email, model.Password, true, "127.0.0.1");
            pf_profileService.Create(pf_user, signupData);
            //////
            ///
            var code = accountService.Users_GenerateVerificationCode(model.UserName);
            var url = Url.Action(
                nameof(ConfirmMail),
                ControllerContext.ActionDescriptor.ControllerName,
                new { code },
                HttpContext.Request.Scheme);
            //Remove Later
            // url.Replace("192.168.200.91", "77.71.113.82");
            //Remove Later
            emailSender.SendMail(
                      model.Email,
                      MessageConstants.RegisterMail_Subject,
                      String.Format(MessageConstants.RegisterMail_Body, model.FullName, MessageConstants.SystemTitle, url));



            SetMessageDialog(false, string.Format("{0}, <br/> Вашата регистрация протече успешно. На електронната Ви поща {1} беше изпратено писмо за да потвърждение.", model.FullName, model.Email), "Регистрация");

            return GotoMessages();
        }

        //[AllowAnonymous]
        //public IActionResult TestCode(string username)
        //{
        //    var code = accountService.Users_GenerateVerificationCode(username);
        //    var user = accountService.Users_GetByVerificationCode(code);
        //    return Content(user.FullName);
        //}

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ConfirmMail(string code)
        {
            var user = accountService.Users_GetByVerificationCode(code);

            if (user == null || user.IsMailConfirmed)
            {
                SetMessageDialog(true, MessageConstants.ConfirmMail_NotFound);
            }
            else
            {

                if (accountService.Users_ConfirmAndApproveMail(user))
                {


                    ////// e te tuka se pravi usera, ama za sega e na Register   aangelov
                    //SignupData signupData = new SignupData();
                    //signupData.Email = user.Email;
                    //signupData.IsDaylightSaving = true;
                    //signupData.IsSubscribed = false;
                    //signupData.IsTos = true;
                    //signupData.Name = user.FullName;
                    //var pf_user = pf_userService.CreateUserByID(user.Id, user.FullName, user.Email, user.Password, true ,"127.0.0.1");
                    //pf_profileService.Create(pf_user, signupData);

                    SetMessageDialog(false, MessageConstants.RegisterOK_Message, MessageConstants.RegisterOK_Title);
                }
                else
                {
                    SetMessageDialog(true, MessageConstants.RegisterFailed_Message);
                }
            }

            return GotoMessages();
        }
        /// <summary>
        /// initiate roundtrip to external authentication provider
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            // start challenge and roundtrip the return URL and 
            var props = new AuthenticationProperties()
            {
                RedirectUri = Url.Action(nameof(ExternalLoginCallback), new { returnUrl }),
                Items =
                    {
                        { "returnUrl", returnUrl },
                        { "scheme", provider },
                    }
            };



            return Challenge(props, provider);
        }

        /// <summary>
        /// Post processing of external authentication
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "")
        {

            var externalAuthResponse = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (externalAuthResponse.Succeeded)
            {
                var internalPrincipal = accountService.Users_LoginRegisterExternalAuth(externalAuthResponse.Principal);
                if (internalPrincipal != null)
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, internalPrincipal);
                }

            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return Redirect("~/");
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgottenPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgottenPassword(ForgottenPasswordViewModel model)
        {
            var user = accountService.Users_GetByUserName(model.UserName);
            if (user == null)
            {
                ModelState.AddModelError(nameof(user.UserName), "Невалиден потребител");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var code = accountService.Users_GenerateVerificationCode(model.UserName);
                var url = Url.Action(
                    nameof(ChangePassword),
                    ControllerContext.ActionDescriptor.ControllerName,
                    new { code },
                    HttpContext.Request.Scheme);

                emailSender.SendMail(
                    user.Email,
                    MessageConstants.ChangePassword_Subject,
                    String.Format(MessageConstants.ChangePassword_Message, url));

            }
            catch (Exception ex)
            {
                SetSavedMessage = false;

                return View(model);
            }

            SetMessageDialog(false, "На Вашият майл е изпратено съобщение за смяна на паролата. Моля, следвайте инструкциите в него", "Забравена парола");
            return GotoMessages();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ChangePassword(string code = null, string returnUrl = null)
        {
            bool codeCheck = true;
            if (!string.IsNullOrEmpty(code))
            {
                var user = accountService.Users_GetByVerificationCode(code);
                if (user == null)
                {
                    codeCheck = false;
                }
            }
            else
            {
                var userProfile = accountService.Users_GetById(userContext.UserId);
                if (userProfile != null)
                {
                    code = accountService.Users_GenerateVerificationCode(userProfile.UserName);
                }
                else
                {
                    codeCheck = false;
                }
            }

            if (!codeCheck)
            {
                SetMessageDialog(true, "Невалиден код за смяна на парола", "Смяна на парола");

                return GotoMessages();
            }

            var model = new ChangePasswordViewModel()
            {
                Code = code,
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (accountService.Users_ChangePassword(model))
            {
                SetSavedMessageExt("Паролата Ви е сменена успешно", true);

                return RedirectToAction(nameof(Login), new { returnUrl = model.ReturnUrl });
            }
            SetSavedMessageExt("Възникна грешка при смяна на паролата", false);

            return View(model);
        }

    }
}