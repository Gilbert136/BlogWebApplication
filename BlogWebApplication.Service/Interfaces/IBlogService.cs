using System.Collections.Generic;
using System.Threading.Tasks;
using BlogWebApplication.Data.Models;

namespace BlogWebApplication.Service.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> Add(Blog blog);
        IEnumerable<Blog> GetBlogs(ApplicationUser applicationUser);
        Task<Blog> GetBlog(int blogId);
        Task<Blog> Update(Blog blog);
    }
}
