using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.Controllers
{
    public class ProductsController : Controller
    {
        private IMemoryCache _memoryCache;
        public ProductsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            _memoryCache.Set<string>("zaman", DateTime.Now.ToString());
            return View();
        }

        public IActionResult Show()
        {
            ViewBag.time = _memoryCache.Get<string>("zaman");
            return View();
        }
    }
}
