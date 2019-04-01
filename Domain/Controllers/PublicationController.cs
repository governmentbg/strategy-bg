using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Portal;
using WebCommon.Extensions;

namespace Domain.Controllers
{
    public class PublicationController : BasePortalController
    {
        private readonly IPublicationService service;
        private readonly IUrlHelper urlHelper;

        public PublicationController(IPublicationService _articleService, IUrlHelper _urlHelper)
        {
            service = _articleService;
            urlHelper = _urlHelper;
        }

        public IActionResult Index(int category = -1)
        {
            ViewBag.category = category;
            if (category > 0)
            {
                ViewBag.categoryName = service.PublicationCategories_GetById(category)?.Name;
            }
            ViewBag.categories = service.PublicationCategories_SelectCombo(this.Lang).ToSelectList(category).AddAllItem();
            ViewBag.RssLink = urlHelper.Action("GetNewsFeed", "Rss", new
            {
                type = RssFeedType.Publications
            });

            return View();
        }

        [HttpPost]
        public JsonResult LoadDataGrid([FromBody]GridRequestModel data)
        {
            int? category = (int)data.param.category;
            string searchTerm = (string)data.param.searchTerm;
            var model = service.Publication_Select(category.EmptyToNull(), searchTerm.EmptyToNull(), this.Lang);

            return Json(new GridResponseModel<ArticleListVM>(data, model));
        }
        public IActionResult View(int id)
        {
            var model = service.Publication_GetById(id);
            model.Title = model.Title.DecodeIfNeeded();
            model.Content = model.Content.DecodeIfNeeded();
            return View(model);
        }

    }
}