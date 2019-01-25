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
    public class PublicConsultationWidgetViewComponent : ViewComponent
    {
        private readonly IConsultationService consultationService;

        public PublicConsultationWidgetViewComponent(IConsultationService _consultationService)
        {
            consultationService = _consultationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int loadCount)
        {
            var model = await consultationService.Portal_List().Skip(0).Take(loadCount).ToListAsync();

            return View(model);
        }
    }
}
