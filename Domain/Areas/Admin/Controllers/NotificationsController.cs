using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Contracts;
using Models.ViewModels.Account;
using Models.ViewModels.Notifications;
using WebCommmon.Controllers;
using WebCommon.Extensions;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = GlobalConstants.Roles.Admin)]
    public class NotificationsController : BaseController
    {
        private readonly INotificationService notificationsService;
        private readonly INomenclatureService nomService;
        private readonly IConsultationService consultationService;
        private readonly IAccountService accountService;



        public NotificationsController(
            INotificationService _notificationsService,
            INomenclatureService _nomService,
            IConsultationService _consultationService,
             IAccountService _accountService)
        {
            notificationsService = _notificationsService;
            nomService = _nomService;
            consultationService = _consultationService;
            accountService = _accountService;
        }

        public IActionResult Index()
        {


            List<UserToNotificateVM> listToNotificate = new List<UserToNotificateVM>() {
        new UserToNotificateVM() {UserId=1,Email="t@g.com"},
      };


            //bool Not = notificationsService.InsertNotificationMessages("MessageTitle", "MessageBody", 1, 1, true, true, listToNotificate);
            notificationsService.SendingInsertedNotifications();
            return View();
        }

        public IActionResult SendByFilter()
        {
            var model = new NotificationByFiltersVM()
            {
                EmailNotification = true,
                SystemNotification = true
            };
            SendByFilter_ViewBag();
            return View(model);
        }

        private void SendByFilter_ViewBag()
        {
            ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList();
            ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Categories.Type_National).ToSelectList().AddAllItem();
            ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Categories.Type_District).ToSelectList().AddAllItem();

            ViewBag.targetGroups = consultationService.GetTargetGroupsDDL();

            ViewBag.userGroups = accountService.GroupUsers_Select()
                                    .Where(x => x.IsActive)
                                    .ToSelectList(x => x.Id, x => x.Organization).AddAllItem();
        }

        [HttpPost]
        public IActionResult SendByFilter(NotificationByFiltersVM model)
        {
            if (!(model.EmailNotification || model.SystemNotification))
            {
                ModelState.AddModelError(nameof(model.EmailNotification), "Изберете поне един начин на известявяне.");
            }
            if (model.CategoryId <= 0 && model.MunicipalityId <= 0 && model.TargetGroupId <= 0 && model.UserGroupId <= 0)
            {
                ModelState.AddModelError(nameof(model.CategoryMasterId), "Изберете стойност в поне един филтър.");
            }
            if (!ModelState.IsValid)
            {
                SendByFilter_ViewBag();
                return View(model);
            }


            int? selectedCat = model.CategoryId;
            if (model.MunicipalityId > 0)
            {
                selectedCat = model.MunicipalityId;
            }

            var listToNotificate = accountService.Users_SelectForNotification(null,
                selectedCat.EmptyToNull(),
                model.TargetGroupId.EmptyToNull(),
                model.UserGroupId.EmptyToNull()).ToList();

            this.SetSavedMessage = notificationsService.InsertNotificationMessages(model.Title, model.Body,
                 1, GlobalConstants.SourceTypes.BlancSource,
                 model.SystemNotification, model.EmailNotification,
                 listToNotificate);

            return View(model);

        }

    }
}