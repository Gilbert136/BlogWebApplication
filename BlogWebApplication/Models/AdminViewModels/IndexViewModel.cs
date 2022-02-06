using System.Collections.Generic;
using BlogWebApplication.Data.Models;
namespace BlogWebApplication.Models.AdminViewModelViewModel {
    public class IndexViewModel{
        public IEnumerable<Post> Post { get; set; }
    }
}