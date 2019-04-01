using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Portal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    public class BannerWidgetViewComponent : BaseLangViewComponent
    {
        private readonly IBannersService bannerService;

        public BannerWidgetViewComponent(IBannersService _bannerService)
        {
            bannerService = _bannerService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string bannerType)
        {
            IEnumerable<BannersListVM> model = await bannerService.GetBannersList(1, this.Lang)
                .Where(x => x.BannerType == bannerType)
                .ToListAsync();

            return View(model);
        }
    }
}
