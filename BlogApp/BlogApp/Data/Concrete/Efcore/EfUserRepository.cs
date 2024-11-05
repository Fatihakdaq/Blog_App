
using BlogApp.Data.Abstract;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.Efcore
{
    public class EfUserRepository : IUserRepository // IPostRepoistory türetilicek // ctrl + . dedikten sorna imperlemente yapıyoruz
    {
        private readonly BlogContext _context;
        public EfUserRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;
        // uygulamam içerisinde işlem yapmak için _context.Post bu şekilde geriye döndericeğiz
        // burada veri tabanından sorgulanmış bir veri olamayacak
        // bu tanımlamaları controller e-action methodları içerinde dah sonradan yapıyor olucağız 
        public void CreateUser(User user)
        {
           _context.Users.Add(user);
           _context.SaveChanges(); // bu değişklerde veri tababına aktarılcak 

        }
    }
}