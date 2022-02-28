using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlogWebApplication.Data.Models
{
    [Table("Comment")]
    public class Comment {
        public Comment(){
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ProjectId { get; set; }
        public string AnonymousUserName { get; set; }

        public virtual Post Post { get; set; }
        public virtual Project Project { get; set; }
        public virtual Comment Parent { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
