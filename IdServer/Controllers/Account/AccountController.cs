// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdServer.Class;
using IdServer.Models.Contracts;
using IdServer.Models.Entities;
using IdServer.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdServer.Controllers.Account
{
    /// <summary>
    /// This sample controller implements a typical login/logout/provision workflow for local and external accounts.
    /// The login service encapsulates the interactions with the user data store. This data store is in-memory only and cannot be used for production!
    /// The interaction service provides a way for the UI to communicate with identityserver for validation and context retrieval
    /// </summary>
    [SecurityHeaders]
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;
        private readonly IUserService _userRepo;
        private readonly IEmailSender _emailSender;
        private readonly IStringLocalizer<SharedResources> Localizer;
        private readonly IConfiguration config;

        public AccountController(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService events,
            IUserService userRepo,
            IEmailSender emailSender,
            IStringLocalizer<SharedResources> localizer,
            IConfiguration _config)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
            _userRepo = userRepo;
            _emailSender = emailSender;
            Localizer = localizer;
            config = _config;
        }


        /// <summary>
        /// Show login page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {

            //throw new Exception("грешка");

            // build a model so we know what to show on the login page
            var vm = await BuildLoginViewModelAsync(returnUrl);
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            string clientName = "Система за управление на потребителите";

            Client client = null;
            if (context != null)
            {
                client = await _clientStore.FindClientByIdAsync(context?.ClientId ?? GlobalConstants.IdServerClientId);
            }

            if (client != null)
            {
                clientName = client.ClientName;
            }

            if (vm.IsExternalLoginOnly)
            {
                // we only have one option for logging in and it's an external provider
                return await ExternalLogin(vm.ExternalLoginScheme, returnUrl);
            }

            TempData["Client"] = clientName;




            return View(vm);
        }

        /// <summary>
        /// Handle postback from username/password login
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            if (context != null)
            {
                Client client = await _clientStore.FindClientByIdAsync(context.ClientId);

                ViewBag.Client = client?.ClientName;
            }


            if (ModelState.IsValid)
            {
                // validate username/password against in-memory store
                if (_userRepo.AreUserCredentialsValid(model.Username, model.Password, context?.ClientId))
                {
                    var user = _userRepo.GetUserByUsername(model.Username);
                    if (user.MustChangePassword)
                    {
                        var code = _userRepo.GetPasswordChangeCode(user.Username);
                        TempData[MessageConstant.WarningMessage] = "Вие сте влезли със служебна парола. Моля, сменете я.";

                        return RedirectToAction(nameof(ChangePassword), new { code, returnUrl = model.ReturnUrl });
                    }

                    var userCclaims = _userRepo.GetClaimsByUserId(user.Id, context?.ClientId ?? GlobalConstants.IdServerClientId);
                    var claims = userCclaims.Select(c => new System.Security.Claims.Claim(c.ClaimType, c.ClaimValue)).ToList();

                    bool redirectTodefault = false;
                    if (config.GetValue<bool>("Settings:is_public"))
                    {
                        //Всички публични потребители, които по погрешка са се логнали в IdServer-а
                        if (context == null)
                        {
                            redirectTodefault = true;
                        }
                    }
                    else
                    {
                        //Всички вътрешни потребители без роли, които по погрешка са се логнали в IdServer-а
                        if (context == null)
                        {
                            if (claims.Where(x => x.Type == "role").Count() == 0)
                            {
                                redirectTodefault = true;
                            }
                        }
                    }

                    if (redirectTodefault)
                    {
                        return RedirectToAction("GotoMainClient");
                    }

                    await _events.RaiseAsync(new UserLoginSuccessEvent(user.Username, user.Id, user.FullName));

                    // only set explicit expiration here if user chooses "remember me". 
                    // otherwise we rely upon expiration configured in cookie middleware.
                    AuthenticationProperties props = null;
                    if (AccountOptions.AllowRememberLogin && model.RememberLogin)
                    {
                        props = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.Add(AccountOptions.RememberMeLoginDuration)
                        };
                    };

                    // issue authentication cookie with subject ID, username and roles
                    await HttpContext.SignInAsync(user.Id, user.Username, props, claims.ToArray());

                    // make sure the returnUrl is still valid, and if so redirect back to authorize endpoint or a local page
                    // the IsLocalUrl check is only necessary if you want to support additional local pages, otherwise IsValidReturnUrl is more strict
                    if (_interaction.IsValidReturnUrl(model.ReturnUrl) || Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return Redirect("~/");
                }

                await _events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials"));

                //ModelState.AddModelError("", Localizer["InvalidCredentials"]);
                TempData[MessageConstant.ErrorMessage] = Localizer["InvalidCredentials"];
            }

            // something went wrong, show form with error
            var vm = await BuildLoginViewModelAsync(model);
            return View(vm);
        }

        public async Task<IActionResult> GotoMainClient()
        {
            var client = await _clientStore.FindClientByIdAsync(config.GetValue<string>("Settings:mainClientId"));
            var url = client.RedirectUris.Where(x => !x.Contains("localhost")).FirstOrDefault()?.Replace("signin-oidc", "");
            ViewBag.url = url;
            return View();
        }

        /// <summary>
        /// initiate roundtrip to external authentication provider
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ExternalLogin(string provider, string returnUrl)
        {
            // start challenge and roundtrip the return URL and 
            var props = new AuthenticationProperties()
            {
                RedirectUri = Url.Action("ExternalLoginCallback"),
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
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            // read external identity from the temporary cookie
            var result = await HttpContext.AuthenticateAsync(IdentityServer4.IdentityServerConstants.ExternalCookieAuthenticationScheme);
            if (result?.Succeeded != true)
            {
                throw new Exception("External authentication error");
            }

            // lookup our user and external provider info
            var (user, provider, providerUserId, claims) = FindUserFromExternalProvider(result);
            var returnUrl = result.Properties.Items["returnUrl"];

            if (user == null)
            {
                await _events.RaiseAsync(new UserLoginFailureEvent(providerUserId, "invalid credentials"));
                TempData[MessageConstant.ErrorMessage] = AccountOptions.InvalidExternalUserErrorMessage;

                return RedirectToAction(nameof(Login), new { returnUrl });
            }

            // this allows us to collect any additonal claims or properties
            // for the specific prtotocols used and store them in the local auth cookie.
            // this is typically used to store data needed for signout from those protocols.
            //var additionalLocalClaims = new List<Claim>();

            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);


            var userCclaims = _userRepo.GetClaimsByUserId(user.Id, context?.ClientId ?? GlobalConstants.IdServerClientId);
            var additionalLocalClaims = userCclaims.Select(c => new System.Security.Claims.Claim(c.ClaimType, c.ClaimValue)).ToList();


            var localSignInProps = new AuthenticationProperties();
            ProcessLoginCallbackForOidc(result, additionalLocalClaims, localSignInProps);
            ProcessLoginCallbackForWsFed(result, additionalLocalClaims, localSignInProps);
            ProcessLoginCallbackForSaml2p(result, additionalLocalClaims, localSignInProps);

            // issue authentication cookie for user
            await _events.RaiseAsync(new UserLoginSuccessEvent(provider, providerUserId, user.Id, user.Username));
            await HttpContext.SignInAsync(user.Id, user.Username, provider, localSignInProps, additionalLocalClaims.ToArray());

            // delete temporary cookie used during external authentication
            await HttpContext.SignOutAsync(IdentityServer4.IdentityServerConstants.ExternalCookieAuthenticationScheme);

            // validate return URL and redirect back to authorization endpoint or a local page

            if (_interaction.IsValidReturnUrl(returnUrl) || Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return Redirect("~/");
        }

        /// <summary>
        /// Show logout page
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            // build a model so the logout page knows what to display
            var vm = await BuildLogoutViewModelAsync(logoutId);

            if (vm.ShowLogoutPrompt == false)
            {
                // if the request for logout was properly authenticated from IdentityServer, then
                // we don't need to show the prompt and can just log the user out directly.
                return await Logout(vm);
            }

            return View(vm);
        }

        /// <summary>
        /// Handle logout page postback
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(LogoutInputModel model)
        {
            // build a model so the logged out page knows what to display
            var vm = await BuildLoggedOutViewModelAsync(model.LogoutId);

            if (User?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await HttpContext.SignOutAsync();

                // raise the logout event
                await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
            }

            // check if we need to trigger sign-out at an upstream identity provider
            if (vm.TriggerExternalSignout)
            {
                // build a return URL so the upstream provider will redirect back
                // to us after the user has logged out. this allows us to then
                // complete our single sign-out processing.
                string url = Url.Action("Logout", new { logoutId = vm.LogoutId });

                // this triggers a redirect to the external provider for sign-out
                return SignOut(new AuthenticationProperties { RedirectUri = url }, vm.ExternalAuthenticationScheme);
            }
            if (!string.IsNullOrEmpty(vm.PostLogoutRedirectUri))
            {
                return Redirect(vm.PostLogoutRedirectUri);
            }
            return View("LoggedOut", vm);
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                // delete local authentication cookie
                await HttpContext.SignOutAsync();

                // raise the logout event
                await _events.RaiseAsync(new UserLogoutSuccessEvent(User.GetSubjectId(), User.GetDisplayName()));
            }

            return Redirect("~/");
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepo.GetUserByUsername(model.Email);

            if (user != null)
            {
                ModelState.AddModelError("Email",(string)Localizer["EmailExists"]);

                return View(model);
            }
            model.IsPublic = config.GetValue<bool>("Settings:IsPublic");

            if (_userRepo.RegisterUser(model))
            {
                try
                {
                    var code = _userRepo.GetVerificationCode(model.Email);
                    var url = Url.Action(
                        nameof(ConfirmMail),
                        ControllerContext.ActionDescriptor.ControllerName,
                        new { code },
                        HttpContext.Request.Scheme);

                    _emailSender.SendMail(
                        model.Email,
                        (string)Localizer["ConfirmMailSubject"],
                        String.Format((string)Localizer["ConfirmMailBody"], TempData.Peek("Client"), url));

                    var message = new AccountMessageViewModel()
                    {
                        Message = (string)Localizer["ConfirmMailInfo"],
                        Title = (string)Localizer["Register"]
                    };

                    return View("AccountMessage", message);
                }
                catch (Exception ex)
                {

                }
            }

            TempData[MessageConstant.ErrorMessage] = "Възникна грешка при регистрацията";

            return View(model);
        }

        [HttpGet]
        public IActionResult ConfirmMail(string code)
        {
            var user = _userRepo.GetUserByVerificationCode(code);
            var message = new AccountMessageViewModel()
            {
                Message = "Възникна грешка по време на потвърждаване на регистрацията Ви",
                Title = "Потвърждение на Email"
            };

            if (user == null)
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.Values.InvalidUser;
            }

            if (_userRepo.ConfirmEmail(user))
            {
                message.Message = "Успешно потвърдихте регистрацията си. За да се активира профила Ви е необходимо одобрение от администратор";
            }

            return View("AccountMessage", message);
        }

        [HttpGet]
        public IActionResult ForgottenPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgottenPassword(ForgottenPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var code = _userRepo.GetPasswordChangeCode(model.UserName);
                var url = Url.Action(
                    nameof(ChangePassword),
                    ControllerContext.ActionDescriptor.ControllerName,
                    new { code },
                    HttpContext.Request.Scheme);

                _emailSender.SendMail(
                    model.UserName,
                    MessageConstant.EmailMessages.ChangePasswordSubject,
                    String.Format(MessageConstant.EmailMessages.ChangePassword, TempData.Peek("Client"), url));

            }
            catch (Exception ex)
            {
                TempData[MessageConstant.ErrorMessage] = "Възникна грешка";

                return View(model);
            }

            var message = new AccountMessageViewModel()
            {
                Message = "На Вашият майл е изпратено съобщение за смяна на паролата. Моля, следвайте инструкциите в него",
                Title = "Забравена парола"
            };

            return View("AccountMessage", message);
        }

        [HttpGet]
        public IActionResult ChangePassword(string code, string returnUrl = null)
        {
            bool result = false;
            var model = new ChangePasswordViewModel()
            {
                Code = code,
                ReturnUrl = returnUrl
            };

            try
            {
                var user = _userRepo.GetUserByPasswordChangeCode(code);
            }
            catch (Exception ex)
            {
                var message = new AccountMessageViewModel()
                {
                    Message = "Невалиден код за смяна на парола",
                    Title = "Смяна на парола"
                };

                return View("AccountMessage", message);
            }

            ViewBag.Valid = result;

            return View(model);
        }

        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userRepo.ChangePassword(model))
            {
                TempData[MessageConstant.SuccessMessage] = "Паролата Ви е сменена успешно";

                return RedirectToAction(nameof(Login), new { returnUrl = model.ReturnUrl });
            }

            TempData[MessageConstant.ErrorMessage] = "Възникна грешка при смяна на паролата";

            return View(model);
        }

        /*****************************************/
        /* helper APIs for the AccountController */
        /*****************************************/
        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null)
            {
                // this is meant to short circuit the UI and only trigger the one external IdP
                return new LoginViewModel
                {
                    EnableLocalLogin = false,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                    ExternalProviders = new ExternalProvider[] { new ExternalProvider { AuthenticationScheme = context.IdP } }
                };
            }

            var schemes = await _schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null ||
                            (x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }

        private async Task<LogoutViewModel> BuildLogoutViewModelAsync(string logoutId)
        {
            var vm = new LogoutViewModel { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };

            if (User?.Identity.IsAuthenticated != true)
            {
                // if the user is not authenticated, then just show logged out page
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            var context = await _interaction.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                // it's safe to automatically sign-out
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            // show the logout prompt. this prevents attacks where the user
            // is automatically signed out by another malicious web page.
            return vm;
        }

        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(logoutId);

            var vm = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (User?.Identity.IsAuthenticated == true)
            {
                var idp = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (idp != null && idp != IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync(idp);
                    if (providerSupportsSignout)
                    {
                        if (vm.LogoutId == null)
                        {
                            // if there's no current logout context, we need to create one
                            // this captures necessary info from the current logged in user
                            // before we signout and redirect away to the external IdP for signout
                            vm.LogoutId = await _interaction.CreateLogoutContextAsync();
                        }

                        vm.ExternalAuthenticationScheme = idp;
                    }
                }
            }

            return vm;
        }

        private (User user, string provider, string providerUserId, IEnumerable<System.Security.Claims.Claim> claims) FindUserFromExternalProvider(AuthenticateResult result)
        {
            var externalUser = result.Principal;

            // try to determine the unique id of the external user (issued by the provider)
            // the most common claim type for that are the sub claim and the NameIdentifier
            // depending on the external provider, some other claim type might be used
            var userIdClaim = externalUser.FindFirst(JwtClaimTypes.Subject) ??
                              externalUser.FindFirst(ClaimTypes.NameIdentifier) ??
                              throw new Exception("Unknown userid");

            // remove the user id claim so we don't include it as an extra claim if/when we provision the user
            var claims = externalUser.Claims.ToList();
            claims.Remove(userIdClaim);

            var provider = result.Properties.Items["scheme"];
            var providerUserId = userIdClaim.Value;

            // find external user
            User user = _userRepo.FindByExternalProvider(provider, providerUserId);

            return (user, provider, providerUserId, claims);
        }

        private void ProcessLoginCallbackForOidc(AuthenticateResult externalResult, List<System.Security.Claims.Claim> localClaims, AuthenticationProperties localSignInProps)
        {
            // if the external system sent a session id claim, copy it over
            // so we can use it for single sign-out
            var sid = externalResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtClaimTypes.SessionId);
            if (sid != null)
            {
                localClaims.Add(new System.Security.Claims.Claim(JwtClaimTypes.SessionId, sid.Value));
            }

            // if the external provider issued an id_token, we'll keep it for signout
            var id_token = externalResult.Properties.GetTokenValue("id_token");
            if (id_token != null)
            {
                localSignInProps.StoreTokens(new[] { new AuthenticationToken { Name = "id_token", Value = id_token } });
            }
        }

        private void ProcessLoginCallbackForWsFed(AuthenticateResult externalResult, List<System.Security.Claims.Claim> localClaims, AuthenticationProperties localSignInProps)
        {
        }

        private void ProcessLoginCallbackForSaml2p(AuthenticateResult externalResult, List<System.Security.Claims.Claim> localClaims, AuthenticationProperties localSignInProps)
        {
        }

        public ActionResult ExternalLoginPrivacyText()
        {
            return View();
        }
    }
}