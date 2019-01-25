using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.Contracts;
using Models.ViewModels.Account;
using System.Linq;
using WebCommmon.Controllers;
using WebCommon.Extensions;
using WebCommon.Services;

namespace Domain.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = GlobalConstants.Roles.AdminAndAdminGroup)]
    public class UsersController : BaseAdminController
    {
        private readonly IAccountService accountService;
        private readonly IUserContext userContext;
        public UsersController(IAccountService _accountService, IUserContext _userContext)
        {
            accountService = _accountService;
            userContext = _userContext;
        }
        public IActionResult Index()
        {
            ViewBag.userTypes = accountService.Combo_UserTypes().AddAllItem();
            TempData["groupId"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult LoadData(IDataTablesRequest request, string fullName, string userName, int? userType, bool? isApproved = null)
        {
            var data = accountService.Users_Select(fullName.EmptyToNull(), userName.EmptyToNull(), userType.EmptyToNull(), isApproved);
            var filteredData = data;
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Register(int? groupId = null)
        {
            var model = new RegisterInternalUserVM()
            {
                GroupId = groupId
            };
            if (groupId > 0)
            {
                model.GroupName = accountService.GroupUsers_Select(groupId.Value).FirstOrDefault()?.Organization;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Register(RegisterInternalUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = accountService.Users_GetByUserName(model.UserName);
            if (user != null)
            {
                ModelState.AddModelError(nameof(RegisterInternalUserVM.UserName), "Потребителското име вече съществува.");
                return View(model);
            }

            this.SetSavedMessage = accountService.Users_RegisterInternal(model);
            if (SetSavedMessage)
            {
                //var code = accountService.Users_GetVerificationCode(model.UserName);
                //var url = Url.Action(
                //    nameof(ConfirmMail),
                //    ControllerContext.ActionDescriptor.ControllerName,
                //    new { code },
                //    HttpContext.Request.Scheme);

                //_emailSender.SendMail(
                //    model.Email,
                //    (string)Localizer["ConfirmMailSubject"],
                //    String.Format((string)Localizer["ConfirmMailBody"], TempData.Peek("Client"), url));


                return RedirectToAction(nameof(Update), new { id = model.Id });
            }

            return View(model);
        }

        public IActionResult Update(int id)
        {
            if (TempData.Peek("groupId") != null)
            {
                ViewBag.backUrl = Url.Action("Users", "GroupUsers", new { groupId = TempData.Peek("groupId") });
            }
            var model = accountService.Users_GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.SetSavedMessage = accountService.Users_Update(model);
            model = accountService.Users_GetById(model.Id);
            return View(model);
        }

        public IActionResult UserGroups(int userId)
        {
            var model = accountService.UserInGroup_Select(null, userId);
            ViewBag.user = accountService.Users_GetById(userId);
            return View(model);
        }
        [HttpPost]
        public IActionResult UserGroups_LoadData(IDataTablesRequest request, int userId)
        {
            var data = accountService.UserInGroup_Select(null, userId);
            var filteredData = data;
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult UserGroups_AddGroup(int userId)
        {
            var user = accountService.Users_GetById(userId);
            ViewBag.groups = accountService.GroupUsers_Select()
                                    .Where(x => x.IsActive)
                                    .ToSelectList(x => x.Id, x => x.Organization);
            var model = new UserInGroupVM()
            {
                UserId = user.Id,
                UserFullName = user.GetFullName
            };
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult UserGroups_AddGroup(UserInGroupVM model)
        {
            SetSavedMessage = accountService.UserInGroup_Add(model.GroupUserId, model.UserId);
            return RedirectToAction(nameof(UserGroups), new { userId = model.UserId });
        }

        public IActionResult Roles(int userId)
        {
            var model = accountService.UserRoles_Select(userId);
            var user = accountService.Users_GetById(userId);

            model.Username = user?.UserName;
            model.FullName = user?.GetFullName;
            return View(model);
        }

        [HttpPost]
        public IActionResult Roles(UserRolesVM model)
        {
            this.SetSavedMessage = accountService.UserRoles_Save(model);
            return View(model);
        }

    }
}