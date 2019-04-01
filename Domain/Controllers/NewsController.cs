using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Portal;
using WebCommon.Extensions;

namespace Domain.Controllers
{
    public class NewsController : BasePortalController
    {
        private readonly INewsService service;
        private readonly IUrlHelper urlHelper;

        public NewsController(INewsService _service, IUrlHelper _urlHelper)
        {
            service = _service;
            urlHelper = _urlHelper;
        }

        public IActionResult Index(int category = -1)
        {
            ViewBag.category = category;
            if (category > 0)
            {
                ViewBag.categoryName = service.NewsCategories_GetById(category)?.Name;
            }
            ViewBag.categories = service.NewsCategories_SelectCombo(this.Lang).ToSelectList(category).AddAllItem();
            ViewBag.RssLink = urlHelper.Action("GetNewsFeed", "Rss", new
            {
                type = RssFeedType.News
            });

            return View();
        }

        [HttpPost]
        public JsonResult LoadDataGrid([FromBody]GridRequestModel data)
        {
            int? category = (int)data.param.category;
            string searchTerm = (string)data.param.searchTerm;
            var model = service.News_Select(category.EmptyToNull(), searchTerm.EmptyToNull(), this.Lang);

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