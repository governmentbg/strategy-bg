using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Models.Contracts;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCommmon.Controllers;
using static WebCommon.CommonConstants;

namespace Domain.Areas.Admin.Controllers
{
    [Authorize]
    public class BaseAdminController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.IsAdmin = false;
            var user = this.User;
            if (user != null)
            {

                if (user.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == GlobalConstants.Roles.Admin))
                {
                    ViewBag.IsAdmin = true;
                }

                if (user.Claims.Where(x => x.Type == CustomClaims.UserType).FirstOrDefault()?.Value == GlobalConstants.UserTypes.Public.ToString())
                {
                    filterContext.Result = RedirectToAction("Index", "Home", new { area = "" });
                }
            }

        }

        public void MakeSourceItemVM(int sourceType, int sourceId)
        {
            var model = new SourceItemVM()
            {
                SourceType = sourceType,
                SourceId = sourceId
            };

            switch (model.SourceType)
            {
                case GlobalConstants.SourceTypes.PublicConsultation:
                    model.BackUrl = Url.Action("Edit", "Consultation", new { area = "admin", id = model.SourceId });
                    model.SourceTypeName = "Обществена консултация";
                    break;
                case GlobalConstants.SourceTypes.PublicConsultationDocuments:
                    model.BackUrl = Url.Action("EditDocument", "Consultation", new { area = "admin", id = model.SourceId });
                    model.SourceTypeName = "Документ";
                    break;
            }

            ViewBag.sourceItem = model;
        }

        public void SaveSiteLog(string tableName, int action, int recordId,bool approved, string details)
        {

            ISiteLogService siteLogService = (ISiteLogService)HttpContext.RequestServices.GetService(typeof(ISiteLogService));
            siteLogService.Log(tableName, recordId, approved, action, details);
        }
    }
}
