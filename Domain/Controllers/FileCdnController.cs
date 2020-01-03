using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileCDN.Models;
using FileCDN.Models.Service;
using ImageProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCommmon.Controllers;
using Models;
using Models.Context;
using Models.ViewModels;
using WebCommon.Extensions;
using Microsoft.Extensions.Logging;
using Models.Contracts;

namespace Domain.Controllers
{
    /// <summary>
    /// Управление на файлове
    /// </summary>
    public class FileCdnController : BaseController
    {
        private readonly ICdnService<MainContext> cdnService;
        private readonly IImageService imgService;
        private readonly ILibraryService libService;
        private readonly ILogger logger;
        public FileCdnController(
            ICdnService<MainContext> _cdnService,
            IImageService _imgService,
             ILibraryService _libService,
            ILogger<FileCdnController> _logger)
        {
            this.cdnService = _cdnService;
            this.imgService = _imgService;
            this.libService = _libService;
            logger = _logger;
        }

        [HttpPost]
        public JsonResult GetFileList([FromBody]GridRequestModel data)
        {
            var model = cdnService.Select(
                   new FileSelect()
                   {
                       SourceType = (int)data.param.sourceType,
                       SourceID = (string)data.param.sourceId,
                       SearchText = data.filter.EmptyToNull()
                   })
                   .Where(x => x.IsActive == true)
                   .OrderByDescending(x => x.DateUploaded)
                   .AsQueryable();

            return Json(new GridResponseModel<FileCDN.Models.FileInfo>(data, model));
        }

        //public IActionResult UploadFile(int sourceType, string sourceId, string callback = null, string directUploadMethod = null, int stUsed = 0)
        //{
        //    var model = new FileRequest()
        //    {
        //        SourceType = sourceType,
        //        SourceID = sourceId,
        //        JScallback = callback,
        //        DirectUploadMethod = directUploadMethod,
        //        UsedFilesSourceType = stUsed
        //    };
        //    ViewBag.libraries = libService.Select(sourceType, null, null).Where(x => x.IsActive)
        //        .ToSelectList(x => x.Id, x => x.Title, sourceId);
        //    ViewBag.directUpload = !string.IsNullOrEmpty(directUploadMethod);
        //    return PartialView(model);
        //}
        //[HttpPost]
        //public JsonResult UploadFile(FileRequest model, ICollection<IFormFile> files)
        //{
        //    foreach (var file in files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            model.FileName = file.FileName;
        //            model.ContentType = file.ContentType;
        //            model.UserUploaded = this.UserId.ToString();
        //            if (model.SourceType == GlobalConstants.SourceTypes.Library_Images)
        //            {
        //                model.ThumbMaxSize = 150;
        //                model.ThumbSourceType = GlobalConstants.SourceTypes.Library_ImagesThumbs;
        //            }
        //            BinaryReader br = new BinaryReader(file.OpenReadStream());
        //            model.FileContent = br.ReadBytes((int)file.Length);
        //            var cdnresult = cdnService.Upload(model);
        //            if (cdnresult.SavedOK)
        //            {
        //                return Json(new { isOk = true, fileId = cdnresult.FileId, title = model.FileTitle ?? model.FileName });
        //            }
        //        }
        //    }
        //    return Json(new { isOk = false });
        //}

        public FileResult DownloadFile(string id)
        {
            var cdnresult = cdnService.Download(new FileSelect()
            {
                FileId = id
            });

            return File(cdnresult.FileContent, "application/octet-stream", cdnresult.FileName);
        }

        //[HttpPost]
        //public ContentResult DisableFile(string id)
        //{
        //    string result = "failed";
        //    if (cdnService.Disable(new FileSelect()
        //    {
        //        FileId = id
        //    }))
        //    {
        //        result = "ok";
        //    }

        //    return Content(result);
        //}

        [HttpGet]
        public IActionResult ViewImage(string id, int? sourceType = null, string sourceId = null, int max = 0)
        {
            var image = cdnService.Download(new FileSelect { FileId = id, SourceType = sourceType, SourceID = sourceId });
            byte[] imgData = image.FileContent;
            if (imgData == null && sourceType == GlobalConstants.SourceTypes.Library_ImagesThumbs)
            {
                //Липсва thumbnail
                image = cdnService.Download(new FileSelect { FileId = sourceId });
                imgData = image.FileContent;
                if (max == 0)
                {
                    max = 150;
                }
                //AutoCreate thumbnails
            }
            try
            {
                if (max > 0)
                {

                    imgData = imgService.Resize(imgData, max, image.ContentType);

                }
                MemoryStream ms = new MemoryStream(imgData);

                return new FileStreamResult(ms, image.ContentType);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message, id, sourceType);
                return Content("img is null");
            }
        }

        //public IActionResult SelectImageForInsert(string id, string callback)
        //{
        //    var model = new ImageSelectVM()
        //    {
        //        FileId = id,
        //        Max = 0,
        //        Margin = 0,
        //        JScallback = callback
        //    };
        //    ViewBag.positions = new List<SelectListItem>() {
        //        new SelectListItem(){ Text="Ляво подравняване", Value=GlobalConstants.ImagePositions.FloatLeft.ToString(),Selected=true },
        //        new SelectListItem(){ Text="Дясно подравняване", Value=GlobalConstants.ImagePositions.FloatRight.ToString() },
        //        new SelectListItem(){ Text="Вмъкване в текста", Value=GlobalConstants.ImagePositions.Inline.ToString() }
        //    };
        //    return PartialView(model);
        //}
    }

}
