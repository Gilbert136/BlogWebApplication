using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.BlogViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using BlogWebApplication.BusinessManagers;
using BlogWebApplication.Service.Interfaces;

namespace BlogWebApplication.BusinessManager
{
    public class BlogBusinessManager : IBlogBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBlogService _blogService;

        public BlogBusinessManager(UserManager<ApplicationUser> userManager, IBlogService blogService){
            _userManager = userManager;
            _blogService = blogService;
        }
        public async Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal){
            Blog blog = createBlogViewModel.Blog;
            
            blog.Creator = await _userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;

            return await _blogService.Add(blog);
        }
    }
}
