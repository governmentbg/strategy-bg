using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebCommmon.Controllers;

namespace Domain.Areas.Admin.Controllers
{
    /// <summary>
    /// Начален екран
    /// </summary>
    [Area(nameof(Areas.Admin))]
    [Authorize]
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
