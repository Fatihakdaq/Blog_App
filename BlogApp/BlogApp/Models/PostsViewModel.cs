using BlogApp.Entity;

namespace BlogApp.Models
{
	public class PostsViewModel
	{
		public List<Post> Posts { get; set; } = new List<Post>();  // Post listesi olarak tan�mland�, varsay�lan de�er bo� bir liste.
	}
}
