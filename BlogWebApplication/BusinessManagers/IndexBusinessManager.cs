using Microsoft.AspNetCore.Identity;
using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.ProjectViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using BlogWebApplication.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BlogWebApplication.Authorization;
using BlogWebApplication.Models.IndexViewModels;
using PagedList.Core;
using System.Linq;


namespace BlogWebApplication.BusinessManagers
{
    public class IndexBusinessManager : IIndexBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIndexService _indexService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public IndexBusinessManager(UserManager<ApplicationUser> userManager, IIndexService indexService, IAuthorizationService authorizationService, IWebHostEnvironment webHostEnviroment)
        {
            _userManager = userManager;
            _indexService = indexService;
            _webHostEnviroment = webHostEnviroment;
            _authorizationService = authorizationService;
        }

        public async Task<ActionResult<IndexViewModel>> GetRecentProjectViewModel(ClaimsPrincipal claimsPrincipal)
        {
            var result = await _indexService.GetRecentProject();

            if (result is null) return new NotFoundResult();

            return new IndexViewModel { Projects = result.ToList() };
        }

        public async Task<ActionResult<Contact>> CreateContact(IndexViewModel indexViewModel, ClaimsPrincipal claimsPrincipal)
        {
            if (indexViewModel.Contact is null) return new BadRequestResult();

            var result = indexViewModel.Contact;

            result.CreatedOn = DateTime.Now;
            return await _indexService.Add(result);
        }
    }
}
