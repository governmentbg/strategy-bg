using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    public class StrategicDocumentsWidgetViewComponent : ViewComponent
    {
        private readonly IStrategicDocumentsService service;

        public StrategicDocumentsWidgetViewComponent(IStrategicDocumentsService _consultationService)
        {
            service = _consultationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int loadCount)
        {
            var model = await service.Portal_List().Skip(0).Take(loadCount).ToListAsync();

            return View(model);
        }
    }
}
