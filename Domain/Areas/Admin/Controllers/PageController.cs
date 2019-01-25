using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models;
using Models.Context;
using Models.ViewModels.Plugins;
using System.Linq;
using System;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Domain.Areas.Admin.Controllers
{
    /// <summary>
    /// Управление на съдържание
    /// </summary>
    [Area(nameof(Areas.Admin))]
    [Authorize]
    public class PageController : BaseController
    {
        private readonly IPageService pageService;
        public PageController(IPageService _pageService)
        {
            pageService = _pageService;
        }
        [Authorize(Roles = GlobalConstants.Roles.Admin)]
        public IActionResult Index(int pageType, string lang = GlobalConstants.DefaultLang)
        {
            ViewBag.lang = lang;
            ViewBag.pageType = pageService.GetPageType(pageType);
            return View();
        }

        public IActionResult Select(int pageType, string callbackName, string lang = GlobalConstants.DefaultLang)
        {
            //var model = pageService.Select(lang, parent_id);
            ViewBag.lang = lang;
            ViewBag.pageType = pageService.GetPageType(pageType);
            ViewBag.callbackName = callbackName;
            return PartialView();
        }

        public JsonResult GetTreeViewData(int pageType, string lang, bool selectOnly = false)
        {
            var model = pageService
                            .Select(pageType, lang, null)
                            .Select(item => new TreeViewDataVM
                            {
                                id = item.ContentId.ToString(),
                                ContentId = item.ContentId,
                                parent = (item.ParentContentId == -1) ? "#" : item.ParentContentId.ToString(),
                                position = item.OrderBy.ToString(),
                                text = item.Title,
                                icon = GetPageIcon(item.StateID),
                                lang = lang,
                                li_attr = new { lid = item.Id },
                                a_attr = new
                                {
                                    id = item.Id,
                                    contentId = item.ContentId,
                                    url = item.Url,
                                    css = "style" + item.StateID,
                                    update = Url.Action("Edit", new { id = item.Id }),
                                    deleteCurrent = Url.Action("DeletePageItem", new { pageId = item.Id, allTranslations = false }),
                                    deleteAll = Url.Action("DeletePageItem", new { pageId = item.Id, allTranslations = false }),
                                    sub = Url.Action("Add", new { pageType, lang, parentContentId = item.ContentId })
                                }
                            }).ToList();
            if (!selectOnly)
            {
                model.Add(new TreeViewDataVM()
                {
                    id = "new",
                    text = "Добави главна страница",
                    parent = "#",
                    icon = "fa fa-plus",
                    li_attr = new { lid = 0 },
                    a_attr = new
                    {
                        href = Url.Action("Add", new { pageType, lang, parentContentId = -1 })
                    }
                });
            }
            var translations = pageService.SelectTranslations(pageType);
            foreach (var item in model)
            {
                item.t_attr = GlobalConstants.SelectLangs()
                                .Where(x => x.Lang != item.lang)
                                .Select(x => new TranslationVM
                                {
                                    Lang = x.Lang,
                                    ItemUrl = translations.Where(t => t.ContentId == item.ContentId && t.Lang == x.Lang)
                                            .Select(t => Url.Action("Edit", new { id = t.PageId })).FirstOrDefault()
                                            ?? Url.Action("AddTranslation", new { lang = x.Lang, id = item.id }),
                                    LangName = x.Title
                                });
            }
            while (model.Any(x => !model.Any(p => p.id == x.parent) && x.parent != "#"))
            {
                var item = model.FirstOrDefault(x => !model.Any(p => p.id == x.parent) && x.parent != "#");
                for (int i = 0; i < model.Count; i++)
                {
                    if (model[i].id == item.id)
                    {
                        model.RemoveAt(i);
                    }
                }
            }
            return Json(model);
        }
        private string GetPageIcon(int pageStateId)
        {
            switch (pageStateId)
            {
                case GlobalConstants.PageStates.Published:
                    return "fa fa-globe";
                case GlobalConstants.PageStates.Deleted:
                    return "fa fa-trash-o";
                case GlobalConstants.PageStates.Draft:
                default:
                    return "fa fa-sticky-note-o";
            }
        }

        public JsonResult GetSubPageList(int contentId, string lang)
        {
            var model = pageService.Select(GlobalConstants.PageTypes.Pages, lang, contentId);
            return Json(model.Select(x => new
            {
                contentId = x.ContentId,
                url = x.Url,
                title = x.Title
            }));
        }

        public IActionResult Add(int pageType, string lang, int parentContentId)
        {
            var model = new Page()
            {
                PageTypeId = pageType,
                Lang = lang,
                ParentContentId = parentContentId,
                ShowInMenu = true,
                StateID = GlobalConstants.PageStates.Published
            };
            SetViewBag(model);
            return View("Edit", model);
        }

        public IActionResult AddTranslation(string lang, int id)
        {
            var saved = pageService.GetByID(id);
            var model = new Page()
            {
                PageTypeId = saved.PageTypeId,
                Lang = lang,
                ParentContentId = saved.ParentContentId,
                ContentId = saved.ContentId,
                ShowInMenu = saved.ShowInMenu,
                ClassName = saved.ClassName,
                StateID = saved.StateID
            };
            ViewBag.actionName = "Add";
            SetViewBag(model);
            return View("Edit", model);
        }

        [RequestSizeLimit(52428800)]//50MB
        [HttpPost]
        public IActionResult Add(Page model)
        {
            if (ModelState.IsValid)
            {
                if (pageService.AddPage(model))
                {
                    return RedirectToAction("Index", new { pageType = model.PageTypeId, lang = model.Lang });
                }
            }
            SetViewBag(model);
            return View("Edit", model);
        }
        public IActionResult Edit(int id)
        {
            var model = pageService.GetByID(id);
            ViewBag.translations = pageService.GetTranslations(model.ContentId);

            SetViewBag(model);
            return View("Edit", model);
        }
        [RequestSizeLimit(52428800)]//50MB
        [HttpPost]
        public IActionResult Edit(Page model)
        {
            if (ModelState.IsValid)
            {
                if (pageService.UpdatePage(model))
                {
                    return RedirectToAction("Index", new { pageType = model.PageTypeId, lang = model.Lang });
                }
            }
            ViewBag.translations = pageService.GetTranslations(model.ContentId);
            SetViewBag(model);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult ChangeParent(int id, int newParent)
        {
            if (pageService.ChangeParent(id, newParent))
            {
                return Content("ok");
            }
            else
            {
                return Content("failed");
            }
        }
        [HttpPost]
        public IActionResult ChangeOrder(int id, int position_delta)
        {
            for (int i = 0; i < Math.Abs(position_delta); i++)
            {
                pageService.ChangeOrder(id, position_delta > 0);
            }
            return Content("ok");
        }

        private void SetViewBag(Page model)
        {
            ViewBag.pageType = pageService.GetPageType(model.PageTypeId);
        }

        public JsonResult GetTagList(int pageId)
        {
            var page = pageService.GetByID(pageId);
            IEnumerable<SelectListItem> model = null;
            if (string.IsNullOrEmpty(page.Content))
            {
                model = new List<SelectListItem>();

            }
            else
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page.Content);
                var spanList = doc.DocumentNode.Descendants("span");
                model = spanList.Where(x => x.HasClass("page-tag"))
                            .Select(x => x.Attr("id"))
                            .Select(x => new SelectListItem
                            {
                                Text = x,
                                Value = x
                            }).ToList();
            }
            var allText = "Няма зададени отметки";
            if (model.Count() > 0)
            {
                allText = "Изберете отметка";
            }
            return Json(model.AddAllItem(allText));
        }


        public IActionResult DeletePageItem(int pageId, bool allTranslations)
        {
            var page = pageService.GetByID(pageId);
            pageService.DeletePage(pageId, allTranslations);
            return RedirectToAction(nameof(Index), new { pageType = page.PageTypeId, lang = page.Lang });
        }
    }
}