using BlogWebApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApplication.Models.ProjectViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }

        public Comment Comment { get; set; }
    }
}
