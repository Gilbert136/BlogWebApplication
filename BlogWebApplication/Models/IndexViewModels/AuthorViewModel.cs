using BlogWebApplication.Data.Models;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApplication.Models.IndexViewModels
{
    public class AuthorViewModel
    {
        public ApplicationUser Author { get; set; }
        public IPagedList<Post> Posts { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }

    }
}
