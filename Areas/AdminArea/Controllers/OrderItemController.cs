using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wardrobe_Bliss.Areas.AdminArea.Models;

namespace Wardrobe_Bliss.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route("AdminArea/[controller]/[action]")]
    public class OrderItemController : Controller
    { 
        private IConfiguration configuration;
        private HttpClient _client;

        #region configuration
        public OrderItemController(IConfiguration _configuration)
        {
            configuration = _configuration;
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"]);
        }
        #endregion
        #region Api Product delete
        public async Task<IActionResult> ApiOrderItemDelete(int id)
        {
            var res = await _client.DeleteAsync($"OrderItem/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("OrderItemList");
            }
            return RedirectToAction("OrderItemList");
        }
        #endregion
        #region Api Product List
        public async Task<IActionResult> OrderItemList()
        {
            var res = await _client.GetAsync("OrderItem");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<OrderItemsModel>>(data);
                return View(result);
            }
            return View(new List<OrderItemsModel>());
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
