using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.Data.Models;
using System.Threading.Tasks;
using BlogWebApplication.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public IEnumerable<Blog> GetBlogs(ApplicationUser applicationUser){
            return _applicationDbContext.Blog
            .Include(blog => blog.Creator)
            .Include(blog => blog.Approver)
            .Include(blog => blog.Posts)
            .Where(blog => blog.Creator == applicationUser);
        }

        public async Task<Blog> GetBlog(int blogId){
            return await _applicationDbContext.Blog.FirstOrDefaultAsync(blog => blog.Id == blogId);
        }

        public async Task<Blog> Update(Blog blog){
            _applicationDbContext.Update(blog);
            await _applicationDbContext.SaveChangesAsync();
            return blog;
        }
    }
}
