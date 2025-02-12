using Microsoft.AspNetCore.Mvc;

namespace Wardrobe_Bliss.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
