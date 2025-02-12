using Microsoft.AspNetCore.Mvc;

namespace Wardrobe_Bliss.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
