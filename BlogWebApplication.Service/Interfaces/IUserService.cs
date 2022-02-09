using BlogWebApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> Update(ApplicationUser applicationUser);
        ApplicationUser Get(string id);
    }
}
