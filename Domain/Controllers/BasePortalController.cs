using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Models;
using Models.ViewModels;
using System;
using WebCommmon.Controllers;

namespace Domain.Controllers
{
    public class BasePortalController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        private string _currentLang;
        protected string GetCurrentLang
        {
            get
            {
                if (string.IsNullOrEmpty(_currentLang))
                {
                    var requestCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLang = requestCulture.RequestCulture.UICulture.TwoLetterISOLanguageName;

                }
                return _currentLang;
            }
        }
        protected int Lang
        {
            get
            {
                return GlobalConstants.GetLanguageId(GetCurrentLang);
            }
        }


        public void MakeSourceItemVMPortal(int sourceType, int sourceId)
        {
            var model = new SourceItemVM()
            {
                SourceType = sourceType,
                SourceId = sourceId
            };

            switch (model.SourceType)
            {
                case GlobalConstants.SourceTypes.PublicConsultation:
                    model.BackUrl = Url.Action("View", "PublicConsultation", new { area = "", id = model.SourceId });
                    model.SourceTypeName = "Обществена консултация";
                    break;
                case GlobalConstants.SourceTypes.ChangeProposals:

                    model.BackUrl = Url.Action("ViewChangeProposals", "ChangeProposals", new { area = "", id = model.SourceId });
                    model.SourceTypeName = "Законодателна инициатива";
                    break;
            }

            ViewBag.sourceItem = model;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ViewBag.lang = GetCurrentLang ?? GlobalConstants.DefaultLang;
            ViewBag.controllerName = filterContext.RouteData.Values["controller"];
        }
    }
}
