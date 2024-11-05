using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IPostRepository 
       // interface’ler sadece metodların imzasını tutan arayüzlerdir Constructor’ları yoktur dolayısıyla nesnesi üretilmez
    {
        // IQueryable Ne demek ben context üzerinden post veri aldığımda extra IQueryble üzerinden flitrelemeye devam edeblilicem 
        // IEnerable denipde yapılabilir ama neden yapmadık ? 
        // IQueryable 100 tane veriden filirtleme yapmak istediğimizde sadece flitre yapılacak veriler gelir örnek vermek gerekirse 
        // 100 tane tablodan sadece 5 tannesini istiyoruz ve sadece 5 tane gelir 
        // ama IEnerable den ise 100 veriden flitrelme yapmak istdeğimizde ise 100 tannesi gelip içerisinden 
        // 5 tane flitre yapılır o yüzden hız bakımından IQuerblye kullanmak daha mantıklı ve daha avantajlı

        IQueryable<Post> Posts { get; } 
        void CreatePost(Post post);
        void EditPost(Post post);

        // Bu interface Implemente edicek olan bir concreate versiyonu 
        // biz uygulammada ne zaman IPostRepository çağırırsak EfPostRepistory çağırmış oluruz 
        // çünkü biz EfPostRepistory yi IPostRepository impelenete ettik 
        // bu neden dolayı EfPostRepistory çağırmış oluruz 
        // yani ne zaman IPostRepistory çAĞIRISAK EfPostRepistory den nesne üretip getir diyeceğiz 
    }
}
