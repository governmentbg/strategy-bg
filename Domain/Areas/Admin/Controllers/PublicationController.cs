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

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class PublicationController : BaseController
    {
        private readonly IPublicationService service;
        public PublicationController(IPublicationService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoadDataGrid([FromBody]GridRequestModel data)
        {
            DateTime? dateFrom = ((string)data.param.dateFrom).ParseDateTime();
            DateTime? dateTo = ((string)data.param.dateTo).ParseDateTime();
            string term = (string)data.param.term;

            var model = service.Publication_AdminSelect(dateFrom, dateTo, null, term.EmptyToNull());

            return Json(new GridResponseModel<ArticleListAdminVM>(data, model));
        }

        public IActionResult Add()
        {
            var model = new Publications()
            {
                IsActive = true,
                IsApproved = true,
                Date = DateTime.Now
            };
            SetViewBag(model);
            return View(nameof(Edit), model);
        }
        [HttpPost]
        public IActionResult Add(Publications model)
        {
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = service.Publication_SaveData(model);
            if (SetSavedMessage)
            {
                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            return View(nameof(Edit), model);
        }

        public IActionResult Edit(int id)
        {
            var model = service.Find<Publications>(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Text = model.Text.DecodeIfNeeded();
            SetViewBag(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Publications model)
        {
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = service.Publication_SaveData(model);
            return View(model);
        }

        private void SetViewBag(Publications model)
        {
            ViewBag.categories = service.PublicationCategories_SelectCombo().ToSelectList(model.PublicationCategoryId);
        }
    }
}