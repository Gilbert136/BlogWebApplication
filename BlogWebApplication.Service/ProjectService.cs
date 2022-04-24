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
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly LocalSqliteDbContext _localSqliteDbContext;


        public ProjectService(ApplicationDbContext applicationDbContext, LocalSqliteDbContext localSqliteDbContext){
            // _applicationDbContext = applicationDbContext;
            _localSqliteDbContext = localSqliteDbContext;
        }

        public async Task<Project> Add(Project data){
            _localSqliteDbContext.Add(data);
            await _localSqliteDbContext.SaveChangesAsync();
            return data;
        }

        public IEnumerable<Project> GetAll(ApplicationUser applicationUser){
            return _localSqliteDbContext.Project
            .Include(x => x.Creator)
            .Include(x => x.Approver)
            .Include(x => x.Comments)
            .Where(x => x.Creator == applicationUser);
        }

        public IEnumerable<Project> GetAll(string searchString){
            return _localSqliteDbContext.Project
            .OrderByDescending(x => x.UpdatedOn)
            .Include(x => x.Creator)
            .Include(x => x.Comments)
            .Where(x => x.Title.Contains(searchString) || x.Content.Contains(searchString));
        }

        public async Task<Project> Get(int? id){
            return await _localSqliteDbContext.Project
            .Include(x => x.Creator)
            .Include(x => x.Comments).ThenInclude(x => x.Author)
            .Include(x => x.Comments).ThenInclude(x => x.Comments).ThenInclude(x => x.Parent)
            .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Project> Update(Project data){
            _localSqliteDbContext.Update(data);
            await _localSqliteDbContext.SaveChangesAsync();
            return data;
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
