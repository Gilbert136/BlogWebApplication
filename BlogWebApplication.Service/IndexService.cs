using BlogWebApplication.Service.Interfaces;
using BlogWebApplication.Data.Models;
using System.Threading.Tasks;
using BlogWebApplication.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BlogWebApplication.Data.Sqlite;

namespace BlogWebApplication.Service
{
    public class IndexService : IIndexService
    {
        private readonly LocalSqliteDbContext _localSqliteDbContext;
        private readonly ApplicationDbContext _applicationDbContext;


        public IndexService(ApplicationDbContext applicationDbContext, LocalSqliteDbContext localSqliteDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _localSqliteDbContext = localSqliteDbContext;
        }

        public async Task<IEnumerable<Project>> GetRecentProject()
        {
            return await _applicationDbContext.Project
            .Include(x => x.Creator)
            .Include(x => x.Approver)
            .Include(x => x.Comments)
            .Where(x => x.Published == true).ToListAsync();
        }

        public async Task<IEnumerable<Faq>> GetFrequentlyAskedQuestion()
        {
            return await _localSqliteDbContext.Faq.ToListAsync();
            //return new List<Faq>();
        }

        public async Task<Contact> AddContact(Contact contact){
            _applicationDbContext.Add(contact);
            await _applicationDbContext.SaveChangesAsync();
            return contact;
        }
    }
}
