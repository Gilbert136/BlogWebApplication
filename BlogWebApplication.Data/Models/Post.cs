using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogWebApplication.Data.Models
{
    [Table("Post")]
    public class Post {
        public int Id { get; set; }
        public Blog Blog { get; set; }

        public ApplicationUser Poster { get; set; }
        public string Content { get; set; }

        public Post Parent { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
