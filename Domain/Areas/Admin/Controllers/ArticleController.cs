﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using System;
using Models.ViewModels;
using Models.ViewModels.Portal;
using Models.Context.Legacy;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    public class ArticleController : BaseAdminController
    {
        private readonly IArticleService articleService;
        public ArticleController(IArticleService _articleService)
        {
            articleService = _articleService;
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

            var model = articleService.Article_AdminSelect(dateFrom, dateTo, null, term.EmptyToNull());

            return Json(new GridResponseModel<ArticleListAdminVM>(data, model));
        }

        public IActionResult Add()
        {
            var model = new Articles()
            {
                IsActive = true,
                IsApproved = true,
                Date = DateTime.Now
            };

          SetViewBag(model);
            return View(nameof(Edit), model);
        }
        [HttpPost]
        public IActionResult Add(Articles model)
        {
      model.IsApproved = true;
      SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = articleService.Article_SaveData(model);
            if (SetSavedMessage)
            {
        SaveSiteLog(SiteLogTableNames.Articles, SiteLogAction.Add, model.Id, model.IsApproved, model.Title);
        return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            return View(nameof(Edit), model);
        }

        public IActionResult Edit(int id)
        {
            var model = articleService.Find<Articles>(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Text = model.Text.DecodeIfNeeded();
      model.IsApproved = true;
            SetViewBag(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Articles model)
        {
      model.IsApproved = true;
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = articleService.Article_SaveData(model);
      if (SetSavedMessage)
      {
        SaveSiteLog(SiteLogTableNames.Articles, SiteLogAction.Edit, model.Id, model.IsApproved, model.Title);
      }
      return View(model);
        }

        private void SetViewBag(Articles model)
        {
            ViewBag.categories = articleService.ArticleCategories_SelectCombo().ToSelectList(model.ArticleCategoryId);
        }
    }
}