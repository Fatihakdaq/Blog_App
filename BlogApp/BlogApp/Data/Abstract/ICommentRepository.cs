using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; } // Flitreme yaptım
        void CreateComment(Comment comment); 
        // => diyerek ITagRepository constractır üretilmeyeceği için
        //  ve bizede ctor gerekitiği için ayrı bir EfTagRepository impelemete etmemiz gerekecek
    }
}