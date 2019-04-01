using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IdServer.Controllers
{
    public class BaseController : Controller
    {
        public string ActionName
        {
            get
            {
                return (string)ViewBag.actionName;
            }
        }
        public string UserId
        {
            get
            {
                string userId = String.Empty;

                if (User != null && User.Claims != null && User.Claims.Count() > 0)
                {
                    var subClaim = User.Claims
                        .FirstOrDefault(c => c.Type == "sub");

                    if (subClaim != null)
                    {
                        userId = subClaim.Value;
                    }
                }

                return userId;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            /*
             *      Управление на активния елемент на менюто
             *      ViewBag.MenuItemValue съдържа ключовата дума, отговорна за отварянето на менюто
             *      Ако не намери атрибут на action-а MenuItem("{keyword}"), се използва името на action-а
             *      Ако action-а е от вида List_Edit се подава list (отрязва до последния символ долна подчертавка)
             */
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;

            if (controllerActionDescriptor != null)
            {
                ViewBag.actionName = controllerActionDescriptor.ActionName;


                //object currentMenuItem = null;
                //var menuAttrib = controllerActionDescriptor
                //                    .MethodInfo
                //                    .CustomAttributes
                //                    .FirstOrDefault(a => a.AttributeType == typeof(MenuItemAttribute));
                //if (menuAttrib != null)
                //{
                //    currentMenuItem = menuAttrib.ConstructorArguments[0].Value;
                //}
                //if (currentMenuItem == null)
                //{
                //    var actionName = controllerActionDescriptor.ActionName;
                //    if (actionName.Contains('_'))
                //    {
                //        currentMenuItem = actionName.Substring(0, actionName.LastIndexOf('_')).ToLower();
                //    }
                //    else
                //    {
                //        currentMenuItem = actionName.ToLower();
                //    }
                //}
                //ViewBag.MenuItemValue = currentMenuItem;
            }
            // ---------Управление на активния елемент на менюто, край
        }
        //protected void AddSuccessMessage(string message)
        //{
        //    TempData[MessageConstant.SuccessMessage] = message;
        //}
        //protected void AddDangerMessage(string message)
        //{
        //    TempData[MessageConstant.ErrorMessage] = message;
        //}
        //protected void AddWarningMessage(string message)
        //{
        //    TempData[MessageConstant.WarningMessage] = message;
        //}

        protected RedirectToActionResult RedirectToEdit(object routeVals)
        {
            return RedirectToAction("Edit", routeVals);
        }
    }
}