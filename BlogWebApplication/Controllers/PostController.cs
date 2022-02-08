using Microsoft.AspNetCore.Mvc;
using BlogWebApplication.Models.PostViewModels;
using BlogWebApplication.BusinessManagers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BlogWebApplication.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostBusinessManager _postBusinessManager;

        public PostController(IPostBusinessManager postBusinessManager){
            _postBusinessManager = postBusinessManager;
        }

        [Route("Post/{id}"), AllowAnonymous]
        public async Task<IActionResult> Index(int? id)
        {
            var actionResult = await _postBusinessManager.GetPostViewModel(id, User);

            if (actionResult.Result is null)
            {
                return View(actionResult.Value);
            }

            return actionResult.Result;
        }

        public IActionResult Create(){
            return View(new CreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createPostViewModel){
            await _postBusinessManager.CreatePost(createPostViewModel, User);
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Edit(int? id){
            var actionResult =  await _postBusinessManager.GetEditViewModel(id, User);

            if(actionResult.Result is null){
                return View(actionResult.Value);
            }

            return actionResult.Result;
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditViewModel editViewModel){
            var actionResult =  await _postBusinessManager.UpdatePost(editViewModel, User);

            if(actionResult.Result is null){
                return RedirectToAction("Edit", new { editViewModel.Post.Id});
            }

            return actionResult.Result;
        }
    }
}
