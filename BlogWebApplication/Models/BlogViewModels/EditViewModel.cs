using System.ComponentModel.DataAnnotations;
using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Http;

namespace BlogWebApplication.Models.BlogViewModels {
    public class EditViewModel{
        [Display(Name = "Header Image")]
        public IFormFile BlogHeaderImage { get; set; }
        public Blog Blog { get; set; }
    }
}