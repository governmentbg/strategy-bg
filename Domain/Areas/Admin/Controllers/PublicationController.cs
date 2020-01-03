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
using System.Linq;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Models.Context;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCommon.Models;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    public class PublicationController : BaseAdminController
    {
        private readonly IPublicationService service;
        public PublicationController(IPublicationService _service)
        {
            service = _service;
        }
        public IActionResult Index(int lang = GlobalConstants.LangBG)
        {
            ViewBag.lang = lang;
            ViewBag.categories = service.PublicationCategories_SelectCombo().ToSelectList(-1).AddAllItem();
            IEnumerable<TextValueVM> ddlData = new List<TextValueVM>() { new TextValueVM() { Value = "1", Text = "Активни" }, new TextValueVM() { Value = "0", Text = "Неактивни" } };
            ViewBag.active = ddlData.ToSelectList(-1).AddAllItem();
            return View();
        }
        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, DateTime? dateFrom, DateTime? dateTo, int category, bool activeOnly, string term, int lang)

        {



            var data = service.Publication_AdminSelect(dateFrom, dateTo, null, term.EmptyToNull(), activeOnly).Where(x => x.LanguageId == lang);


            if (category > 0)
            { data = service.Publication_AdminSelect(dateFrom, dateTo, category, term.EmptyToNull(), activeOnly).Where(x => x.LanguageId == lang); }
            var filtered = data;
            var response = request.GetResponse(data, filtered);

            return new DataTablesJsonResult(response, true);
        }


        public IActionResult Add(int lang)
        {
            var model = new Publications()
            {
                LanguageId = lang,
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
                SaveSiteLog(SiteLogTableNames.Publications, SiteLogAction.Add, model.Id, model.IsApproved, model.Title);
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
      int logState = SiteLogAction.Edit;
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
      if (model.IsDeleted == true)
      { logState = SiteLogAction.Delete; }
      this.SetSavedMessage = service.Publication_SaveData(model);
            if (SetSavedMessage)
            {
                SaveSiteLog(SiteLogTableNames.Publications, logState, model.Id, model.IsApproved, model.Title);
            }
            return View(model);
        }

        private void SetViewBag(Publications model)
        {
            ViewBag.categories = service.PublicationCategories_SelectCombo().ToSelectList(model.PublicationCategoryId);
        }
    }
}