using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApplication.Data.Models
{
    [Table("Faq")]
    public class Faq{
        public int Id { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
