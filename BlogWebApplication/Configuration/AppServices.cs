using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BlogWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.BusinessManagers;
using BlogWebApplication.Service;
using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.BusinessManagers.Interfaces;
using Microsoft.Extensions.FileProviders;
using System.IO;
using BlogWebApplication.Authorization;
using Microsoft.AspNetCore.Authorization;
using BlogWebApplication.Data.Sqlite;
using System;

namespace BlogWebApplication.Configuration{
    public static class AppServices{
        public static void AddDefaultService(this IServiceCollection serviceCollection, IConfiguration configuration){
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnectionString")));
            serviceCollection.AddDbContext<LocalSqliteDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("LocalSqliteConnectionString")));

            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //serviceCollection.AddDbContext<LocalSqliteDbContext>(opt => opt.UseSqlite($"Data Source={System.IO.Path.Join(path, "blogging.db")}"));

            serviceCollection.AddDefaultIdentity<ApplicationUser>(opt => opt.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<LocalSqliteDbContext>();
            serviceCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            serviceCollection.AddRazorPages();
            serviceCollection.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection){
            serviceCollection.AddScoped<IPostBusinessManager, PostBusinessManager>();
            serviceCollection.AddScoped<IAdminBusinessManager, AdminBusinessManager>();
            serviceCollection.AddScoped<IHomeBusinessManager, HomeBusinessManager>();
            serviceCollection.AddScoped<IPostService, PostService>();
            serviceCollection.AddScoped<IUserService, UserService>();

            serviceCollection.AddScoped<IProjectBusinessManager, ProjectBusinessManager>();
            serviceCollection.AddScoped<IProjectService, ProjectService>();
            serviceCollection.AddScoped<IIndexBusinessManager, IndexBusinessManager>();
            serviceCollection.AddScoped<IIndexService, IndexService>();
        }

        public static void AddCustomerAuthorization(this IServiceCollection serviceCollection){
            serviceCollection.AddTransient<IAuthorizationHandler, BlogAuthorizationHandler>();
        }
    }
}