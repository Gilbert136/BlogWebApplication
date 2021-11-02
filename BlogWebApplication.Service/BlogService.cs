using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.Data.Models;
using System.Threading.Tasks;
using BlogWebApplication.Data;

namespace BlogWebApplication.Service
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BlogService(ApplicationDbContext applicationDbContext){
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Blog> Add(Blog blog){
            _applicationDbContext.Add(blog);
            await _applicationDbContext.SaveChangesAsync();
            return blog;
        }
    }
}
