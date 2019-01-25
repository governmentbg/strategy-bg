using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels.LinksModels;
using Models.Contracts;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Services;
using Models.ViewModels.Calculator;
using WebCommon.Models;
using System;
using Rotativa.AspNetCore;
using System.ComponentModel;

namespace Domain.Controllers
{
	public class CalculatorController : Controller
	{
		#region Calculator
		public IActionResult NewCalculation()
		{
			CalculatorViewModel model = new CalculatorViewModel();

			return View();
		}

		[HttpPost]
		public IActionResult NewCalculation(CalculatorViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			for (int i = 0; i < model.ActivityNumbers; i++)
			{
				CalculatorActivityVM activity = new CalculatorActivityVM();
				model.CalculatorActivities.Add(activity);
			}

			return View("Calculate", model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Calculate(CalculatorViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			model.TotalAdministrativeBurden = 0;

			foreach (var activity in model.CalculatorActivities)
			{
				activity.TotalActivityAdministrativeBurden = Math.Round(activity.ActivityHours * activity.CompanyNumbers * activity.ActivityNumbers * activity.AverageSalary / 170, 2);
				model.TotalAdministrativeBurden += activity.TotalActivityAdministrativeBurden;
			}

			return View("Calculate", model);
		}

		[HttpPost]
		[Description("Административен товар")]
		public IActionResult ExportCalculationToPDF(CalculatorViewModel model)
		{
			model.TotalAdministrativeBurden = 0;

			foreach (var activity in model.CalculatorActivities)
			{
				activity.TotalActivityAdministrativeBurden = Math.Round(activity.ActivityHours * activity.CompanyNumbers * activity.ActivityNumbers * activity.AverageSalary / 170, 2);
				model.TotalAdministrativeBurden += activity.TotalActivityAdministrativeBurden;
			}

			return new ViewAsPdf("_CalculationPDF", model);
		}
		#endregion
	}
}