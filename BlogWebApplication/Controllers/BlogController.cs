using Microsoft.AspNetCore.Mvc;
using BlogWebApplication.Models.BlogViewModels;
using BlogWebApplication.BusinessManagers;
using System.Threading.Tasks;

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
            return View(new CreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createBlogViewModel){
            await _blogBusinessManager.CreateBlog(createBlogViewModel, User);
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(int? id){
            var actionResult =  await _blogBusinessManager.GetEditViewModel(id, User);

            if(actionResult.Result is null){
                return View(actionResult.Value);
            }

            return actionResult.Result;
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditViewModel editViewModel){
            var actionResult =  await _blogBusinessManager.UpdateBlog(editViewModel, User);

            if(actionResult.Result is null){
                return RedirectToAction("Edit", new { editViewModel.Blog.Id});
            }

            return actionResult.Result;
        }
    }
}
