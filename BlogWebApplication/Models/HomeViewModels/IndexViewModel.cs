using BlogWebApplication.Data.Models;
using PagedList.Core;

namespace BlogWebApplication.Models.HomeViewModels
{
    public class IndexViewModel {
        public IPagedList<Post> Post { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
    }
}