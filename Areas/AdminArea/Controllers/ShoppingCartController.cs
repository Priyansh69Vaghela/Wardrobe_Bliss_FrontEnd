using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wardrobe_Bliss.Areas.AdminArea.Models;

namespace Wardrobe_Bliss.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route("AdminArea/[controller]/[action]")]
    public class ShoppingCartController : Controller
    {
        private IConfiguration configuration;
        private HttpClient _client;

        #region configuration
        public ShoppingCartController(IConfiguration _configuration)
        {
            configuration = _configuration;
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"]);
        }
        #endregion
        #region Api Product List
        public async Task<IActionResult> ShoppingCartList()
        {
            var res = await _client.GetAsync("ShoppingCart");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ShoppingCartModel>>(data);
                return View(result);
            }
            return View(new List<ShoppingCartModel>());
        }
        #endregion

        #region Api Product delete
        public async Task<IActionResult> ApiShoppingCartDelete(int id)
        {
            var res = await _client.DeleteAsync($"ShoppingCart/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("ShoppingCartList");
            }
            return RedirectToAction("ShoppingCartList");
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
