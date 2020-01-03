using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context;
using Models.Contracts;

namespace Domain.Controllers
{
    public class OgpController : BasePortalController
    {

        private readonly IOgpService ogpService;
        public OgpController(
            IOgpService _ogpService)
        {
            ogpService = _ogpService;
        }
        public IActionResult Plans()
        {
            var actualPlan = ogpService.SelectPlansForOgpMenu().Where(x => x.StateId == GlobalConstants.OgpElementStates.Actual).FirstOrDefault();
            if(actualPlan != null)
            {
                return RedirectToAction(nameof(Element), new { id = actualPlan.Id });
            }


            var planList = ogpService.Element_Select(null)
                                .Where(x => x.IsActive)
                                .OrderBy(x => x.StateId)
                                .AsQueryable();
            return View(planList);
        }

        public IActionResult Element(int id)
        {
            var model = ogpService.Portal_GetElement(id);
            ViewBag.estimations = ogpService.Estimation_Select(id, null).Where(x => x.IsActive);
            return View(model);
        }
        public IActionResult Estimation(int id)
        {
            var model = ogpService.Estimation_Select(0, null, id).FirstOrDefault();
            return View(model);
        }

        public IActionResult Agenda()
        {
            return View();
        }
        public IActionResult Contacts()
        {
            var model = ogpService.Find<GenericContent>("ogp-contacts");
            return View(model);
        }
    }
}