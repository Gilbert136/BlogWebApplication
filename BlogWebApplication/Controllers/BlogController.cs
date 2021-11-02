using Microsoft.AspNetCore.Mvc;
using BlogWebApplication.Models.BlogViewModels;
using BlogWebApplication.BusinessManager;
using System.Threading.Tasks;
using BlogWebApplication.BusinessManagers;

namespace BlogWebApplication.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogBusinessManager _blogBusinessManager;

        public BlogController(IBlogBusinessManager blogBusinessManager){
            _blogBusinessManager = blogBusinessManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(){
            return View(new CreateBlogViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogViewModel createBlogViewModel){
            await _blogBusinessManager.CreateBlog(createBlogViewModel, User);
            return RedirectToAction("Create");
        }
    }
}
