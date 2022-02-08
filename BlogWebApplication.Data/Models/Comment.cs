using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogWebApplication.Data.Models
{
    [Table("Comment")]
    public class Comment {
        public int Id { get; set; }
        public Post Post { get; set; }
        public ApplicationUser Author { get; set; }
        public string Content { get; set; }
        public Comment Parent { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
