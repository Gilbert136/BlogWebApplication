using BlogWebApplication.Data.Models;
using BlogWebApplication.Models.PostViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using BlogWebApplication.Models.IndexViewModels;

namespace BlogWebApplication.BusinessManagers
{
    public interface IIndexBusinessManager
    {
        Task<ActionResult<IndexViewModel>> GetRecentProjectViewModel(ClaimsPrincipal claimsPrincipal);
    }
}
