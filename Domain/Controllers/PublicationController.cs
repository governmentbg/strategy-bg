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
                ViewBag.categoryID = category;
      }
            ViewBag.categories = service.PublicationCategories_SelectCombo(this.Lang).ToSelectList(category).AddAllItem().DecodeIfNeeded();
            ViewBag.RssLink = urlHelper.Action("GetNewsFeed", "Rss", new
            {
                type = RssFeedType.Publications
            });

            return View();
        }
        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, int? categoryId, string searchTerm)
        {
            string sanitizedSearch = searchTerm.EmptyToNull();
            var data = service.Publication_Select(categoryId.EmptyToNull(), searchTerm.EmptyToNull(), this.Lang);
            var response = request.GetResponse(data, data);
            return new DataTablesJsonResult(response, true);
        }

        //[HttpPost]
        //public JsonResult LoadDataGrid([FromBody]GridRequestModel data)
        //{
        //    int? category = (int)data.param.category;
        //    string searchTerm = (string)data.param.searchTerm;
        //    var model = service.Publication_Select(category.EmptyToNull(), searchTerm.EmptyToNull(), this.Lang);

        //    return Json(new GridResponseModel<ArticleListVM>(data, model));
        //}
        public IActionResult View(int id)
        {
            var model = service.Publication_GetById(id);

            if (model == null || !model.IsActive)
            {
                return View("NotFound");
            }

            model.Title = model.Title.DecodeIfNeeded();
            model.Content = model.Content.DecodeIfNeeded();
            ViewBag.categories = service.PublicationCategories_SelectCombo(this.Lang).ToSelectList(model.CategoryId).AddAllItem();
            return View(model);
        }

    }
}