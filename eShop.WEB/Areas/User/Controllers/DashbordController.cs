using Microsoft.AspNetCore.Mvc;

namespace eShop.WEB.Areas.User.Controllers
{
	public class DashbordController : BaseUserController
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
