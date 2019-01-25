using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{

    [Area(nameof(Areas.Admin))]
    [Authorize]
    public class AjaxController : BaseController
    {

        private readonly ICommonService commonService;
        public AjaxController(ICommonService _commonService)
        {
            commonService = _commonService;
        }

        [HttpPost]
        public JsonResult GetFileList(int sourceType, int sourceId)
        {
            var model = commonService.FileCdn_GetList(sourceType, sourceId); ;

            return Json(model);
        }

        [HttpPost]
        public ContentResult AppendUsedFile(string fileId, int sourceType, int sourceId)
        {
            var result = commonService.FileCdn_AppendUsedFile(fileId, sourceType, sourceId);
            if (result)
            {
                return Content("ok");
            }
            else
            {
                return Content("failed");
            }
        }
        [HttpPost]
        public ContentResult RemoveUsedFile(string fileId, int sourceType, int sourceId)
        {
            var result = commonService.FileCdn_RemoveUsedFile(fileId, sourceType, sourceId);
            if (result)
            {
                return Content("ok");
            }
            else
            {
                return Content("failed");
            }
        }
    }
}
