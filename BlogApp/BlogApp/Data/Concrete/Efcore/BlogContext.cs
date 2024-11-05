using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.Efcore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            // Dışarıdan bir Connection string göndermek için altaypıyı hazırladık 
        }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Tag> Tags => Set<Tag>();



		// OnModelCreating metodu burada tanımlanacak.
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Foreign Key ilişkilerini ve silme davranışlarını burada tanımlıyoruz.
			modelBuilder.Entity<Comment>()
				.HasOne(c => c.Post)
				.WithMany(p => p.Comments)
				.HasForeignKey(c => c.PostId)
				.OnDelete(DeleteBehavior.Restrict);  // Cascade yerine Restrict kullanarak döngüyü önlüyoruz.

			modelBuilder.Entity<Comment>()
				.HasOne(c => c.User)
				.WithMany(u => u.Comments)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);  // Cascade yerine Restrict kullanarak döngüyü önlüyoruz.

			// Eğer başka tablolar veya ilişkiler de varsa, bunları burada tanımlayabilirsiniz.
		}

	}
}