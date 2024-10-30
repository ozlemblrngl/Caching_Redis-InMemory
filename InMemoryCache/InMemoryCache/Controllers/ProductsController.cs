using InMemoryCache.Models;
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

            // options.AbsoluteExpiration = DateTime.Now.AddSeconds(10); // 10 sn lik ömür vermiş olduk.

            options.AbsoluteExpiration = DateTime.Now.AddMinutes(1); // her koşulda 1 dk lik süre var, slidingtime ile veri tutarsızlığı olmasın diye tüm ömrü 1 dk ile sınırlamış olduk.
            options.SlidingExpiration = TimeSpan.FromSeconds(20); // 10 sn aralıklı ömür verdik eğer 10 sn içerisinde tetiklenirse ömrü 10 sn daha uzayacak her defasında. Tetiklenmezse ölecek.

            options.Priority = CacheItemPriority.High;
            
            options.RegisterPostEvictionCallback((key, value, reason, state) => {

                 _memoryCache.Set("callback", $"{key}-->{value} => silinme sebebi: {reason}");

            }); // calback metodu içinde bir delege çağırıyoruz. Burada ayrı bir fonksiyon yazmak yerine callback func ile parametrelerle burada çağırdık. 


            _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), options);

            Product product = new Product() { Id = 1, Name = "Bilgisayar", Price = 100.5 };
            _memoryCache.Set<Product>("product1", product);
            _memoryCache.Set<double>("money1", 250.50);

            return View();
        }

        public IActionResult Show()
        {
            _memoryCache.TryGetValue("zaman", out string timeCache);
            _memoryCache.TryGetValue("callback", out string callback);

            ViewBag.time = timeCache;
            ViewBag.callback = callback;

            ViewBag.product = _memoryCache.Get<Product>("product1");
            ViewBag.money = _memoryCache.Get<double>("money1");
            



            return View();
        }
    }
}
