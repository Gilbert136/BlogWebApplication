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
            var result = await _indexBusinessManager.GetIndexViewModel(User);

            if (result.Result is null) return View(result.Value);

            return result.Result;
        }

        [HttpPost("Index/Contact")]
        public async Task<IActionResult> Comment(IndexViewModel indexViewModel)
        {
            var actionResult = await _indexBusinessManager.CreateContact(indexViewModel, User);

            if (actionResult.Result is null)
            {
                return RedirectToAction("Index");
            }
            return actionResult.Result;
        }
    }
}
