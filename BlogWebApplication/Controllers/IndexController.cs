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
    public class IndexController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IndexController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
