using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    public class MasterPageViewComponent : BaseLangViewComponent
    {
        private readonly IPageService service;

        public MasterPageViewComponent(IPageService _service)
        {
            service = _service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int pageTypeId, string display = "list", string title = "")
        {
            var model = await service.Select(pageTypeId, this.GetCurrentLang, -1, true)
                .Where(x => x.ShowInMenu == true && x.StateID == GlobalConstants.PageStates.Published).ToListAsync();

            switch (display)
            {
                case "menu":
                    ViewBag.menuTitle = title; 
                    return View("Menu", model);
                default:
                    return View(model);
            }

        }
    }
}
