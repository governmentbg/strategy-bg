using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTables;
using DataTables.AspNet.Core;
using IdServer.Models.Contracts;
using DataTables.AspNet.AspNetCore;
using IdServer.Extensions;
using IdServer.ViewModels;
using IdServer.Class;
using WebCommon.Extensions;

namespace IdServer.Controllers.Account
{
    [Authorize]
    public class ManageController : BaseController
    {
        private readonly IUserService userService;
        public ManageController(IUserService _userService)
        {
            userService = _userService;
        }
        public IActionResult Users()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Users_LoadData(IDataTablesRequest request, bool active = true, bool confirmed = true, bool internalUser = true)
        {
            var data = userService.Select_UserVM(active, confirmed, internalUser);
            var filteredData = data;

            if (request.Search.Value != null)
            {
                filteredData = data.Where(x => x.FullName.Contains(request.Search.Value ?? x.FullName));
            }
            var response = request.GetResponse(data, filteredData);
            return new DataTablesJsonResult(response, true);
        }

        public IActionResult Users_Edit(string id)
        {
            var model = userService.GetUserEditVMBySubjectId(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Users_Edit(UserEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (userService.SaveUserEdit(model))
            {
                TempData[MessageConstant.SuccessMessage] = MessageConstant.Values.SaveOK;
            }
            else
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.Values.SaveFailed;
            }
            return View(model);
        }

        public IActionResult Users_Roles(string id)
        {
            var model = userService.LoadUserRoles(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Users_Roles(UserRolesVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (userService.SaveUserRoles(model))
            {
                TempData[MessageConstant.SuccessMessage] = MessageConstant.Values.SaveOK;
            }
            else
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.Values.SaveFailed;
            }
            return RedirectToAction(this.ActionName, new { id = model.UserId });
        }

        [Authorize]
        public IActionResult Profile()
        {
            var model = userService.GetUserEditVMBySubjectId(this.UserId);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Profile(UserEditVM model)
        {
            model.Id = this.UserId;
            model.Email = this.User.Identity.Name;
            model.IsActive = true;
            model.IsMailConfirmed = true;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (userService.SaveUserEdit(model))
            {
                TempData[MessageConstant.SuccessMessage] = MessageConstant.Values.SaveOK;
            }
            else
            {
                TempData[MessageConstant.ErrorMessage] = MessageConstant.Values.SaveFailed;
            }

            return View(model);
        }

        public PartialViewResult ChangePassword()
        {
            ChangeSelfPasswordViewModel model = new ChangeSelfPasswordViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult ChangePassword(ChangeSelfPasswordViewModel model)
        {
            Response.StatusCode = 566;
            var oldPassOk = userService.AreUserCredentialsValid(this.User.Identity.Name, model.OldPassword, GlobalConstants.IdServerClientId);
            if (!oldPassOk)
            {
                ModelState.AddModelError("OldPassword", "Невалидна съществуваща парола");
            }

            if (model.Password != model.PasswordAgain)
            {
                ModelState.AddModelError("PasswordAgain", "Невалидна съществуваща парола");
            }

            if (ModelState.IsValid)
            {
                model.Code = userService.GetPasswordChangeCode(this.User.Identity.Name);
                if (userService.ChangePassword(model))
                {
                    TempData[MessageConstant.SuccessMessage] = "Паролата Ви е сменена успешно";
                    Response.StatusCode = 200;

                }
            }
            return PartialView(model);
        }

        public IActionResult MigrateUsers()
        {
            userService.MigrateOldUsers();
            return Content("ok");
        }
    }
}