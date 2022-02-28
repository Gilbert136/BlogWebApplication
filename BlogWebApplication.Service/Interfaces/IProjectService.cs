using System.Collections.Generic;
using System.Threading.Tasks;
using BlogWebApplication.Data.Models;

namespace BlogWebApplication.Service.Interfaces
{
    public interface IProjectService
    {
        Task<Project> Add(Project data);
        IEnumerable<Project> GetAll(ApplicationUser applicationUser);
        IEnumerable<Project> GetAll(string searchString);
        Task<Project> Get(int? id);
        Task<Project> Update(Project data);
        Task<Comment> Add(Comment comment);
        Comment GetComment(int commentId);
    }
}
