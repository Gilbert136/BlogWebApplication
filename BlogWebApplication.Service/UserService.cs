using BlogWebApplication.Data;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogWebApplication.Data.Sqlite;


namespace BlogWebApplication.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private readonly LocalSqliteDbContext _localSqliteDbContext;

        public UserService(ApplicationDbContext applicationDbContext, LocalSqliteDbContext localSqliteDbContext)
        {
            // _applicationDbContext = applicationDbContext;
            _localSqliteDbContext = localSqliteDbContext;
        }

        public ApplicationUser Get(string id)
        {
            return _localSqliteDbContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public async Task<ApplicationUser> Update(ApplicationUser applicationUser)
        {
            _localSqliteDbContext.Update(applicationUser);
            await _localSqliteDbContext.SaveChangesAsync();
            return applicationUser;
        }
    }
}
