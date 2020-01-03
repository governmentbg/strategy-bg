using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Context.Ogp;
using Models.Contracts;
using WebCommon.Extensions;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    [Authorize]
    public partial class OgpController : BaseAdminController
    {

        private readonly IOgpService ogpService;

        public OgpController(IOgpService _ogpService)
        {
            ogpService = _ogpService;
        }
        public IActionResult PlanElements(int? parentId = null)
        {
            ViewBag.parentId = parentId;
            if (parentId > 0)
            {
                ViewBag.parent = ogpService.Find<NationalPlanElements>(parentId);
            }

            return View();
        }
        [HttpPost]
        public IActionResult PlanElements_LoadData(IDataTablesRequest request, int? parentId)
        {
            var data = ogpService.Element_Select(parentId);
            var filtered = data;
            if (request.Search?.Value != null)
            {
                string term = request.Search?.Value;
                filtered = data.Where(x => x.Title.Contains(term));
            }
            var response = request.GetResponse(data, filtered);

            return new DataTablesJsonResult(response, true);
        }

        public IActionResult PlanElements_Add(int? parentId)
        {
            var model = new NationalPlanElements()
            {
                ParentID = parentId,
                IsActive = true
            };
            PlanElements_ViewBags(model);

            return View(nameof(PlanElements_Edit), model);
        }

        [HttpPost]
        public IActionResult PlanElements_Add(NationalPlanElements model)
        {
            if (!ModelState.IsValid)
            {
                PlanElements_ViewBags(model);
                return View(nameof(PlanElements_Edit), model);
            }

            SetSavedMessage = ogpService.Element_SaveData(model);
            if (SetSavedMessage)
            {
        SaveSiteLog(SiteLogTableNames.OGP, SiteLogAction.Add, model.Id, true, model.Title);
        return RedirectToAction(nameof(PlanElements_Edit), new { id = model.Id });
            }
            return View(nameof(PlanElements_Edit), model);
        }
        public IActionResult PlanElements_Edit(int id)
        {
            var model = ogpService.Find<NationalPlanElements>(id);
            PlanElements_ViewBags(model);
            return View(nameof(PlanElements_Edit), model);
        }
        [HttpPost]
        public IActionResult PlanElements_Edit(NationalPlanElements model)
        {
            if (!ModelState.IsValid)
            {
                PlanElements_ViewBags(model);
                return View(nameof(PlanElements_Edit), model);
            }

            SetSavedMessage = ogpService.Element_SaveData(model);
            if (SetSavedMessage)
      {
        SaveSiteLog(SiteLogTableNames.OGP, SiteLogAction.Edit, model.Id, true, model.Title);
        return RedirectToAction(nameof(PlanElements_Edit), new { id = model.Id });
            }
            return View(nameof(PlanElements_Edit), model);
        }
        private void PlanElements_ViewBags(NationalPlanElements model)
        {
            ViewBag.types = ogpService.ElementType_Combo().ToSelectList(model.ElementTypeId);
            ViewBag.states = ogpService.NationalPlanStates_Combo().ToSelectList(model.NationalPlanStateId);
        }
    }
}