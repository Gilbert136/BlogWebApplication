using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApplication.Models.ProjectViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name = "Header Image")]
        public IFormFile PostHeaderImage { get; set; }
        public Project Project { get; set; }
    }
}
