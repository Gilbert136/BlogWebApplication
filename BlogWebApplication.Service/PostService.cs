using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.Data.Models;
using System.Threading.Tasks;
using BlogWebApplication.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogWebApplication.Service
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostService(ApplicationDbContext applicationDbContext){
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Post> Add(Post Post){
            _applicationDbContext.Add(Post);
            await _applicationDbContext.SaveChangesAsync();
            return Post;
        }

        public IEnumerable<Post> GetPosts(ApplicationUser applicationUser){
            return _applicationDbContext.Post
            .Include(x => x.Creator)
            .Include(x => x.Approver)
            .Include(x => x.Comment)
            .Where(x => x.Creator == applicationUser);
        }

        public IEnumerable<Post> GetPosts(string searchString){
            return _applicationDbContext.Post
            .OrderByDescending(x => x.UpdatedOn)
            .Include(x => x.Creator)
            .Include(x => x.Comment)
            .Where(x => x.Title.Contains(searchString) || x.Content.Contains(searchString));
        }

        public async Task<Post> GetPost(int PostId){
            return await _applicationDbContext.Post
            .Include(x => x.Creator)
            .Include(x => x.Comment).ThenInclude(x => x.Author)
            .Include(x => x.Comment).ThenInclude(x => x.Comments).ThenInclude(x => x.Parent)
            .FirstOrDefaultAsync(Post => Post.Id == PostId);
        }

        public async Task<Post> Update(Post Post){
            _applicationDbContext.Update(Post);
            await _applicationDbContext.SaveChangesAsync();
            return Post;
        }

        public async Task<Comment> Add(Comment comment)
        {
            _applicationDbContext.Add(comment);
            await _applicationDbContext.SaveChangesAsync();
            return comment;
        }

        public Comment GetComment(int commentId)
        {
            return _applicationDbContext.Comment
                .Include(x => x.Author)
                .Include(x => x.Post)
                .Include(x => x.Parent)
                .FirstOrDefault(x => x.Id == commentId);
        }
    }
}
