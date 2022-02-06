using System.Security.Claims;
using BlogWebApplication.BusinessManagers.Interfaces;
using BlogWebApplication.Models.AdminViewModelViewModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Service.Interfaces;

namespace BlogWebApplication.BusinessManagers {
    public class AdminBusinessManager : IAdminBusinessManager{
        private UserManager<ApplicationUser>  _userManager;
        private IBlogService _blogService;

        public AdminBusinessManager(UserManager<ApplicationUser> userManager, IBlogService blogService){
            _userManager = userManager;
            _blogService = blogService;
        }
        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimPrincipal){
            var applicationUser = await _userManager.GetUserAsync(claimPrincipal);
            return new IndexViewModel {
                Blog = _blogService.GetBlogs(applicationUser)
            };
        }
    }
}