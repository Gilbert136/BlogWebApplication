using System.ComponentModel.DataAnnotations;
using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Http;

namespace BlogWebApplication.Models.ProjectViewModels {
    public class EditViewModel{
        [Display(Name = "Header Image")]
        public IFormFile PostHeaderImage { get; set; }
        public Project Project { get; set; }
    }
}