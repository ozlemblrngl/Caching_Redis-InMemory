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

            // ömür vermek için kullandığımız sınıf
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();

            options.AbsoluteExpiration = DateTime.Now.AddSeconds(10); // 10 sn lik ömür vermiş olduk.
            _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), options);



            return View();
        }

        public IActionResult Show()
        {
            _memoryCache.TryGetValue("zaman", out string timecache);

            ViewBag.time = timecache;
            return View();
        }
    }
}
