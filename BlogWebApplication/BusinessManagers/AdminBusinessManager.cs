using System.Security.Claims;
using BlogWebApplication.BusinessManagers.Interfaces;
using BlogWebApplication.Models.AdminViewModelViewModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using BlogWebApplication.Models.AdminViewModels;
using System.IO;

namespace BlogWebApplication.BusinessManagers {
    public class AdminBusinessManager : IAdminBusinessManager{
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminBusinessManager(UserManager<ApplicationUser> userManager, IPostService postService, IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _postService = postService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal){
            var applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel {
                Post = _postService.GetPosts(applicationUser)
            };
        }

        public async Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            return new AboutViewModel
            {
                ApplicationUser = applicationUser,
                SubHeader = applicationUser.SubHeader,
                Content = applicationUser.AboutContent
            };
        }

        public async Task UpdateAbout(AboutViewModel aboutViewModel, ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await _userManager.GetUserAsync(claimsPrincipal);
            applicationUser.SubHeader = aboutViewModel.SubHeader;
            applicationUser.AboutContent = aboutViewModel.Content;

            if (aboutViewModel.HeaderImage != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string pathToImage = $@"{webRootPath}/UserFile/Users/{applicationUser.Id}/HeaderImage.jpg";

                EnsureFolder(pathToImage);

                using (var fileStream = new FileStream(pathToImage, FileMode.Create))
                {
                    await aboutViewModel.HeaderImage.CopyToAsync(fileStream);
                }
            }

            await _userService.Update(applicationUser);
        }

        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}