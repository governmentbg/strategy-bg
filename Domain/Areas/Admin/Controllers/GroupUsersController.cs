using System.Linq;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Account;
using Models.Contracts;
using Models.ViewModels.Account;
using WebCommmon.Controllers;
using WebCommon.Extensions;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    [Authorize(Roles = GlobalConstants.Roles.AdminAndAdminGroup)]
    public class GroupUsersController : BaseAdminController
    {
        private readonly IAccountService accountService;
        private readonly INomenclatureService nomService;
        public GroupUsersController(IAccountService _accountService, INomenclatureService _nomService)
        {
            accountService = _accountService;
            nomService = _nomService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request)
        {
            var data = accountService.GroupUsers_Select();
            var filteredData = data;
            if (!string.IsNullOrEmpty(request?.Search?.Value))
            {
                filteredData = data.Where(x => x.Organization.Contains(request.Search.Value));
            }
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Add()
        {
            var model = new GroupUserVM()
            {
                IsActive = true
            };
            SetViewBag(model);
            return View(nameof(Edit), model);
        }
        [HttpPost]
        public IActionResult Add(GroupUserVM model)
        {
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = accountService.GroupUsers_SaveData(model);
            if (SetSavedMessage)
            {
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            return View(nameof(Edit), model);
        }

        public IActionResult Edit(int id)
        {
            var model = accountService.GroupUsers_Select(id).FirstOrDefault();
            SetViewBag(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GroupUserVM model)
        {
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = accountService.GroupUsers_SaveData(model);
            return View(model);
        }

        public IActionResult Users(int groupId)
        {
            TempData["groupId"] = groupId;
            var model = accountService.GroupUsers_Select(groupId).FirstOrDefault();
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Users_LoadData(IDataTablesRequest request, int groupId)
        {
            var data = accountService.UserInGroup_Select(groupId, null);
            var filteredData = data;
            if (!string.IsNullOrEmpty(request?.Search?.Value))
            {
                filteredData = data.Where(x => x.UserFullName.Contains(request.Search.Value));
            }
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Remove(int groupId, int userId)
        {
            if (accountService.UserInGroup_Remove(groupId, userId))
            {
                SetSavedMessageExt("Потребителя е премахнат от групата успешно.", true);
            }
            else
            {
                SetSavedMessage = false;
            }
            return Content(SetSavedMessage.ToString());
        }

        private void SetViewBag(GroupUserVM model)
        {
            ViewBag.institutions = nomService.GetInstitutionTypesDDL().ToSelectList(x => x.Value, x => x.Text, model.InstitutionTypeId);
        }
    }
}