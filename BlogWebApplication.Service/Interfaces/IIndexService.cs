using System.Collections.Generic;
using System.Threading.Tasks;
using BlogWebApplication.Data.Models;

namespace BlogWebApplication.Service.Interfaces
{
    public interface IIndexService
    {
        Task<IEnumerable<Project>> GetRecentProject();
        Task<IEnumerable<Faq>> GetFrequentlyAskedQuestion();
        Task<Contact> AddContact(Contact contact);
    }
}
