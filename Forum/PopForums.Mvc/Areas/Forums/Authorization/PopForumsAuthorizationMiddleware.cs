using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using PopForums.Services;

namespace PopForums.Mvc.Areas.Forums.Authorization
{
	public class PopForumsAuthorizationMiddleware
	{
		private readonly RequestDelegate _next;

		public PopForumsAuthorizationMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public Task InvokeAsync(HttpContext context, IUserService userService, IProfileService profileService, ISetupService setupService)
		{
			if (!setupService.IsRuntimeConnectionAndSetupGood())
				return _next.Invoke(context);
      //		var authResult = context.AuthenticateAsync(PopForumsAuthorizationDefaults.AuthenticationScheme).Result;
      //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,accountService.GeneratePrincipalByUsername(model.Username));
      var authResult = context.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme).Result;

      var identity = authResult?.Principal?.Identity as ClaimsIdentity;
			if (identity != null)
			{
        IEnumerable<Claim> CaimsList = identity.Claims;

        int _userID =-1;

        try
        {
          _userID = Convert.ToInt32(CaimsList.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").Value.ToString());
        }
        catch { }

        var user = userService.GetUser(_userID); 
				if (user != null)
				{
					foreach (var role in user.Roles)
						identity.AddClaim(new Claim(PopForumsAuthorizationDefaults.ForumsClaimType, role));
					context.Items["PopForumsUser"] = user;
					var profile = profileService.GetProfile(user);
					context.Items["PopForumsProfile"] = profile;
					context.User = new ClaimsPrincipal(identity);
				}
			}
			return _next.Invoke(context);
		}
	}
}