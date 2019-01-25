using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models.Context.Ogp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCommon.Extensions;

namespace Domain.Areas.Admin.Controllers
{
    public partial class OgpController
    {
        public IActionResult Estimations(int elementId, int? parentId = null)
        {
            ViewBag.parentId = parentId;

            if (parentId > 0)
            {
                var parent = ogpService.Find<NationalPlanEstimations>(parentId);
                ViewBag.parent = parent;
                elementId = parent.ElementID;
            }
            ViewBag.elementId = elementId;
            ViewBag.element = ogpService.Find<NationalPlanElements>(elementId);


            return View();
        }
        [HttpPost]
        public IActionResult Estimations_LoadData(IDataTablesRequest request, int elementId, int? parentId)
        {
            var data = ogpService.Estimation_Select(elementId, parentId);
            var filtered = data;
            if (request.Search?.Value != null)
            {
                string term = request.Search?.Value;
                filtered = data.Where(x => x.Title.Contains(term));
            }
            var response = request.GetResponse(data, filtered);

            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Estimations_Add(int elementId, int? parentId = null)
        {
            var model = new NationalPlanEstimations()
            {
                ElementID = elementId,
                IsActive = true
            };
            if (parentId > 0)
            {
                var parent = ogpService.Find<NationalPlanEstimations>(parentId);
                model.ParentID = parentId;
                model.EstimationTypeId = parent.EstimationTypeId;
            }
            Estimations_ViewBags(model);

            return View(nameof(Estimations_Edit), model);
        }

        [HttpPost]
        public IActionResult Estimations_Add(NationalPlanEstimations model)
        {
            if (!ModelState.IsValid)
            {
                Estimations_ViewBags(model);
                return View(nameof(Estimations_Edit), model);
            }

            SetSavedMessage = ogpService.Estimation_SaveData(model);
            if (SetSavedMessage)
            {
                return RedirectToAction(nameof(Estimations_Edit), new { id = model.Id });
            }
            return View(nameof(Estimations_Edit), model);
        }
        public IActionResult Estimations_Edit(int id)
        {
            var model = ogpService.Find<NationalPlanEstimations>(id);
            Estimations_ViewBags(model);
            return View(nameof(Estimations_Edit), model);
        }
        [HttpPost]
        public IActionResult Estimations_Edit(NationalPlanEstimations model)
        {
            if (!ModelState.IsValid)
            {
                Estimations_ViewBags(model);
                return View(nameof(Estimations_Edit), model);
            }

            SetSavedMessage = ogpService.Estimation_SaveData(model);
            if (SetSavedMessage)
            {
                return RedirectToAction(nameof(Estimations_Edit), new { id = model.Id });
            }
            return View(nameof(Estimations_Edit), model);
        }
        private void Estimations_ViewBags(NationalPlanEstimations model)
        {
            ViewBag.types = ogpService.EstimationType_Combo().ToSelectList(model.EstimationTypeId);
            if (model.ParentID > 0)
            {
                var parent = ogpService.Find<NationalPlanEstimations>(model.ParentID);
                ViewBag.planElements = ogpService.NationalPlanSubElements_Combo(parent.ElementID).ToSelectList(model.ElementID);
            }
        }
    }
}
