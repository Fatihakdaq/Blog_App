using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class TagsMenu : ViewComponent
    {
        private readonly ITagRepository _tagRepository;

        public TagsMenu(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Tags = await  _tagRepository.Tags.ToListAsync();
            return View(Tags);
        }
    }
}