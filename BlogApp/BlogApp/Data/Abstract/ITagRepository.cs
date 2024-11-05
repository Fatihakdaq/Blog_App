using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags { get; } // Flitreme yaptım
        void CreateTag(Tag Tag); 
        // => diyerek ITagRepository constractır üretilmeyeceği için
        //  ve bizede ctor gerekitiği için ayrı bir EfTagRepository impelemete etmemiz gerekecek
    }
}