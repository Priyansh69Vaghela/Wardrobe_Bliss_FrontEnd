using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Wardrobe_Bliss.Areas.AdminArea.Models;

namespace Wardrobe_Bliss.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route("AdminArea/[controller]/[action]")]
    public class ProductController : Controller
    {
        private IConfiguration configuration;
        private HttpClient _client;

        #region configuration
        public ProductController(IConfiguration _configuration)
        {
            configuration = _configuration;
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"]);
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        
        
        #region Api Product List
        public async Task<IActionResult> ProductList()
        {
            var res = await _client.GetAsync("Product");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductModel>>(data);
                return View(result);
            }
            return View(new List<ProductModel>());
        }
        #endregion

        #region Api Product Insert
        public async Task<IActionResult> AddProduct(int? id)
        {
            if (id.HasValue)
            {
                var res = await _client.GetAsync($"Product/{id}");
                if (res.IsSuccessStatusCode)
                {
                    var data = await res.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ProductModel>(data);
                    return View(result);
                }   
            }
            return View();
        }
        #endregion

        #region Api Save
        [HttpPost]
        public async Task<IActionResult> ApiSave(ProductModel product)
        {
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage res;
            if (product.product_id == null)
            {
                res = await _client.PostAsync("Product", content);
            }
            else
            {
                res = await _client.PutAsync($"Product/{product.product_id}", content);
            }
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return RedirectToAction("AddProduct", product);
        }
        }
        #endregion

        //#region Api Product delete
        //public async Task<IActionResult> ApiProductDelete(int id)
        //{
        //    var res = await _client.DeleteAsync($"Product/{id}");
        //    if (res.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("ProductList");
        //    }
        //    return RedirectToAction("ProductList");
        //}
        //#endregion


}
