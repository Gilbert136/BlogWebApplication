using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using BlogWebApplication.Models.ProjectViewModels;
using BlogWebApplication.Data.Models;
using BlogWebApplication.BusinessManagers;

namespace BlogWebApplication.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProjectBusinessManager _projectBusinessManager;

        public ProjectController(IProjectBusinessManager projectBusinessManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _projectBusinessManager = projectBusinessManager;
        }

        [Route("project/{id}"), AllowAnonymous]
        public async Task<IActionResult> Index(int? id)
        {
            var actionResult = await _projectBusinessManager.GetViewModel(id, User);
            if (actionResult.Result is null) return View(actionResult.Value);
            return actionResult.Result;
        }

        [HttpGet("project/create")]
        public IActionResult Create(){
            return View(new CreateViewModel{});
        }

        [HttpPost("project/add")]
        public async Task<IActionResult> Add(CreateViewModel createProjectViewModel){
            await _projectBusinessManager.Create(createProjectViewModel, User);
            return RedirectToAction("Create");
        }

        [AllowAnonymous]
        [HttpPost("project/comment")]
        public async Task<IActionResult> Comment(ProjectViewModel viewModel)
        {
            var actionResult = await _projectBusinessManager.CreateComment(viewModel, User);

            if (actionResult.Result is null)
            {
                return RedirectToAction("Index", new { viewModel.Project.Id });
            }

            return actionResult.Result;
        }
    }
}
