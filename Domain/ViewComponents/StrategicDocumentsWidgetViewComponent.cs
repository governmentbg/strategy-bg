using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    public class StrategicDocumentsWidgetViewComponent : BaseLangViewComponent
    {
        private readonly IStrategicDocumentsService service;

        public StrategicDocumentsWidgetViewComponent(IStrategicDocumentsService _consultationService)
        {
            service = _consultationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int loadCount)
        {
            var model = await service.Portal_List(this.Lang).Skip(0).Take(loadCount).ToListAsync();

            return View(model);
        }
    }
}
