using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Portal;
using WebCommon.Extensions;

namespace Domain.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService service;

        public NewsController(INewsService _service)
        {
            service = _service;
        }

        public IActionResult Index(int category = -1)
        {
            ViewBag.category = category;
            if (category > 0)
            {
                ViewBag.categoryName = service.NewsCategories_GetById(category)?.Name;
            }
            return View();
        }

        [HttpPost]
        public JsonResult LoadDataGrid([FromBody]GridRequestModel data)
        {
            int? category = (int)data.param.category;
            var model = service.News_Select(category.EmptyToNull(), data.filter.EmptyToNull());

            return Json(new GridResponseModel<ArticleListVM>(data, model));
        }

        public IActionResult View(int id)
        {
            var model = service.News_GetById(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Content = model.Content.DecodeIfNeeded();
            return View(model);
        }

     
    }
}