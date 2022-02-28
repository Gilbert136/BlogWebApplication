using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogWebApplication.Models;
using BlogWebApplication.BusinessManagers;
using BlogWebApplication.BusinessManagers.Interfaces;
using BlogWebApplication.Models.IndexViewModels;
using BlogWebApplication.Data.Models;

namespace BlogWebApplication.Controllers
{
    public class IndexController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IIndexBusinessManager _indexBusinessManager;

        public IndexController(IIndexBusinessManager indexBusinessManager, ILogger<HomeController> logger)
        {
            _logger = logger;
            _indexBusinessManager = indexBusinessManager;
        }

        public async Task<IActionResult> Index()
        {
            var actionResult = await _indexBusinessManager.GetRecentProjectViewModel(User);
            if (actionResult.Result is null) return View(actionResult.Value);
            return actionResult.Result;
        }
    }
}
