using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ICommentRepository _CommentRepository;
        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _CommentRepository = commentRepository;
        }
        public async Task<IActionResult> Index(string tag)
        {
            var posts = _postRepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }

            return View(new PostsViewModel { Posts = await posts.ToListAsync() });
        }

        public async Task<IActionResult> Details(string url)
        {
            var post = await _postRepository
                         .Posts
                         .Include(p => p.Tags)
                         .Include(p => p.Comments)
                         .ThenInclude(c => c.User)
                         .FirstOrDefaultAsync(p => p.Url == url);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost]
        public JsonResult AddComment(int PostId, string Text)
        {

            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                PostId = PostId,
                Text = Text,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(UserId ?? "")

            };

            _CommentRepository.CreateComment(entity);
            //  return Redirect ("/posts/details/" + Url);
            // return RedirectToAction("post_details", new { url = Url });
            // return View();
            return Json(
                new
                {
                    username,
                    Text,
                    entity.PublishedOn,
                    avatar
                });
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _postRepository.CreatePost(
                  new Post
                  {
                      Title = model.Title,
                      Content = model.Content,
                      Url = model.Url,
                      UserId = int.Parse(userId ?? ""),
                      PublishedOn = DateTime.Now,
                      Image = "1.jpg",
                      IsActive = false
                  });
                return RedirectToAction("Index");

            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var Role = User.FindFirstValue(ClaimTypes.Role);

            var posts = _postRepository.Posts;

            if (string.IsNullOrEmpty(Role))
            {
                posts = posts.Where(x => x.UserId == userId);
            }
            return View(await posts.ToListAsync());
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _postRepository.Posts.FirstOrDefault(i => i.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            var model = new PostCreateViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                Url = post.Url,
                IsActive = post.IsActive
            };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(PostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                var entityToUpdate = new Post
                {
                    PostId = model.PostId,
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    Url = model.Url,
                };

                if (User.FindFirstValue(ClaimTypes.Role) == "admin")
                {
                    entityToUpdate.IsActive = model.IsActive;
                }
                _postRepository.EditPost(entityToUpdate);
                return RedirectToAction("List");
            }

            return View();
        }
    }
}