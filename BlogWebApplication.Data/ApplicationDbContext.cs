using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogWebApplication.Data.Convertors;

namespace BlogWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Faq> Faq { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(t => t.Tags)
                .HasConversion(new StringCollectionJsonValueConvertor())
                .Metadata.SetValueComparer(new CollectionValueComparer<string>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
