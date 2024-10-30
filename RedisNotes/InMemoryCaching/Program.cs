internal class Program
{
    private static void Main(string[] args)
    {
        //AddMemoryCache() servis ve IMemoryCache interface
        // InMemory Cache i kullanacaksak öncelikle memorycache servisini eklememiz lazım.
        // Akabinde nerede kullanacaksak ilgili sınıfın constructorında IMemoryCache interface i dependency injection yoluyla kullanmamız gerekiyor.

        // InMemoryCache Get() --> memoryden bir data almak için ve Set() ---> memory ye bir data yazmak için.
        // Bunlar aynı zamanda generic metotlardır, resim, döküman, pdf, ya da bir sınıfı serialize ederek de tutabiliriz.Tek sınırımız bizim memorydeki hafıza miktarımızdır. Yeter ki serialize edelim.

        // cache de değerlerimizi her zaman key value olarak tutarız.Key value çiftlerinden bir data almak istediğimizde ona hangi key değerini atamışsak o değeri alırız.
        // cache datası için ömür belirtmezsek ömür boyu ram de durmaya devam eder. Eğer işletim sistemini yeniden başlatırsak bu dataya erişemeyiz.
        // Uygulamayı yeniden ayağa kaldırırsak ram sıfırlanır çünkü.

        // InMemoryCache TryGetValue() --> herhangi bir değeri almak için kullanırız ve Remove() --> key i silmek için kullanırız.
        // GetOrCreate() ilgili keya sahip data varsa getirir yoksa oluşturur.

        // AbsoluteExpiration ve SlidingExpiration
        // AbsoluteExpiration cache in ömrü bu süre kadar olur örn 5 dk verdik 5 dk sonra biter.
        // SlidingExpiration diyelim ki 5 dk verdik memoryde 5 dk kalır. 5 dk içinde bu dataya erişilmezse silinir ancak ulaşılırsa ömrü 5 dk daha uzer. kısaca verilen sürede kullanıldığı sürece kullanılır.
        // AbsoluteExpiration kullanmak daha makuldür çünkü SlidingExpiration de sürekli yenilenebilme ihtimali var ve bu da verinin güncel olmaması gibi durumlara neden olabilir.
        // ikisini bir arada kullanmak mümkündür. SlidingExpiration da AbsoluteExpiration belirlersek, ilgili dataya ne kadar ulaşılırsa ulaşılsın nihai ömrü absoluteExpirationdaki kadar olacaktır.


        // Caching Priority
        // memory doldu diyelim, bu durumda memoryden hangi key'in öncelikli olarak silineceğini belirlemektir. Bazı verilerin cache de kalması önemlidir ve bu nedenle memory dolduğunda cacheden öncelikli olmayanların silinmesi gerekir. 
        // options.Priority = CacheItemPriority.Low, .Normal, .High, .NeverRemove  
        // Hafıza dolduğunda ve yeni veri eklemek istediğimizde Low öncelikli silineceklerdir, Low yoksa öncelikli silinecek Normal'dır. Normal da kalmadıysa High silinecektir.
        // Kısaca silinme önceliğine göre Low düşük seviyede öneme, normal Low'dan daha yüksek seviyede öneme, High Normal'dan yüksek seviyede öneme sahiptir. 
        // NeverRemove ise asla silinmesini istemediğimiz datadır. Burada veri eklerken şöyle bir sıkıntı olabilir:
        // memory doldu ve hepsi de neverremove dan oluşuyor o zaman program exception fırlatacaktır çünkü ne yeni veriyi alacak yeri vardır ne de silinebilecek verisi. 

        // RegisterPostEvictionCallback() metodu:
        // memory den bir data silindiği zaman hangi sebeple silindi bunu tespit edebiliyoruz.
        // bu metot bir delegeye işaret eder bu delege de PostEvictDelegate 'tir içine girersek bu metodun silinen key'e ve değerine, silinme nedenine ve state'ne haiz olduğunu görürürz parametrelerinde.
        // bkz: public delegate void PostEvictionDelegate(object key, object? value, EvictionReason reason, object? state);

        // complex types caching 
        // burada complex types tan kastımız classlar ve nesne örneklerimizin cachlenmesidir.
        // inmemoryde set metodu içerisine obje aldığından dolayı içeirisinde her türlü types tutabiliyoruz. Bir pdf dosyası da, bir class nesne örneği vs. de tutabiliyoruz kısaca.
        // serilasyon işlemini IMemoryCache halledecek. 
        // ancak redis kısmında serilasyonu kendimiz yapacağız: ya binary'e ya da json serialize işlemini yapmamız gerekecek. 


    }
}