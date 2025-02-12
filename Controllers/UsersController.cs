using Microsoft.AspNetCore.Mvc;

namespace Wardrobe_Bliss.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
