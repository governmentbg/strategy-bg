using Microsoft.AspNetCore.Mvc;

namespace PopForums.Mvc.Controllers
{
    public class ForumController : Controller
    {
	    public IActionResult Index()
	    {
            return View();
        }
	}
}
