using System.Collections.Generic;
using BlogWebApplication.Data.Models;
using PagedList.Core;

namespace BlogWebApplication.Models.IndexViewModels
{
    public class IndexViewModel {
        public IPagedList<Project> Post { get; set; }
        public string SearchString { get; set; }
        public int PageNumber { get; set; }

        public IList<Project> Projects { get; set; }
        public IList<Faq> Faqs { get; set; }
        public Contact Contact { get; set; }
    }
}