using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsForDNN.Models;
using NewsForDNN.Services;
using System.Diagnostics;

namespace NewsForDNN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriesApi _categoriesApi;
        private readonly INewsApi _newsApi;
        public HomeController(ILogger<HomeController> logger, ICategoriesApi categoriesApi, INewsApi newsApi)
        {
            _logger = logger;
            _categoriesApi = categoriesApi;
            _newsApi = newsApi;
        }

        public async Task<IActionResult> Index(int page = 1, int category = -1)
        {
            var take = 20;
            var skip = (page - 1) * take; 
            var totalNews = await _newsApi.TotalNews(category);
            ViewData["Categories"] = await _categoriesApi.GetAll();
            ViewData["TotalNews"] = totalNews;
            ViewData["Take"] = take;
            ViewData["Page"] = page;
            ViewData["ShowLastestNews"] = (page == 1 && category == - 1);
            var news = await _newsApi.GetAll(take, skip, category);
            return View(news);
        }

        [HttpGet("Detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var news = await _newsApi.Get(id);
            return View(news);
        }

        public async Task<IActionResult> Search(string k, int page = 1)
        {
            var category = -1;
            var take = 20;
            var skip = (page - 1) * take;
            var totalNews = await _newsApi.TotalNews(category, k);
            ViewData["Categories"] = await _categoriesApi.GetAll();
            ViewData["TotalNews"] = totalNews;
            ViewData["Take"] = take;
            ViewData["Page"] = page;
            ViewData["ShowLastestNews"] = false;
            var news = await _newsApi.Search(k, take, skip);
            return View("index", news);
        }

        public async Task<IActionResult> SmartCalculator()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}