﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PopForums.Models;
using PopForums.Mvc.Areas.Forums.Authorization;
using PopForums.Services;

namespace PopForums.Mvc.Areas.Forums.Controllers
{
	[Area("Forums")]
	public class SetupController : Controller
	{
		public SetupController(ISetupService setupService)
		{
			_setupService = setupService;
		}

		private readonly ISetupService _setupService;

		public static string Name = "Setup";

		[PopForumsAuthorizationIgnore]
		public ActionResult Index()
		{
			if (!_setupService.IsConnectionPossible())
				return View("NoConnection");
			if (_setupService.IsDatabaseSetup())
				return StatusCode(403);
			var setupVariables = new SetupVariables
			{
				SmtpPort = 25,
				ServerDaylightSaving = true,
				ServerTimeZone = -5
			};

			return View(setupVariables);
		}

		[PopForumsAuthorizationIgnore]
		[HttpPost]
		public ActionResult Index(SetupVariables setupVariables)
		{
			if (_setupService.IsDatabaseSetup())
				return StatusCode(403);
			Exception exc;
			var user = _setupService.SetupDatabase(setupVariables, out exc);
			if (exc != null)
				return View("Exception", exc);
			// can't login here because all of the normal app startup was skipped
			//await AuthorizationController.PerformSignInAsync(true, user, HttpContext);
			return View("Success");
		}
	}
}