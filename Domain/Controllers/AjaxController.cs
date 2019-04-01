using Domain.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using Models.ViewModels.Portal;
using System;
using System.Linq;
using System.Security.Claims;

namespace Domain.Controllers
{
    /// <summary>
    /// Ajax услуги за извличане на данни чрез Javascript
    /// </summary>
    public class AjaxController : Controller
    {
        private readonly INomenclatureService nomenclatureService;

        private readonly ICommentService commentService;

        private readonly INotificationService notificationservice;

        public int UserId
        {
            get
            {
                int userId = 0;

                if (User != null && User.Claims != null && User.Claims.Count() > 0)
                {
                    var subClaim = User.Claims
                        .FirstOrDefault(c => c.Type == ClaimTypes.Sid);

                    if (subClaim != null)
                    {
                        Int32.TryParse(subClaim.Value, out userId);
                    }
                }

                return userId;
            }
        }

        public AjaxController(
            INomenclatureService _nomenclatureService,
            ICommentService _commentService,
            INotificationService _notificationservice)
        {
            nomenclatureService = _nomenclatureService;
            commentService = _commentService;
            notificationservice = _notificationservice;
        }

        [HttpGet]
        public IActionResult SearchCategory(string query)
        {
            return new JsonResult(nomenclatureService.SearchCategory(query));
        }

        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            var activity = nomenclatureService.GetCategory(id);

            if (activity == null)
            {
                return BadRequest();
            }

            return new JsonResult(activity);
        }

        [HttpGet]
        public IActionResult GetComboCategories(int masterCat, int municipalityId = -1)
        {
            var model = nomenclatureService.ComboCategories(masterCat, municipalityId);

            if (model == null)
            {
                return BadRequest();
            }

            return new JsonResult(model);
        }

        [HttpGet]
        public IActionResult GetComments(int sourceTypeId, int sourceId)
        {
            var comments = commentService.GetComments(sourceTypeId, sourceId);

            return new JsonResult(new { comments });
        }

        [HttpGet]
        public IActionResult GetNewSystemMessagesForCurrentUser()
        {
            var count = notificationservice.CurrentUserSystemNotification_NewMessages();

            return new JsonResult(new { count });
        }

        [HttpPost]
        public IActionResult AddComment(PostCommentVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            commentService.AddComment(model, UserId);

            return this.StatusCode(201);
        }

        public IActionResult PublicConsultationWidget(int loadCount, string type)
        {
            return ViewComponent("PublicConsultationWidget", new { loadCount, type });
        }

        //INomService nomService;
        //IApplicationService appService;
        //public AjaxController(INomService _nomService, IApplicationService _appService)
        //{
        //    nomService = _nomService;
        //    appService = _appService;
        //}

        //public JsonResult Countries()
        //{
        //    var model = nomService.Country_Select(GlobalConstants.DefaultLang);
        //    return Json(model);
        //}
        //public JsonResult Ekkate(string parentCode, bool addAllItem = true)
        //{
        //    var model = nomService.Ekkate_Select(GlobalConstants.DefaultLang, parentCode).ToList();
        //    if (addAllItem)
        //    {
        //        model.Insert(0, new WebCommon.Models.TextValueVM() { Text = "Изберете", Value = null });
        //    }
        //    return Json(model);
        //}

        //public JsonResult Dashboard()
        //{
        //    var result = new List<DashboardVM>();
        //    var registeredCount = appService.Application_SelectInternal(null, null, null, null, null, GlobalConstants.ApplicationStates.Registered).Count();
        //    if (registeredCount > 0)
        //    {
        //        result.Add(new DashboardVM()
        //        {
        //            Count = registeredCount,
        //            Title = "Нови заявления",
        //            Description = "Новорегистрирани заявления, достъпни за обработка",
        //            Url = Url.Action("Index", "Application", new { stateId = GlobalConstants.ApplicationStates.Registered })
        //        });
        //    }

        //    return Json(result);
        //}
    }
}