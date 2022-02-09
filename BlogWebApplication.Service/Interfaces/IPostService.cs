using System.Collections.Generic;
using System.Threading.Tasks;
using BlogWebApplication.Data.Models;

namespace BlogWebApplication.Service.Interfaces
{
    public interface IPostService
    {
        Task<Post> Add(Post Post);
        IEnumerable<Post> GetPosts(ApplicationUser applicationUser);
        IEnumerable<Post> GetPosts(string searchString);
        Task<Post> GetPost(int PostId);
        Task<Post> Update(Post Post);
    }
}
