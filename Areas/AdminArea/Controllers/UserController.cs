using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Wardrobe_Bliss.Areas.AdminArea.Models;

namespace Wardrobe_Bliss.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Route("AdminArea/[controller]/[action]")]
    public class UserController : Controller
    {
        private IConfiguration configuration;
        private HttpClient _client;

        #region configuration
        public UserController(IConfiguration _configuration)
        {
            configuration = _configuration;
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"]);
        }
        #endregion

        #region Api Product delete
        public async Task<IActionResult> ApiUserDelete(int id)
        {
            var res = await _client.DeleteAsync($"User/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("UserList");
            }
            return RedirectToAction("UserList");
        }
        #endregion
        #region Api Product List
        public async Task<IActionResult> UserList()
        {
            var res = await _client.GetAsync("Users");
            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<UsersModel>>(data);
                return View(result);
            }
            return View(new List<UsersModel>());
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
