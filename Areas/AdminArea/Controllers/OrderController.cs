using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wardrobe_Bliss.Areas.AdminArea.Models;

namespace Wardrobe_Bliss.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route("AdminArea/[controller]/[action]")]
    public class OrderController : Controller
    {
        private IConfiguration configuration;
        private HttpClient _client;

        #region configuration
        public OrderController(IConfiguration _configuration)
        {
            configuration = _configuration;
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"]);
        }
        #endregion
        #region Api Product delete
        public async Task<IActionResult> ApiOrderDelete(int id)
        {
            var res = await _client.DeleteAsync($"Order/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("OrderList");
            }
            return RedirectToAction("OrderList");
        }
        #endregion
        #region Api Product List
        public async Task<IActionResult> OrderList()
        {
            var res = await _client.GetAsync("Order");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<OrderModel>>(data);
                return View(result);
            }
            return View(new List<OrderModel>());
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
