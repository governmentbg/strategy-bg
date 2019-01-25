using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using System;
using Models.ViewModels;
using Models.ViewModels.Portal;
using Models.Context.Legacy;
using DataTables.AspNet.Core;
using System.Linq;
using DataTables.AspNet.AspNetCore;
using Models.Context;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class GenericContentController : BaseController
    {
        private readonly ICommonService commonService;
        public GenericContentController(ICommonService _commonService)
        {
            commonService = _commonService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request)
        {

            var data = commonService.GenericContent_Select();
            var filteredData = data;
            if (!string.IsNullOrEmpty(request.Search?.Value))
            {
                var term = (string)request.Search?.Value;
                filteredData = data.Where(x => x.Title.Contains(term));
            }
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Add()
        {
            var model = new GenericContent()
            {
                IsActive = true
            };
            return View(nameof(Edit), model);
        }
        [HttpPost]
        public IActionResult Add(GenericContent model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = commonService.GenericContent_SaveData(model);
            if (SetSavedMessage)
            {
                return RedirectToAction(nameof(Edit), new { id = model.Alias });
            }
            return View(nameof(Edit), model);
        }

        public IActionResult Edit(string id)
        {
            var model = commonService.Find<GenericContent>(id);
            model.SavedAlias = model.Alias;
            model.Title = model.Title.DecodeIfNeeded();
            model.Text = model.Text.DecodeIfNeeded();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GenericContent model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = commonService.GenericContent_SaveData(model);
            return View(model);
        }
       
    }
}