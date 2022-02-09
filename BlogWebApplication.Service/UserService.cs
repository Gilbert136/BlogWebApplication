using BlogWebApplication.Data;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public ApplicationUser Get(string id)
        {
            return _applicationDbContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public async Task<ApplicationUser> Update(ApplicationUser applicationUser)
        {
            _applicationDbContext.Update(applicationUser);
            await _applicationDbContext.SaveChangesAsync();
            return applicationUser;
        }
    }
}
