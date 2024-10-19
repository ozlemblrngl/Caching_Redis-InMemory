internal class Program
{
    private static void Main(string[] args)
    {
        //AddMemoryCache() servis ve IMemoryCache interface
        // InMemory Cache i kullanacaksak öncelikle memorycache servisini eklememiz lazım.
        // Akabinde nerede kullanacaksak ilgili sınıfın constructorında IMemoryCache interface i dependency injection yoluyla kullanmamız gerekiyor.

        // InMemoryCache Get() --> memoryden bir data almak için ve Set() ---> memory ye bir data yazmak için.
        // Bunlar aynı zamanda generic metotlardır, resim, döküman, pdf, ya da bir sınıfı serialize ederek de tutabiliriz.Tek sınırımız bizim memorydeki hafıza miktarımızdır. Yeter ki serialize edelim.
    }
}