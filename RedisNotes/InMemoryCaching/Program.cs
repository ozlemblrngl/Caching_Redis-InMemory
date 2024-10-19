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
    }
}