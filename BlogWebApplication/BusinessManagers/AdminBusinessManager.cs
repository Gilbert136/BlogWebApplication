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
        private IPostService _postService;

        public AdminBusinessManager(UserManager<ApplicationUser> userManager, IPostService postService){
            _userManager = userManager;
            _postService = postService;
        }
        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimPrincipal){
            var applicationUser = await _userManager.GetUserAsync(claimPrincipal);
            return new IndexViewModel {
                Post = _postService.GetPosts(applicationUser)
            };
        }
    }
}