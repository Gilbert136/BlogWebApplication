using BlogWebApplication.Data.Convertors;
using BlogWebApplication.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogWebApplication.Data.Sqlite
{
    public class LocalSqliteDbContext : IdentityDbContext<ApplicationUser>
    {
        public LocalSqliteDbContext(DbContextOptions<LocalSqliteDbContext> options) : base(options)
        {
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

            modelBuilder.Entity<Faq>().HasData(
                new Faq(){
                    Id = 1,
                    Head = "What is the purpose of this Organization?",
                    Body = "We are a community of software developers, engineers and designers with the passion of improving our communities through technology. Our main activity is in software development with strict focus in education, the environment and small-scale businesses."
                },
                new Faq(){
                    Id = 2,
                    Head = "What are the skills I need to become a member?",
                    Body = "Any skill is greatly embraced in this community. We need dedicated, motivated and committed individuals who are willing to sometimes sacrifice their time and energy. Having knowledge in programming or any technology related field will be a great bonus but do not worry we occasionally provide free technology classes to our community members which everyone can benefit from. Aside from that, we encourge everyone to join and contribute irrespective of the age or gender or whatever."
                },
                new Faq()
                {
                    Id = 3,
                    Head = "Will I be paid for contributing to this community?",
                    Body = "No, nobody gets paid. Your contribution goes a long way in helping solve problems in our community which in turn helps us and our next generation live a better life. Most of our activies here is strictly to give back to the community."
                },
                new Faq()
                {
                    Id = 4,
                    Head = "Who are the beneficiaries of our contribution?",
                    Body = "The community and everyone who want to be part of the community. Majority of the our projects are hosted on open source platforms which makes it automatically available to everyone who wants to contribute. Note, we do not permit the use of our property for profit benefits. Doing so will attract punishment."
                },
                new Faq()
                {
                    Id = 5,
                    Head = "What does the organization seeks to achieve in the next year?",
                    Body = "We seek to launch at least one software application in each of the project categories at the end of each year. We can only achieve this with your help."
                },
                 new Faq()
                 {
                     Id = 6,
                     Head = "Who is funding the organization?",
                     Body = "Currently, The organization started with only 500 cedis as its capital which is provided solely by the founder. In the future, we hope to consider other funding options."
                 },
                 new Faq()
                 {
                     Id = 7,
                     Head = "What are some of the organization's challenges?",
                     Body = "I will say that finding enough right people to join the organization has been a real challenge. I partly believe that since there are no financial motivation, majority gets discouraged. I am hoping that, there will be a time where things will be better. Another current challenge is at the deployment stage. There are few free online hosts and most are very limited in processing capacity and as a results limits our output. There are also instances where there are no computing devices available to deploy the software.We once visited a school in a community in Ghana.We wanted to deploy an application which helps stage one students to learn how to count numbers, because there were no computers available in the school.We were not able to achieve our target."
                 },
                 new Faq()
                 {
                     Id = 8,
                     Head = "What is the organization's long term goals?",
                     Body = "We seeks to become the main drivers of change in our community through technology. We hope in the next five years, we will be able to empower the youths and other individuals in our community with technology by collaboration with other stakeholders to provide computers and other mobiles devices to help set up an Information Communication Technology(ICT) Center in every community in Ghana. We can only achieve this with your help."
                 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
