using Microsoft.AspNetCore.Mvc;

namespace eShop.WEB.Areas.Administrator.Controllers
{
    [Area(nameof(Administrator))]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
