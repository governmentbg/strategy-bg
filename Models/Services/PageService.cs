using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;

namespace Models.Services
{
    public class PageService : IPageService
    {
        private readonly MainContext db;
        public PageService(MainContext _db)
        {
            db = _db;
        }


        public IQueryable<PageVM> Select(int pageType, string lang, int? parentContentId, bool loadContent = false)
        {
            var result = db.Pages
                .Where(x =>
                    x.PageTypeId == pageType &&
                    x.ParentContentId == (parentContentId ?? x.ParentContentId) &&
                    x.Lang == lang)
                .OrderBy(x => x.OrderBy);

            if (loadContent)
            {
                return result.Select(x => new PageVM
                {
                    Id = x.Id,
                    Lang = x.Lang,
                    ParentContentId = x.ParentContentId,
                    ContentId = x.ContentId,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    Controller = x.Controller,
                    Action = x.Action,
                    Content = x.Content,
                    Url = x.Url,
                    ClassName = x.ClassName,
                    ShowInMenu = x.ShowInMenu,
                    OrderBy = x.OrderBy,
                    StateID = x.StateID
                })
                .AsQueryable();
            }
            else
            {
                return result.Select(x => new PageVM
                {
                    Id = x.Id,
                    Lang = x.Lang,
                    ParentContentId = x.ParentContentId,
                    ContentId = x.ContentId,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    Controller = x.Controller,
                    Action = x.Action,
                    Url = x.Url,
                    ClassName = x.ClassName,
                    ShowInMenu = x.ShowInMenu,
                    OrderBy = x.OrderBy,
                    StateID = x.StateID

                })
                .AsQueryable();
            }
        }


        public IQueryable<TranslationVM> SelectTranslations(int pageType)
        {
            return db.Pages.Where(x => x.PageTypeId == pageType)
                .Select(x => new TranslationVM
                {
                    PageId = x.Id,
                    ContentId = x.ContentId,
                    Lang = x.Lang
                }).ToList().AsQueryable();
        }


