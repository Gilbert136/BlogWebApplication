using System.ComponentModel.DataAnnotations;
using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Http;

namespace BlogWebApplication.Models.PostViewModels {
    public class EditViewModel{
        [Display(Name = "Header Image")]
        public IFormFile PostHeaderImage { get; set; }
        public Post Post { get; set; }
    }
}