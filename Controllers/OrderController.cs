using Microsoft.AspNetCore.Mvc;

namespace Wardrobe_Bliss.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
