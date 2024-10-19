internal class Program
{
    private static void Main(string[] args)
    {
        //AddMemoryCache() servis ve IMemoryCache interface
        // InMemory Cache i kullanacaksak öncelikle memorycache servisini eklememiz lazım.
        // Akabinde nerede kullanacaksak ilgili sınıfın constructorında IMemoryCache interface i dependency injection yoluyla kullanmamız gerekiyor.
    }
}