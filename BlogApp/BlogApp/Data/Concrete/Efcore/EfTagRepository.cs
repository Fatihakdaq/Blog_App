
using BlogApp.Data.Abstract;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.Efcore
{
    public class EfTagRepository : ITagRepository // IPostRepoistory türetilicek // ctrl + . dedikten sorna imperlemente yapıyoruz
    {
        private readonly BlogContext _context;
        public EfTagRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Tag> Tags => _context.Tags;
        // uygulamam içerisinde işlem yapmak için _context.Post bu şekilde geriye döndericeğiz
        // burada veri tabanından sorgulanmış bir veri olamayacak
        // bu tanımlamaları controller e-action methodları içerinde dah sonradan yapıyor olucağız 
        public void CreateTag(Tag Tag)
        {
           _context.Tags.Add(Tag);
           _context.SaveChanges(); // bu değişklerde veri tababına aktarılcak 

        }
    }
}