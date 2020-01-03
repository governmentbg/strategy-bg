using Microsoft.Extensions.Logging;
using Models.Context;
using Models.Context.Legacy;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Linq;
using WebCommon.Services;

namespace Models.Services
{
    public class BannersService : BaseService, IBannersService
    {
        private readonly ILogger logger;
        private readonly IUserContext userContext;

        public BannersService(
            MainContext context
            , ILogger<BannersService> _logger
            , IUserContext _userContext)
        {
            this.db = context;
            logger = _logger;
            userContext = _userContext;
        }

        public IQueryable<BannersListVM> GetBannersList(int active = -1, int lang = GlobalConstants.LangBG)
        {
            return (from d in All<Banners>()
                .Where(x => x.LanguageId == lang && (x.IsActive == ((active == -1) ? x.IsActive : (active == 1 ? true : false))))

                    join f in db.FilesCDNUsed.Where(fu => fu.source_type == GlobalConstants.SourceTypes.BannerImage)
                    on d.Id equals f.source_id into n_f
                    from x in n_f.DefaultIfEmpty()
                    select new BannersListVM()
                    {
                        Id = d.Id,
                        Label = d.BannerName,
                        Link = d.Link,
                        IsActive = d.IsActive,
                        IsDeleted = d.IsDeleted,
                        IsApproved = d.IsApproved,
                        DateCreated = d.DateCreated,
                        BannerType = d.BannerType,
                        MainImageFileId = (x != null) ? x.cdn_file_id : null
                    }).AsQueryable();
        }

        public BannersVM GetItem(int id)
        {
            return All<Banners>()
                .Where(d => d.Id == id)
                .Select(d => new BannersVM()
                {
                    Id = d.Id,
                    Label = d.BannerName,
                    IsActive = d.IsActive,
                    IsApproved = d.IsApproved,
                    IsDeleted = d.IsDeleted,
                    LanguageId = d.LanguageId,
                    Link = d.Link,
                    BannerType = d.BannerType ?? ""
                })
                .FirstOrDefault();
        }

        public bool SaveItem(BannersVM model)
        {
            var result = false;
            Banners entity = null;

            try
            {
                if (model.Id > 0)
                {
                    entity = All<Banners>().Find(model.Id);

                    if (entity != null)
                    {
                        entity.IsActive = model.IsActive;
                        entity.BannerName = model.Label;
                        entity.ModifiedByUserId = userContext.UserId;
                        entity.DateModified = DateTime.Now;
                        entity.IsDeleted = model.IsDeleted;
                        entity.IsApproved = model.IsApproved;
                        entity.Link = model.Link;
                        entity.BannerType = model.BannerType ?? "";
                    }
                }
                else
                {
                    entity = new Banners()
                    {
                        IsActive = model.IsActive,
                        BannerName = model.Label,
                        CreatedByUserId = userContext.UserId,
                        ModifiedByUserId = userContext.UserId,
                        DateModified = DateTime.Now,
                        DateCreated = DateTime.Now,
                        IsApproved = true,
                        LanguageId = model.LanguageId,
                        IsDeleted = model.IsDeleted,
                        Link = model.Link,
                        BannerType = model.BannerType ?? "",
                        ImagePath = ""
                    };

                    db.Banners.Add(entity);
                }

                if (entity != null)
                {
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Bannerss->SaveItem");
            }

            return result;
        }
    }
}
