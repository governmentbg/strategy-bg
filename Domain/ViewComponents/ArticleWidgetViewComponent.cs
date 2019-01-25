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
    public class ArticleWidgetViewComponent : ViewComponent
    {
        private readonly INewsService newsService;
        private readonly IPublicationService publicationService;

        public ArticleWidgetViewComponent(INewsService _newsService, IPublicationService _publicationService)
        {
            newsService = _newsService;
            publicationService = _publicationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string view,
        int loadCount)
        {
            IEnumerable<ArticleListVM> model = null;
            switch (view.ToLower())
            {
                case "news":
                    model = await newsService.News_Select(null, null).Skip(0).Take(loadCount).ToListAsync();
                    break;
                case "publication":
                    model = await publicationService.Publication_Select(null, null).Skip(0).Take(loadCount).ToListAsync();
                    break;
            }

            return View(view, model);
        }
    }
}
