using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>(); // Bir User ın birden fazla yorumu olabilir.
        public List<Post> Posts { get; set; } = new List<Post>(); // Bir User birden fazla postu olabilir.
    }
}