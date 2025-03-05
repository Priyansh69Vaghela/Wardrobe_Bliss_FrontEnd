using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wardrobe_Bliss.Areas.AdminArea.Models;

namespace Wardrobe_Bliss.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route("AdminArea/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private IConfiguration configuration;
        private HttpClient _client;

        #region configuration
        public CategoryController(IConfiguration _configuration)
        {
            configuration = _configuration;
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"]);
        }
        #endregion
        #region Api Product delete
        public async Task<IActionResult> ApiCategoryDelete(int id)
        {
            var res = await _client.DeleteAsync($"Category/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return RedirectToAction("CategoryList");
        }
        #endregion
        #region Api Product List
        public async Task<IActionResult> CategoryList()
        {
            var res = await _client.GetAsync("Category");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<CategoryModel>>(data);
                return View(result);
            }
            return View(new List<CategoryModel>());
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
