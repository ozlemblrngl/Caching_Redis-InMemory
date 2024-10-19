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
            //zaman key'ine sahip bir data var mı yok mu kontrolü için iki yol vardır:

            //1. yol eğer zaman key i yoksa buna içeriği set et
            if (string.IsNullOrEmpty(_memoryCache.Get<string>("zaman")))
            {
                _memoryCache.Set<string>("zaman", DateTime.Now.ToString());
            }

            //2.yol
            // eğer zaman key'i varsa bunun değerini al string timecache de dön. yoksa içeriği set et 
            if (_memoryCache.TryGetValue("zaman", out string timecache))
            {
                _memoryCache.Set<string>("zaman", DateTime.Now.ToString());
            }

            //eğer değer varsa timecache in değeri üzerinden devam edebiliriz.

            return View();
        }

        public IActionResult Show()
        {
            // ilgili key'e sahip olan data'yı memory den silmek için Remove'u kullanıyoruz.
            _memoryCache.Remove("zaman");

            // GetOrCreate() ilgili keya sahip data varsa getirir yoksa oluşturur.Bu metotla hiç var mı yok mu teker teker uğraşmadan işlemleri yapıyoruz.
            // entry nin gelmesinin sebebi key dışında başka özellik vs set etmek istiyorsak diye geliyor.
            _memoryCache.GetOrCreate<string>("zaman", entry =>
            {
                //entry. yazınca çıkıyor tüm ekstra özellikler
                return DateTime.Now.ToString();
            });
            ViewBag.time = _memoryCache.Get<string>("zaman");
            return View();
        }
    }
}
