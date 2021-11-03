using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.BlogViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using BlogWebApplication.BusinessManagers;
using BlogWebApplication.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BlogWebApplication.BusinessManager
{
    public class BlogBusinessManager : IBlogBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public BlogBusinessManager(UserManager<ApplicationUser> userManager, IBlogService blogService, IWebHostEnvironment webHostEnviroment)
        {
            _userManager = userManager;
            _blogService = blogService;
            _webHostEnviroment = webHostEnviroment;
        }
        public async Task<Blog> CreateBlog(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal){
            Blog blog = createViewModel.Blog;
            
            blog.Creator = await _userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;

            blog = await _blogService.Add(blog);

            string webRootPath = _webHostEnviroment.WebRootPath;
            string pathToImage = $@"{webRootPath}\UserFiles\Blogs\{blog.Id}\HeaderImage.jpg";
            EnsureFloder(pathToImage);

            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await createViewModel?.BlogHeaderImage?.CopyToAsync(fileStream);
            }

            return blog;
        }

        private void EnsureFloder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if(directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
