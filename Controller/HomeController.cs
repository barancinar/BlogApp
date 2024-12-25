using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private ITagRepository _tagRepository;

        public HomeController(IPostRepository postRepository, ICommentRepository commentRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _tagRepository = tagRepository;
        }
        public async Task<IActionResult> Index(string tag)
        {
            var claims = User.Claims;

            var posts = _postRepository
                        .Posts
                        .Include(p => p.Tags)
                        .Include(p => p.User)
                        .Include(p => p.Comments)
                        .Where(i => i.IsActive == true);


            // Eğer "tag" varsa postları filtrele
            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }

            return View(new PostsViewModel { Posts = await posts.ToListAsync() });
        }










    }
}

