using System.Security.Claims;
using System.Threading.Tasks;
using BlogWebApplication.Models.AdminViewModels;
using BlogWebApplication.Models.AdminViewModelViewModel;

namespace BlogWebApplication.BusinessManagers.Interfaces{
    public interface IAdminBusinessManager {
        Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimPrincipal);
        Task UpdateAbout(AboutViewModel aboutViewModel, ClaimsPrincipal claimsPrincipal);
        Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal);
    }
}

