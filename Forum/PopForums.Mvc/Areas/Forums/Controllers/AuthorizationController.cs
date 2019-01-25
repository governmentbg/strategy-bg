﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Mvc;
using PopForums.ExternalLogin;
using PopForums.Models;
using PopForums.Mvc.Areas.Forums.Authorization;
using PopForums.Mvc.Areas.Forums.Services;
using PopForums.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using AuthenticationProperties = Microsoft.AspNetCore.Authentication.AuthenticationProperties;

namespace PopForums.Mvc.Areas.Forums.Controllers
{
	[Area("Forums")]
	public class AuthorizationController : Controller
	{
		public AuthorizationController(IUserService userService, IExternalUserAssociationManager externalUserAssociationManager, IUserRetrievalShim userRetrievalShim)
		{
			_userService = userService;
			_externalUserAssociationManager = externalUserAssociationManager;
			_userRetrievalShim = userRetrievalShim;
		}

		public static string Name = "Authorization";

		private readonly IUserService _userService;
		private readonly IExternalUserAssociationManager _externalUserAssociationManager;
		private readonly IUserRetrievalShim _userRetrievalShim;

		[HttpGet]
		public async Task<RedirectResult> Logout()
		{
			string link;
			if (Request == null || string.IsNullOrWhiteSpace(Request.Headers["Referer"]))
				link = Url.Action("Index", HomeController.Name);
			else
			{
				link = Request.Headers["Referer"];
				if (!link.Contains(Request.Host.Value))
					link = Url.Action("Index", HomeController.Name);
			}
			var user = _userRetrievalShim.GetUser(HttpContext);
			_userService.Logout(user, HttpContext.Connection.RemoteIpAddress.ToString());
			await HttpContext.SignOutAsync(PopForumsAuthorizationDefaults.AuthenticationScheme);
			return Redirect(link);
		}

		[HttpPost]
		public async Task<JsonResult> LogoutAsync()
		{
			var user = _userRetrievalShim.GetUser(HttpContext);
			_userService.Logout(user, HttpContext.Connection.RemoteIpAddress.ToString());
			await HttpContext.SignOutAsync(PopForumsAuthorizationDefaults.AuthenticationScheme);
			return Json(new BasicJsonMessage { Result = true });
		}

		[HttpPost]
		public async Task<IActionResult> Login(string email, string password)
		{
			User user;
			if (_userService.Login(email, password, HttpContext.Connection.RemoteIpAddress.ToString(), out user))
			{
				await PerformSignInAsync(user, HttpContext);
				return Json(new BasicJsonMessage { Result = true });
			}

			return Json(new BasicJsonMessage { Result = false, Message = Resources.LoginBad });
		}

		public static async Task PerformSignInAsync(User user, HttpContext httpContext)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Name)
			};

			var props = new AuthenticationProperties
			{
				IsPersistent = true,
				ExpiresUtc = DateTime.UtcNow.AddYears(1)
			};

			var id = new ClaimsIdentity(claims, PopForumsAuthorizationDefaults.AuthenticationScheme);
			await httpContext.SignInAsync(PopForumsAuthorizationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), props);
		}

		[HttpPost]
		public async Task<JsonResult> LoginAndAssociate(string email, string password, bool persistCookie)
		{
			var ip = HttpContext.Connection.RemoteIpAddress.ToString();
			User user;
            if (_userService.Login(email, password, ip, out user))
			{
				var authResult = await GetExternalLoginInfoAsync(HttpContext);
				if (authResult != null)
				{
					_externalUserAssociationManager.Associate(user, authResult, ip);
					await PerformSignInAsync(user, HttpContext);
					return Json(new BasicJsonMessage { Result = true });
				}
			}

			return Json(new BasicJsonMessage { Result = false, Message = Resources.LoginBad });
		}

		[HttpPost]
		[AllowAnonymous]
		public IActionResult ExternalLogin(string provider, string returnUrl = null)
		{
			var redirectUrl = Url.Action(nameof(ExternalLoginCallback), Name, new { ReturnUrl = returnUrl });
			var properties = ConfigureExternalAuthenticationProperties(provider, redirectUrl);
			return Challenge(properties, provider);
		}

		private const string LoginProviderKey = "LoginProvider";
		private const string XsrfKey = "XsrfId";

		public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null)
		{
			var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
			properties.Items[LoginProviderKey] = provider;
			if (userId != null)
			{
				properties.Items[XsrfKey] = userId;
			}
			return properties;
		}

		public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
		{
			if (remoteError != null)
			{
				// TODO: deal with this
			}
			var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            var info = await GetExternalLoginInfoAsync(HttpContext);
			if (info == null)
				return RedirectToAction("Login", "Account", new { error = Resources.ExpiredLogin });
			var email = info.ExternalPrincipal.HasClaim(x => x.Type == ClaimTypes.Email) ? info.ExternalPrincipal.FindFirst(ClaimTypes.Email).Value : null;
			var name = info.ExternalPrincipal.HasClaim(x => x.Type == ClaimTypes.Name) ? info.ExternalPrincipal.FindFirst(ClaimTypes.Name).Value : null;
			var externalAuthResult = new ExternalAuthenticationResult
			{
				Issuer = info.LoginProvider,
				Email = email,
				Name = name,
				ProviderKey = info.ProviderKey
			};
			var matchResult = _externalUserAssociationManager.ExternalUserAssociationCheck(externalAuthResult, ip);
			if (matchResult.Successful)
			{
				_userService.Login(matchResult.User, ip);
				await PerformSignInAsync(matchResult.User, HttpContext);
				return Redirect(returnUrl);
			}
			ViewBag.Referrer = returnUrl;
			return View();
		}

		// PopForums doesn't use the Xsrf property, because it associates claims with user accounts, not 
		// accounts with claims. For example, a user can't add a Facebook association while already logged in.
		// They must use their PF credentials after getting valid claims from the 3rd party.
		public static async Task<ExternalLoginInfo> GetExternalLoginInfoAsync(HttpContext httpContext, string expectedXsrf = null)
		{
			var auth = await httpContext.AuthenticateAsync(PopForumsAuthorizationDefaults.AuthenticationScheme);
			var items = auth?.Properties?.Items;
			if (auth?.Principal == null || items == null || !items.ContainsKey(LoginProviderKey))
			{
				return null;
			}

			if (expectedXsrf != null)
			{
				if (!items.ContainsKey(XsrfKey))
				{
					return null;
				}
				var userId = items[XsrfKey];
				if (userId != expectedXsrf)
				{
					return null;
				}
			}

			var claim = auth.Principal.FindFirst(ClaimTypes.NameIdentifier);
			var providerKey = claim?.Value;
			var provider = items[LoginProviderKey];
			if (providerKey == null || provider == null)
			{
				return null;
			}
			return new ExternalLoginInfo(auth.Principal, provider, providerKey, provider);
		}
	}
}
