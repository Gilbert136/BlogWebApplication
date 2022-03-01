using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.Data.Models;
using System.Threading.Tasks;
using BlogWebApplication.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlogWebApplication.Service
{
    public class IndexService : IIndexService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IndexService(ApplicationDbContext applicationDbContext){
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Project>> GetRecentProject()
        {
            return await _applicationDbContext.Project
            .Include(x => x.Creator)
            .Include(x => x.Approver)
            .Include(x => x.Comments)
            .Where(x => x.Published == true).ToListAsync();
        }

        public async Task<Contact> Add(Contact contact){
            _applicationDbContext.Add(contact);
            await _applicationDbContext.SaveChangesAsync();
            return contact;
        }
    }
}
