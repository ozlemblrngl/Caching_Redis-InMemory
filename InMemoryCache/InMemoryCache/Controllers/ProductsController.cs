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
            options.SlidingExpiration = TimeSpan.FromSeconds(10); // 10 sn aralıklı ömür verdik eğer 10 sn içerisinde tetiklenirse ömrü 10 sn daha uzayacak her defasında. Tetiklenmezse ölecek.

            options.Priority = CacheItemPriority.High;
            
            options.RegisterPostEvictionCallback((key, value, reason, state) => {

                 _memoryCache.Set("callback", $"{key}-->{value} => silinme sebebi: {reason}");

            }); // calback metodu içinde bir delege çağırıyoruz. Burada ayrı bir fonksiyon yazmak yerine callback func ile parametrelerle burada çağırdık. 


            _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), options);

            

            return View();
        }

        public IActionResult Show()
        {
            _memoryCache.TryGetValue("zaman", out string timeCache);
            _memoryCache.TryGetValue("callback", out string callback);

            ViewBag.time = timeCache;
            ViewBag.callback = callback;



            return View();
        }
    }
}
