using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Contracts;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    public class MasterPageViewComponent : ViewComponent
    {
        private readonly IPageService service;

        public MasterPageViewComponent(IPageService _service)
        {
            service = _service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int pageTypeId)
        {
            var model = await service.Select(pageTypeId, GlobalConstants.DefaultLang, -1, true)
                .Where(x => x.ShowInMenu == true && x.StateID == GlobalConstants.PageStates.Published).ToListAsync();

            return View(model);
        }
    }
}
