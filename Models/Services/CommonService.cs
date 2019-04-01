using FileCDN.Models.Data;
using Models.Context;
using Models.Contracts;
using Models.ViewModels;
using Models.ViewModels.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebCommon.Services;

namespace Models.Services
{
    public class CommonService : BaseService, ICommonService
    {
        private readonly IUserContext userContext;
        public CommonService(MainContext _db, IUserContext _userContext)
        {
            db = _db;
            userContext = _userContext;
        }

        public bool FileCdn_AppendUsedFile(string fileId, int sourceType, int sourceId)
        {
            var model = new FilesCDNUsed()
            {
                cdn_file_id = fileId,
                source_type = sourceType,
                source_id = sourceId
            };
            db.FilesCDNUsed.Add(model);
            db.SaveChanges();
            model.order_by = model.id;
            db.FilesCDNUsed.Update(model);
            db.SaveChanges();
            return true;
        }

        public IQueryable<DocumentLinkVM> FileCdn_GetList(int sourceType, int sourceId)
        {
            return (from uf in All<FilesCDNUsed>()
                    join f in All<FileCdn>() on uf.cdn_file_id equals f.Id
                    where uf.source_type == sourceType && uf.source_id == sourceId
                    orderby uf.order_by, uf.id
                    select new DocumentLinkVM
                    {
                        DocumentId = uf.id,
                        FileName = f.FileName,
                        FileTitle = f.FileTitle,
                        FileId = f.Id,
                        SourceType = f.SourceType,
                        IsReportVisible = f.IsReportVisible,
                        DateExparing = f.DateExparing
                    }).AsQueryable();
        }

        public bool FileCdn_MoveUsedFile(int usedFileId, bool moveUp, int sourceType, int sourceId)
        {
            var currentFile = db.FilesCDNUsed.Find(usedFileId);


            var nextFile = db.FilesCDNUsed
                                .Where(x => x.source_type == sourceType && x.source_id == sourceId)
                                .Where(x => x.order_by > currentFile.order_by)
                                .OrderBy(x => x.order_by)
                                .FirstOrDefault();
            if (moveUp)
            {
                nextFile = db.FilesCDNUsed
                                .Where(x => x.source_type == sourceType && x.source_id == sourceId)
                                .Where(x => x.order_by < currentFile.order_by)
                                .OrderByDescending(x => x.order_by)
                                .FirstOrDefault();
            }

            if (nextFile != null)
            {
                int currentOrder = currentFile.order_by;
                currentFile.order_by = nextFile.order_by;
                nextFile.order_by = currentOrder;
                db.FilesCDNUsed.Update(currentFile);
                db.FilesCDNUsed.Update(nextFile);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool FileCdn_RemoveUsedFile(string fileId, int sourceType, int sourceId)
        {
            DeleteRange<FilesCDNUsed>(x => x.cdn_file_id == fileId && x.source_type == sourceType && x.source_id == sourceId);
            db.SaveChanges();
            return true;
        }

        public bool FileCdn_RenameUsedFile(string fileId, string fileTitle)
        {
            var file = All<FileCdn>().FirstOrDefault(x => x.Id == fileId);
            file.FileTitle = fileTitle;
            db.FileCdn.Update(file);
            db.SaveChanges();
            return true;
        }

        public bool GenericContent_SaveData(GenericContent model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.SavedAlias))
                {
                    var saved = Find<GenericContent>(model.SavedAlias);

                    saved.Alias = model.Alias;
                    saved.Title = model.Title;
                    saved.Text = model.Text;
                    saved.Remark = model.Remark;
                    saved.IsActive = model.IsActive;
                    saved.ModifiedByUserId = userContext.UserId;
                    saved.DateModified = DateTime.Now;

                    All<GenericContent>().Update(saved);
                    db.SaveChanges();
                }
                else
                {

                    model.CreatedByUserId = userContext.UserId;
                    model.DateCreated = DateTime.Now;

                    model.ModifiedByUserId = userContext.UserId;
                    model.DateModified = model.DateCreated;

                    All<GenericContent>().Add(model);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IQueryable<GenericContentVM> GenericContent_Select()
        {
            return All<GenericContent>()
                         .Select(x => new GenericContentVM
                         {
                             Alias = x.Alias,
                             Title = x.Title,
                             Remark = x.Remark
                         }).AsQueryable();
        }
    }
}
