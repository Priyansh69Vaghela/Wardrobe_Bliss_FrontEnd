using Microsoft.AspNetCore.Mvc;

namespace Wardrobe_Bliss.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
