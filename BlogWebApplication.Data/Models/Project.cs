using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApplication.Data.Models
{
    [Table("Project")]
    public class Project {
        public Project() {
            Tags = new List<string>();
            Comments = new List<Comment>();
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public string Repository { get; set; }
        public bool Published { get; set;}
        public bool Approved { get; set;}
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public ApplicationUser Creator { get; set; }
        public ApplicationUser Approver { get; set; }
        public virtual ICollection<string> Tags { get; set; }

        [ForeignKey(nameof(Comment.ProjectId))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
