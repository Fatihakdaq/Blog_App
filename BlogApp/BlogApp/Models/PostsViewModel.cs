using BlogApp.Entity;

namespace BlogApp.Models
{
	public class PostsViewModel
	{
		public List<Post> Posts { get; set; } = new List<Post>();  // Post listesi olarak tanýmlandý, varsayýlan deðer boþ bir liste.
	}
}
