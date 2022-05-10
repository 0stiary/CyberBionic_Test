using Microsoft.AspNetCore.Mvc;

namespace ASP.net.Controllers
{
	public class HomeController : Controller
	{
		// GET
		public IActionResult Index()
		{
			return View();
		}
	}
}