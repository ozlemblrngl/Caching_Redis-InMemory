using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.Controllers
{
    public class ProductsController : Controller
    {
        private IMemoryCache _memoryCache;
        public ProductsController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
