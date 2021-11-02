using System.Threading.Tasks;
using BlogWebApplication.Data.Models;

namespace BlogWebApplication.Service.Interfaces
{
    public interface IBlogService
    {
        Task<Blog> Add(Blog blog);
    }
}
