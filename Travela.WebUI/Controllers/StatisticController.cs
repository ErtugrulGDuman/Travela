using Microsoft.AspNetCore.Mvc;

namespace Travela.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync("https://localhost:7106/api/Category/CategoryCount");
            var jsonData = await responseMesage.Content.ReadAsStringAsync();
            ViewBag.c = jsonData;
            return View();
        }
    }
}
