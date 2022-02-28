using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.ProjectViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using BlogWebApplication.Models.IndexViewModels;

namespace BlogWebApplication.BusinessManagers
{
    public interface IProjectBusinessManager
    {
        Task<Project> Create(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> Update(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        IndexViewModel GetIndexViewModel(string searchString, int? page);
        Task<ActionResult<ProjectViewModel>> GetViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<Comment>> CreateComment(ProjectViewModel viewModel, ClaimsPrincipal claimsPrincipal);
    }
}
