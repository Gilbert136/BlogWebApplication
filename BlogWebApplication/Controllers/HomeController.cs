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

namespace BlogWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostBusinessManager _postBusinessManager;
        private readonly IHomeBusinessManager _homeBusinessManager;


        public HomeController(ILogger<HomeController> logger, IPostBusinessManager postBusinessManager, IHomeBusinessManager homeBusinessManager)
        {
            _logger = logger;
            _postBusinessManager = postBusinessManager;
            _homeBusinessManager = homeBusinessManager;
        }

        public IActionResult Index(string searchString, int? page)
        {
            return View(_postBusinessManager.GetIndexViewModel(searchString, page));
        }

        public IActionResult Author(string authorId, string searchString, int? page)
        {
            var actionResult = _homeBusinessManager.GetAuthorViewModel(authorId, searchString, page);
            if (actionResult.Result is null) return View(actionResult.Value);

            return actionResult.Result;
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
