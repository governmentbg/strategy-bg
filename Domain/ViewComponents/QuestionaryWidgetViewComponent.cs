using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Portal;
using Models.ViewModels.Questionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewComponents
{
    public class QuestionaryWidgetViewComponent : BaseLangViewComponent
    {
        private readonly IQuestionaryService service;

        public QuestionaryWidgetViewComponent(IQuestionaryService _service)
        {
            service = _service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            DateTime lastDate = new DateTime(2100, 1, 1);
            QuestionaryListViewModel model = await service.GetQuestionaries(null)
                        .Where(x => x.OpenningDate.Date <= DateTime.Now.Date && (x.ClosingDate ?? lastDate) >= DateTime.Now.Date)
                        .Where(x => x.SourceType == null)
                        .OrderByDescending(x => x.OpenningDate)
                        .FirstOrDefaultAsync();
            //TODO!!!!!!!!!!!!!!!!!
            if (this.Lang != GlobalConstants.LangBG)
            {
                model = null;
            }
            //TODO!!!!!!!!!!!!!!!!!
            return View(model);
        }
    }
}