        public bool AddPage(Page model)
        {
            try
            {
                model.DatePublished = DateTime.Now;

                if (model.ContentId > 0)
                {
                    //Запис на превод
                    model.DateCreated = DateTime.Now;
                    model.OrderBy = model.ContentId;
                    db.Pages.Add(model);
                    db.SaveChanges();
                }
                else
                {
                    model.ContentId = 0;
                    model.DateCreated = DateTime.Now;

                    db.Pages.Add(model);
                    db.SaveChanges();

                    model.ContentId = model.Id;
                    model.OrderBy = model.Id;
                    db.Pages.Update(model);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdatePage(Page model)
        {
            try
            {
                var saved = db.Pages.AsNoTracking().FirstOrDefault(x => x.Id == model.Id);

                model.DateCreated = saved.DateCreated;
                model.DatePublished = DateTime.Now;
                db.Pages.Update(model);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Page GetByContentID(string lang, int content_id)
        {
            return db.Pages
                        .Include(x => x.PageLinks)
                        .Where(x => x.Lang == lang && x.ContentId == content_id)
                        .FirstOrDefault();
        }

        public Page GetByID(int id)
        {
            return db.Pages.Where(x => x.Id == id).FirstOrDefault();

        }

        public IEnumerable<TranslationVM> GetTranslations(int content_id)
        {
            return (from l in GlobalConstants.SelectLangs()
                    join p in db.Pages.Where(x => x.ContentId == content_id) on l.Lang equals p.Lang into translations
                    from t in translations.DefaultIfEmpty()
                    select new TranslationVM
                    {
                        PageId = (t != null) ? t.Id : 0,
                        Lang = l.Lang,
                        ContentId = content_id,
                        LangName = l.Title
                    }).ToList();
        }

        public Page GetForTranslate(int id)
        {
            var model = db.Pages.AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            model.Id = 0;

            return model;
        }

        public PageType GetPageType(int id)
        {
            return db.PageTypes.Find(id);
        }

        public bool ChangeParent(int id, int newParent)
        {
            var page = db.Pages.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (page != null)
            {
                var newParentContentId = -1;
                if (newParent > 0)
                {
                    newParentContentId = db.Pages.AsNoTracking().FirstOrDefault(x => x.Id == newParent).ContentId;
                }
                var pages = db.Pages.Where(x => x.ContentId == page.ContentId);
                foreach (var item in pages)
                {
                    item.ParentContentId = newParentContentId;
                    db.Pages.Update(item);
                }
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeOrder(int id, bool moveDown)
        {
            var page = db.Pages.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (page != null)
            {

                Page nextPage = null;
                nextPage = db.Pages.AsNoTracking()
                    .Where(x =>
                        x.ParentContentId == page.ParentContentId)
                    .Where(x => x.OrderBy > page.OrderBy)
                    .OrderBy(x => x.OrderBy)
                    .FirstOrDefault();

                if (!moveDown)
                {
                    //преместване нагоре
                    nextPage = db.Pages.AsNoTracking()
                        .Where(x =>
                            x.ParentContentId == page.ParentContentId)
                        .Where(x => x.OrderBy < page.OrderBy)
                        .OrderByDescending(x => x.OrderBy)
                        .FirstOrDefault();
                }

                var tmpOrder = page.OrderBy;
                var oldPages = db.Pages.Where(x => x.ContentId == page.ContentId);
                var nextPages = db.Pages.Where(x => x.ContentId == nextPage.ContentId);
                foreach (var item in oldPages)
                {
                    item.OrderBy = nextPage.OrderBy;
                    db.Pages.Update(item);
                }
                foreach (var item in nextPages)
                {
                    item.OrderBy = tmpOrder;
                    db.Pages.Update(item);
                }

                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public IQueryable<PageVM> SelectPeerPages(int pageId)
        {
            List<PageVM> result = new List<PageVM>();

            var currentPage = db.Pages.Find(pageId);



            return result.AsQueryable();
        }

        public IQueryable<PageVM> SelectParentPages(string lang, int content_id)
        {
            List<PageVM> result = new List<PageVM>();

            var currentPage = db.Pages.FirstOrDefault(x => x.Lang == lang && x.ContentId == content_id);

            var parentId = currentPage.ParentContentId;
            while (parentId > 0)
            {
                currentPage = db.Pages.FirstOrDefault(x => x.Lang == lang && x.ContentId == parentId);
                if (currentPage != null)
                {
                    result.Insert(0, new PageVM()
                    {
                        Id = currentPage.Id,
                        ParentContentId = currentPage.ParentContentId,
                        ContentId = currentPage.ContentId,
                        Title = currentPage.Title,
                        StateID = currentPage.StateID,
                        ShowInMenu = currentPage.ShowInMenu
                    });

                    parentId = currentPage.ParentContentId;
                }
            }


            return result.AsQueryable();
        }

        public IQueryable<SearchItemVM> SearchItems(string lang, string term)
        {
            List<SearchItemVM> result = new List<SearchItemVM>();

            //Търсене по заглавие на страница
            var pageByTitleandContent = db.Pages.Where(x => x.Lang == lang && x.Title.Contains(term))
                            .Select(x => new SearchItemVM
                            {
                                ItemType = GlobalConstants.SearchItemType.PageItem,
                                Url = x.Url,
                                Id = x.ContentId,
                                Title = x.Title,
                                LastEdited = x.DatePublished
                            }).Union(
                                db.Pages.Where(x => x.Lang == lang && x.Content.Contains(term))
                                            .Select(x => new SearchItemVM
                                            {
                                                ItemType = GlobalConstants.SearchItemType.PageItem,
                                                Url = x.Url,
                                                Id = x.ContentId,
                                                Title = x.Title,
                                                LastEdited = x.DatePublished
                                            })
                            ).Distinct();

            var docsByTitle = db.FileCdn.Where(x => x.SourceType == GlobalConstants.SourceTypes.Library_Documents && x.IsActive
                                        && x.FileTitle.Contains(term))
                                        .Select(x => new SearchItemVM
                                        {
                                            ItemType = GlobalConstants.SearchItemType.DocItem,
                                            Url = x.Id,
                                            Title = x.FileTitle,
                                            LastEdited = x.DateUploaded
                                        });

            return pageByTitleandContent.Union(docsByTitle).OrderByDescending(x => x.LastEdited).AsQueryable();
        }

        public bool DeletePage(int pageId, bool deleteAllTranslation)
        {
            try
            {
                if (deleteAllTranslation)
                {
                    var page = db.Pages.Where(x => x.Id == pageId).AsNoTracking().FirstOrDefault();
                    var pagesForDelete = db.Pages.Where(x => x.ContentId == page.ContentId);
                    db.Pages.RemoveRange(pagesForDelete);
                }
                else
                {
                    var page = db.Pages.Where(x => x.Id == pageId).FirstOrDefault();
                    db.Pages.Remove(page);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SavePageLink(PageLink model)
        {
            if (model.Id > 0)
            {
                //var saved = db.PageLinks.Find(model.Id);
                db.PageLinks.Update(model);
                db.SaveChanges();
            }
            else
            {
                db.PageLinks.Add(model);
                db.SaveChanges();
                model.OrderBy = model.Id;
                db.PageLinks.Update(model);
                db.SaveChanges();
            }
            return true;
        }

        public IQueryable<PageLink> SelectPageLink(int pageId)
        {
            return db.PageLinks.Where(x => x.PageId == pageId).OrderBy(x => x.OrderBy).AsQueryable();
        }

        public T Find<T>(object id) where T : class
        {
            return db.Set<T>().Find(id);
        }

        public bool DeletePageLink(int id)
        {
            db.PageLinks.Remove(Find<PageLink>(id));
            db.SaveChanges();
            return true;
        }

        public bool SavePageLinkFromSelectedPage(int pageId, int contentId, string lang)
        {
            var pageTypeId = GetPageType(pageId, null);
            var subPages = Select(pageTypeId, lang, contentId).ToList();
            if (subPages.Any())
            {
                foreach (var item in subPages)
                {
                    var newLink = new PageLink()
                    {
                        PageId = pageId,
                        Title = item.Title,
                        Href = string.Format("#page-{0}-{1}", item.ContentId, item.Url)
                    };
                    db.PageLinks.Add(newLink);
                    db.SaveChanges();
                    newLink.OrderBy = newLink.Id;
                    db.PageLinks.Update(newLink);
                    db.SaveChanges();
                }

            }
            return true;
        }

        public int GetPageType(int? pageId, int? contentId)
        {
            return db.Pages.Where(x => x.Id == (pageId ?? x.Id) && x.ContentId == (contentId ?? x.ContentId))
                .FirstOrDefault()
                ?.PageTypeId ?? GlobalConstants.PageTypes.OV;
        }

        public int GetContentIdByUrl(int pageType, string url)
        {
            return db.Pages.Where(x => x.PageTypeId == pageType && x.Url == url)
                            .FirstOrDefault()
                            ?.ContentId ?? 0;
        }
    }
}
