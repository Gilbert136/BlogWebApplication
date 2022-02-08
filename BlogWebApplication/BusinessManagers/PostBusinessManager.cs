using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.PostViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using BlogWebApplication.BusinessManagers;
using BlogWebApplication.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlogWebApplication.Authorization;
using BlogWebApplication.Models.HomeViewModels;
using PagedList.Core;
using System.Linq;


namespace BlogWebApplication.BusinessManagers
{
    public class PostBusinessManager : IPostBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPostService _postService;

        private readonly IAuthorizationService _authorizationService;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public PostBusinessManager(UserManager<ApplicationUser> userManager, IPostService postService, IAuthorizationService authorizationService, IWebHostEnvironment webHostEnviroment)
        {
            _userManager = userManager;
            _postService = postService;
            _webHostEnviroment = webHostEnviroment;
            _authorizationService = authorizationService;
        }

        public IndexViewModel GetIndexViewModel(string searchString, int? page){
            int pageSize = 20;
            int pageNumber = page ?? 1;
            var posts = _postService.GetPosts(searchString ?? string.Empty).Where(blog => blog.Published);

            return new IndexViewModel {
                Post = new StaticPagedList<Post>(posts.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, posts.Count()),
                SearchString = searchString,
                PageNumber = pageNumber
            };
        }

        public async Task<ActionResult<PostViewModel>> GetPostViewModel(int? id, ClaimsPrincipal claimsPrincipal)
        {
            if(id is null) return new BadRequestResult();

            var postId = id.Value;
            var post = await _postService.GetPost(postId);

            if (post is null) return new NotFoundResult();

            if (!post.Published)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(claimsPrincipal, post, Operations.Read);

                if (!authorizationResult.Succeeded) return DetermineActionResult(claimsPrincipal);
            }

            return new PostViewModel { Post = post };
        }

        public async Task<Post> CreatePost(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal){
            Post post = createViewModel.Post;
            
            post.Creator = await _userManager.GetUserAsync(claimsPrincipal);
            post.CreatedOn = DateTime.Now;
            post.UpdatedOn = DateTime.Now;
            post = await _postService.Add(post);

            string webRootPath = _webHostEnviroment.WebRootPath;
            string pathToImage = $@"{webRootPath}/UserFiles/Blogs/{post.Id}/HeaderImage.jpg";
            EnsureFolder(pathToImage);

            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await createViewModel?.PostHeaderImage?.CopyToAsync(fileStream);
            }
            return post;
        }

        public async Task<ActionResult<EditViewModel>> UpdatePost(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal){
            var post = await _postService.GetPost(editViewModel.Post.Id);

            if(post is null){
                return new NotFoundResult();
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(claimsPrincipal, post, Operations.Update);
            if(!authorizationResult.Succeeded) return DetermineActionResult(claimsPrincipal);

            post.Published = editViewModel.Post.Published;
            post.Title = editViewModel.Post.Title;
            post.Content = editViewModel.Post.Content;
            post.UpdatedOn = DateTime.Now;

            if(editViewModel.PostHeaderImage != null){
                string webRootPath = _webHostEnviroment.WebRootPath;
                string pathToImage = $@"{webRootPath}/UserFile/Blogs/{post.Id}/HeaderImage.jpg";

                EnsureFolder(pathToImage);

                using(var fileStream = new FileStream(pathToImage, FileMode.Create)){
                    await editViewModel.PostHeaderImage.CopyToAsync(fileStream);
                }
            }

            return new EditViewModel {
                Post = await _postService.Update(post)
            };
        }

        public async Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal){
            if(id is null) return new BadRequestResult();

            var postId = id.Value;
            var post = await _postService.GetPost(postId);

            if(post is null) return new NotFoundResult();

            var authorizationResult = await _authorizationService.AuthorizeAsync(claimsPrincipal, post, Operations.Update);

            if(!authorizationResult.Succeeded) return DetermineActionResult(claimsPrincipal);

            return new EditViewModel{ Post = post };
        }

        private ActionResult DetermineActionResult(ClaimsPrincipal claimsPrincipal){
            if(claimsPrincipal.Identity.IsAuthenticated) return new ForbidResult();
            else return new ChallengeResult();
        }

        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if(directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
