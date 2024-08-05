using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop.WEB.Areas.User.Controllers
{
	[Area("User")]
	[Authorize]
	public class BaseUserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
