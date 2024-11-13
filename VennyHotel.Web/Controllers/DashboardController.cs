using Microsoft.AspNetCore.Mvc;

namespace VennyHotel.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
