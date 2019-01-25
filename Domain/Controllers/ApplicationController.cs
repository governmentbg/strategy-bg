using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using Models;
using Models.Context.Application;
using Models.Contracts;

namespace Domain.Controllers
{
    /// <summary>
    /// Административен модул за управление на подадените заявления
    /// </summary>
    [Authorize]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService appService = null;
        public ApplicationController(IApplicationService _appService)
        {
            appService = _appService;
        }
        public IActionResult Index(int? applicationTypeId = null, DateTime? dateRegFrom = null, DateTime? dateRegTo = null, string orgName = null, string localName = null, int? stateId = null)
        {
            ViewBag.applicationTypes = appService.All<ApplicationType>(x => x.IsActive).OrderBy(x => x.NameBG).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();
            ViewBag.applicationStates = appService.All<ApplicationState>(x => x.IsActive && x.Id > GlobalConstants.ApplicationStates.New).OrderBy(x => x.Id).ToSelectList(x => x.Id, x => x.NameBG).AddAllItem();
            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int? applicationTypeId = null, DateTime? dateRegFrom = null, DateTime? dateRegTo = null, string orgName = null, string localName = null, int? stateId = null)
        {
            var data = appService.Application_SelectInternal(applicationTypeId.EmptyToNull(), dateRegFrom.MakeFromDate(), dateRegTo.MakeToDate(), orgName.EmptyToNull(), localName.EmptyToNull(), stateId.EmptyToNull());

            var filteredData = data;

            var response = request.GetResponse(data, filteredData);

            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Preview(int id)
        {
            var model = appService.Application_GetByIdFull(id);
            switch (model.ApplicationTypeId)
            {
                case GlobalConstants.ApplicationTypes.Sending:
                    return View("PreviewSending", model);
                case GlobalConstants.ApplicationTypes.Posting:
                    return View("PreviewPosting", model);
                default:
                    break;
            }
            return View(model);
        }

        public IActionResult AcceptApplication(int appId, string ts)
        {
            if (appService.Application_UpdateState(appId, GlobalConstants.ApplicationStates.Accepted))
            {
                TempData[GlobalConstants.UserMessages.Success] = "Заявлението е успешно прието.";
            }
            else
            {
                TempData[GlobalConstants.UserMessages.Danger] = "Проблем при приемане на заявление. Моля, опитайте по-късно.";
            }
            return RedirectToAction(nameof(Preview), new { id = appId });
        }

        public IActionResult RejectApplication(int appId, string ts)
        {
            if (appService.Application_UpdateState(appId, GlobalConstants.ApplicationStates.Rejected))
            {
                TempData[GlobalConstants.UserMessages.Success] = "Заявлението е успешно е маркирано като неприето.";
            }
            else
            {
                TempData[GlobalConstants.UserMessages.Danger] = "Проблем при редакция на заявление. Моля, опитайте по-късно.";
            }
            return RedirectToAction(nameof(Preview), new { id = appId });
        }

    }
}