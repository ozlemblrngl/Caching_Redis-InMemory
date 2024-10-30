internal class Program
{
    private static void Main(string[] args)
    {
        // Caching Nedir?
        // Çok sık kullandığımız dataların kaydedilmesi hem de ihtiyaç halinde okunması tekniğidir.
        // ikiye ayrılır:

        //    1- In-Memory Caching 
        //    2- Distributed Caching

        // In Memory Caching

        // uygulamayla ilgili dataların, uygulamayı barındıran Web Server'ın ram'inde yani memory sinde kaydetme işlemidir. Ram'de tutulur data.
        // Verilere hızlıca ulaşabilmek için Ram'de kaydedilir datalar.

        // Distributed Caching

        // Tamamen ayrı bir cach servisinde tutulur.
        // cachelenmiş datalar ayrı serviste tutulacağı için, uygulama restart dahi olsa cacheler kaybolmaz.
        // Ayrıca inmemory de olduğu gibi aynı verinin farklı versiyonlardan gelebilecek farklı veri kayıtlarının oluşturacağı tutarsızlıkların da burada önüne geçilir.
        // dezavantajı daha yavaştır, in memory çok daha hızlıdır
        // bir de implementasyonu in memory'e göre daha uğraştırıcıdır. 
        // Ancak bunlar çok da büyük sorunlar değil keza veri tutarlılığı hızdan çok daha önemlidir.


        // On-Demand ve Prepopulation

        // Cachlenmek istenen veri çok sık güncellenmeyen bir veri olmalı ve çok sık erişilmek istenen bir veri olmalı. Bu iki özelliği bulunmalıdır.
        // Peki biz bu veriyi ne zaman cacheleyeceğiz. Bu noktada On-demand ve prepopulation kavramları karşımıza çıkar.

        // On-demand veriyi sadece talep olduğunda cachelememiz anlamına gelir.
        // Yani bir request gelir ilgili veriyi veritabanından çekeriz. Bunu cacheleriz ve bu cachelenen veriyi ilgili requeste response döneriz.
        // kısaca ilgili veriyi sadece talep anında cacheleriz talep edilmezse cachelemeyiz.

        // Prepopulation ise uygulamahyı ayağa kaldırdığımızda daha talep gelmeden veritabanına gidip verileri çekip cachelemedir.
        // daha sonra bir istek geldiğinde cacheden response olarak veriyi dönebiliriz.

        // bu iki cacheleme zamanının birbirlerine üstünlüğü yoktur. Uygulama amacına göre herhangi birini kullanabiliriz.


        // REDİS 

        // remote dictionary server->Redis

        // verileri veritabanında tutan bir NoSql veritabanıdır. En büyük avantajlarından bir tanesi veri tiplerine sahip olmasıdır.
        // Dataları dictionary şeklinde bir key value olarak tutmaz. Veri tipleri kullanır.Kullandığımız veri tiplerine karşılık burada da veri tiplerimiz bulunmaktadır.
        // Biz oop deki senaryomuza uygun olarak redis tarafında bir veri tipi bulabilmekteyiz. Verileri memory'de tuttuğu için çok hızlı bir şekilde verileri okuyabilir ve yazabiliriz.
        // Güçlü olduğu yönlerden birisi veri tutarlılığıdır. Diyelim ki on farklı instance var bunların hepsi ayağa kalktığında hepsi redis'ten beslendiği için veri tutarlı olacaktır. 

        // Uygulaması InMemory'deki gibidir, cachelemek istediğimiz veriyi server'dan çekiyoruz ve cacheliyoruz. Daha sonraki isteklerde öncelikle veritabanından okumak yerine önbelleğe bakıyoruz
        // varsa veri önbellekten okuyoruz ve client'lara bu veriyi dönüyoruz. 

        // Distributed Cache'in şu avantajı da vardır; biz kullanıcılara ilişkin session bilgilerini de redis'te saklayabiliriz.
        // InMemory kullandığımızda session tarafında veri tutarsızlığı yaşayabilirken, redis tarafında kullacıların oturum bilgilerini tutarken veri tutarsızlığından kurtulmuş oluruz. 


    }
}