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
using System;
using Models.ViewModels;
using Models.ViewModels.Portal;
using Models.Context.Legacy;
using Elastic.Models.Data;
using System.Text;
using Elastic.Models.Contracts;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Areas.Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class NewsController : BaseController
    {
        private readonly INewsService service;
        private readonly IDataIndexerService dataIndexerService;
        public NewsController(INewsService _service, IDataIndexerService _dataIndexerService)
        {
            service = _service;
            dataIndexerService = _dataIndexerService;
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

            var model = service.News_AdminSelect(dateFrom, dateTo, null, term.EmptyToNull());

            return Json(new GridResponseModel<ArticleListAdminVM>(data, model));
        }

        public IActionResult Add()
        {
            var model = new News()
            {
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
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(nameof(Edit), model);
            }

            SetSavedMessage = service.News_SaveData(model);
            if (SetSavedMessage)
            {
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
              {}
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

            SetViewBag(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(News model)
        {
            SetViewBag(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = service.News_SaveData(model);
            return View(model);
        }

        private void SetViewBag(News model)
        {
            ViewBag.categories = service.NewsCategories_SelectCombo().ToSelectList(model.NewsCategoryId);
        }
    }
}