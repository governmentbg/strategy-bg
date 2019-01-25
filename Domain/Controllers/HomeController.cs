using Microsoft.AspNetCore.Mvc;
using Models.Contracts;
using WebCommmon.Controllers;
using WebCommon.Models;

namespace Domain.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAccountService accountService;
        public HomeController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SamplePage()
        {
            return View();
        }

        public IActionResult Message(bool isError = false)
        {
            MessageDialogVM model = this.GetMessageDialog();
            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

       
    }
}