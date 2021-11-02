using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.BlogViewModels;
using BlogWebApplication.BusinessManagers.Interface;

namespace BlogWebApplication.BusinessManagers
{
    public interface IBlogBusinessManager
    {
        Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimPrincipal);
    }
}
