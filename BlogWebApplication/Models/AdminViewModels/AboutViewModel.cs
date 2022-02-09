using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApplication.Models.AdminViewModels
{
    public class AboutViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name="Header Image")]
        public IFormFile HeaderImage { get; set; }
        [Display(Name="Sub-Image")]
        public string SubHeader { get; set; }
        public string Content { get; set; }
    }
}
