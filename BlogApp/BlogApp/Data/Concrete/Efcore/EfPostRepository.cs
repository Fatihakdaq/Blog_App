
using BlogApp.Data.Abstract;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.Efcore
{
    public class EfPostRepository : IPostRepository // IPostRepoistory türetilicek // ctrl + . dedikten sorna imperlemente yapıyoruz
    {
        private readonly BlogContext _context;
        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;
        // uygulamam içerisinde işlem yapmak için _context.Post bu şekilde geriye döndericeğiz
        // burada veri tabanından sorgulanmış bir veri olamayacak
        // bu tanımlamaları controller e-action methodları içerinde dah sonradan yapıyor olucağız 
        public void CreatePost(Post post)
        {  
            _context.Posts.Add(post);
            _context.SaveChanges(); // bu değişklerde veri tababına aktarılcak 

        }

        public void EditPost(Post post)
        {
            var entity = _context.Posts.FirstOrDefault(x => x.PostId == post.PostId);
            if (entity != null)
            {
                entity.Title = post.Title;
                entity.Description = post.Description;
                entity.Content = post.Content;
                entity.Url = post.Url;
                entity.IsActive = post.IsActive;

                _context.SaveChanges();
            }
        }
    }
}