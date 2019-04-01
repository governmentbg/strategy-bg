using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Context.Account;
using Models.ViewModels.Account;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCommon.Extensions;

namespace Domain.Controllers
{
  public partial class AccountController
  {
    [Authorize]
    public IActionResult Profile()
    {
      var model = accountService.Users_GetById(userContext.UserId);
      return View(model);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Profile(UserEditVM model)
    {
      model.Id = userContext.UserId;
      this.SetSavedMessage = accountService.Users_UpdateProfile(model);
      if (this.SetSavedMessage)
      {
        var userName = accountService.Users_GetById(userContext.UserId).UserName;
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        accountService.GeneratePrincipalByUsername(userName));
        return RedirectToAction(nameof(Profile));
      }

      model = accountService.Users_GetById(model.Id);
      return View(model);
    }


    public IActionResult Categories()
    {
      UserInCategoriesVM model = accountService.UserInCategoriesVM_Select(userContext.UserId);

      return View(model);
    }

    /*
    [HttpPost]
    public IActionResult Categories_LoadData(IDataTablesRequest request)
    {
      var data = accountService.UserInCategories_Select(userContext.UserId, null);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    public IActionResult Categories_Add()
    {
      var model = new UserInCategoryVM();
      ViewBag.catMasters = nomService.ComboCategories(0).ToSelectList();
      ViewBag.catNational = nomService.ComboCategories(GlobalConstants.Category.Type_National).ToSelectList().AddAllItem();
      ViewBag.catDistrict = nomService.ComboCategories(GlobalConstants.Category.Type_District).ToSelectList().AddAllItem();
      return PartialView(model);
    }
    */

    [HttpPost]
    public IActionResult Categories(UserInCategoriesVM userInCategories)
    {
			SetSavedMessage = false;

      if (accountService.UserInCategories_SaveAll(userContext.UserId, userInCategories))
      {
        SetSavedMessage = true;
      }

      UserInCategoriesVM model = accountService.UserInCategoriesVM_Select(userContext.UserId);

      return View(model);
    }

    [HttpPost]
    public IActionResult Categories_Add(UserInCategoryVM model)
    {
      int categorySelected = 0;
      switch (model.CategoryMasterId)
      {
        case GlobalConstants.Category.Type_National:
          categorySelected = model.CategoryId;
          break;
        default:
          categorySelected = model.MunicipalityId;
          break;
      }
      accountService.UserInCategories_Add(userContext.UserId, categorySelected);

      return RedirectToAction(nameof(Categories));
    }

    public IActionResult Categories_Remove(int categoryId)
    {
      accountService.UserInCategories_Remove(userContext.UserId, categoryId);

      return Content("ok");
    }


    public IActionResult TargetGroups()
    {
      return View();
    }

    [HttpPost]
    public IActionResult TargetGroups_LoadData(IDataTablesRequest request)
    {
      var data = accountService.UserInTargetGroups_Select(userContext.UserId, null);

      var response = request.GetResponse(data);

      return new DataTablesJsonResult(response, true);
    }

    public IActionResult TargetGroups_Add()
    {
      var model = new UserInTargetGroupVM();
      ViewBag.groups = consulationService.GetTargetGroupsDDL();
      return PartialView(model);
    }

    [HttpPost]
    public IActionResult TargetGroups_Add(UserInTargetGroupVM model)
    {
      accountService.UserInTargetGroups_Add(userContext.UserId, model.TargetGroupId);

      return RedirectToAction(nameof(TargetGroups));
    }

    public IActionResult TargetGroups_Remove(int targetGroupId)
    {
      accountService.UserInTargetGroups_Remove(userContext.UserId, targetGroupId);

      return Content("ok");
    }
  }
}
