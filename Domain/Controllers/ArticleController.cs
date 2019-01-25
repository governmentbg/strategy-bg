using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Ogp;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon.Extensions;

namespace Domain.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService service;

        public ArticleController(IArticleService _service)
        {
            service = _service;
        }

        public IActionResult Index(int category = -1)
        {
            ViewBag.category = category;
            if (category > 0)
            {
                ViewBag.categoryName = service.ArticleCategories_GetById(category)?.Name;
            }
            return View();
        }

        [HttpPost]
        public JsonResult LoadDataGrid([FromBody]GridRequestModel data)
        {
            int? category = (int)data.param.category;
            var model = service.Article_Select(category.EmptyToNull(), data.filter.EmptyToNull());

            return Json(new GridResponseModel<ArticleListVM>(data, model));
        }

        public JsonResult SelectAsEvents(DateTime start, DateTime end)
        {
            var model = service.Article_Select(null, null)
                    .Where(x => start <= x.EventDate && end >= x.EventDate)
                    .ToList()
                    .Select(x => new EventVM
                    {
                        Start = x.EventDate.ToString("o"),
                        Title = x.Title,
                        Url = Url.Action(nameof(View), new { id = x.Id })
                    });
           
            return Json(model);
        }

        public IActionResult View(int id)
        {
            var model = service.Article_GetById(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Content = model.Content.DecodeIfNeeded();
            return View(model);
        }


    }
}