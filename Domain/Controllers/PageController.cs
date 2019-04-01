using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using WebCommon.Models;

namespace Domain.Controllers
{
  public class PageController : BasePortalController
  {
    private readonly IPageService pageService;
    public PageController(IPageService _pageService)
    {
      pageService = _pageService;
    }

    public IActionResult PreviewByUrl(int pageType, string url)
    {
      var contentId = pageService.GetContentIdByUrl(pageType, url);
      return RedirectToAction(nameof(Preview), new { id = contentId, url });
    }

    public IActionResult Preview(int id, string url = null)
    {
      var model = pageService.GetByContentID(this.GetCurrentLang, id);
      if (model == null)
      {
        return RedirectToAction("Index");
      }
      model.Content = ResolvePageId(model.Content);
      foreach (var item in model.PageLinks)
      {
        item.Href = ResolvePageUrl(item.Href);
      }
      ViewBag.breadcrumbs = pageService.SelectParentPages(this.GetCurrentLang, id)
                                  .Where(x => x.ShowInMenu == true && x.StateID == GlobalConstants.PageStates.Published)
                                  .ToList()
                                  .Select(x => new BreadcrumbVM
                                  {
                                    Url = Url.Action(nameof(Preview), new { id = x.ContentId, url = x.Url }),
                                    Title = x.Title
                                  });
      ViewBag.httpScheme = HttpContext.Request.Scheme;
      return View(model);
    }

    protected string ResolvePageId(string html)
    {
      if (string.IsNullOrEmpty(html))
      {
        return html;
      }
      HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
      doc.LoadHtml(html);
      var anchorList = doc.DocumentNode.Descendants("a");
      foreach (var node in anchorList)
      {
        var pageHref = node.Attr("href");
        if (string.IsNullOrEmpty(pageHref))
        {
          continue;
        }
        node.SetAttributeValue("href", ResolvePageUrl(pageHref));
        //модалните линкове се кодират като #modal-123#ch13
        //#modal- константа
        //123 ContentId
        //ch13 Tag
        if (pageHref.StartsWith("#modal-"))
        {
          var href = pageHref.Replace("#modal-", "");
          int diesIndex = href.IndexOf('#');
          var tag = href.Substring(diesIndex + 1);
          if (diesIndex == -1)
          {
            diesIndex = href.Length;
            tag = null;
          }
          var contentId = href.Substring(0, diesIndex);

          node.SetAttributeValue("href", "#");
          node.SetAttributeValue("data-modal", "true");
          node.SetAttributeValue("data-contentId", contentId);
          if (!string.IsNullOrEmpty(tag))
          {
            node.SetAttributeValue("data-tag", tag);
          }
        }
      }
      var areaList = doc.DocumentNode.Descendants("area");
      foreach (var node in areaList)
      {
        var pageHref = node.Attr("href");
        if (string.IsNullOrEmpty(pageHref))
        {
          continue;
        }
        node.SetAttributeValue("href", ResolvePageUrl(pageHref));
      }
      var pageTags = doc.DocumentNode.Descendants("span");
      foreach (var item in pageTags)
      {
        if (item.Attributes.Any(x => x.Name == "class" && x.Value == "page-tag"))
        {
          item.RemoveAllChildren();
          for (var i = 0; i < item.Attributes.Count; i++)
          {
            var attr = item.Attributes[i];
            if (attr.Name != "id")
            {
              attr.Remove();
            }
          }
        }
      }
      return doc.DocumentNode.InnerHtml;
    }

    protected string ResolvePageUrl(string pageHref)
    {
      if (string.IsNullOrEmpty(pageHref))
      {
        return pageHref;
      }
      if (pageHref.StartsWith("#page-"))
      {
        var href = pageHref.Replace("#page-", "");
        var contentId = href.Substring(0, href.IndexOf('-'));

        try
        {
          var page = pageService.GetByContentID(this.GetCurrentLang, int.Parse(contentId));
          if (page.SpecialPage)
          {
            return Url.Action(page.Action, page.Controller);
          }
        }
        catch { }


        //Тук се включва и page-Tag-а '#ch3' например
        var url = href.Substring(href.IndexOf('-') + 1);
        return Url.Action("Preview", "Page", new { id = contentId, url = url }).Replace("%23", "#");
      }

      if (pageHref.StartsWith("#file-"))
      {
        var fileId = pageHref.Replace("#file-", "");
        return Url.Action("DownloadFile", "FileCdn", new { id = fileId });
      }
      return pageHref;
    }
  }
}