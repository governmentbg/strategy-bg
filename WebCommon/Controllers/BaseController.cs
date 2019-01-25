using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using WebCommon.Models;
//using Models;

namespace WebCommmon.Controllers
{

    public class BaseController : Controller
    {
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


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;

            if (controllerActionDescriptor != null)
            {
                ViewBag.actionName = controllerActionDescriptor.ActionName;
            }

            
        }

        private bool _setSavedMessage;
        public bool SetSavedMessage
        {
            get
            {
                return _setSavedMessage;
            }
            set
            {
                _setSavedMessage = value;

                if (value)
                {
                    SetSavedMessageExt("Записът премина успешно.", true);
                }
                else
                {
                    SetSavedMessageExt("Проблем по време на запис.", true);
                }
            }
        }
        public void SetSavedMessageExt(string message, bool isOk)
        {
            _setSavedMessage = isOk;
            if (isOk)
            {
                TempData["UserMessage_Success"] = message;
            }
            else
            {
                TempData["UserMessage_Danger"] = message;
            }
        }

        public void SetMessageDialog(bool isError, string message, string title = "Грешка")
        {
            TempData["MessageDialog"] = new MessageDialogVM()
            {
                IsError = isError,
                Title = title,
                Message = message
            }.AsString();
        }

        protected MessageDialogVM GetMessageDialog()
        {
            if (TempData.Peek("MessageDialog") != null)
            {
                return MessageDialogVM.FromString((string)TempData["MessageDialog"]);
            }
            else
            {
                return null;
            }
        }

        public RedirectToActionResult GotoMessages()
        {
            return RedirectToAction("Message", "Home");
        }
    }
}
