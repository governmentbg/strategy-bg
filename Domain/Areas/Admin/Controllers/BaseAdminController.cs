using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{
    public class BaseAdminController : BaseController
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.IsAdmin = false;
            var user = this.User;
            if (user != null && user.Claims.Any(x => x.Type == ClaimTypes.Role && x.Value == GlobalConstants.Roles.Admin))
            {
                ViewBag.IsAdmin = true;
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
    }
}
