using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;
using Models.ViewModels.Portal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    public class PublicConsultationWidgetViewComponent : BaseLangViewComponent
    {
        private readonly IConsultationService consultationService;

        public PublicConsultationWidgetViewComponent(IConsultationService _consultationService)
        {
            consultationService = _consultationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int loadCount, string type)
        {
            var data = consultationService.Portal_List(this.Lang);
            IEnumerable<PublicConsultationVM> model = null;
            switch (type)
            {
                case "comment":
                    model = await data.OrderByDescending(x => x.CommentsCount).Skip(0).Take(loadCount).ToListAsync();
                    break;
                default:
                    model = await data.OrderByDescending(x => x.OpenningDate).Skip(0).Take(loadCount).ToListAsync();
                    break;
            }

            ViewBag.pcWidgetSortType = type;
            return View(model);
        }
    }
}
