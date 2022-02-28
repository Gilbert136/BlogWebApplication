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
    public class ProjectBusinessManager : IProjectBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProjectService _projectService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public ProjectBusinessManager(UserManager<ApplicationUser> userManager, IProjectService projectService, IAuthorizationService authorizationService, IWebHostEnvironment webHostEnviroment)
        {
            _userManager = userManager;
            _projectService = projectService;
            _webHostEnviroment = webHostEnviroment;
            _authorizationService = authorizationService;
        }

        public IndexViewModel GetIndexViewModel(string searchString, int? page){
            int pageSize = 20;
            int pageNumber = page ?? 1;
            var results = _projectService.GetAll(searchString ?? string.Empty).Where(x => x.Published);

            return new IndexViewModel {
                Post = new StaticPagedList<Project>(results.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, results.Count()),
                SearchString = searchString,
                PageNumber = pageNumber
            };
        }

        public async Task<ActionResult<ProjectViewModel>> GetViewModel(int? id, ClaimsPrincipal claimsPrincipal)
        {
            if(id is null) return new BadRequestResult();

            var result = await _projectService.Get(id);

            if (result is null) return new NotFoundResult();

            if (!result.Published)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(claimsPrincipal, result, Operations.Read);

                if (!authorizationResult.Succeeded) return DetermineActionResult(claimsPrincipal);
            }

            return new ProjectViewModel { Project = result };
        }

        public async Task<Project> Create(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal){
            var result = createViewModel.Project;
            
            result.Creator = await _userManager.GetUserAsync(claimsPrincipal);
            result.CreatedOn = DateTime.Now;
            result.UpdatedOn = DateTime.Now;
            result = await _projectService.Add(result);

            string webRootPath = _webHostEnviroment.WebRootPath;
            string pathToImage = $@"{webRootPath}/UserFiles/Projects/{result.Id}/HeaderImage.jpg";
            EnsureFolder(pathToImage);

            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await createViewModel?.PostHeaderImage?.CopyToAsync(fileStream);
            }
            return result;
        }

        public async Task<ActionResult<Comment>> CreateComment(ProjectViewModel viewModel, ClaimsPrincipal claimsPrincipal)
        {
            if (viewModel.Project is null || viewModel.Project.Id == 0) return new BadRequestResult();

            var result = await _projectService.Get(viewModel.Project.Id);

            if (result is null) return new NotFoundResult();

            var comment = viewModel.Comment;
            comment.Author = await _userManager.GetUserAsync(claimsPrincipal);
            comment.Project = result;
            comment.CreatedOn = DateTime.Now;
            
            if(comment.Parent != null){
                comment.Parent = _projectService.GetComment(comment.Parent.Id);
            }

            return await _projectService.Add(comment);
        }

        public async Task<ActionResult<EditViewModel>> Update(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal){
            var result = await _projectService.Get(editViewModel.Project.Id);

            if(result is null) return new NotFoundResult();

            var authorizationResult = await _authorizationService.AuthorizeAsync(claimsPrincipal, result, Operations.Update);
            if(!authorizationResult.Succeeded) return DetermineActionResult(claimsPrincipal);

            result.Published = editViewModel.Project.Published;
            result.Title = editViewModel.Project.Title;
            result.Content = editViewModel.Project.Content;
            result.UpdatedOn = DateTime.Now;

            if(editViewModel.PostHeaderImage != null){
                string webRootPath = _webHostEnviroment.WebRootPath;
                string pathToImage = $@"{webRootPath}/UserFile/Projects/{result.Id}/HeaderImage.jpg";

                EnsureFolder(pathToImage);

                using(var fileStream = new FileStream(pathToImage, FileMode.Create)){
                    await editViewModel.PostHeaderImage.CopyToAsync(fileStream);
                }
            }

            return new EditViewModel {
                Project = await _projectService.Update(result)
            };
        }

        public async Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal){
            if(id is null) return new BadRequestResult();

            var result = await _projectService.Get(id);

            if(result is null) return new NotFoundResult();

            var authorizationResult = await _authorizationService.AuthorizeAsync(claimsPrincipal, result, Operations.Update);

            if(!authorizationResult.Succeeded) return DetermineActionResult(claimsPrincipal);

            return new EditViewModel{ Project = result };
        }

        private ActionResult DetermineActionResult(ClaimsPrincipal claimsPrincipal){
            if(claimsPrincipal.Identity.IsAuthenticated) return new ForbidResult();
            else return new ChallengeResult();
        }

        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if(directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
