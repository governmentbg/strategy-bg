using System.Linq;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Account;
using Models.Contracts;
using WebCommmon.Controllers;
using WebCommon.Extensions;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class GroupsController : BaseController
    {
        private readonly IAccountService accountService;
        public GroupsController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request)
        {
            var data = accountService.Groups_Select();
            var filteredData = data;
            if (!string.IsNullOrEmpty(request?.Search?.Value))
            {
                filteredData = data.Where(x => x.Name.Contains(request.Search.Value));
            }
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Add()
        {
            var model = new Groups()
            {
                IsActive = true
            };
            return View(nameof(Edit), model);
        }
        [HttpPost]
        public IActionResult Add(Groups model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = accountService.Groups_SaveData(model);
            if (SetSavedMessage)
            {
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            return View(nameof(Edit), model);
        }

        public IActionResult Edit(int id)
        {
            var model = accountService.Find<Groups>(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Groups model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = accountService.Groups_SaveData(model);
            return View(model);
        }
    }
}