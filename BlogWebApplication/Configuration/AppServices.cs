using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BlogWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.BusinessManagers;
using BlogWebApplication.Service;
using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.BusinessManager;

namespace BlogWebApplication.Configuration{
    public static class AppServices{
        public static void AddDefaultService(this IServiceCollection serviceCollection, IConfiguration configuration){
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnectionPostgreSql")) );
            serviceCollection.AddDefaultIdentity<ApplicationUser>(opt => opt.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>();
            serviceCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            serviceCollection.AddRazorPages();
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection){
            serviceCollection.AddScoped<IBlogBusinessManager, BlogBusinessManager>();
            serviceCollection.AddScoped<IBlogService, BlogService>();
        }
    }
}