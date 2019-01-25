using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.Context;
using Models.ViewModels.Plugins;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{
    /// <summary>
    /// Управление на библиотеки от файлове
    /// </summary>
    [Area(nameof(Areas.Admin))]
    [Authorize]
    public class LibraryController : BaseController
    {
        private readonly ILibraryService libService;
        public LibraryController(ILibraryService _libService)
        {
            libService = _libService;
        }
        public IActionResult Index(int source_type)
        {
            ViewBag.source_type = source_type;
            return View();
        }
        public IActionResult Select(int source_type)
        {
            ViewBag.source_type = source_type;
            return PartialView();
        }

        public JsonResult GetTreeViewData(int source_type, bool selectOnly = false)
        {
            var model = libService
                            .Select(source_type, null, null)
                            .Select(item => new TreeViewDataVM
                            {
                                id = item.Id.ToString(),
                                text = item.Title,
                                parent = (item.ParentId == -1) ? "#" : item.ParentId.ToString(),
                                // icon = "fa fa-image",
                                li_attr = new { lid = item.Id },
                                a_attr = new
                                {
                                    update = Url.Action("Edit", new { id = item.Id }),
                                    sub = Url.Action("Add", new { source_type = item.SourceType, parent_id = item.Id })
                                }
                            }).ToList();
            if (!selectOnly)
            {
                model.Add(new TreeViewDataVM()
                {
                    id = "new",
                    text = "Добави папка",
                    parent = "#",
                    icon = "fa fa-plus",
                    a_attr = new
                    {
                        href = Url.Action("Add", new { source_type, parent_id = -1 })
                    }

                });
            }
            return Json(model);
        }

        public IActionResult Add(int source_type, int parent_id)
        {
            var model = new Library()
            {
                SourceType = source_type,
                ParentId = parent_id,
                IsActive = true

            };

            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Add(Library model)
        {
            if (ModelState.IsValid)
            {
                if (libService.Save(model))
                {
                    return RedirectToAction("Index", new { source_type = model.SourceType, parent_id = model.ParentId });
                }
            }

            return View("Edit", model);
        }
        public IActionResult Edit(int id)
        {
            var model = libService.GetByID(id);

            return View("Edit", model);
        }
        [HttpPost]
        public IActionResult Edit(Library model)
        {
            if (ModelState.IsValid)
            {
                if (libService.Save(model))
                {
                    return RedirectToAction("Index", new { source_type = model.SourceType, parent_id = model.ParentId });
                }
            }
            return View("Edit", model);
        }

       
        
    }
}