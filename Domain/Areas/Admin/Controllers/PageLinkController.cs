using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.Context;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using System.Linq;

namespace Domain.Areas.Admin.Controllers
{
    /// <summary>
    /// Външни връзки към страници
    /// </summary>
    [Area(nameof(Areas.Admin))]
    public class PageLinkController : BaseController
    {
        private readonly IPageService pageService;
        public PageLinkController(IPageService _pageService)
        {
            pageService = _pageService;
        }
        public IActionResult Index(int pageId)
        {
            //var model = pageService.Select(lang, parent_id);
            SetViewBag(pageId);
            var data = pageService.SelectPageLink(pageId).ToList();
            return View(data);
        }

        public IActionResult Add(int pageId)
        {
            var model = new PageLink()
            {
                PageId = pageId
            };
            SetViewBag(model.PageId);
            return View(nameof(Edit), model);
        }



        [HttpPost]
        public IActionResult Add(PageLink model)
        {
            if (ModelState.IsValid)
            {
                if (pageService.SavePageLink(model))
                {
                    return RedirectToAction(nameof(Index), new { pageId = model.PageId });
                }
            }
            SetViewBag(model.PageId);

            return View(nameof(Edit), model);
        }
        public IActionResult Edit(int id)
        {
            var model = pageService.Find<PageLink>(id);

            SetViewBag(model.PageId);

            return View(nameof(Edit), model);
        }
        [HttpPost]
        public IActionResult Edit(PageLink model)
        {
            if (ModelState.IsValid)
            {
                if (pageService.SavePageLink(model))
                {
                    return RedirectToAction(nameof(Index), new { pageId = model.PageId });
                }
            }
            SetViewBag(model.PageId);

            return View(nameof(Edit), model);
        }


        private void SetViewBag(int pageId)
        {
            var page = pageService.GetByID(pageId);
            ViewBag.page = page;
        }


        public IActionResult DeletePageLinkItem(int id)
        {
            var pageLink = pageService.Find<PageLink>(id);
            pageService.DeletePageLink(id);
            return RedirectToAction(nameof(Index), new { pageId = pageLink.PageId });
        }

        [HttpPost]
        public IActionResult InsertFromSelectedPage(int pageId, int contentId, string lang)
        {
            pageService.SavePageLinkFromSelectedPage(pageId, contentId, lang);
            return RedirectToAction(nameof(Index), new { pageId });
        }
    }
}