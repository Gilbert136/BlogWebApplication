using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.BlogViewModels;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BlogWebApplication.BusinessManagers
{
    public interface IBlogBusinessManager
    {
        Task<Blog> CreateBlog(CreateViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
