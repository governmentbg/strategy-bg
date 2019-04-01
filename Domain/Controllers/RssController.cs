using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Categories;
using Models.ViewModels.Portal;
using WebCommon.Extensions;
using WilderMinds.RssSyndication;

namespace Domain.Controllers
{
    public class RssController : BasePortalController
    {
        private readonly IConsultationService consultationService;
        private readonly INomenclatureService nomService;
        private readonly IStrategicDocumentsService strategicDocumentsService;
        private readonly IPublicationService publicationService;
        private readonly INewsService newsService;
        private readonly IConfiguration config;
        private readonly IUrlHelper urlHelper;

        public RssController(IConsultationService _consultationService,
            INomenclatureService _nomService,
            IStrategicDocumentsService _strategicDocumentsService,
            IPublicationService _publicationService,
            INewsService _newsService,
            IConfiguration _config,
            IUrlHelper _urlHelper)
        {
            consultationService = _consultationService;
            nomService = _nomService;
            strategicDocumentsService = _strategicDocumentsService;
            publicationService = _publicationService;
            newsService = _newsService;
            config = _config;
            urlHelper = _urlHelper;
        }

        [AllowAnonymous]
        public IActionResult GetDocumentFeed(RssFeedType type, int categoryMasterId, int? categoryId, int? municipalityId, int? validState)
        {
            var feed = GetFeed(type);
            int limit = config.GetValue<int>($"RssFeedsSettings:{(int)type}:Limit");
            var options = new SerializeOption()
            {
                Encoding = Encoding.UTF8
            };

            switch (type)
            {
                case RssFeedType.PublicConsultations:
                    var data = consultationService.Portal_List(this.Lang, validState.EmptyToNull());
                    var url = urlHelper.Action("View", "PublicConsultation", null, "https", "strategy.bg");
                    feed.Items = GetDocumentItems(categoryMasterId, categoryId, municipalityId, validState, limit, data, url);

                    break;
                case RssFeedType.StrategicDocuments:
                    var sdData = strategicDocumentsService.Portal_List(this.Lang, validState.EmptyToNull());
                    var sdUrl = urlHelper.Action("View", "StrategicDocument", null, "https", "strategy.bg");
                    feed.Items = GetDocumentItems(categoryMasterId, categoryId, municipalityId, validState, limit, sdData, sdUrl);

                    break;
                case RssFeedType.Publications:
                case RssFeedType.News:
                    return GetNewsFeed(type);
                default:
                    return BadRequest();
            }

            return new ContentResult
            {
                ContentType = "application/rss+xml",
                Content = feed.Serialize(options),
                StatusCode = 200
            };
        }

        private ICollection<Item> GetDocumentItems(int categoryMasterId, int? categoryId, int? municipalityId, int? validState, int limit, IEnumerable<ICategorySearchableItem> data, string url)
        {
            ICollection<Item> items = new List<Item>();   
            var filteredData = nomService.FilterByCategories(data, categoryMasterId, categoryId, municipalityId);
            filteredData = filteredData
                .Take(limit > 0 ? limit : filteredData.Count());

            foreach (IRssItem item in filteredData)
            {
                items.Add(new Item()
                {
                    Author = new Author() { Name = "strategy.bg" },
                    Title = item.Title,
                    Link = new Uri($"{url}/{item.Id}"),
                    Categories = new List<string>() { item.Category },
                    Comments = new Uri($"{url}/{item.Id}"),
                    PublishDate = item.PublishDate
                });
            }

            return items;
        }

        [AllowAnonymous]
        public IActionResult GetNewsFeed(RssFeedType type)
        {
            var feed = GetFeed(type);
            int limit = config.GetValue<int>($"RssFeedsSettings:{(int)type}:Limit");
            IQueryable<ArticleListVM> data = null;
            string url = String.Empty;
            var options = new SerializeOption()
            {
                Encoding = Encoding.UTF8
            };

            switch (type)
            {
                case RssFeedType.Publications:
                    data = publicationService.Publication_Select(null, null, Lang);
                    url = urlHelper.Action("View", "Publication", null, "https", "strategy.bg");

                    break;
                case RssFeedType.News:
                    data = newsService.News_Select(null, null, Lang);
                    url = urlHelper.Action("View", "News", null, "https", "strategy.bg");

                    break;
                default:
                    return BadRequest();
            }

            data = data.Take(limit > 0 ? limit : data.Count());
            feed.Items = GetNewsItems(data, url);

            return new ContentResult
            {
                ContentType = "application/rss+xml",
                Content = feed.Serialize(options),
                StatusCode = 200
            };
        }

        private ICollection<Item> GetNewsItems(IQueryable<ArticleListVM> data, string url)
        {
            ICollection<Item> items = new List<Item>();

            foreach (IRssItem item in data)
            {
                items.Add(new Item()
                {
                    Author = new Author() { Name = "strategy.bg" },
                    Title = item.Title,
                    Link = new Uri($"{url}/{item.Id}"),
                    Categories = new List<string>() { item.Category },
                    Comments = new Uri($"{url}/{item.Id}"),
                    PublishDate = item.PublishDate
                });
            }

            return items;
        }

        private Feed GetFeed(RssFeedType type)
        {
            return new Feed()
            {
                Title = config.GetValue<string>($"RssFeedsSettings:{(int)type}:Title"),
                Description = config.GetValue<string>($"RssFeedsSettings:{(int)type}:Description"),
                Link = new Uri(config.GetValue<string>($"RssFeedsSettings:{(int)type}:Link")),
                Copyright = $"Copyright {DateTime.Now.Year} strategy.bg",
                Items = new List<Item>()
            };
        }
    }
}