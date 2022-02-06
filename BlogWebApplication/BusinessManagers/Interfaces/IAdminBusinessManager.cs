using System.Security.Claims;
using System.Threading.Tasks;
using BlogWebApplication.Models.AdminViewModelViewModel;

namespace BlogWebApplication.BusinessManagers.Interfaces{
    public interface IAdminBusinessManager {
        Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimPrincipal);
    }
}

