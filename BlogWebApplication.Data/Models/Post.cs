using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApplication.Data.Models
{
    [Table("Post")]
    public class Post {
        public int Id { get; set; }
        public ApplicationUser Creator { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool Published { get; set;}
        public bool Approved { get; set;}
        public ApplicationUser Approver { get; set; }
        public virtual IEnumerable<Comment> Comment { get; set; }
    }
}
