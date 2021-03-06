﻿using System.Linq;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Account;
using Models.Contracts;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using System;
using Models.ViewModels;
using Models.ViewModels.Portal;
using Models.Context.Legacy;
using Elastic.Models.Data;
using System.Text;
using Elastic.Models.Contracts;
using static Models.GlobalConstants;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    public class NewsController : BaseAdminController
    {
        private readonly INewsService service;
        private readonly IDataIndexerService dataIndexerService;
        public NewsController(INewsService _service, IDataIndexerService _dataIndexerService)
        {
            service = _service;
            dataIndexerService = _dataIndexerService;
        }
        public IActionResult Index(int lang = GlobalConstants.LangBG, bool activeOnly = true)
        {
            ViewBag.lang = lang;
            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, DateTime? dateFrom, DateTime? dateTo, string term, int lang, bool activeOnly)
        {
            var data = service.News_AdminSelect(dateFrom, dateTo, null, term.EmptyToNull(), activeOnly).Where(x => x.LanguageId == lang);
            var filtered = data;
            var response = request.GetResponse(data, filtered);

            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Add(int lang)
        {
            var model = new News()
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
        public IActionResult Add(News model)
        {
            model.IsApproved = true;
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }
    
      SetSavedMessage = service.News_SaveData(model);
            if (SetSavedMessage)
            {
                SaveSiteLog(SiteLogTableNames.News, SiteLogAction.Add, model.Id, model.IsApproved, model.Title);
                //***Indexing in Elastic******************************************************************
                try
                {
                    elasticContent _document = new elasticContent();
                    _document.Content = Convert.ToBase64String(Encoding.UTF8.GetBytes(model.Text));
                    _document.Path = dataIndexerService.PathCreator(SystemPaths.News, model.Id);
                    _document.docId = model.Id.ToString();
                    dataIndexerService.indexDocument(_document);
                }
                catch (Exception es_ex)
                { }
                //***************************************************************************************

                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }
            return View(nameof(Edit), model);
        }

        public IActionResult Edit(int id)
        {
            var model = service.Find<News>(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Text = model.Text.DecodeIfNeeded();

            model.IsApproved = true;

            SetViewBag(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(News model)
        {
      int logState = SiteLogAction.Edit;
            model.IsApproved = true;
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
    
        if (model.IsDeleted == true)
        { logState = SiteLogAction.Delete; }
    

      this.SetSavedMessage = service.News_SaveData(model);
            if (SetSavedMessage)
            {
                SaveSiteLog(SiteLogTableNames.News, logState, model.Id, model.IsApproved, model.Title);
            }
            return View(model);
        }

        private void SetViewBag(News model)
        {
            ViewBag.categories = service.NewsCategories_SelectCombo(model.LanguageId).ToSelectList(model.NewsCategoryId);
            //AddLanguageNameToViewbag(model.LanguageId);
        }
    }
}