using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; } // Flitreme yaptım
        void CreateUser(User user); 
        // => diyerek ITagRepository constractır üretilmeyeceği için
        //  ve bizede ctor gerekitiği için ayrı bir EfTagRepository impelemete etmemiz gerekecek
    }
}