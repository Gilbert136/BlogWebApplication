using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.Data.Models;
using System.Threading.Tasks;
using BlogWebApplication.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BlogWebApplication.Data.Sqlite;


namespace BlogWebApplication.Service
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly LocalSqliteDbContext _localSqliteDbContext;

        public PostService(ApplicationDbContext applicationDbContext, LocalSqliteDbContext localSqliteDbContext){
            // _applicationDbContext = applicationDbContext;
            _localSqliteDbContext = localSqliteDbContext;
        }

        public async Task<Post> Add(Post Post){
            _localSqliteDbContext.Add(Post);
            await _localSqliteDbContext.SaveChangesAsync();
            return Post;
        }

        public IEnumerable<Post> GetPosts(ApplicationUser applicationUser){
            return _localSqliteDbContext.Post
            .Include(x => x.Creator)
            .Include(x => x.Approver)
            .Include(x => x.Comment)
            .Where(x => x.Creator == applicationUser);
        }

        public IEnumerable<Post> GetPosts(string searchString){
            return _localSqliteDbContext.Post
            .OrderByDescending(x => x.UpdatedOn)
            .Include(x => x.Creator)
            .Include(x => x.Comment)
            .Where(x => x.Title.Contains(searchString) || x.Content.Contains(searchString));
        }

        public async Task<Post> GetPost(int PostId){
            return await _localSqliteDbContext.Post
            .Include(x => x.Creator)
            .Include(x => x.Comment).ThenInclude(x => x.Author)
            .Include(x => x.Comment).ThenInclude(x => x.Comments).ThenInclude(x => x.Parent)
            .FirstOrDefaultAsync(Post => Post.Id == PostId);
        }

        public async Task<Post> Update(Post Post){
            _localSqliteDbContext.Update(Post);
            await _localSqliteDbContext.SaveChangesAsync();
            return Post;
        }

        public async Task<Comment> Add(Comment comment)
        {
            _localSqliteDbContext.Add(comment);
            await _localSqliteDbContext.SaveChangesAsync();
            return comment;
        }

        public Comment GetComment(int commentId)
        {
            return _localSqliteDbContext.Comment
                .Include(x => x.Author)
                .Include(x => x.Post)
                .Include(x => x.Parent)
                .FirstOrDefault(x => x.Id == commentId);
        }
    }
}
